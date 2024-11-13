namespace CvImageEqualizer.UI.WinForms;

partial class ImageEqualizerMainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

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

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        menuStrip = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        openToolStripMenuItem = new ToolStripMenuItem();
        tableLayoutPanelMain = new TableLayoutPanel();
        tableLayoutPanelImages = new TableLayoutPanel();
        groupBoxSourceImage = new GroupBox();
        pictureBoxSourceImage = new PictureBox();
        groupBoxEqualizedImage = new GroupBox();
        pictureBoxEqualizedImage = new PictureBox();
        tableLayoutPanelControl = new TableLayoutPanel();
        btnClose = new Button();
        tableLayoutPanelIntermediateInfo = new TableLayoutPanel();
        groupBoxInfo = new GroupBox();
        tableLayoutPanelInfo = new TableLayoutPanel();
        lblAngleDeviationDegreesText = new Label();
        lblAngleDeviationDegreesValue = new Label();
        groupBoxIntermediateImages = new GroupBox();
        tableLayoutPanelProcessedImages = new TableLayoutPanel();
        groupBoxFilteredImage = new GroupBox();
        pictureBoxFilteredImg = new PictureBox();
        groupBoxBinaryImg = new GroupBox();
        pictureBoxBinary = new PictureBox();
        groupBoxExtractedRect = new GroupBox();
        pictureBoxROI = new PictureBox();
        openFileDialog = new OpenFileDialog();
        menuStrip.SuspendLayout();
        tableLayoutPanelMain.SuspendLayout();
        tableLayoutPanelImages.SuspendLayout();
        groupBoxSourceImage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxSourceImage).BeginInit();
        groupBoxEqualizedImage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxEqualizedImage).BeginInit();
        tableLayoutPanelControl.SuspendLayout();
        tableLayoutPanelIntermediateInfo.SuspendLayout();
        groupBoxInfo.SuspendLayout();
        tableLayoutPanelInfo.SuspendLayout();
        groupBoxIntermediateImages.SuspendLayout();
        tableLayoutPanelProcessedImages.SuspendLayout();
        groupBoxFilteredImage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxFilteredImg).BeginInit();
        groupBoxBinaryImg.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxBinary).BeginInit();
        groupBoxExtractedRect.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxROI).BeginInit();
        SuspendLayout();
        // 
        // menuStrip
        // 
        menuStrip.ImageScalingSize = new Size(20, 20);
        menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
        menuStrip.Location = new Point(0, 0);
        menuStrip.Name = "menuStrip";
        menuStrip.Size = new Size(849, 28);
        menuStrip.TabIndex = 0;
        menuStrip.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem
        // 
        fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem });
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new Size(46, 24);
        fileToolStripMenuItem.Text = "File";
        // 
        // openToolStripMenuItem
        // 
        openToolStripMenuItem.Name = "openToolStripMenuItem";
        openToolStripMenuItem.Size = new Size(128, 26);
        openToolStripMenuItem.Text = "Open";
        openToolStripMenuItem.Click += openToolStripMenuItem_Click;
        // 
        // tableLayoutPanelMain
        // 
        tableLayoutPanelMain.ColumnCount = 2;
        tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanelMain.Controls.Add(tableLayoutPanelImages, 0, 0);
        tableLayoutPanelMain.Controls.Add(tableLayoutPanelControl, 1, 0);
        tableLayoutPanelMain.Dock = DockStyle.Fill;
        tableLayoutPanelMain.Location = new Point(0, 28);
        tableLayoutPanelMain.Name = "tableLayoutPanelMain";
        tableLayoutPanelMain.RowCount = 1;
        tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanelMain.Size = new Size(849, 526);
        tableLayoutPanelMain.TabIndex = 1;
        // 
        // tableLayoutPanelImages
        // 
        tableLayoutPanelImages.ColumnCount = 1;
        tableLayoutPanelImages.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanelImages.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanelImages.Controls.Add(groupBoxSourceImage, 0, 0);
        tableLayoutPanelImages.Controls.Add(groupBoxEqualizedImage, 0, 1);
        tableLayoutPanelImages.Dock = DockStyle.Fill;
        tableLayoutPanelImages.Location = new Point(3, 3);
        tableLayoutPanelImages.Name = "tableLayoutPanelImages";
        tableLayoutPanelImages.RowCount = 2;
        tableLayoutPanelImages.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanelImages.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanelImages.Size = new Size(418, 520);
        tableLayoutPanelImages.TabIndex = 0;
        // 
        // groupBoxSourceImage
        // 
        groupBoxSourceImage.Controls.Add(pictureBoxSourceImage);
        groupBoxSourceImage.Dock = DockStyle.Fill;
        groupBoxSourceImage.Location = new Point(3, 3);
        groupBoxSourceImage.Name = "groupBoxSourceImage";
        groupBoxSourceImage.Size = new Size(412, 254);
        groupBoxSourceImage.TabIndex = 0;
        groupBoxSourceImage.TabStop = false;
        groupBoxSourceImage.Text = "Source image";
        // 
        // pictureBoxSourceImage
        // 
        pictureBoxSourceImage.BorderStyle = BorderStyle.FixedSingle;
        pictureBoxSourceImage.Dock = DockStyle.Fill;
        pictureBoxSourceImage.Location = new Point(3, 23);
        pictureBoxSourceImage.Name = "pictureBoxSourceImage";
        pictureBoxSourceImage.Size = new Size(406, 228);
        pictureBoxSourceImage.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxSourceImage.TabIndex = 0;
        pictureBoxSourceImage.TabStop = false;
        // 
        // groupBoxEqualizedImage
        // 
        groupBoxEqualizedImage.Controls.Add(pictureBoxEqualizedImage);
        groupBoxEqualizedImage.Dock = DockStyle.Fill;
        groupBoxEqualizedImage.Location = new Point(3, 263);
        groupBoxEqualizedImage.Name = "groupBoxEqualizedImage";
        groupBoxEqualizedImage.Size = new Size(412, 254);
        groupBoxEqualizedImage.TabIndex = 1;
        groupBoxEqualizedImage.TabStop = false;
        groupBoxEqualizedImage.Text = "Equalized image";
        // 
        // pictureBoxEqualizedImage
        // 
        pictureBoxEqualizedImage.BorderStyle = BorderStyle.FixedSingle;
        pictureBoxEqualizedImage.Dock = DockStyle.Fill;
        pictureBoxEqualizedImage.Location = new Point(3, 23);
        pictureBoxEqualizedImage.Name = "pictureBoxEqualizedImage";
        pictureBoxEqualizedImage.Size = new Size(406, 228);
        pictureBoxEqualizedImage.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxEqualizedImage.TabIndex = 0;
        pictureBoxEqualizedImage.TabStop = false;
        // 
        // tableLayoutPanelControl
        // 
        tableLayoutPanelControl.ColumnCount = 1;
        tableLayoutPanelControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanelControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanelControl.Controls.Add(btnClose, 0, 1);
        tableLayoutPanelControl.Controls.Add(tableLayoutPanelIntermediateInfo, 0, 0);
        tableLayoutPanelControl.Dock = DockStyle.Fill;
        tableLayoutPanelControl.Location = new Point(427, 3);
        tableLayoutPanelControl.Name = "tableLayoutPanelControl";
        tableLayoutPanelControl.RowCount = 2;
        tableLayoutPanelControl.RowStyles.Add(new RowStyle(SizeType.Percent, 92.5F));
        tableLayoutPanelControl.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        tableLayoutPanelControl.Size = new Size(419, 520);
        tableLayoutPanelControl.TabIndex = 1;
        // 
        // btnClose
        // 
        btnClose.Dock = DockStyle.Right;
        btnClose.Location = new Point(322, 483);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(94, 34);
        btnClose.TabIndex = 0;
        btnClose.Text = "Close";
        btnClose.UseVisualStyleBackColor = true;
        btnClose.Click += btnClose_Click;
        // 
        // tableLayoutPanelIntermediateInfo
        // 
        tableLayoutPanelIntermediateInfo.ColumnCount = 1;
        tableLayoutPanelIntermediateInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanelIntermediateInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanelIntermediateInfo.Controls.Add(groupBoxInfo, 0, 0);
        tableLayoutPanelIntermediateInfo.Controls.Add(groupBoxIntermediateImages, 0, 1);
        tableLayoutPanelIntermediateInfo.Dock = DockStyle.Fill;
        tableLayoutPanelIntermediateInfo.Location = new Point(3, 3);
        tableLayoutPanelIntermediateInfo.Name = "tableLayoutPanelIntermediateInfo";
        tableLayoutPanelIntermediateInfo.RowCount = 2;
        tableLayoutPanelIntermediateInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
        tableLayoutPanelIntermediateInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanelIntermediateInfo.Size = new Size(413, 474);
        tableLayoutPanelIntermediateInfo.TabIndex = 1;
        // 
        // groupBoxInfo
        // 
        groupBoxInfo.Controls.Add(tableLayoutPanelInfo);
        groupBoxInfo.Dock = DockStyle.Fill;
        groupBoxInfo.Location = new Point(3, 3);
        groupBoxInfo.Name = "groupBoxInfo";
        groupBoxInfo.Size = new Size(407, 144);
        groupBoxInfo.TabIndex = 0;
        groupBoxInfo.TabStop = false;
        groupBoxInfo.Text = "Info";
        // 
        // tableLayoutPanelInfo
        // 
        tableLayoutPanelInfo.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
        tableLayoutPanelInfo.ColumnCount = 2;
        tableLayoutPanelInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanelInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanelInfo.Controls.Add(lblAngleDeviationDegreesText, 0, 0);
        tableLayoutPanelInfo.Controls.Add(lblAngleDeviationDegreesValue, 1, 0);
        tableLayoutPanelInfo.Dock = DockStyle.Fill;
        tableLayoutPanelInfo.Location = new Point(3, 23);
        tableLayoutPanelInfo.Name = "tableLayoutPanelInfo";
        tableLayoutPanelInfo.RowCount = 2;
        tableLayoutPanelInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanelInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanelInfo.Size = new Size(401, 118);
        tableLayoutPanelInfo.TabIndex = 0;
        // 
        // lblAngleDeviationDegreesText
        // 
        lblAngleDeviationDegreesText.AutoSize = true;
        lblAngleDeviationDegreesText.Dock = DockStyle.Fill;
        lblAngleDeviationDegreesText.Location = new Point(4, 1);
        lblAngleDeviationDegreesText.Name = "lblAngleDeviationDegreesText";
        lblAngleDeviationDegreesText.Size = new Size(193, 57);
        lblAngleDeviationDegreesText.TabIndex = 0;
        lblAngleDeviationDegreesText.Text = "Deviation angle (degrees)";
        lblAngleDeviationDegreesText.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblAngleDeviationDegreesValue
        // 
        lblAngleDeviationDegreesValue.AutoSize = true;
        lblAngleDeviationDegreesValue.Dock = DockStyle.Fill;
        lblAngleDeviationDegreesValue.Location = new Point(204, 1);
        lblAngleDeviationDegreesValue.Name = "lblAngleDeviationDegreesValue";
        lblAngleDeviationDegreesValue.Size = new Size(193, 57);
        lblAngleDeviationDegreesValue.TabIndex = 1;
        lblAngleDeviationDegreesValue.Text = "0";
        lblAngleDeviationDegreesValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // groupBoxIntermediateImages
        // 
        groupBoxIntermediateImages.Controls.Add(tableLayoutPanelProcessedImages);
        groupBoxIntermediateImages.Dock = DockStyle.Fill;
        groupBoxIntermediateImages.Location = new Point(3, 153);
        groupBoxIntermediateImages.Name = "groupBoxIntermediateImages";
        groupBoxIntermediateImages.Size = new Size(407, 318);
        groupBoxIntermediateImages.TabIndex = 1;
        groupBoxIntermediateImages.TabStop = false;
        groupBoxIntermediateImages.Text = "Intermediate images";
        // 
        // tableLayoutPanelProcessedImages
        // 
        tableLayoutPanelProcessedImages.ColumnCount = 2;
        tableLayoutPanelProcessedImages.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanelProcessedImages.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanelProcessedImages.Controls.Add(groupBoxFilteredImage, 0, 0);
        tableLayoutPanelProcessedImages.Controls.Add(groupBoxBinaryImg, 1, 0);
        tableLayoutPanelProcessedImages.Controls.Add(groupBoxExtractedRect, 0, 1);
        tableLayoutPanelProcessedImages.Dock = DockStyle.Fill;
        tableLayoutPanelProcessedImages.Location = new Point(3, 23);
        tableLayoutPanelProcessedImages.Name = "tableLayoutPanelProcessedImages";
        tableLayoutPanelProcessedImages.RowCount = 2;
        tableLayoutPanelProcessedImages.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanelProcessedImages.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanelProcessedImages.Size = new Size(401, 292);
        tableLayoutPanelProcessedImages.TabIndex = 0;
        // 
        // groupBoxFilteredImage
        // 
        groupBoxFilteredImage.Controls.Add(pictureBoxFilteredImg);
        groupBoxFilteredImage.Dock = DockStyle.Fill;
        groupBoxFilteredImage.Location = new Point(3, 3);
        groupBoxFilteredImage.Name = "groupBoxFilteredImage";
        groupBoxFilteredImage.Size = new Size(194, 140);
        groupBoxFilteredImage.TabIndex = 0;
        groupBoxFilteredImage.TabStop = false;
        groupBoxFilteredImage.Text = "Filter";
        // 
        // pictureBoxFilteredImg
        // 
        pictureBoxFilteredImg.BorderStyle = BorderStyle.FixedSingle;
        pictureBoxFilteredImg.Dock = DockStyle.Fill;
        pictureBoxFilteredImg.Location = new Point(3, 23);
        pictureBoxFilteredImg.Name = "pictureBoxFilteredImg";
        pictureBoxFilteredImg.Size = new Size(188, 114);
        pictureBoxFilteredImg.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxFilteredImg.TabIndex = 0;
        pictureBoxFilteredImg.TabStop = false;
        // 
        // groupBoxBinaryImg
        // 
        groupBoxBinaryImg.Controls.Add(pictureBoxBinary);
        groupBoxBinaryImg.Dock = DockStyle.Fill;
        groupBoxBinaryImg.Location = new Point(203, 3);
        groupBoxBinaryImg.Name = "groupBoxBinaryImg";
        groupBoxBinaryImg.Size = new Size(195, 140);
        groupBoxBinaryImg.TabIndex = 1;
        groupBoxBinaryImg.TabStop = false;
        groupBoxBinaryImg.Text = "Binary";
        // 
        // pictureBoxBinary
        // 
        pictureBoxBinary.BorderStyle = BorderStyle.FixedSingle;
        pictureBoxBinary.Dock = DockStyle.Fill;
        pictureBoxBinary.Location = new Point(3, 23);
        pictureBoxBinary.Name = "pictureBoxBinary";
        pictureBoxBinary.Size = new Size(189, 114);
        pictureBoxBinary.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxBinary.TabIndex = 0;
        pictureBoxBinary.TabStop = false;
        // 
        // groupBoxExtractedRect
        // 
        groupBoxExtractedRect.Controls.Add(pictureBoxROI);
        groupBoxExtractedRect.Dock = DockStyle.Fill;
        groupBoxExtractedRect.Location = new Point(3, 149);
        groupBoxExtractedRect.Name = "groupBoxExtractedRect";
        groupBoxExtractedRect.Size = new Size(194, 140);
        groupBoxExtractedRect.TabIndex = 2;
        groupBoxExtractedRect.TabStop = false;
        groupBoxExtractedRect.Text = "Extracted ROI";
        // 
        // pictureBoxROI
        // 
        pictureBoxROI.BorderStyle = BorderStyle.FixedSingle;
        pictureBoxROI.Dock = DockStyle.Fill;
        pictureBoxROI.Location = new Point(3, 23);
        pictureBoxROI.Name = "pictureBoxROI";
        pictureBoxROI.Size = new Size(188, 114);
        pictureBoxROI.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxROI.TabIndex = 0;
        pictureBoxROI.TabStop = false;
        // 
        // ImageEqualizerMainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(849, 554);
        Controls.Add(tableLayoutPanelMain);
        Controls.Add(menuStrip);
        MainMenuStrip = menuStrip;
        Name = "ImageEqualizerMainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "ImageEqualizer";
        menuStrip.ResumeLayout(false);
        menuStrip.PerformLayout();
        tableLayoutPanelMain.ResumeLayout(false);
        tableLayoutPanelImages.ResumeLayout(false);
        groupBoxSourceImage.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBoxSourceImage).EndInit();
        groupBoxEqualizedImage.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBoxEqualizedImage).EndInit();
        tableLayoutPanelControl.ResumeLayout(false);
        tableLayoutPanelIntermediateInfo.ResumeLayout(false);
        groupBoxInfo.ResumeLayout(false);
        tableLayoutPanelInfo.ResumeLayout(false);
        tableLayoutPanelInfo.PerformLayout();
        groupBoxIntermediateImages.ResumeLayout(false);
        tableLayoutPanelProcessedImages.ResumeLayout(false);
        groupBoxFilteredImage.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBoxFilteredImg).EndInit();
        groupBoxBinaryImg.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBoxBinary).EndInit();
        groupBoxExtractedRect.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBoxROI).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip menuStrip;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem openToolStripMenuItem;
    private TableLayoutPanel tableLayoutPanelMain;
    private TableLayoutPanel tableLayoutPanelImages;
    private GroupBox groupBoxSourceImage;
    private GroupBox groupBoxEqualizedImage;
    private PictureBox pictureBoxSourceImage;
    private PictureBox pictureBoxEqualizedImage;
    private OpenFileDialog openFileDialog;
    private TableLayoutPanel tableLayoutPanelControl;
    private Button btnClose;
    private TableLayoutPanel tableLayoutPanelIntermediateInfo;
    private GroupBox groupBoxInfo;
    private GroupBox groupBoxIntermediateImages;
    private TableLayoutPanel tableLayoutPanelInfo;
    private Label lblAngleDeviationDegreesText;
    private Label lblAngleDeviationDegreesValue;
    private TableLayoutPanel tableLayoutPanelProcessedImages;
    private GroupBox groupBoxFilteredImage;
    private PictureBox pictureBoxFilteredImg;
    private GroupBox groupBoxBinaryImg;
    private PictureBox pictureBoxBinary;
    private GroupBox groupBoxExtractedRect;
    private PictureBox pictureBoxROI;
}
