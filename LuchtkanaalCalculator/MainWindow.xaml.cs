using System;
using System.Windows;
using System.Windows.Controls;

namespace LuchtkanaalCalculator;

/// <summary>
/// Interactielogica voor MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private static bool TryGetPositiveDouble(string text, out double value)
    {
        if (double.TryParse(text, out value) && value > 0)
            return true;

        value = 0;
        return false;
    }

    private bool TryGetArea(out double area)
    {
        if (TryGetPositiveDouble(i1_4.Text, out double diameter))
        {
            area = Math.PI * Math.Pow(diameter / 2000.0, 2);
            return true;
        }

        if (TryGetPositiveDouble(i1_5.Text, out double width) && TryGetPositiveDouble(i1_6.Text, out double height))
        {
            area = (width / 1000.0) * (height / 1000.0);
            return true;
        }

        if (TryGetPositiveDouble(i1_3.Text, out area))
            return true;

        area = 0;
        return false;
    }

    private void UpdateDerivedFieldsFromArea(double area)
    {
        i1_3.Text = Math.Round(area, 4).ToString();

        // Werk de diameter altijd bij zodat deze overeenkomt met de nieuwe oppervlakte
        double diameter = Math.Sqrt(4 * area / Math.PI) * 1000;
        i1_4.Text = Math.Round(diameter, 0).ToString();

        bool widthValid = TryGetPositiveDouble(i1_5.Text, out double width);
        bool heightValid = TryGetPositiveDouble(i1_6.Text, out double height);

        // Forceer update van afmetingen: prioriteit op behoud van breedte als beide bekend zijn
        if (widthValid)
        {
            i1_6.Text = Math.Round(area * 1_000_000 / width, 0).ToString();
        }
        else if (heightValid)
        {
            i1_5.Text = Math.Round(area * 1_000_000 / height, 0).ToString();
        }
        else
        {
            double side = Math.Sqrt(area * 1_000_000);
            i1_5.Text = Math.Round(side, 0).ToString();
            i1_6.Text = Math.Round(side, 0).ToString();
        }
    }

    private void btnBerekenDebietOpp_Click(object sender, RoutedEventArgs e)
    {
        if (TryGetPositiveDouble(i1_1.Text, out double q) && TryGetPositiveDouble(i1_2.Text, out double v))
        {
            // A = Q / (v * 3600)
            double area = q / (v * 3600);
            UpdateDerivedFieldsFromArea(area);
        }
    }

    private void btnBerekenDebietArea_Click(object sender, RoutedEventArgs e)
    {
        if (!TryGetPositiveDouble(i1_2.Text, out double v))
        {
            return;
        }

        if (!TryGetArea(out double area))
        {
            return;
        }

        double q = v * area * 3600;
        i1_1.Text = Math.Round(q, 0).ToString();
        UpdateDerivedFieldsFromArea(area);
    }

    private void btnBerekenSnelheidOpp_Click(object sender, RoutedEventArgs e)
    {
        if (!TryGetPositiveDouble(i1_1.Text, out double q))
        {
            return;
        }

        if (!TryGetArea(out double area))
        {
            return;
        }

        double v = q / (area * 3600);
        i1_2.Text = Math.Round(v, 0).ToString();
        UpdateDerivedFieldsFromArea(area);
    }

    private void btnBerekenDebietRond_Click(object sender, RoutedEventArgs e)
    {
        if (!TryGetPositiveDouble(i1_2.Text, out double v))
        {
            return;
        }

        if (!TryGetPositiveDouble(i1_4.Text, out double diameter))
        {
            return;
        }

        double area = Math.PI * Math.Pow(diameter / 2000.0, 2);
        double q = v * area * 3600;

        i1_1.Text = Math.Round(q, 0).ToString();
        UpdateDerivedFieldsFromArea(area);
    }

    private void btnBerekenSnelheidRond_Click(object sender, RoutedEventArgs e)
    {
        if (!TryGetPositiveDouble(i1_1.Text, out double q))
        {
            return;
        }

        if (!TryGetPositiveDouble(i1_4.Text, out double diameter))
        {
            return;
        }

        double area = Math.PI * Math.Pow(diameter / 2000.0, 2);
        double v = q / (area * 3600);

        i1_2.Text = Math.Round(v, 0).ToString();
        UpdateDerivedFieldsFromArea(area);
    }

    private void btnBerekenDebietBxH_Click(object sender, RoutedEventArgs e)
    {
        if (TryGetPositiveDouble(i1_2.Text, out double v) && 
            TryGetPositiveDouble(i1_5.Text, out double width) && 
            TryGetPositiveDouble(i1_6.Text, out double height))
        {
            double area = (width / 1000.0) * (height / 1000.0);
            double q = v * area * 3600;
            
            i1_1.Text = Math.Round(q, 0).ToString();
            UpdateDerivedFieldsFromArea(area);
        }
    }

    private void btnBerekenSnelheidBxH_Click(object sender, RoutedEventArgs e)
    {
        if (TryGetPositiveDouble(i1_1.Text, out double q) && 
            TryGetPositiveDouble(i1_5.Text, out double width) && 
            TryGetPositiveDouble(i1_6.Text, out double height))
        {
            double area = (width / 1000.0) * (height / 1000.0);
            double v = q / (area * 3600);
            
            i1_2.Text = Math.Round(v, 0).ToString();
            UpdateDerivedFieldsFromArea(area);
        }
    }

    private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
    {
        i1_1.Clear();
        i1_2.Clear();
        i1_3.Clear();
        i1_4.Clear();
        i1_5.Clear();
        i1_6.Clear();
    }

    private void TextBox_GotFocus(object sender, RoutedEventArgs e)
    {
        if (sender is TextBox textBox)
        {
            textBox.SelectAll();
        }
    }

    private void btnInfo_Click(object sender, RoutedEventArgs e)
    {
        InfoWindow infoWindow = new InfoWindow();
        infoWindow.Owner = this;
        infoWindow.ShowDialog();
    }

    private void btnAfsluiten_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}
