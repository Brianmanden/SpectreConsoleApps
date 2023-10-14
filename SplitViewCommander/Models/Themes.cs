using Spectre.Console;

namespace SplitViewCommander
{
    /// <summary>
    /// Class that defines all the available Themes
    /// </summary>
    public class Themes
    {
        private List<Theme> AllThemes = new List<Theme>();

        public Themes()
        {   
            Theme blue1 = new(
                    EnumThemes.Blue1,
                    new Style(Color.DarkSlateGray3, Color.DarkBlue),
                    Color.White,
                    new Style(Color.DarkGreen, Color.PaleTurquoise1),
                    new Style(Color.DarkSlateGray3, Color.DarkBlue),
                    Color.White
                );

            Theme blue2 = new(
                EnumThemes.Blue2,
                new Style(Color.DarkSlateGray1, Color.Blue3),
                Color.White,
                new Style(Color.DarkGreen, Color.PaleTurquoise1),
                new Style(Color.DarkSlateGray1, Color.Blue3),
                Color.White
            );

            Theme blue3 = new(
                EnumThemes.Blue3,
                new Style(Color.DarkSlateGray2, Color.Blue1),
                Color.White,
                new Style(Color.DarkGreen, Color.PaleTurquoise1),
                new Style(Color.DarkSlateGray2, Color.Blue1),
                Color.White
            );

            Theme green = new(
                EnumThemes.Green,
                new Style(new Color(255, 255, 0), new Color(0, 197, 132)),
                Color.LightGreen,
                new Style(new Color(255, 255, 0), new Color(0, 197, 132)),
                new Style(new Color(255, 255, 0), new Color(0, 197, 132)),
                Color.White
            );

            Theme gray = new(
                EnumThemes.Gray,
                new Style(new Color(163, 207, 205), new Color(103, 115, 129)),
                Color.DarkSlateGray3,
                new Style(Color.DarkGreen, Color.PaleTurquoise1),
                new Style(new Color(163, 207, 205), new Color(103, 115, 129)),
                Color.White
            );

            AllThemes.Add(blue1);
            AllThemes.Add(blue2);
            AllThemes.Add(blue3);
            AllThemes.Add(green);
            AllThemes.Add(gray);
        }

        /// <summary>
        /// Gets the Number of Themes available.
        /// </summary>
        /// <returns>Number of Themes</returns>
        public int GetNumberOfThemes()
        {
            return Enum.GetNames(typeof(EnumThemes)).Length;
        }

        /// <summary>
        /// Gets a specific Theme.
        /// </summary>
        /// <param name="index">Index of the Theme.</param>
        /// <returns>Theme chosen by index number.</returns>
        public Theme GetTheme(int index)
        {
            return AllThemes[index];

        }

        /// <summary>
        /// Gets a specific Theme.
        /// </summary>
        /// <param name="name">Enum Value of the Theme.</param>
        /// <returns>Theme chosen by Enum Value.</returns>
        public Theme GetTheme(EnumThemes name)
        {
            return AllThemes.Single(t => t.Name == name);
        }

        /// <summary>
        /// Get all Themes.
        /// </summary>
        /// <returns>All Themes</returns>
        public List<Theme> GetThemes()
        {
            return AllThemes;
        }
    }
}