

namespace App;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureMopups()
            .UseMauiCameraView()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Brands-Regular-400.otf", "FAS");
                fonts.AddFont("Free-Regular-400.otf", "FAS");
                fonts.AddFont("Free-Solid-900.otf", "FAS");
            });
        builder.Services.AddSingleton<GetDataHelper>();
        builder.Services.AddSingleton<HttpClient>();
        builder.Services.AddSingleton<ICRUDHttpServices, CRUDHttpServices>();
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoginPageViewModel>();
        builder.Services.AddSingleton<Sql_Lite_LocalDB>();
        builder.Services.AddSingleton<ILoginServices, LoginServicesV2>();
        builder.Services.AddSingleton<IApplicationData, ApplicatonDataV2>();
        builder.Services.AddSingleton<MainPageContentView>();
        builder.Services.AddSingleton<MainPageContentViewViewModel>();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<HomePageViewModel>();
        builder.Services.AddScoped<CardPage>();
        builder.Services.AddScoped<CartViewModel>();
        builder.Services.AddScoped<SettignsPage>();
        builder.Services.AddScoped<SettingsPageViewModel>();
        builder.Services.AddSingleton<PaymentsPage>();
        builder.Services.AddSingleton<PaymentsPageViewModel>();
        builder.Services.AddSingleton<PaymentPagePopup>();
        builder.Services.AddSingleton<PaymentPopupPageViewModel>();
        builder.Services.AddSingleton<ICalacOrderServices, CalcOrderServices>();
        builder.Services.AddScoped<ClientPage>();
        builder.Services.AddScoped<ClientPageViewModel>();
        builder.Services.AddScoped<AddNewClientPage>();
        builder.Services.AddScoped<AddNewClientPageViewModel>();
        builder.Services.AddSingleton<IPostNewCustomer, PostNewCustomer>();
        builder.Services.AddSingleton<IPostOrder, PostOrder>();
        builder.Services.AddSingleton<ISavedOrder, SavedOrderV2>();
        builder.Services.AddSingleton<SavedOrderPage>();
        builder.Services.AddSingleton<SavedOrderViewModel>();
        builder.Services.AddScoped<IUpdateDataHome, UpdateDataHome>();
        builder.Services.AddSingleton<ICreateNewCustomer , CreateNewCustomer>();
        builder.Services.AddSingleton<PrintService>();
        builder.Services.AddSingleton<IPrinter , Printer>();
        builder.Services.AddSingleton<IOrderPrinter, OrderPrinter>();



#if DEBUG
        builder.Logging.AddDebug();
#endif
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
        {
#if ANDROID
            
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#endif
        });

        GlobalFontSettings.FontResolver = new FontResolver();


        return builder.Build();
    }
}

