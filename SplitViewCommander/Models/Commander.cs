using Spectre.Console;
using SplitViewCommander.Models;

namespace SplitViewCommander
{
    /// <summary>
    /// Main Class of the Split View Commander project.
    /// </summary>
    public class Commander
    {
        /// <summary>
        /// Renders the complete layout of the Split View Commander.
        /// </summary>
        //public void RenderLayout(int styles)
        public void RenderLayout(AppState appState)
        {
            Theme theme = appState.CurrentTheme;

            #region MenuBar
            var menuBarItems = new Markup[] {
                new Markup($"[{theme.MenuBarShortcutColor}]F[/]ile", theme.MenuBarStyle).LeftJustified(),
                new Markup($"[{theme.MenuBarShortcutColor}]M[/]ark", theme.MenuBarStyle).LeftJustified(),
                new Markup($"[{theme.MenuBarShortcutColor}]C[/]ommands", theme.MenuBarStyle).LeftJustified(),
                new Markup($"[{theme.MenuBarShortcutColor}]O[/]ptions", theme.MenuBarStyle).LeftJustified(),
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

            //TODO REFACTOR
            if (appState.ActivePanel == "LEFT")
            {
                bodyContent.AddColumn("[reverse]Drive/Folder 1[/]");
                bodyContent.AddColumn("Drive/Folder 2");
            }
            else
            {
                bodyContent.AddColumn("Drive/Folder 1");
                bodyContent.AddColumn("[reverse]Drive/Folder 2[/]");
            }

            bodyContent.AddRow(new Rule(), new Rule());
            bodyContent.AddRow("..", "..");
            bodyContent.AddRow("files", "ANOTHERFILE.EXT");
            bodyContent.AddRow("FILENAME.EXT", "ANOTHERFILE.EXT");
            bodyContent.AddRow("FILENAME.EXT", "ANOTHERFILE.EXT");
            bodyContent.AddRow("FILENAME.EXT", "ANOTHERFILE.EXT");
            #endregion

            #region Footer Button Bar
            Markup[] footerButtonItems = new Markup[]{
                new Markup($"[{theme.ButtonMenuShortcutColor}]F3[/] View",                  theme.ButtonMenuStyles).LeftJustified(),
                new Markup($"[{theme.ButtonMenuShortcutColor}]F4[/] Edit",                  theme.ButtonMenuStyles).LeftJustified(),
                new Markup($"[{theme.ButtonMenuShortcutColor}]F5[/] Copy",                  theme.ButtonMenuStyles).LeftJustified(),
                new Markup($"[{theme.ButtonMenuShortcutColor}]F6[/] Move/Rename",           theme.ButtonMenuStyles).LeftJustified(),
                new Markup($"[{theme.ButtonMenuShortcutColor}]F7[/] Make Folder",           theme.ButtonMenuStyles).LeftJustified(),
                new Markup($"[{theme.ButtonMenuShortcutColor}]F8[/] Delete file/folder",    theme.ButtonMenuStyles).LeftJustified(),
                new Markup($"[{theme.ButtonMenuShortcutColor}]F10[/] Exit SVC",             theme.ButtonMenuStyles).LeftJustified(),
            };

            Table footerMenu = new Table();
            footerMenu.Border = TableBorder.None;
            foreach (Markup item in footerButtonItems)
            {
                footerMenu.AddColumn(new TableColumn(item));
            };
            #endregion

            #region Render Main Layout
            Table mainTable = new Table()
                        .Centered()
                        .Border(TableBorder.Rounded)
                        .Centered()
                        .Title("Split View Commander", theme.MenuBarStyle)
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
