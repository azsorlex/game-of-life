namespace Game_of_Life
{
    public static class Extensions
    {
        public static IEnumerable<Panel> GetActivePanels(this Panel[,] matrix)
        {
            foreach (var panel in matrix)
                if (panel.BackColor == Color.Yellow)
                    yield return panel;
        }

        public static void Toggle_Colour(this Panel panel)
        {
            panel.BackColor = panel.BackColor == Color.Yellow ? Color.Gray : Color.Yellow;
            panel.Refresh();
        }

        public static void Set_Colour(this Panel panel, Color color)
        {
            panel.BackColor = color;
            panel.Refresh();
        }
    }
}