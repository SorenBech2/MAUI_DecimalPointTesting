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
        var numberFormat = CultureInfo.CurrentCulture.NumberFormat;
        Debug.WriteLine($"NumberDecimalSeparator: {numberFormat.NumberDecimalSeparator}");
        Debug.WriteLine($"NumberGroupSeparator: {numberFormat.NumberGroupSeparator}");
    }
}
