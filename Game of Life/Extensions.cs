namespace Game_of_Life
{
    public static class Extensions
    {
        public static void Toggle_Colour(this Panel panel)
        {
            panel.BackColor = panel.BackColor == Color.Yellow ? Color.Gray : Color.Yellow;
            panel.Refresh();
        }
    }
}