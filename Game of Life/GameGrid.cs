using System.Collections;
using System.Collections.Concurrent;

namespace Game_of_Life
{
    public sealed partial class GameGrid : DataGridView, IEnumerable<DataGridViewCell>
    {
        private readonly int width;
        private readonly int height;

        public GameGrid(int width, int height) : base()
        {
            DoubleBuffered = true;
            this.width = width;
            this.height = height;
        }

        public IEnumerable<DataGridViewCell> GetCellsToProcess()
        {
            var test = new ConcurrentDictionary<DataGridViewCell, object?>();

            Parallel.ForEach(this, cell =>
            {
                if (cell.Style.BackColor == Color.Yellow)
                {
                    foreach (var c in GetNeighbours(cell))
                    {
                        test.TryAdd(c, null);
                    }
                }
            });

            return test.Keys;
        }

        private IEnumerable<DataGridViewCell> GetNeighbours(DataGridViewCell cell)
        {
            var x = cell.ColumnIndex;
            var y = cell.RowIndex;

            for (var nY = y - 1; nY <= y + 1; nY++)
                for (var nX = x - 1; nX <= x + 1; nX++)
                    if (nY >= 0 && nY < height && nX >= 0 && nX < width)
                        yield return this[nX, nY];
        }

        public IEnumerator<DataGridViewCell> GetEnumerator()
        {
            foreach (DataGridViewRow row in Rows)
                foreach (DataGridViewCell cell in row.Cells)
                    yield return cell;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}