using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Material.Icons.WinUI.Demo;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    private readonly MainViewModel ViewModel;

    public MainWindow()
    {
        this.InitializeComponent();
        this.ViewModel = new MainViewModel();
    }

    private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (GridView_Icons.SelectedItem != null)
        {
            string selectedIcon = GridView_Icons.SelectedItem.ToString();

            ViewModel.Result = $"<materialIcons:MaterialIcon Kind=\"{selectedIcon}\"/>";
        }
        else
        {
            ViewModel.Result = string.Empty;
        }
    }

    private void Result_PointerPressed(object sender, RoutedEventArgs e)
    {
        (sender as TextBox).SelectAll();
    }
}
