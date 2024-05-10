using Microsoft.UI.Xaml.Markup;

namespace Material.Icons.WinUI;

[MarkupExtensionReturnType(ReturnType = typeof(MaterialIcon))]
public class MaterialIconExt : MarkupExtension
{
    public MaterialIconExt()
    { }

    public MaterialIconExt(MaterialIconKind kind)
    {
        Kind = kind;
    }

    public MaterialIconExt(MaterialIconKind kind, double size)
    {
        Kind = kind;
        Size = size;
    }

    public MaterialIconKind Kind { get; set; }

    public double? Size { get; set; }

    protected override object ProvideValue()
    {
        var result = new MaterialIcon { Kind = Kind };

        if (Size.HasValue)
        {
            result.Height = Size.Value;
            result.Width = Size.Value;
        }

        return result;
    }
}
