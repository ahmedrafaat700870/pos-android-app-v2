namespace App.Views.CameraPage;
public partial class _CameraView : ContentView
{
    private Action<string> setBarcode;
    private CameraViewLang vmLang;

    public _CameraView(Action<string> setBarcode)
    {
        InitializeComponent();
        this.setBarcode = setBarcode;
        LoadLang();
        BindingContext = vmLang;
    }


    public void Set_SetBarcodeAction(Action<string> setBarcode)
    {
        this.setBarcode = setBarcode;
    }

    public void LoadLang()
    {
        vmLang = HerlperSettings.GetLang().CameraViewLang.GetLang();
    }

    private async void CameraView_CamerasLoaded(object sender, EventArgs e)
    {
        if (cameraView.Cameras.Count > 0)
        {
            cameraView.Camera = cameraView.Cameras.FirstOrDefault();
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await cameraView.StopCameraAsync();
                await cameraView.StartCameraAsync();
            });
        }
    }

    private void GoHome()
    {
        App.helperNavigation.NavigateToHome();
    }

    private void close_Clicked(object sender, EventArgs e)
    {
        CloseCam();
        GoHome();
    }

    private void cam1_Clicked(object sender, EventArgs e)
    {
        CameraView_CamerasLoaded(null, null);
    }

    private async void cam2_Clicked(object sender, EventArgs e)
    {
        cameraView.Camera = cameraView.Cameras.LastOrDefault();
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await cameraView.StopCameraAsync();
            await cameraView.StartCameraAsync();
        });
    }

    private void CloseCam()
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await cameraView.StopCameraAsync();
        });
    }


    private void cameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            resualt.Text = args.Result[0].Text;
        });
    }


    private void StopCamera()
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await cameraView.StopCameraAsync();
        });
    }

    private void resualt_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            string barcode = resualt.Text;
            if (string.IsNullOrEmpty(barcode)) return;
            StopCamera();
            setBarcode(barcode);
            GoHome();
        }
        catch { }
    }

}