namespace Game_of_Life
{
    public static class Extensions
    {
        public static IEnumerable<Panel> GetActivePanels(this Panel[][] matrix) => matrix.SelectMany(row => row.Where(p => p.BackColor == Color.Yellow));

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