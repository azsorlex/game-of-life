namespace Game_of_Life
{
    public partial class GameWindow : Form
    {
        public GameWindow()
        {
            InitializeComponent();

            Generate_Game_Matrix();
        }

        private void Panel_Colour_Switch(object sender)
        {
            var p = sender as Panel;

            if (p.BackColor == Color.Yellow)
                p.BackColor = Color.Gray;
            else
                p.BackColor = Color.Yellow;

            p.Refresh();
        }

        private void panel_Click(object sender, EventArgs e) => Panel_Colour_Switch(sender);

        private void playPauseButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                button.Text = "Play";
            }
            else
            {
                timer1.Enabled = true;
                button.Text = "Pause";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var invocations = new List<Panel>();

            foreach (var panel in panelMatrix.SelectMany(row => row))
            {
                var name = panel.Name.Split("_");
                var y = int.Parse(name[0]);
                var x = int.Parse(name[1]);

                byte activeNeighbours = 0;
                for (var nY = y - 1; nY <= y + 1; nY++)
                    for (var nX = x - 1; nX <= x + 1; nX++)
                        try
                        {
                            if (!(nY == y && nX == x) && panelMatrix[nY][nX].BackColor == Color.Yellow)
                                activeNeighbours++;
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            continue;
                        }

                switch (activeNeighbours)
                {
                    case byte n when panel.BackColor == Color.Yellow && (n == 0 || n == 1):
                        invocations.Add(panel);
                        break;

                    case byte n when panel.BackColor == Color.Yellow && (n == 2 || n == 3):
                        break;

                    case byte n when panel.BackColor == Color.Yellow && n >= 4:
                        invocations.Add(panel);
                        break;

                    case byte n when panel.BackColor == Color.Gray && n == 3:
                        invocations.Add(panel);
                        break;
                }
            }

            foreach (var panel in invocations)
                panel.Invoke(() => Panel_Colour_Switch(panel));
        }
    }
}
