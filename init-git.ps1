# EventEase - Git Initialization Script
# Run this script to initialize Git and prepare for GitHub upload

Write-Host "🚀 Initializing Git repository for EventEase..." -ForegroundColor Cyan
Write-Host ""

# Check if Git is installed
if (-not (Get-Command git -ErrorAction SilentlyContinue)) {
    Write-Host "❌ Git is not installed. Please install Git from https://git-scm.com/" -ForegroundColor Red
    exit 1
}

Write-Host "✅ Git is installed" -ForegroundColor Green

# Initialize Git repository
Write-Host ""
Write-Host "Initializing Git repository..." -ForegroundColor Yellow
git init

# Add all files
Write-Host ""
Write-Host "Adding all files..." -ForegroundColor Yellow
git add .

# Create initial commit
Write-Host ""
Write-Host "Creating initial commit..." -ForegroundColor Yellow
git commit -m "Initial commit: EventEase Blazor application

- Add Event browsing and search functionality
- Add Event details and registration pages  
- Add reusable EventCard component
- Add comprehensive documentation
- Add GitHub templates and workflows
- Configure .gitignore and licensing"

Write-Host ""
Write-Host "✅ Git repository initialized successfully!" -ForegroundColor Green
Write-Host ""
Write-Host "📋 Next steps:" -ForegroundColor Cyan
Write-Host "1. Create a new repository on GitHub: https://github.com/new"
Write-Host "2. Run the following commands (replace YOUR-USERNAME):"
Write-Host ""
Write-Host "   git remote add origin https://github.com/YOUR-USERNAME/EventEase.git" -ForegroundColor Yellow
Write-Host "   git branch -M main" -ForegroundColor Yellow
Write-Host "   git push -u origin main" -ForegroundColor Yellow
Write-Host ""
Write-Host "For detailed instructions, see GITHUB_UPLOAD_CHECKLIST.md" -ForegroundColor Cyan
Write-Host ""
Write-Host "🎉 Happy coding!" -ForegroundColor Green
