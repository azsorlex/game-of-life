namespace Game_of_Life
{
    public partial class GameWindow : Form
    {
        private readonly int gridWidth;
        private readonly int gridHeight;
        private readonly int buttonLength;

        public GameWindow(int width, int height, int buttonLength)
        {
            gridWidth = width;
            gridHeight = height;
            this.buttonLength = buttonLength;

            InitializeComponent();
            Generate_Game_Matrix();
        }

        private void playPauseButton_Click(object sender, EventArgs e) => ((Button)sender).Text = (refreshTimer.Enabled = !refreshTimer.Enabled) ? "Pause" : "Play";

        private void refreshTimer_Tick(object sender, EventArgs e) => Parallel.ForEach(gameGrid.GetCellsToProcess(), cell =>
        {
            var x = cell.ColumnIndex;
            var y = cell.RowIndex;
            byte activeNeighbours = 0;

            for (var nY = y - 1; nY <= y + 1; nY++)
                for (var nX = x - 1; nX <= x + 1; nX++)
                    if (nY >= 0 && nY < gridHeight && nX >= 0 && nX < gridWidth && !(nY == y && nX == x) && gameGrid[nX, nY].Style.BackColor == Color.Yellow)
                        activeNeighbours++;

            if ((activeNeighbours == 3 && cell.Style.BackColor == Color.Gray) ||
                (activeNeighbours < 2 && cell.Style.BackColor == Color.Yellow) ||
                (activeNeighbours >= 4 && cell.Style.BackColor == Color.Yellow))
                gameGrid.BeginInvoke(cell.Toggle_Colour);
        });

        private void speedSlider_Scroll(object sender, EventArgs e) => refreshTimer.Interval = (sender as TrackBar).Value;

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (refreshTimer.Enabled)
                playPauseButton.PerformClick();

            foreach (var cell in gameGrid.Where(x => x.Style.BackColor == Color.Yellow))
                cell.Toggle_Colour();
        }

        private void gameGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var cell = (sender as DataGridView).CurrentCell;
            cell.Toggle_Colour();
            cell.Selected = false;
        }
    }
}