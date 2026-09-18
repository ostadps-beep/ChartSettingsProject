using System;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Windows.Input;

public class ChartSettingsViewModel : INotifyPropertyChanged
{
    private ChartSettingsModel _model;

    public ChartSettingsViewModel()
    {
        _model = new ChartSettingsModel();
        ApplyCommand = new RelayCommand(_ => Apply());
        OkCommand = new RelayCommand(_ => Ok());
        CancelCommand = new RelayCommand(_ => Cancel());
        ResetCommand = new RelayCommand(_ => Reset());
    }

    public ChartSettingsModel Model => _model;

    public ICommand ApplyCommand { get; }
    public ICommand OkCommand { get; }
    public ICommand CancelCommand { get; }
    public ICommand ResetCommand { get; }

    public int BodyThickness
    {
        get => _model.Candles.BodyThickness;
        set { _model.Candles.BodyThickness = Math.Clamp(value, 1, 10); OnPropertyChanged(nameof(BodyThickness)); }
    }

    public bool ShowWicks
    {
        get => _model.Candles.ShowWicks;
        set { _model.Candles.ShowWicks = value; OnPropertyChanged(nameof(ShowWicks)); }
    }

    public string BackgroundColor
    {
        get => _model.Grid.BackgroundColor;
        set { _model.Grid.BackgroundColor = value; OnPropertyChanged(nameof(BackgroundColor)); }
    }

    private void Apply() => Save();
    private void Ok() => Save();
    private void Cancel() { }

    private void Reset()
    {
        _model = new ChartSettingsModel();
        OnPropertyChanged(nameof(Model));
    }

    private void Save()
    {
        File.WriteAllText("ChartSettings.json", JsonSerializer.Serialize(_model, new JsonSerializerOptions { WriteIndented = true }));
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

public class RelayCommand : ICommand
{
    private readonly Action<object> _execute;
    public RelayCommand(Action<object> execute) => _execute = execute;
    public bool CanExecute(object parameter) => true;
    public void Execute(object parameter) => _execute(parameter);
    public event EventHandler CanExecuteChanged;
}
