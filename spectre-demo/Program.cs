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

AnsiConsole.Status()
    .Start("Generating project...", ctx =>
    {
        if (answerReadme)
	    {
            AnsiConsole.MarkupLine("LOG: Creating README ...");
            Thread.Sleep(2500);
            ctx.Status("Next task");
            ctx.Spinner(Spinner.Known.Star);
            ctx.SpinnerStyle(Style.Parse("red"));
	    }

        if (answerGitIgnore)
	    {
            AnsiConsole.MarkupLine("LOG: Creating .gitignore ...");
            Thread.Sleep(2500);
            ctx.Status("Next task");
            ctx.Spinner(Spinner.Known.Smiley);
            ctx.SpinnerStyle(Style.Parse("green"));
	    }

        AnsiConsole.MarkupLine($"LOG: Configuring test framework - {framework}\n");
        ctx.Status("_");
        ctx.Spinner(Spinner.Known.Star2);
        ctx.SpinnerStyle(Style.Parse("blue"));
        Thread.Sleep(2000);
    }
);