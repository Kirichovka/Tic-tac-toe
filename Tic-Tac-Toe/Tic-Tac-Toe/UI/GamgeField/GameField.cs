using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tic_Tac_Toe.UI.GameField
{
 
    public partial class GameField : UserControl
    {
        public event EventHandler<CellClickEventArgs> CellClicked;
        private TableLayoutPanel tableLayoutPanel;
        private int gridSize;

        public GameField(int gridSize)
        {
            this.gridSize = gridSize;
            InitializeComponent();
            SetupGrid();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "GameField";
            this.ResumeLayout(false);
        }

        private void SetupGrid()
        {
            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = gridSize,
                RowCount = gridSize
            };

            for (int i = 0; i < gridSize; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / gridSize));
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / gridSize));
            }

            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    Button cellButton = new Button
                    {
                        Dock = DockStyle.Fill,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Arial", 24, FontStyle.Bold),
                        FlatAppearance = { BorderColor = Color.Black, BorderSize = 1 },
                        Tag = new Point(row, col)
                    };
                    cellButton.Click += CellButton_Click;
                    tableLayoutPanel.Controls.Add(cellButton, col, row);
                }
            }

            this.Controls.Add(tableLayoutPanel);
        }

        private void CellButton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Point coordinates)
            {
                CellClicked?.Invoke(this, new CellClickEventArgs(coordinates));
            }
        }


        public void UpdateField(Tic_Tac_Toe.Game.Field field)
        {
            foreach (Control control in tableLayoutPanel.Controls)
            {
                if (control is Button btn && btn.Tag is Point coordinates)
                {
                    char cellValue = field.GetCell(coordinates.X, coordinates.Y);
                    btn.Text = cellValue == '-' ? "" : cellValue.ToString();
                }
            }
        }
    }
    public class CellClickEventArgs : EventArgs
    {
        public Point Coordinates { get; }

        public CellClickEventArgs(Point coordinates)
        {
            Coordinates = coordinates;
        }
    }
}
