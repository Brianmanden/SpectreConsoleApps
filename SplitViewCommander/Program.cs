using Spectre.Console;
using System.Xml.Linq;

namespace SplitViewCommander
{
    internal class Program
    {
        private static string vertSplit = "";

        static void Main(string[] args)
        {
            #region Grid Test Layout

            Style headerStyles = new Style(Color.White, Color.DarkSeaGreen4_1);
            Style bodyStyles = new Style(Color.DarkGreen, Color.PaleTurquoise1);
            Style footerStyles = new Style(Color.Blue, Color.DarkSlateGray3);

            var grid = new Grid();

            // Add columns 
            grid.AddColumn();
            grid.AddColumn();
            grid.AddColumn();
            grid.AddColumn();
            grid.AddColumn();
            grid.AddColumn();
            grid.AddColumn();

            // Add header row 
            grid.AddRow(new Markup[]{
                new Markup("[bold underline grey]F[/]iles", headerStyles).LeftJustified(),
                new Markup("[bold underline grey]M[/]ark", headerStyles).LeftJustified(),
                new Markup("Co[bold underline grey]m[/]mands", headerStyles).LeftJustified(),
                new Markup("C[bold underline grey]o[/]nfiguration", headerStyles).LeftJustified()
            });

            // Add body row
            for (int i = 0; i < 5; i++)
            {
                grid.AddRow(new Text[]{
                    new Text("Filename", bodyStyles).RightJustified(),
                    new Text(".ext", bodyStyles).LeftJustified(),
                    new Text("Filename", bodyStyles).LeftJustified(),
                    new Text(".ext", bodyStyles).LeftJustified()
                });
            }

            // Add footer row
            grid.AddRow(new Text[]{
                new Text("[F3] View" + vertSplit, footerStyles).LeftJustified(),
                new Text("[F4] Edit" + vertSplit, footerStyles).LeftJustified(),
                new Text("[F5] Copy" + vertSplit, footerStyles).LeftJustified(),
                new Text("[F6] Move/Rename" + vertSplit, footerStyles).LeftJustified(),
                new Text("[F7] Make Folder" + vertSplit, footerStyles).LeftJustified(),
                new Text("[F8] Delete file/folder" + vertSplit, footerStyles).LeftJustified(),
                new Text("[F10] Exit SVC", footerStyles).LeftJustified(),
            });

            //var embedded = new Grid();

            //embedded.AddColumn();
            //embedded.AddColumn();

            //embedded.AddRow(new Text("Embedded I"), new Text("Embedded II"));
            //embedded.AddRow(new Text("Embedded III"), new Text("Embedded IV"));

            // Add content row 
            //grid.AddRow(
            //    new Text("Row 1").LeftJustified(),
            //    new Text("Row 2").Centered(),
            //    embedded
            //);

            // Write centered cell grid contents to Console
            AnsiConsole.Write(grid);
            #endregion

            Console.WriteLine(Environment.NewLine);

            Console.ReadKey();
        }
    }
}