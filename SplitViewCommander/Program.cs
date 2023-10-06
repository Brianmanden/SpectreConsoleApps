using Spectre.Console;

namespace SplitViewCommander
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region TableDemo

            #region Styles
            Style menuBarStyles = new Style(Color.White, Color.DarkSeaGreen4_1);
            Color boldCharColor = Color.Orange1;
            Style bodyStyles = new Style(Color.DarkGreen, Color.PaleTurquoise1);
            Style buttonMenuStyles = new Style(Color.Blue, Color.DarkSlateGray3);
            #endregion

            #region MenuBar


            var menuBarItems = new Markup[] {
                new Markup($"[{boldCharColor}]F[/]ile", menuBarStyles).LeftJustified(),
                new Markup($"[{boldCharColor}]M[/]ark", menuBarStyles).LeftJustified(),
                new Markup($"[{boldCharColor}]C[/]ommands", menuBarStyles).LeftJustified(),
            };

            Table menuBar = new Table();
            menuBar.Border = TableBorder.None;
            foreach (Markup item in menuBarItems)
            {
                menuBar.AddColumn(new TableColumn(item));
            }
            #endregion

            #region Files
            //var files = AnsiConsole.Prompt(
            //    new MultiSelectionPrompt<string>()
            //        .NotRequired()
            //        .AddChoices<string>(
            //            new[]{
            //                "file1.ext",
            //                "file2.ext",
            //                "file3.ext",
            //                "file4.ext",
            //                "file5.ext",
            //                "file7.ext",
            //                "file8.ext",
            //            }
            //        )                
            //);
            #endregion

            #region Body Content
            Table bodyContent = new Table();
            bodyContent.Border = TableBorder.None;
            bodyContent.Expand = true;
            bodyContent.AddColumn("Drive/Folder 1");
            bodyContent.AddColumn("Drive/Folder 2");
            bodyContent.AddRow(new Rule(), new Rule());
            bodyContent.AddRow("files", "ANOTHERFILE.EXT");
            bodyContent.AddRow("FILENAME.EXT", "ANOTHERFILE.EXT");
            bodyContent.AddRow("FILENAME.EXT", "ANOTHERFILE.EXT");
            bodyContent.AddRow("FILENAME.EXT", "ANOTHERFILE.EXT");
            #endregion

            #region Footer Button Bar
            Text[] footerButtonItems = new Text[]{
                new Text("[F3] View", buttonMenuStyles).LeftJustified(),
                new Text("[F4] Edit", buttonMenuStyles).LeftJustified(),
                new Text("[F5] Copy", buttonMenuStyles).LeftJustified(),
                new Text("[F6] Move/Rename", buttonMenuStyles).LeftJustified(),
                new Text("[F7] Make Folder", buttonMenuStyles).LeftJustified(),
                new Text("[F8] Delete file/folder", buttonMenuStyles).LeftJustified(),
                new Text("[F10] Exit SVC", buttonMenuStyles).LeftJustified(),
            };

            Table footerMenu = new Table();
            footerMenu.Border = TableBorder.None;
            foreach (Text item in footerButtonItems)
            {
                footerMenu.AddColumn(new TableColumn(item));
            };
            #endregion

            #region Render Main Table
            Table mainTable = new Table()
                        .Centered()
                        .Border(TableBorder.Square)
                        .Title("Split View Commander", menuBarStyles)
                        //.AddColumn(new TableColumn(string.Empty))
                        .AddColumn(new TableColumn(menuBar))
                        .AddRow(bodyContent)
                        .AddRow(new Rule())
                        .AddRow(footerMenu);

            AnsiConsole.Write(mainTable);
            #endregion

            #endregion

            Console.ReadKey();
        }
    }
}