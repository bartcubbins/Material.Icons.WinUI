using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Material.Icons.WinUI.Demo;

public partial class MainViewModel : ObservableObject
{
    private readonly ObservableCollection<MaterialIconKind> allKinds;

    [ObservableProperty]
    private ObservableCollection<MaterialIconKind> kinds;

    [ObservableProperty]
    private string filter;

    [ObservableProperty]
    private string result;

    public MainViewModel()
    {
        allKinds = new ObservableCollection<MaterialIconKind>(Enum.GetValues(typeof(MaterialIconKind)).Cast<MaterialIconKind>());
        kinds = allKinds;
    }

    partial void OnFilterChanged(string value)
    {
        ApplyFilter(value.ToLower());
    }

    private void ApplyFilter(string filter)
    {
        if (string.IsNullOrEmpty(filter))
        {
            Kinds = allKinds;
        }
        else
        {
            Kinds = new ObservableCollection<MaterialIconKind>(allKinds.Where(kind => kind.ToString().ToLower().Contains(filter)));
        }
    }
}
