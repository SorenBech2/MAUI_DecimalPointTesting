using System.Diagnostics;
using System.Globalization;

namespace MAUI_DecimalPointTesting;

public partial class MainPage : ContentPage
{
    readonly MainViewModel _viewModel;
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Debug.WriteLine("Below output is generated using .NET");
        
        var currentCulture = CultureInfo.CurrentCulture;
        var numberFormat = currentCulture.NumberFormat;

        Debug.WriteLine($"Device Culture Name : {currentCulture.Name}");
        Debug.WriteLine($"Device Display name : {currentCulture.DisplayName}");
        Debug.WriteLine($"Device Language name : {currentCulture.TwoLetterISOLanguageName}");
        
        Debug.WriteLine(" ");
        Debug.WriteLine($"Device NumberDecimalSeparator: {numberFormat.NumberDecimalSeparator}");
        Debug.WriteLine($"Device NumberGroupSeparator: {numberFormat.NumberGroupSeparator}");

#if IOS
        Debug.WriteLine(" "); Debug.WriteLine(" ");
        Debug.WriteLine("Below output is generated using iOS native code.");

        var locale = Foundation.NSLocale.CurrentLocale;
        
        Debug.WriteLine($"Device CurrentLocale.LanguageCode: {locale.LanguageCode}");
        Debug.WriteLine($"Device CurrentLocale.CountryCode: {locale.CountryCode}");
        Debug.WriteLine(" ");
        Debug.WriteLine($"Device CurrentLocale.DecimalSeparator: {locale.DecimalSeparator}");
        Debug.WriteLine($"Device CurrentLocale.GroupingSeparator: {locale.GroupingSeparator}");
#endif
#if ANDROID
        Debug.WriteLine(" "); Debug.WriteLine(" ");
        Debug.WriteLine("Below output is generated using Android native code");
        
        var locale = Java.Util.Locale.Default;
        Android.Icu.Text.DecimalFormatSymbols decimalFormat = new();

        Debug.WriteLine($"Device Language: {locale.Language}");
        Debug.WriteLine($"Device Country: {locale.Country}");
        Debug.WriteLine($"Device Display Language: {locale.DisplayLanguage}");
        Debug.WriteLine($"Device Display Country: {locale.DisplayCountry}");
        Debug.WriteLine(" ");
        Debug.WriteLine($"Device DecimalSeparator: {decimalFormat.DecimalSeparator}");
        Debug.WriteLine($"Device GroupingSeparator: {decimalFormat.GroupingSeparator}"); 
#endif
    }
}
