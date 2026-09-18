using System;
using System.ComponentModel;
using System.Windows.Input;
using System.IO;
using Newtonsoft.Json;

public class ChartSettingsViewModel : INotifyPropertyChanged
{
    public ChartSettingsRoot Settings { get; set; } = new();

    // لیست‌ها برای ComboBox ها
    public IList<string> ChartTypes { get; } = new[] { "Candlestick", "Line", "Histogram", "Combined" };
    public IList<string> ZoomBehaviors { get; } = new[] { "Time Axis", "Price Axis", "Both" };
    public IList<string> PriceAxisPositions { get; } = new[] { "Left", "Right" };
    public IList<string> GridStyles { get; } = new[] { "Solid", "Dashed", "Dotted" };
    public IList<string> EngineModes { get; } = new[] { "Normal", "HighPerformance", "SafeMode" };

    // Commands
    public ICommand ApplyCommand { get; }
    public ICommand OkCommand { get; }
    public ICommand CancelCommand { get; }
    public ICommand ResetCommand { get; }

    // ColorPicker Commands
    public ICommand PickAxisColorCommand { get; }
    public ICommand PickBullColorCommand { get; }
    public ICommand PickBearColorCommand { get; }
    public ICommand PickBackgroundColorCommand { get; }
    public ICommand PickToolColorCommand { get; }
    public ICommand PickAnalyticalMainColorCommand { get; }
    public ICommand PickHudTextColorCommand { get; }

    public ChartSettingsViewModel()
    {
        ApplyCommand = new RelayCommand(Apply);
        OkCommand = new RelayCommand(Ok);
        CancelCommand = new RelayCommand(Cancel);
        ResetCommand = new RelayCommand(Reset);

        PickAxisColorCommand = new RelayCommand(() => PickColor(v => Settings.Axes.AxisColor = v));
        PickBullColorCommand = new RelayCommand(() => PickColor(v => Settings.Candles.BullColor = v));
        PickBearColorCommand = new RelayCommand(() => PickColor(v => Settings.Candles.BearColor = v));
        PickBackgroundColorCommand = new RelayCommand(() => PickColor(v => Settings.GridBackground.BackgroundColor = v));
        PickToolColorCommand = new RelayCommand(() => PickColor(v => Settings.DrawingTools.ToolColor = v));
        PickAnalyticalMainColorCommand = new RelayCommand(() => PickColor(v => Settings.AnalyticalModules.MainColor = v));
        PickHudTextColorCommand = new RelayCommand(() => PickColor(v => Settings.HudOverlay.TextColor = v));
    }

    // -----------------------------
    // APPLY — اجرای تنظیمات سنگین
    // -----------------------------
    private void Apply()
    {
        // مثال: ارسال تنظیمات سنگین به موتور
        SendToEngine("fps", Settings.Performance.FpsLimit);
        SendToEngine("gpu", Settings.Performance.GpuAcceleration);
        SendToEngine("engineMode", Settings.Advanced.EngineMode);
        SendToEngine("visibleCandles", Settings.Chart.VisibleCandles);

        // وابستگی‌ها
        if (!Settings.GridBackground.ShowGrid)
        {
            Settings.GridBackground.GridLineStyle = "None";
            Settings.GridBackground.GridTransparency = 100;
        }

        if (!Settings.Candles.ShowWicks)
        {
            Settings.Candles.WickThickness = 0;
        }

        OnPropertyChanged(nameof(Settings));
    }

    // -----------------------------
    // OK — ذخیره + بستن پنل
    // -----------------------------
    private void Ok()
    {
        SaveSettings();
        // اینجا پنل را می‌بندی (در پروژهٔ اصلی)
    }

    // -----------------------------
    // CANCEL — بستن بدون ذخیره
    // -----------------------------
    private void Cancel()
    {
        // فقط پنل را ببند
    }

    // -----------------------------
    // RESET — بازگشت به پیش‌فرض‌ها
    // -----------------------------
    private void Reset()
    {
        Settings = new ChartSettingsRoot();
        OnPropertyChanged(nameof(Settings));
    }

    // -----------------------------
    // ذخیره تنظیمات در JSON
    // -----------------------------
    private void SaveSettings()
    {
        var json = JsonConvert.SerializeObject(Settings, Formatting.Indented);
        File.WriteAllText("chart_settings.json", json);
    }

    // -----------------------------
    // لود تنظیمات از JSON
    // -----------------------------
    public void LoadSettings()
    {
        if (!File.Exists("chart_settings.json"))
            return;

        var json = File.ReadAllText("chart_settings.json");
        Settings = JsonConvert.DeserializeObject<ChartSettingsRoot>(json);
        OnPropertyChanged(nameof(Settings));
    }

    // -----------------------------
    // انتخاب رنگ (ColorPicker)
    // -----------------------------
    private void PickColor(Action<string> setter)
    {
        // اینجا ColorPicker واقعی پروژه را صدا می‌زنی
        string selectedColor = "#FF00FF"; // مثال
        setter(selectedColor);
        OnPropertyChanged(nameof(Settings));
    }

    // -----------------------------
    // ارسال تنظیمات به موتور اصلی
    // -----------------------------
    private void SendToEngine(string key, object value)
    {
        // اینجا Bridge پایتون/C++ را صدا می‌زنی
        // مثال:
        // PythonBridge.Send(key, value);
    }

    // -----------------------------
    // INotifyPropertyChanged
    // -----------------------------
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}