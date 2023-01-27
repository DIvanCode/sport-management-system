namespace sport_management_system.frontend.library;

public class Table
{
    private string TableName;
    private Point TableLocation;

    public int Rows;
    public int Columns;
    public List<int> RowHeight;
    public List<int> ColumnWidth;
    public List<List<Label>> table;

    public Table(string tableName, Point tableLocation, int rows, int columns)
    {
        TableName = tableName;
        TableLocation = tableLocation;

        Rows = rows;
        Columns = columns;

        RowHeight = new List<int>(new int[Rows]);
        ColumnWidth = new List<int>(new int[Columns]);

        table = new List<List<Label>>();
        for (var rowIndex = 0; rowIndex < Rows; ++rowIndex)
        {
            table.Add(new List<Label>(new Label[Columns]));
        }
    }
    
    public void SetRowHeight(int rowIndex, int height)
    {
        RowHeight[rowIndex] = PageHandler.GetDIP(height);
    }

    public void SetColumnWidth(int columnIndex, int width)
    {
        ColumnWidth[columnIndex] = PageHandler.GetDIP(width);
    }

    private Point CalculateLocation(int rowIndex, int columnIndex)
    {
        var x = TableLocation.X;
        var y = TableLocation.Y;
        
        for (var beforecolumnIndex = 0; beforecolumnIndex < columnIndex; ++beforecolumnIndex)
        {
            x += ColumnWidth[beforecolumnIndex];
        }
        
        for (var beforeRowIndex = 0; beforeRowIndex < rowIndex; ++beforeRowIndex)
        {
            y += RowHeight[beforeRowIndex];
        }

        return new Point(x, y);
    }

    public Label InitializeCell(int rowIndex, int columnIndex, string text)
    {   
        var label = new Label();
        
        label.Name = TableName + "Table_" + rowIndex + "-" + columnIndex;

        label.Location = CalculateLocation(rowIndex, columnIndex);
        label.Size = new Size(ColumnWidth[columnIndex], RowHeight[rowIndex]);
        label.TabIndex = 0;

        label.AutoSize = false;
        label.TextAlign = ContentAlignment.MiddleCenter;
        label.Dock = DockStyle.None;

        label.Font = PageHandler.SmallFont;
        label.BorderStyle = BorderStyle.FixedSingle;

        label.Text = text;

        return table[rowIndex][columnIndex] = label;
    }

    public void AddClickAction(int rowIndex, int columnIndex, EventHandler clickAction)
    {
        table[rowIndex][columnIndex].Click += clickAction;
    }
}