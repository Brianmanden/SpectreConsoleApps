using Spectre.Console;

AnsiConsole.Markup("[underline red]Hello[/] World!\n");
AnsiConsole.Markup("[green]This is all green[/]\n");

var answerReadme = AnsiConsole.Confirm("Generate a [green]README[/] file?");
var answerGitIgnore = AnsiConsole.Confirm("Generate a [yellow].gitignore[/] file?");

var framework = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
            .Title("Select [green]test framework[/] to use")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up or down to reveal more frameworks[/])")
            .AddChoices(
                new[]
                {
                    "XUnit", "NUnit", "MSTest"
                }
            ));

AnsiConsole.Markup($"Chosen framework was: {framework}\n");

AnsiConsole.Write(
    new FigletText("Scaffold-demo")
        .LeftAligned()
        .Color(Color.DarkOrange3)
);