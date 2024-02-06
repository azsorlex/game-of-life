namespace Game_of_Life
{
    public partial class GameWindow : Form
    {
        private readonly int gridWidth;
        private readonly int gridHeight;
        private readonly int buttonLength;
        private readonly Panel[][] panelMatrix;

        public GameWindow(int width, int height, int buttonLength)
        {
            panelMatrix = new Panel[height][];
            gridWidth = width;
            gridHeight = height;
            this.buttonLength = buttonLength;

            InitializeComponent();
            Generate_Game_Matrix();
        }

        private void Panel_Colour_Switch(object sender)
        {
            var p = sender as Panel;
            p.BackColor = p.BackColor == Color.Yellow ? Color.Gray : Color.Yellow;
            p.Refresh();
        }

        private IEnumerable<Panel> Process_Panel(Panel panel, bool firstInvocation = true)
        {
            var name = panel.Name.Split("_");
            var y = int.Parse(name[0]);
            var x = int.Parse(name[1]);

            byte activeNeighbours = 0;
            for (var nY = y - 1; nY <= y + 1; nY++)
            {
                for (var nX = x - 1; nX <= x + 1; nX++)
                {
                    if (!(nY == y && nX == x) && nY >= 0 && nY < gridHeight && nX >= 0 && nX < gridWidth)
                    {
                        var neighbour = panelMatrix[nY][nX];
                        if (neighbour.BackColor == Color.Yellow)
                            activeNeighbours++;

                        if (firstInvocation && Process_Panel(neighbour, false).Any())
                            yield return neighbour;
                    }
                }
            }

            if ((panel.BackColor == Color.Gray && activeNeighbours == 3) ||
                (panel.BackColor == Color.Yellow && activeNeighbours < 2) ||
                (panel.BackColor == Color.Yellow && activeNeighbours >= 4))
                yield return panel;
        }

        private void panel_Click(object sender, EventArgs e) => Panel_Colour_Switch(sender);

        private void playPauseButton_Click(object sender, EventArgs e) => ((Button)sender).Text = (refreshTimer.Enabled = !refreshTimer.Enabled) ? "Pause" : "Play";

        private void timer1_Tick(object sender, EventArgs e)
        {
            var invocations = new List<Panel>();

            // Get the panels that need to be updated without changing their states
            foreach (var panel in panelMatrix.SelectMany(row => row.Where(p => p.BackColor == Color.Yellow)))
                invocations.AddRange(Process_Panel(panel).Where(x => !invocations.Contains(x)));

            // Update the states of the returned panels
            invocations.ForEach(panel => panel.Invoke(() => Panel_Colour_Switch(panel)));
        }
    }
}