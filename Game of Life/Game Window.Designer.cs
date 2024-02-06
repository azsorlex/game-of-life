
using System.ComponentModel;
using Timer = System.Windows.Forms.Timer;

namespace Game_of_Life
{
    partial class GameWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Generate_Game_Matrix()
        {
            for (var y = 0; y < gridHeight; y++)
            {
                var row = new Panel[gridWidth];
                for (var x = 0; x < gridWidth; x++)
                {
                    var panel = new Panel()
                    {
                        Name = $"{y}_{x}",
                        Location = new(10 + ((buttonLength - 1) * x), 10 + ((buttonLength - 1) * y)),
                        Size = new(buttonLength, buttonLength),
                        BackColor = Color.Gray,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    panel.Click += panel_Click;
                    row[x] = panel;
                }
                panelMatrix[y] = row;
                Controls.AddRange(row);
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new Container();
            PlayPauseButton = new Button();
            refreshTimer = new Timer(components);
            SuspendLayout();
            // 
            // PlayPauseButton
            // 
            PlayPauseButton.Location = new Point(862, 769);
            PlayPauseButton.Name = "PlayPauseButton";
            PlayPauseButton.Size = new Size(122, 47);
            PlayPauseButton.TabIndex = 0;
            PlayPauseButton.Text = "Play";
            PlayPauseButton.UseVisualStyleBackColor = true;
            PlayPauseButton.Click += playPauseButton_Click;
            // 
            // refreshTimer
            // 
            refreshTimer.Tick += timer1_Tick;
            // 
            // GameWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(996, 828);
            Controls.Add(PlayPauseButton);
            Name = "GameWindow";
            Text = "Game of Life";
            ResumeLayout(false);
        }
        #endregion

        private Button PlayPauseButton;
        private Timer refreshTimer;
    }
}