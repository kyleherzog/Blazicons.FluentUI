# Blazicons.FluentUI
Provides the Fluent UI icon library packaged as [Blazicons](https://github.com/kyleherzog/Blazicons), SVG icon components for Blazor.

Check out the [Demo Site](http://blazicons.com).

![Nuget](https://img.shields.io/nuget/v/Blazicons.FluentUI)

[![Build Status](https://dev.azure.com/kyleherzog/Blazicons/_apis/build/status%2FBlazicons.FluentUI?branchName=main)](https://dev.azure.com/kyleherzog/Blazicons/_build/latest?definitionId=39&branchName=main)

## Getting Started
To get started using the Fluent UI Blazicons, just install the Blazicons.FluentUI NuGet package.

Next add the Blazicons reference to the `_Imports.razor` file in the Blazor project.

```csharp
@using Blazicons
```

Finally, add the Blazicon component to your Blazor pages/components.
```html
<Blazicon Svg="FluentUiIcon.Alert"></Blazicon>
```

## Parameters & Styling
See the [Blazicons](https://github.com/kyleherzog/Blazicons) documentation for details on parameters and styling.

## Credits
Thanks to the creators of [Fluent UI System Icons](https://github.com/microsoft/fluentui-system-icons)