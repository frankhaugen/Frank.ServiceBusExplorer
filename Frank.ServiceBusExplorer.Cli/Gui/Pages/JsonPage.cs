using Spectre.Console;

namespace Frank.ServiceBusExplorer.Cli.Gui.Pages;

public class TextPage(string header, string body) : IPage
{
    private readonly Panel _panel = new Panel(body)
        .Header(header)
        .Collapse()
        .RoundedBorder()
        .BorderColor(Color.Yellow);

    public void Display() => AnsiConsole.Write(_panel);
}