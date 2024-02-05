namespace Game_of_Life
{
    public partial class GameWindow : Form
    {
        public GameWindow()
        {
            InitializeComponent();

            Generate_Game_Matrix();
        }

        private async void panel_Click(object sender, EventArgs e)
        {
            var p = sender as Panel;
            p.BackColor = Color.Yellow;
            p.Capture = true;
            p.Refresh();
            await Task.Delay(1000);
            p.BackColor = Color.Gray;
            p.Capture = false;
            p.Refresh();
        }
    }
}
