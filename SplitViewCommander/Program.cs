using Spectre.Console;

namespace SplitViewCommander
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region TableDemo

            #region Styles
            Style menuBarStyles = new Style(Color.DarkSlateGray1, Color.Blue3);
            Color menuBarBoldCharColor = Color.White;

            Style bodyStyles = new Style(Color.DarkGreen, Color.PaleTurquoise1);
            
            Style buttonMenuStyles = new Style(Color.DarkSlateGray1, Color.Blue3);
            Color buttonMenuBoldCharColor = Color.White;
            #endregion

            #region MenuBar
            var menuBarItems = new Markup[] {
                new Markup($"[{menuBarBoldCharColor}]F[/]ile", menuBarStyles).LeftJustified(),
                new Markup($"[{menuBarBoldCharColor}]M[/]ark", menuBarStyles).LeftJustified(),
                new Markup($"[{menuBarBoldCharColor}]C[/]ommands", menuBarStyles).LeftJustified(),
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
            Markup[] footerButtonItems = new Markup[]{
                new Markup($"[{buttonMenuBoldCharColor}]F3[/] View", buttonMenuStyles).LeftJustified(),
                new Markup($"[{buttonMenuBoldCharColor}]F4[/] Edit", buttonMenuStyles).LeftJustified(),
                new Markup($"[{buttonMenuBoldCharColor}]F5[/] Copy", buttonMenuStyles).LeftJustified(),
                new Markup($"[{buttonMenuBoldCharColor}]F6[/] Move/Rename", buttonMenuStyles).LeftJustified(),
                new Markup($"[{buttonMenuBoldCharColor}]F7[/] Make Folder", buttonMenuStyles).LeftJustified(),
                new Markup($"[{buttonMenuBoldCharColor}]F8[/] Delete file/folder", buttonMenuStyles).LeftJustified(),
                new Markup($"[{buttonMenuBoldCharColor}]F10[/] Exit SVC", buttonMenuStyles).LeftJustified(),
            };

            Table footerMenu = new Table();
            footerMenu.Border = TableBorder.None;
            foreach (Markup item in footerButtonItems)
            {
                footerMenu.AddColumn(new TableColumn(item));
            };
            #endregion

            #region Render Main Table
            Table mainTable = new Table()
                        .Centered()
                        .Border(TableBorder.Rounded)
                        .Centered()
                        .Title("Split View Commander", menuBarStyles)
                        .AddColumn(new TableColumn(menuBar))
                        .AddRow(bodyContent)
                        .AddRow(new Rule())
                        .AddRow(footerMenu);
            //mainTable.UseSafeBorder = true;

            AnsiConsole.Write(mainTable);
            #endregion

            #endregion

            Console.ReadKey();
        }
    }
}