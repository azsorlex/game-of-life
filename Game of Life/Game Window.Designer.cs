
namespace Game_of_Life
{
    partial class GameWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private List<List<Panel>> panelMatrix = new();

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                Controls.Clear();
                panelMatrix.Clear();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            PlayPauseButton = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // PlayPauseButton
            // 
            PlayPauseButton.Location = new Point(766, 497);
            PlayPauseButton.Name = "PlayPauseButton";
            PlayPauseButton.Size = new Size(122, 47);
            PlayPauseButton.TabIndex = 0;
            PlayPauseButton.Text = "Play";
            PlayPauseButton.UseVisualStyleBackColor = true;
            PlayPauseButton.Click += playPauseButton_Click;
            // 
            // timer1
            // 
            timer1.Interval = 50;
            timer1.Tick += timer1_Tick;
            // 
            // GameWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(911, 563);
            Controls.Add(PlayPauseButton);
            Name = "GameWindow";
            Text = "Game of Life";
            ResumeLayout(false);
        }

        #endregion

        private void Generate_Game_Matrix()
        {
            var gridWidth = 20;
            var gridHeight = 20;
            var buttonLength = 20;

            for (var y = 0; y < gridHeight; y++)
            {
                var row = new List<Panel>(gridWidth);
                for (var x = 0; x < gridWidth; x++)
                {
                    var panel = new Panel()
                    {
                        Name = $"{y}_{x}",
                        Location = new Point(10 + (buttonLength * x), 10 + (buttonLength * y)),
                        Size = new Size(buttonLength, buttonLength),
                        BackColor = Color.Gray,
                        Capture = false,
                    };
                    panel.Click += panel_Click;
                    row.Add(panel);
                }
                panelMatrix.Add(row);
                Controls.AddRange(row.ToArray());
            };
        }

        private Button PlayPauseButton;
        private System.Windows.Forms.Timer timer1;
    }
}
