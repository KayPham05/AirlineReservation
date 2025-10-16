namespace AirlineReservation.WinForms.Views;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null!;
    private System.Windows.Forms.TextBox originTextBox = null!;
    private System.Windows.Forms.TextBox destinationTextBox = null!;
    private System.Windows.Forms.Label originLabel = null!;
    private System.Windows.Forms.Label destinationLabel = null!;
    private System.Windows.Forms.Button searchButton = null!;
    private System.Windows.Forms.Button saveButton = null!;
    private System.Windows.Forms.DataGridView flightsGridView = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        originTextBox = new System.Windows.Forms.TextBox();
        destinationTextBox = new System.Windows.Forms.TextBox();
        originLabel = new System.Windows.Forms.Label();
        destinationLabel = new System.Windows.Forms.Label();
        searchButton = new System.Windows.Forms.Button();
        saveButton = new System.Windows.Forms.Button();
        flightsGridView = new System.Windows.Forms.DataGridView();
        ((System.ComponentModel.ISupportInitialize)flightsGridView).BeginInit();
        SuspendLayout();
        // 
        // originTextBox
        // 
        originTextBox.Location = new System.Drawing.Point(120, 20);
        originTextBox.Name = "originTextBox";
        originTextBox.Size = new System.Drawing.Size(120, 23);
        originTextBox.TabIndex = 0;
        // 
        // destinationTextBox
        // 
        destinationTextBox.Location = new System.Drawing.Point(120, 60);
        destinationTextBox.Name = "destinationTextBox";
        destinationTextBox.Size = new System.Drawing.Size(120, 23);
        destinationTextBox.TabIndex = 1;
        // 
        // originLabel
        // 
        originLabel.AutoSize = true;
        originLabel.Location = new System.Drawing.Point(40, 23);
        originLabel.Name = "originLabel";
        originLabel.Size = new System.Drawing.Size(74, 15);
        originLabel.TabIndex = 2;
        originLabel.Text = "Điểm khởi hành";
        // 
        // destinationLabel
        // 
        destinationLabel.AutoSize = true;
        destinationLabel.Location = new System.Drawing.Point(40, 63);
        destinationLabel.Name = "destinationLabel";
        destinationLabel.Size = new System.Drawing.Size(63, 15);
        destinationLabel.TabIndex = 3;
        destinationLabel.Text = "Điểm đến";
        // 
        // searchButton
        // 
        searchButton.Location = new System.Drawing.Point(260, 20);
        searchButton.Name = "searchButton";
        searchButton.Size = new System.Drawing.Size(100, 23);
        searchButton.TabIndex = 4;
        searchButton.Text = "Tìm chuyến bay";
        searchButton.UseVisualStyleBackColor = true;
        searchButton.Click += searchButton_Click;
        // 
        // saveButton
        // 
        saveButton.Location = new System.Drawing.Point(260, 60);
        saveButton.Name = "saveButton";
        saveButton.Size = new System.Drawing.Size(100, 23);
        saveButton.TabIndex = 5;
        saveButton.Text = "Lưu thay đổi";
        saveButton.UseVisualStyleBackColor = true;
        saveButton.Click += saveButton_Click;
        // 
        // flightsGridView
        // 
        flightsGridView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        flightsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        flightsGridView.Location = new System.Drawing.Point(20, 110);
        flightsGridView.Name = "flightsGridView";
        flightsGridView.RowTemplate.Height = 25;
        flightsGridView.Size = new System.Drawing.Size(600, 280);
        flightsGridView.TabIndex = 6;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(640, 420);
        Controls.Add(flightsGridView);
        Controls.Add(saveButton);
        Controls.Add(searchButton);
        Controls.Add(destinationLabel);
        Controls.Add(originLabel);
        Controls.Add(destinationTextBox);
        Controls.Add(originTextBox);
        Name = "MainForm";
        Text = "Quản lý đặt vé";
        ((System.ComponentModel.ISupportInitialize)flightsGridView).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
