// ChartSettingsPanel/ColorPicker.cs
using System.Windows.Media;

public static class ColorPicker
{
    /// <summary>
    /// تبدیل رنگ انتخاب‌شده به فرمت Hex (#RRGGBB)
    /// </summary>
    public static string ToHex(Color color)
    {
        return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
    }
}
