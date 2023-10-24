using System;
using System.Windows.Forms;

public class CinemaHall : Form
{
    public CinemaHall(int rows, int cols)
    {
        Text = "Кинозал";
        AutoSize = true;

        Label screenLabel = new Label();
        screenLabel.Text = "ЭКРАН";
        screenLabel.Dock = DockStyle.Top;
        screenLabel.BackColor = System.Drawing.Color.Blue;
        screenLabel.ForeColor = System.Drawing.Color.White;
        screenLabel.TextAlign = ContentAlignment.MiddleCenter;

        TableLayoutPanel layout = new TableLayoutPanel();
        layout.Dock = DockStyle.Fill;

        layout.ColumnCount = cols;
        layout.RowCount = rows;

        layout.ColumnStyles.Clear();
        layout.RowStyles.Clear();
        for (int col = 0; col < cols; col++)
        {
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / rows));
        }
        for (int row = 0; row < rows; row++)
        {
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                ToggleButton toggleButton = new ToggleButton(new Point(col, row));
                layout.Controls.Add(toggleButton, col, row);
            }
        }

        // Create a TableLayoutPanel for the total sum and confirm button
        TableLayoutPanel bottomLayout = new TableLayoutPanel();
        bottomLayout.Dock = DockStyle.Bottom;
        bottomLayout.ColumnCount = 2;
        bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
        bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));

        // Create a label for displaying the total sum
        Label totalSumLabel = new Label();
        totalSumLabel.Text = "Total Sum: $0.00"; // You can update this text dynamically
        totalSumLabel.TextAlign = ContentAlignment.MiddleLeft;

        // Create a confirm button
        Button confirmButton = new Button();
        confirmButton.Text = "Подтвердить";
        confirmButton.Dock = DockStyle.Fill;
        confirmButton.Click += ConfirmButton_Click;

        // Add the label and button to the bottomLayout
        bottomLayout.Controls.Add(totalSumLabel, 0, 0);
        bottomLayout.Controls.Add(confirmButton, 1, 0);

        // Add the layouts to the form
        Controls.Add(layout);
        Controls.Add(screenLabel);
        Controls.Add(bottomLayout);
    }

    private void ConfirmButton_Click(object sender, EventArgs e)
    {
    }
}

public class ToggleButton : Button
{
    private bool isOccupied = false;
    private Point placePosition = new Point();

    public ToggleButton(Point placePosition)
    {
        Click += ToggleOccupied;
        this.placePosition = placePosition;
        Dock = DockStyle.Fill;
        Text = "ряд:" + $"{placePosition.X + 1}" + "место:" + $"{placePosition.Y + 1}";
        BackColor = System.Drawing.Color.Gray;
    }

    private void ToggleOccupied(object sender, EventArgs e)
    {
        isOccupied = !isOccupied;
        UpdateAppearance();
    }

    private void UpdateAppearance()
    {
        if (isOccupied)
        {
            BackColor = System.Drawing.Color.Red;
            Text = "Занято";
        }
        else
        {
            BackColor = System.Drawing.Color.Gray;
            Text = "ряд:" + $"{placePosition.X + 1}" + "место:" + $"{placePosition.Y + 1}";
        }
    }
}
