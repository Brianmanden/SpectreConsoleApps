using Spectre.Console;
using SplitViewCommander;
using SplitViewCommander.Models;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        // Ctrl + C does not exit program when set to true.
        Console.TreatControlCAsInput = true;
        AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

        AppState appState = new AppState();
        appState.ActivePanel = "LEFT";

        Commander svc = new();

        #region TEST Choose Styles

        Themes themes = new Themes();
        List<Theme> allThemes = themes.GetThemes();

        int numberOfStyles = themes.GetNumberOfThemes();

        string[] styleOptions = new String[numberOfStyles + 1];
        for (int i = 0; i < numberOfStyles; i++)
        {
            styleOptions[i] = allThemes[i].Name.ToString();
        }
        styleOptions[numberOfStyles] = "Exit";

        AnsiConsole.WriteLine("Chose a styleset or exit");
        var chosenStyle = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .AddChoices(
                    styleOptions
                )
        );

        AnsiConsole.Clear();
        
        Enum.TryParse(chosenStyle, out EnumThemes chosenTheme);
        Theme currentTheme = themes.GetTheme(chosenTheme);
        appState.CurrentTheme = currentTheme;

        svc.RenderLayout(appState);

        #endregion

        #region TEST Key Press and Key Presses in Combination
        ConsoleKeyInfo input;
        do
        {
            input = Console.ReadKey(true);

            StringBuilder output = new StringBuilder(
                          String.Format("You pressed {0}", input.Key.ToString()));
            bool modifiers = false;

            if (input.Modifiers.HasFlag(ConsoleModifiers.Alt))
            {
                output.Append(", together with " + ConsoleModifiers.Alt.ToString());
                modifiers = true;
            }
            if (input.Modifiers.HasFlag(ConsoleModifiers.Control))
            {
                if (modifiers)
                {
                    output.Append(" and ");
                }
                else
                {
                    output.Append(", together with ");
                    modifiers = true;
                }
                output.Append(ConsoleModifiers.Control.ToString());
            }
            if (input.Modifiers.HasFlag(ConsoleModifiers.Shift))
            {
                if (modifiers)
                {
                    output.Append(" and ");
                }
                else
                {
                    output.Append(", together with ");
                    modifiers = true;
                }
                output.Append(ConsoleModifiers.Shift.ToString());
            }
            output.Append(".");

            //TODO REFACTOR
            if (input.Key == ConsoleKey.Tab)
            {
                if (appState.ActivePanel == "LEFT")
                {
                    appState.ActivePanel = "RIGHT";
                }
                else
                {
                    appState.ActivePanel = "LEFT";
                }
            }

            AnsiConsole.Clear();
            svc.RenderLayout(appState);
            Console.WriteLine(output.ToString());

        } while (input.Key != ConsoleKey.F10);
        #endregion
    }

    static void OnProcessExit(object sender, EventArgs e)
    {
        AnsiConsole.Clear();
        AnsiConsole.Write( new FigletText("Thank you for using").Centered().Color(Color.Green));
        AnsiConsole.Write( new FigletText("Split View Commander").Centered().Color(Color.Red));
        Thread.Sleep(1000);
    }
}