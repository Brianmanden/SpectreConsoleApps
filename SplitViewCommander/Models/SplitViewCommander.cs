using Spectre.Console;

namespace Models
{
    /// <summary>
    /// Main Class of the Split View Commander project.
    /// </summary>
    public class SplitViewCommander
    {
        /// <summary>
        /// Returns zero based amount of styles defined.
        /// </summary>
        public int Styles => menuBarStyles.Length;

        #region Styles
        public Style[] menuBarStyles = new[]{
                new Style(Color.DarkSlateGray1, Color.Blue3),
                new Style(Color.DarkSlateGray2, Color.Blue1),
                new Style(Color.DarkSlateGray3, Color.DarkBlue),
                new Style(Color.Green, Color.Yellow),
                new Style(Color.DarkRed, Color.DarkRed_1),
            };

        public Color menuBarBoldCharColor = Color.White;

        public Style[] bodyStyles = new[] {
                new Style(Color.DarkGreen, Color.PaleTurquoise1),
                new Style(Color.DarkGreen, Color.PaleTurquoise1),
                new Style(Color.DarkGreen, Color.PaleTurquoise1),
                new Style(Color.DarkGreen, Color.PaleTurquoise1),
                new Style(Color.DarkGreen, Color.PaleTurquoise1),
            };

        public Style[] buttonMenuStyles = new[] {
                new Style(Color.DarkSlateGray1, Color.Blue3),
                new Style(Color.DarkSlateGray2, Color.Blue1),
                new Style(Color.DarkSlateGray3, Color.DarkBlue),
                new Style(Color.Green, Color.Yellow),
                new Style(Color.DarkRed, Color.DarkRed_1),
            };

        public Color buttonMenuBoldCharColor = Color.White;
        #endregion

        public SplitViewCommander(){}

        /// <summary>
        /// Renders the complete layout of the Split View Commander.
        /// </summary>
        public void RenderLayout(int styles)
        {
            #region MenuBar
            var menuBarItems = new Markup[] {
                new Markup($"[{menuBarBoldCharColor}]F[/]ile", menuBarStyles[styles]).LeftJustified(),
                new Markup($"[{menuBarBoldCharColor}]M[/]ark", menuBarStyles[styles]).LeftJustified(),
                new Markup($"[{menuBarBoldCharColor}]C[/]ommands", menuBarStyles[styles]).LeftJustified(),
            };

            Table menuBar = new Table();
            menuBar.Border = TableBorder.None;
            foreach (Markup item in menuBarItems)
            {
                menuBar.AddColumn(new TableColumn(item));
            }
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
                new Markup($"[{buttonMenuBoldCharColor}]F3[/] View", buttonMenuStyles[styles]).LeftJustified(),
                new Markup($"[{buttonMenuBoldCharColor}]F4[/] Edit", buttonMenuStyles[styles]).LeftJustified(),
                new Markup($"[{buttonMenuBoldCharColor}]F5[/] Copy", buttonMenuStyles[styles]).LeftJustified(),
                new Markup($"[{buttonMenuBoldCharColor}]F6[/] Move/Rename", buttonMenuStyles[styles]).LeftJustified(),
                new Markup($"[{buttonMenuBoldCharColor}]F7[/] Make Folder", buttonMenuStyles[styles]).LeftJustified(),
                new Markup($"[{buttonMenuBoldCharColor}]F8[/] Delete file/folder", buttonMenuStyles[styles]).LeftJustified(),
                new Markup($"[{buttonMenuBoldCharColor}]F10[/] Exit SVC", buttonMenuStyles[styles]).LeftJustified(),
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
                        .Title("Split View Commander", menuBarStyles[styles])
                        .AddColumn(new TableColumn(menuBar))
                        .AddRow(bodyContent)
                        .AddRow(new Rule())
                        .AddRow(footerMenu);
            //mainTable.UseSafeBorder = true;

            AnsiConsole.Write(mainTable);
            #endregion
        }
    }
}
