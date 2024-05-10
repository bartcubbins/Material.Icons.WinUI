using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System.ComponentModel;

namespace Material.Icons.WinUI;

public class MaterialIcon : Control
{
    public MaterialIcon()
    {
        this.DefaultStyleKey = typeof(MaterialIcon);
    }

    public static readonly DependencyProperty KindProperty
        = DependencyProperty.Register(nameof(Kind), typeof(MaterialIconKind), typeof(MaterialIcon),
            new PropertyMetadata(default(MaterialIconKind), KindPropertyChangedCallback));

    private static void KindPropertyChangedCallback(DependencyObject dependencyObject,
                                                    DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        => ((MaterialIcon)dependencyObject).UpdateData();

    /// <summary>
    /// Gets or sets the icon to display.
    /// </summary>
    public MaterialIconKind Kind
    {
        get => (MaterialIconKind)GetValue(KindProperty);
        set => SetValue(KindProperty, value);
    }

    private static readonly DependencyProperty DataProperty
        = DependencyProperty.Register(nameof(Data), typeof(string), typeof(MaterialIcon), new PropertyMetadata(""));

    /// <summary>
    /// Gets the icon path data for the current <see cref="Kind"/>.
    /// </summary>
    [TypeConverter(typeof(GeometryConverter))]
    public string Data
    {
        get => (string)GetValue(DataProperty);
        private set => SetValue(DataProperty, value);
    }

    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        UpdateData();
    }

    private void UpdateData()
    {
        Data = MaterialIconDataProvider.GetData(Kind);
    }
}
