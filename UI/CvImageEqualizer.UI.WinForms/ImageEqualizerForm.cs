using CvImageEqualizer.Core.Equalizers;
using Emgu.CV;

namespace CvImageEqualizer.UI.WinForms;

public partial class ImageEqualizerMainForm : Form
{
    private readonly ImageEqualizer _imageEqualizer;

    public ImageEqualizerMainForm()
    {
        InitializeComponent();
        openFileDialog.Filter = "Image Files | *.jpg; *.jpeg; *.png";
        _imageEqualizer = new ImageEqualizer();
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            var diagResult = openFileDialog.ShowDialog();
            if (diagResult == DialogResult.OK)
            {
                pictureBoxSourceImage.Image = new Bitmap(openFileDialog.FileName);
                var equalizedImageData = _imageEqualizer.Equalize(openFileDialog.FileName);

                pictureBoxEqualizedImage.Image = equalizedImageData.EqualizedImage.ToBitmap();

                pictureBoxFilteredImg.Image = equalizedImageData.FilteredImage.ToBitmap();

                pictureBoxBinary.Image = equalizedImageData.BinaryImage.ToBitmap();

                pictureBoxROI.Image = equalizedImageData.ExtractedROI.ToBitmap();

                pictureBoxRemovedHighlightsImg.Image = equalizedImageData
                    .RemovedHighlightsImage.ToBitmap();

                lblAngleDeviationDegreesValue.Text = equalizedImageData.AngleDeviationDegrees.ToString("0.000");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}
