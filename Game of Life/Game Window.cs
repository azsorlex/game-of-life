using System.Collections.Concurrent;

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

        private IEnumerable<Panel> Live_Or_Die(Panel panel, ConcurrentDictionary<string, Panel>? existingInvocations, bool firstInvocation = true)
        {
            var name = panel.Name.Split("_");
            var y = byte.Parse(name[0]);
            var x = byte.Parse(name[1]);
            byte activeNeighbours = 0;

            for (var nY = y - 1; nY <= y + 1; nY++)
            {
                for (var nX = x - 1; nX <= x + 1; nX++)
                {
                    if (nY >= 0 && nY < gridHeight && nX >= 0 && nX < gridWidth && !(nY == y && nX == x))
                    {
                        var neighbour = panelMatrix[nY][nX];
                        if (neighbour.BackColor == Color.Yellow)
                            activeNeighbours++;

                        if (firstInvocation && !(existingInvocations?.TryGetValue(neighbour.Name, out _) ?? false) && Live_Or_Die(neighbour, null, false).Any())
                            yield return neighbour;
                    }
                }
            }

            if ((activeNeighbours == 3 && panel.BackColor == Color.Gray) ||
                (activeNeighbours < 2 && panel.BackColor == Color.Yellow) ||
                (activeNeighbours >= 4 && panel.BackColor == Color.Yellow))
                yield return panel;
        }

        private void panel_Click(object sender, EventArgs e) => (sender as Panel)?.Toggle_Colour();

        private void playPauseButton_Click(object sender, EventArgs e) => ((Button)sender).Text = (refreshTimer.Enabled = !refreshTimer.Enabled) ? "Pause" : "Play";

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            var invocations = new ConcurrentDictionary<string, Panel>();

            // Get the panels that need to be updated without changing their states
            Parallel.ForEach(panelMatrix.GetActivePanels(), panel =>
            {
                foreach (var x in Live_Or_Die(panel, invocations))
                    invocations.TryAdd(x.Name, x);
            });

            // Update the states of the returned panels
            foreach (var panel in invocations.Values)
                panel.Toggle_Colour();
        }

        private void speedSlider_Scroll(object sender, EventArgs e) => refreshTimer.Interval = (sender as TrackBar).Value;

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (refreshTimer.Enabled)
                playPauseButton.PerformClick();

            foreach (var panel in panelMatrix.GetActivePanels())
                panel.Set_Colour(Color.Gray);
        }
    }
}