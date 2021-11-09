using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudDemo.Client.Components.Shared;
using MudDemo.Client.Models;
using Toolbelt.Blazor.HotKeys;

namespace MudDemo.Client.Shared;

public partial class MainLayout : IDisposable
{
    private readonly Palette _darkPalette = new()
    {
        Black = "#27272f",
        Background = "rgb(21,27,34)",
        BackgroundGrey = "#27272f",
        Surface = "#212B36",
        DrawerBackground = "rgb(21,27,34)",
        DrawerText = "rgba(255,255,255, 0.50)",
        DrawerIcon = "rgba(255,255,255, 0.50)",
        AppbarBackground = "#27272f",
        AppbarText = "rgba(255,255,255, 0.70)",
        TextPrimary = "rgba(255,255,255, 0.70)",
        TextSecondary = "rgba(255,255,255, 0.50)",
        ActionDefault = "#adadb1",
        ActionDisabled = "rgba(255,255,255, 0.26)",
        ActionDisabledBackground = "rgba(255,255,255, 0.12)",
        Divider = "rgba(255,255,255, 0.12)",
        DividerLight = "rgba(255,255,255, 0.06)",
        TableLines = "rgba(255,255,255, 0.12)",
        LinesDefault = "rgba(255,255,255, 0.12)",
        LinesInputs = "rgba(255,255,255, 0.3)",
        TextDisabled = "rgba(255,255,255, 0.2)"
    };

    private readonly Palette _lightPalette = new();

    private readonly MudTheme _theme = new()
    {
        Palette = new Palette
        {
            Primary = Colors.Green.Default
        },
        LayoutProperties = new LayoutProperties
        {
            AppbarHeight = "80px",
            DefaultBorderRadius = "12px"
        },
        Typography = new Typography
        {
            Default = new Default
            {
                FontSize = "0.9rem",
            }
        }
    };

    private readonly UserModel _user = new()
    {
        Avatar = "./sample-data/avatar.png",
        DisplayName = "MudDemo",
        Email = "muddemo@demo.com.au",
        Role = "Admin"
    };

    private bool _canMiniSideMenuDrawer = true;
    private bool _commandPaletteOpen;

    private HotKeysContext? _hotKeysContext;
    private bool _sideMenuDrawerOpen;

    private ThemeManagerModel _themeManager = new()
    {
        IsDarkMode = false,
        PrimaryColor = Colors.Green.Default
    };

    private bool _themingDrawerOpen;
    [Inject] private IDialogService _dialogService { get; set; }
    [Inject] private HotKeys _hotKeys { get; set; }
    [Inject] private ILocalStorageService _localStorage { get; set; }

    public void Dispose()
    {
        _hotKeysContext?.Dispose();
    }

    protected override async Task OnInitializedAsync()
    {
        if (await _localStorage.ContainKeyAsync("themeManager"))
            _themeManager = await _localStorage.GetItemAsync<ThemeManagerModel>("themeManager");

        await ThemeManagerChanged(_themeManager);

        _hotKeysContext = _hotKeys.CreateContext()
            .Add(ModKeys.Meta, Keys.K, OpenCommandPalette, "Open command palette.");
    }

    private void ToggleSideMenuDrawer()
    {
        _sideMenuDrawerOpen = !_sideMenuDrawerOpen;
    }

    private async Task ThemeManagerChanged(ThemeManagerModel themeManager)
    {
        _themeManager = themeManager;

        _theme.Palette = _themeManager.IsDarkMode ? _darkPalette : _lightPalette;
        _theme.Palette.Primary = _themeManager.PrimaryColor;

        await UpdateThemeManagerLocalStorage();
    }

    private async Task OpenCommandPalette()
    {
        if (!_commandPaletteOpen)
        {
            var options = new DialogOptions
            {
                NoHeader = true,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            };

            var commandPalette = _dialogService.Show<CommandPalette>("", options);
            _commandPaletteOpen = true;

            await commandPalette.Result;
            _commandPaletteOpen = false;
        }
    }

    private async Task UpdateThemeManagerLocalStorage()
    {
        await _localStorage.SetItemAsync("themeManager", _themeManager);
    }
}