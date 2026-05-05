# Contributing to EventEase

First off, thank you for considering contributing to EventEase! It's people like you that make EventEase such a great tool.

## Code of Conduct

This project and everyone participating in it is governed by our commitment to providing a welcoming and inspiring community for all. Please be respectful and constructive.

## How Can I Contribute?

### Reporting Bugs

Before creating bug reports, please check the existing issues as you might find out that you don't need to create one. When you are creating a bug report, please include as many details as possible:

* **Use a clear and descriptive title** for the issue to identify the problem.
* **Describe the exact steps which reproduce the problem** in as many details as possible.
* **Provide specific examples to demonstrate the steps**.
* **Describe the behavior you observed after following the steps** and point out what exactly is the problem with that behavior.
* **Explain which behavior you expected to see instead and why.**
* **Include screenshots and animated GIFs** if possible.
* **Include your environment details**: OS, .NET version, browser, etc.

### Suggesting Enhancements

Enhancement suggestions are tracked as GitHub issues. When creating an enhancement suggestion, please include:

* **Use a clear and descriptive title** for the issue to identify the suggestion.
* **Provide a step-by-step description of the suggested enhancement** in as many details as possible.
* **Provide specific examples to demonstrate the steps** or provide screenshots.
* **Describe the current behavior** and **explain which behavior you expected to see instead** and why.
* **Explain why this enhancement would be useful** to most EventEase users.

### Pull Requests

* Fill in the required template
* Do not include issue numbers in the PR title
* Follow the C# coding style guide
* Include thoughtfully-worded, well-structured tests
* Document new code
* End all files with a newline

## Development Process

### Setup Development Environment

1. Fork the repo
2. Clone your fork:
   ```bash
   git clone https://github.com/your-username/EventEase.git
   cd EventEase
   ```
3. Add upstream remote:
   ```bash
   git remote add upstream https://github.com/original-owner/EventEase.git
   ```
4. Create a branch:
   ```bash
   git checkout -b feature/your-feature-name
   ```

### Making Changes

1. Make your changes in your feature branch
2. Add or update tests as necessary
3. Ensure all tests pass:
   ```bash
   dotnet test
   ```
4. Ensure the code builds:
   ```bash
   dotnet build
   ```
5. Commit your changes:
   ```bash
   git commit -m "Add some feature"
   ```

### Submitting Changes

1. Push to your fork:
   ```bash
   git push origin feature/your-feature-name
   ```
2. Open a Pull Request from your fork to the main repository
3. Wait for review and address any feedback

## Coding Guidelines

### C# Style Guide

* Use 4 spaces for indentation
* Use PascalCase for class names and method names
* Use camelCase for local variables and parameters
* Use meaningful variable names
* Add XML documentation comments for public APIs
* Keep methods focused and concise

### Blazor Component Guidelines

* Use `@page` directive at the top for routable components
* Add `@rendermode InteractiveServer` for interactive components
* Use meaningful component and parameter names
* Implement proper data binding patterns
* Add CSS isolation files for component styles
* Document component parameters

### Git Commit Messages

* Use the present tense ("Add feature" not "Added feature")
* Use the imperative mood ("Move cursor to..." not "Moves cursor to...")
* Limit the first line to 72 characters or less
* Reference issues and pull requests liberally after the first line

Example:
```
Add event filtering by date range

- Implement DateRange filter component
- Update EventService with date filtering
- Add tests for date range functionality

Fixes #123
```

## Project Structure

```
EventEase/
├── Components/           # Blazor components
│   ├── Layout/          # Layout components
│   ├── Pages/           # Routable pages
│   └── Shared/          # Shared/reusable components
├── Models/              # Data models
├── Services/            # Business logic services
└── wwwroot/            # Static assets
```

## Testing

* Write unit tests for new services
* Write component tests for new Blazor components
* Ensure all tests pass before submitting PR
* Aim for high code coverage

## Documentation

* Update README.md if you change functionality
* Update IMPLEMENTATION_SUMMARY.md for architectural changes
* Add code comments for complex logic
* Update XML documentation for public APIs

## Community

* Be welcoming to newcomers
* Be respectful of differing viewpoints
* Accept constructive criticism gracefully
* Focus on what is best for the community

## Questions?

Feel free to open an issue with your question or reach out to the maintainers.

## License

By contributing to EventEase, you agree that your contributions will be licensed under the MIT License.

---

Thank you for contributing to EventEase! 🎉
