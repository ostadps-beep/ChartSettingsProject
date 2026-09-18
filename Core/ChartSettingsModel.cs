// ChartSettingsModel.cs

public class ChartSettingsRoot
{
    public ChartSettings Chart { get; set; } = new();
    public AxesSettings Axes { get; set; } = new();
    public CandleSettings Candles { get; set; } = new();
    public GridBackgroundSettings GridBackground { get; set; } = new();
    public DrawingToolsSettings DrawingTools { get; set; } = new();
    public AnalyticalModulesSettings AnalyticalModules { get; set; } = new();
    public HudOverlaySettings HudOverlay { get; set; } = new();
    public PerformanceSettings Performance { get; set; } = new();
    public WorkspaceSettings Workspace { get; set; } = new();
    public AdvancedSettings Advanced { get; set; } = new();
}

// 1) Chart
public class ChartSettings
{
    public string Type { get; set; } = "Candlestick";
    public string ZoomBehavior { get; set; } = "Both";
    public int ZoomSpeed { get; set; } = 50;
    public int ScrollSpeed { get; set; } = 50;
    public int VisibleCandles { get; set; } = 1500;
    public bool AutoFit { get; set; } = true;
    public string MouseWheel { get; set; } = "Zoom";
}

// 2) Axes
public class AxesSettings
{
    public string PricePosition { get; set; } = "Right";
    public bool ShowLastPrice { get; set; } = true;
    public bool ShowHorizontalGrid { get; set; } = true;
    public int DecimalCount { get; set; } = 2;
    public bool ShowPlusMinus { get; set; } = false;
    public string AxisColor { get; set; } = "#CCCCCC";
    public int AxisThickness { get; set; } = 2;
    public string TimePosition { get; set; } = "Bottom";
    public bool ShowVerticalGrid { get; set; } = true;
    public string TimeFormat { get; set; } = "HH:MM";
}

// 3) Candles
public class CandleSettings
{
    public string BullColor { get; set; } = "#00FF55";
    public string BearColor { get; set; } = "#FF3333";
    public string WickColor { get; set; } = "#FFFFFF";
    public int BodyThickness { get; set; } = 3;
    public int WickThickness { get; set; } = 2;
    public int Spacing { get; set; } = 2;
    public bool ShowWicks { get; set; } = true;
    public bool ShowBody { get; set; } = true;
}

// 4) Grid & Background
public class GridBackgroundSettings
{
    public string BackgroundColor { get; set; } = "#1E1E1E";
    public string GradientMode { get; set; } = "None";
    public int BackgroundTransparency { get; set; } = 0;
    public bool ShowGrid { get; set; } = true;
    public string HorizontalLineColor { get; set; } = "#333333";
    public string VerticalLineColor { get; set; } = "#333333";
    public string GridLineStyle { get; set; } = "Solid";
    public int GridTransparency { get; set; } = 20;
}

// 5) Drawing Tools
public class DrawingToolsSettings
{
    public string ToolColor { get; set; } = "#00A8FF";
    public int ToolThickness { get; set; } = 2;
    public string ToolLineStyle { get; set; } = "Solid";
    public int ToolTransparency { get; set; } = 0;
    public string SnapMode { get; set; } = "None";
    public string SelectionMode { get; set; } = "Single";
    public bool ShowLabels { get; set; } = true;
    public string Hotkey { get; set; } = "";
    public string DragBehavior { get; set; } = "Free";
}

// 6) Analytical Modules
public class AnalyticalModulesSettings
{
    public List<double> InputParameters { get; set; } = new() { 14, 5 };
    public string DisplayType { get; set; } = "Line";
    public string MainColor { get; set; } = "#00FFAA";
    public string AlertColor { get; set; } = "#FFAA00";
    public string AreaBackground { get; set; } = "#333333";
    public string UpdateMode { get; set; } = "Tick";
    public bool Enabled { get; set; } = true;
    public int Transparency { get; set; } = 0;
    public int Thickness { get; set; } = 2;
}

// 7) HUD & Overlay
public class HudOverlaySettings
{
    public List<string> HudItems { get; set; } = new();
    public string HudPosition { get; set; } = "Top";
    public bool FixedFollow { get; set; } = true;
    public string TextColor { get; set; } = "#FFFFFF";
    public int FontSize { get; set; } = 12;
    public string FontType { get; set; } = "Segoe UI";
    public int HudTransparency { get; set; } = 0;
}

// 8) Performance
public class PerformanceSettings
{
    public int FpsLimit { get; set; } = 60;
    public bool AntiAliasing { get; set; } = true;
    public bool GpuAcceleration { get; set; } = true;
    public int BufferSize { get; set; } = 64;
    public string LogLevel { get; set; } = "Warning";
    public string ErrorBehavior { get; set; } = "Show";
}

// 9) Workspace
public class WorkspaceSettings
{
    public bool SaveLayout { get; set; } = false;
    public bool LoadLayout { get; set; } = false;
    public bool ResetLayout { get; set; } = false;
    public string ExportSettings { get; set; } = "JSON";
    public bool ImportSettings { get; set; } = false;
}

// 10) Advanced
public class AdvancedSettings
{
    public bool MultiThreading { get; set; } = true;
    public int CacheSize { get; set; } = 128;
    public bool BackupRestore { get; set; } = false;
    public string EngineMode { get; set; } = "Normal";
    public PythonBridgeSettings PythonBridge { get; set; } = new();
}

public class PythonBridgeSettings
{
    public string Host { get; set; } = "127.0.0.1";
    public int Port { get; set; } = 5000;
    public int Timeout { get; set; } = 3000;
}