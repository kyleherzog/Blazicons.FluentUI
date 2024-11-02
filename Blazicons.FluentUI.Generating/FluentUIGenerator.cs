using System.Text.RegularExpressions;
using Blazicons.Generating;
using CodeCasing;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Threading;

namespace Blazicons.FluentUI.Generating;

[Generator]
internal class FluentUIGenerator : ISourceGenerator
{
    public void Execute(GeneratorExecutionContext context)
    {
        using var taskContext = new JoinableTaskContext();
        var taskFactory = new JoinableTaskFactory(taskContext);
        var downloader = new RepoDownloader(new Uri(Properties.Resources.DownloadAddress));
        taskFactory.Run(
            async () =>
            {
                await downloader.Download("assets\\/((?!Temp [LR]T[RL])[^\\/])*\\/SVG\\/\\w*\\.svg$").ConfigureAwait(true);
            });

        var svgFolder = Path.Combine(downloader.ExtractedFolder, $"{downloader.RepoName}-{downloader.BranchName}", "assets");
        context.WriteIconsClass("FluentUiIcon", svgFolder, "*_24_regular.svg", GetPropertyName);

        svgFolder = Path.Combine(downloader.ExtractedFolder, $"{downloader.RepoName}-{downloader.BranchName}", "assets");
        context.WriteIconsClass("FluentUiFilledIcon", svgFolder, "*_24_filled.svg", GetPropertyName);

        downloader.CleanUp();
    }

    public void Initialize(GeneratorInitializationContext context)
    {
        // required by ISourceGenerator
    }

    private static string GetPropertyName(string fileName)
    {
        const string prefix = "Ic_Fluent_";
        var result = Path.GetFileNameWithoutExtension(fileName);
        result = result.Substring(prefix.Length);
        result = Regex.Replace(result, @"_24_\w*$", string.Empty);
        return result.ToPascalCase();
    }
}