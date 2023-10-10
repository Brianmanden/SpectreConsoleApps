using Models;
using Spectre.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        bool keepLooping = true;

        var svc = new SplitViewCommander();

        #region TEST Choose Styles
        int numberOfStyles = svc.Styles;
        string[] styleOptions = new String[numberOfStyles + 1];
        for (int i = 0; i < numberOfStyles; i++)
        {
            styleOptions[i] = i.ToString();
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
                AnsiConsole.WriteLine("Ok .. bye bye.");
            }
            else { 
                AnsiConsole.Clear();
                svc.RenderLayout(Convert.ToInt32(chosenStyle));
            }
        }

        #endregion
    }
}