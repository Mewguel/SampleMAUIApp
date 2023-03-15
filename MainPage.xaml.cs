using ZXing.Net.Maui;
using ZXing.Net.Maui.Readers;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace SmplBarCodeReaderMAUI;

public partial class MainPage : ContentPage
{

// namespace here
    public MainPage()
    {
        InitializeComponent();
        // for setting 2D or 1D Barcode
        //barcodeReader.Options = new BarcodeReaderOptions() 
        //{ 
        //	Formats = BarcodeFormats.
        //};
    }

    private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        Dispatcher.Dispatch(() => { 
            barcodeResult.Text = $"{e.Results[0].Value} {e.Results[0].Format}";
        });
    }

    private void ShowQRScanner(object sender, EventArgs args)
    {
        qrFields.IsVisible = !qrFields.IsVisible;
        nfcFields.IsVisible = !nfcFields.IsVisible;

        //var fieldToast = Toast.Make(qrFields.IsVisible.ToString(), ToastDuration.Short, 14);
        //await fieldToast.Show();
        if (qrFields.IsVisible)
        {
            QRButton.Text = "Show NFC Menu";
        }
        else
        {
            QRButton.Text = "Show QR Scanner";
        }

    }

    private void WriteNFCTag(object sender, EventArgs args)
    {
        // TODO: Check if there is a nearby TAG
        DetectNFCTag(sender, args);
        var entryText = nfcTextEntryField.Text;
        if (entryText == "" || entryText == null)
        {
            var error = Toast.Make("Error Empty Input", ToastDuration.Long, 16);
            error.Show();
        }
        else
        {
            var success = Toast.Make(entryText + " successfully written", ToastDuration.Long, 16);
            success.Show();
        }
    }
        

    //TBD: has return ??
    private void ReadNFCTag(object sender, EventArgs args)
    {
        DetectNFCTag(sender, args);
    }

    private async void DetectNFCTag(object sender, EventArgs args)
    {
        var nfcDetected = Toast.Make("Tag Detected", ToastDuration.Short, 14);
        await nfcDetected.Show();
    }
}

