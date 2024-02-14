namespace Game_of_Life
{
    public static class Extensions
    {
        public static void Toggle_Colour(this DataGridViewCell cell) => cell.Style.BackColor = cell.Style.BackColor == Color.Yellow ? Color.Gray : Color.Yellow;
    }
}