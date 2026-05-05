# Deployment Guide for EventEase

This guide covers various deployment options for the EventEase Blazor Server application.

## Table of Contents
- [Prerequisites](#prerequisites)
- [Local Deployment](#local-deployment)
- [Azure App Service Deployment](#azure-app-service-deployment)
- [Docker Deployment](#docker-deployment)
- [IIS Deployment](#iis-deployment)
- [Environment Configuration](#environment-configuration)

---

## Prerequisites

- .NET 10 SDK or later
- Access to deployment target (Azure, server, etc.)
- Basic understanding of web deployment concepts

---

## Local Deployment

### Development Mode
```bash
cd EventEase
dotnet run
```

### Production Build
```bash
dotnet publish -c Release -o ./publish
cd publish
dotnet EventEase.dll
```

---

## Azure App Service Deployment

### Using Azure CLI

1. **Login to Azure**
   ```bash
   az login
   ```

2. **Create Resource Group**
   ```bash
   az group create --name EventEaseRG --location eastus
   ```

3. **Create App Service Plan**
   ```bash
   az appservice plan create --name EventEasePlan --resource-group EventEaseRG --sku B1 --is-linux
   ```

4. **Create Web App**
   ```bash
   az webapp create --name eventease-app --resource-group EventEaseRG --plan EventEasePlan --runtime "DOTNET:10.0"
   ```

5. **Deploy Application**
   ```bash
   dotnet publish -c Release
   cd EventEase/bin/Release/net10.0/publish
   zip -r eventease.zip .
   az webapp deployment source config-zip --resource-group EventEaseRG --name eventease-app --src eventease.zip
   ```

### Using Visual Studio

1. Right-click on the EventEase project
2. Select **Publish**
3. Choose **Azure**
4. Select **Azure App Service (Windows)** or **Azure App Service (Linux)**
5. Sign in to your Azure account
6. Create new or select existing App Service
7. Click **Publish**

### Using GitHub Actions

The project includes a GitHub Actions workflow in `.github/workflows/dotnet.yml` that can be extended for Azure deployment:

```yaml
- name: Deploy to Azure Web App
  uses: azure/webapps-deploy@v2
  with:
    app-name: 'eventease-app'
    publish-profile: ${{ secrets.AZURE_WEBAPP_PUBLISH_PROFILE }}
    package: ./publish
```

---

## Docker Deployment

### Create Dockerfile

Create a `Dockerfile` in the root directory:

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["EventEase/EventEase.csproj", "EventEase/"]
RUN dotnet restore "EventEase/EventEase.csproj"
COPY . .
WORKDIR "/src/EventEase"
RUN dotnet build "EventEase.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EventEase.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventEase.dll"]
```

### Build and Run Docker Container

```bash
# Build the image
docker build -t eventease:latest .

# Run the container
docker run -d -p 8080:80 --name eventease-container eventease:latest

# Access the application
# Navigate to http://localhost:8080
```

### Docker Compose

Create `docker-compose.yml`:

```yaml
version: '3.8'
services:
  web:
    build: .
    ports:
      - "8080:80"
    environment:
      - ASPNETCORE_ENVIRONMENT=Production
    restart: unless-stopped
```

Run with:
```bash
docker-compose up -d
```

---

## IIS Deployment

### Prerequisites
- Windows Server with IIS installed
- .NET 10 Hosting Bundle installed

### Steps

1. **Publish the Application**
   ```bash
   dotnet publish -c Release -o C:\inetpub\wwwroot\EventEase
   ```

2. **Create Application Pool**
   - Open IIS Manager
   - Right-click **Application Pools** > **Add Application Pool**
   - Name: `EventEaseAppPool`
   - .NET CLR version: **No Managed Code**
   - Managed pipeline mode: **Integrated**

3. **Create Website**
   - Right-click **Sites** > **Add Website**
   - Site name: `EventEase`
   - Application pool: `EventEaseAppPool`
   - Physical path: `C:\inetpub\wwwroot\EventEase`
   - Binding: HTTP, port 80 (or configure as needed)

4. **Configure Permissions**
   - Grant `IIS_IUSRS` read access to the application folder

5. **Configure web.config**
   The publish process should create this automatically, but ensure it exists:
   ```xml
   <?xml version="1.0" encoding="utf-8"?>
   <configuration>
     <location path="." inheritInChildApplications="false">
       <system.webServer>
         <handlers>
           <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModuleV2" resourceType="Unspecified" />
         </handlers>
         <aspNetCore processPath="dotnet" arguments=".\EventEase.dll" stdoutLogEnabled="false" stdoutLogFile=".\logs\stdout" hostingModel="inprocess" />
       </system.webServer>
     </location>
   </configuration>
   ```

6. **Start the Website**
   - Select the site in IIS Manager
   - Click **Start** in the Actions panel

---

## Environment Configuration

### Development Environment

Update `appsettings.Development.json`:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### Production Environment

Update `appsettings.Production.json`:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "yourdomain.com"
}
```

### Environment Variables

Common environment variables to configure:

```bash
# Application environment
ASPNETCORE_ENVIRONMENT=Production

# Server URLs
ASPNETCORE_URLS=http://+:80;https://+:443

# HTTPS configuration
ASPNETCORE_HTTPS_PORT=443

# Kestrel configuration
ASPNETCORE_Kestrel__Certificates__Default__Path=/path/to/cert.pfx
ASPNETCORE_Kestrel__Certificates__Default__Password=yourpassword
```

---

## SSL/TLS Configuration

### Using Let's Encrypt (Linux)

```bash
# Install Certbot
sudo apt-get update
sudo apt-get install certbot

# Obtain certificate
sudo certbot certonly --standalone -d yourdomain.com

# Configure in appsettings.json
{
  "Kestrel": {
    "Endpoints": {
      "Https": {
        "Url": "https://*:443",
        "Certificate": {
          "Path": "/etc/letsencrypt/live/yourdomain.com/fullchain.pem",
          "KeyPath": "/etc/letsencrypt/live/yourdomain.com/privkey.pem"
        }
      }
    }
  }
}
```

---

## Performance Optimization

### Production Optimizations

1. **Enable Response Compression**
   ```csharp
   // In Program.cs
   builder.Services.AddResponseCompression(options =>
   {
       options.EnableForHttps = true;
   });
   ```

2. **Configure Caching**
   ```csharp
   builder.Services.AddResponseCaching();
   app.UseResponseCaching();
   ```

3. **Use Production Logging**
   Configure appropriate logging levels for production

---

## Monitoring and Diagnostics

### Application Insights (Azure)

```csharp
// In Program.cs
builder.Services.AddApplicationInsightsTelemetry(
    builder.Configuration["ApplicationInsights:ConnectionString"]);
```

### Health Checks

```csharp
// In Program.cs
builder.Services.AddHealthChecks();
app.MapHealthChecks("/health");
```

---

## Troubleshooting

### Common Issues

1. **Application doesn't start**
   - Check logs in `./logs` directory
   - Verify .NET 10 runtime is installed
   - Check port availability

2. **SignalR connection fails**
   - Ensure WebSocket support is enabled
   - Check firewall rules
   - Verify load balancer configuration for sticky sessions

3. **Static files not loading**
   - Verify `app.UseStaticFiles()` is called
   - Check wwwroot folder permissions

---

## Security Checklist

- [ ] HTTPS is enforced
- [ ] Environment-specific configurations are in place
- [ ] Sensitive data is not in source control
- [ ] HSTS is configured
- [ ] Security headers are set
- [ ] CORS is properly configured if needed
- [ ] Authentication/Authorization is implemented (when added)

---

## Post-Deployment Testing

1. Navigate to the deployed URL
2. Test all main features:
   - Home page loads
   - Events list displays
   - Search functionality works
   - Event details page loads
   - Registration form works
3. Test on different devices and browsers
4. Monitor application logs for errors

---

## Support

For deployment issues:
1. Check the [troubleshooting section](#troubleshooting)
2. Review application logs
3. Open an issue on GitHub

---

**Happy Deploying!** 🚀
