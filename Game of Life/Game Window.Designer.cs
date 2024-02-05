
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
            SuspendLayout();
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 870);
            Name = "Game Window";
            Text = "Game of Life";
            ResumeLayout(false);
        }

        private void Generate_Game_Matrix()
        {
            var gridWidth = 99;
            var gridHeight = 99;
            var buttonWidth = 8;
            var buttonHeight = 8;

            for (var h = 0; h < gridHeight; h++)
            {
                var row = new List<Panel>(gridWidth);
                for (var w = 0; w < gridWidth; w++)
                {
                    var location = new Point(10 + (buttonWidth * w), 10 + (buttonHeight * h));
                    var panel = new Panel()
                    {
                        Name = $"{location.X}_{location.Y}",
                        Location = location,
                        Size = new Size(buttonWidth, buttonHeight),
                        BackColor = Color.Gray,
                        Capture = false
                    };
                    panel.Click += panel_Click;
                    row.Add(panel);
                }
                panelMatrix.Add(row);
                Controls.AddRange(row.ToArray());
            };
        }

        #endregion
    }
}
