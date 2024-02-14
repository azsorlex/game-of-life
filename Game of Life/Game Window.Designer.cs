
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
            for (var x = 0; x < gridWidth;  x++)
            {
                var column = new DataGridViewColumn();
                column.Width = buttonLength;
                column.CellTemplate = new DataGridViewTextBoxCell();
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                column.Resizable = DataGridViewTriState.False;
                gameGrid.Columns.Add(column);
            }
            for (var y = 0; y < gridHeight; y++)
            {
                var row = new DataGridViewRow();
                row.Height = buttonLength;
                row.Resizable = DataGridViewTriState.False;
                gameGrid.Rows.Add(row);
            }
            foreach (var cell in gameGrid)
                cell.Style.BackColor = Color.Gray;
        }

        private void InitializeGameGrid()
        {
            // 
            // gameGrid
            // 
            gameGrid.AllowUserToAddRows = false;
            gameGrid.AllowUserToDeleteRows = false;
            gameGrid.AllowUserToResizeColumns = false;
            gameGrid.AllowUserToResizeRows = false;
            gameGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            gameGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            gameGrid.CausesValidation = false;
            gameGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            gameGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gameGrid.ColumnHeadersHeight = 29;
            gameGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gameGrid.ColumnHeadersVisible = false;
            gameGrid.EditMode = DataGridViewEditMode.EditProgrammatically;
            gameGrid.EnableHeadersVisualStyles = false;
            gameGrid.Location = new Point(12, 12);
            gameGrid.MultiSelect = false;
            gameGrid.Name = "gameGrid";
            gameGrid.ReadOnly = true;
            gameGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gameGrid.RowHeadersVisible = false;
            gameGrid.RowHeadersWidth = 51;
            gameGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            gameGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gameGrid.ShowCellErrors = false;
            gameGrid.ShowCellToolTips = false;
            gameGrid.ShowEditingIcon = false;
            gameGrid.ShowRowErrors = false;
            gameGrid.Size = new Size(1317, 811);
            gameGrid.TabIndex = 3;
            gameGrid.TabStop = false;
            gameGrid.VirtualMode = true;
            gameGrid.CellClick += gameGrid_CellClick;
            Controls.Add(gameGrid);
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
            gameGrid = new GameGrid(gridWidth, gridHeight);
            ((ISupportInitialize)speedSlider).BeginInit();
            ((ISupportInitialize)gameGrid).BeginInit();
            SuspendLayout();
            InitializeGameGrid();
            // 
            // playPauseButton
            // 
            playPauseButton.Location = new Point(372, 830);
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
            speedSlider.Location = new Point(17, 838);
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
            resetButton.Location = new Point(517, 830);
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
            ClientSize = new Size(1341, 906);
            Controls.Add(resetButton);
            Controls.Add(speedSlider);
            Controls.Add(playPauseButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "GameWindow";
            Text = "Game of Life";
            ((ISupportInitialize)speedSlider).EndInit();
            ((ISupportInitialize)gameGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Button playPauseButton;
        private Timer refreshTimer;
        private TrackBar speedSlider;
        private Button resetButton;
        private GameGrid gameGrid;
    }
}