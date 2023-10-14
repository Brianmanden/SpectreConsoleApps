using Spectre.Console;
using SplitViewCommander;

internal class Program
{
    private static void Main(string[] args)
    {
        bool keepLooping = true;

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

        while (keepLooping == true)
        {
            AnsiConsole.WriteLine("Chose a styleset or exit");
            var chosenStyle = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .AddChoices(
                        styleOptions
                    )
            );

            if (chosenStyle == "Exit")
            {
                keepLooping = false;
                AnsiConsole.WriteLine("OK .. bye bye.");
            }
            else { 
                AnsiConsole.Clear();
                Enum.TryParse(chosenStyle, out EnumThemes chosenTheme);
                Theme chosenTheme2 = themes.GetTheme(chosenTheme);
                //svc.RenderLayout(Convert.ToInt32(chosenStyle));
                svc.RenderLayout(chosenTheme2);
            }
        }

        #endregion
    }
}