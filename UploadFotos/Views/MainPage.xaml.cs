
using UploadFotos.Services;


namespace UploadFotos.Views
{
    public partial class MainPage : ContentPage
    {
        UploadImage uploadImage { get; set; }

        public MainPage()
        {
            InitializeComponent();
            uploadImage = new UploadImage();
        }

        private async void UploadImage_Clicked(object sender, EventArgs e)
        {
            var img = await uploadImage.OpenMediaPickerAsync();
            if (img != null)
            {
                var imageFile = await uploadImage.Upload(img);
                if (imageFile != null)
                {
                    Image_Upload.Source = ImageSource.FromStream(() =>
                        uploadImage.ByteArrayToStream(uploadImage.StringToByteBase64(imageFile.byteBase64))
                    );
                }
            }
        }
    }
}
