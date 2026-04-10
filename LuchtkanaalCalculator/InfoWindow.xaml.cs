using System.Diagnostics;
using System.Windows;

namespace LuchtkanaalCalculator;

public partial class InfoWindow : Window
{
    public InfoWindow()
    {
        InitializeComponent();
    }

    private void btnKofi_Click(object sender, RoutedEventArgs e)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "https://ko-fi.com/antoinevandenhurk",
            UseShellExecute = true
        });
    }
}