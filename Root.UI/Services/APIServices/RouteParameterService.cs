namespace Root.UI.Services.APIServices;

public class RouteParameterService
{
    public event Action? OnChange;

    private string? _parametro;
    public string? Parametro
    {
        get => _parametro;
        set
        {
            if (_parametro != value)
            {
                _parametro = value;
                OnChange?.Invoke();
            }
        }
    }
}