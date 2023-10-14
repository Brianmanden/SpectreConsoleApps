using Spectre.Console;

namespace SplitViewCommander
{
    public class Theme
    {
        public EnumThemes Name { get; set; }
        public Style MenuBarStyle { get; set; }
        public Color MenuBarShortcutColor = Color.White;
        public Style BodyStyles { get; set; }
        public Style ButtonMenuStyles { get; set; }
        public Color ButtonMenuShortcutColor = Color.White;

        /// <summary>
        /// Returns a theme defined by the given method arguments.
        /// </summary>
        /// <param name="name">The Name of the Theme.</param>
        /// <param name="menuBar">Sets the Style of the Menubar.</param>
        /// <param name="menubarShortcut">Sets the Color of the shortcut characters in the Menubar.</param>
        /// <param name="bodyStyle">Sets the Style of the Body.</param>
        /// <param name="buttonMenu">Sets the Style of the Button Menu.</param>
        /// <param name="buttonMenuShortcut">Sets the Color of the shortcut characters in the Button Menu.</param>
        public Theme(
            EnumThemes name,
            Style menuBar,
            Color menubarShortcut, 
            Style bodyStyle,
            Style buttonMenu,
            Color buttonMenuShortcut)
        {
            Name = name;
            MenuBarStyle = menuBar;
            MenuBarShortcutColor = menubarShortcut;
            BodyStyles = bodyStyle;
            ButtonMenuStyles = buttonMenu;
            ButtonMenuShortcutColor = buttonMenuShortcut;
        }
    }
}
