
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
                    panelMatrix[y, x] = panel;
                    Controls.Add(panel);
                }
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
            playPauseButton = new Button();
            refreshTimer = new Timer(components);
            speedSlider = new TrackBar();
            resetButton = new Button();
            ((ISupportInitialize)speedSlider).BeginInit();
            SuspendLayout();
            // 
            // playPauseButton
            // 
            playPauseButton.Location = new Point(367, 1028);
            playPauseButton.Margin = new Padding(3, 4, 3, 4);
            playPauseButton.Name = "playPauseButton";
            playPauseButton.Size = new Size(139, 63);
            playPauseButton.TabIndex = 0;
            playPauseButton.Text = "Play";
            playPauseButton.UseVisualStyleBackColor = true;
            playPauseButton.Click += playPauseButton_Click;
            // 
            // refreshTimer
            // 
            refreshTimer.Interval = 499;
            refreshTimer.Tick += refreshTimer_Tick;
            // 
            // speedSlider
            // 
            speedSlider.Location = new Point(12, 1036);
            speedSlider.Maximum = 499;
            speedSlider.Minimum = 1;
            speedSlider.Name = "speedSlider";
            speedSlider.RightToLeft = RightToLeft.Yes;
            speedSlider.Size = new Size(349, 56);
            speedSlider.SmallChange = 5;
            speedSlider.TabIndex = 1;
            speedSlider.TickFrequency = 5;
            speedSlider.Value = 499;
            speedSlider.Scroll += speedSlider_Scroll;
            // 
            // resetButton
            // 
            resetButton.Location = new Point(512, 1028);
            resetButton.Margin = new Padding(3, 4, 3, 4);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(139, 63);
            resetButton.TabIndex = 2;
            resetButton.Text = "Reset";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // GameWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1138, 1104);
            Controls.Add(resetButton);
            Controls.Add(speedSlider);
            Controls.Add(playPauseButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "GameWindow";
            Text = "Game of Life";
            ((ISupportInitialize)speedSlider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Button playPauseButton;
        private Timer refreshTimer;
        private TrackBar speedSlider;
        private Button resetButton;
    }
}