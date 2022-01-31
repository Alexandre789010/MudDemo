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

    private readonly Palette _lightPalette = new()
    {
            Primary = "#2d4275",
            Black = "#272c34ff",
            Tertiary = "#1ec8a5ff",
            Success = "#00c853ff",
            Secondary = "#728BC9",
            Info = "#2196f3ff"
    };

    private readonly MudTheme _theme = new()
    {
        Palette = new Palette
        {
            Primary = "#2d4275",
        },
        LayoutProperties = new LayoutProperties
        {
            AppbarHeight = "80px",
            DefaultBorderRadius = "6px",
        },
        Typography = new Typography
        {
            Default = new Default
            {
                FontSize = ".875rem",
                FontWeight = 400,
                LineHeight = 1.43,
                LetterSpacing = "normal",
                FontFamily = new string[] { "Public Sans", "Roboto", "Arial", "sans-serif" }
            },
            H1 = new H1
            {
                FontSize = "4rem",
                FontWeight = 700,
                LineHeight = 1.167,
                LetterSpacing = "-.01562em"
            },
            H2 = new H2
            {
                FontSize = "3.75rem",
                FontWeight = 300,
                LineHeight = 1.2,
                LetterSpacing = "-.00833em"
            },
            H3 = new H3
            {
                FontSize = "3rem",
                FontWeight = 600,
                LineHeight = 1.8,
                LetterSpacing = "0"
            },
            H4 = new H4
            {
                FontSize = "1.8rem",
                FontWeight = 700,
                LineHeight = 1.235,
                LetterSpacing = ".007em"
            },
            H5 = new H5
            {
                FontSize = "1.8rem",
                FontWeight = 700,
                LineHeight = 2,
                LetterSpacing = "0"
            },
            H6 =new H6
            {
                FontSize= "1.125rem",
                FontWeight=700,
                LineHeight=2,
                LetterSpacing= ".0075em"  
            },
            Button = new Button
            {
                FontSize= ".875rem",
                FontWeight =500,
                LineHeight=1.75,
                LetterSpacing= ".02857em"
            },
            Subtitle1 = new Subtitle1
            {
                FontSize = "1.1rem",
                FontWeight = 500,
                LineHeight = 1.75,
                LetterSpacing = ".00938em"
            },
            Subtitle2 = new Subtitle2
            {
                FontSize = "1rem",
                FontWeight = 600,
                LineHeight = 1.8,
                LetterSpacing = ".00714em"
            },
            Body1 = new Body1
            {
                FontSize = "1rem",
                FontWeight = 400,
                LineHeight = 1.5,
                LetterSpacing = ".00938em"
            },
            Body2 = new Body2
            {
                FontSize = ".875rem",
                FontWeight = 400,
                LineHeight = 1.43,
                LetterSpacing = ".01071em"
            },
            Caption = new Caption
            {
                FontSize= ".75rem",
                FontWeight=400,
                LineHeight = 1.66,
                LetterSpacing = ".03333em"
            },
            Overline =new Overline
            {
              FontSize= ".75rem",
              FontWeight =400,
              LineHeight = 2.66,
              LetterSpacing= ".08333em"
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

    private bool _canMiniSideMenuDrawer = false;
    private bool _commandPaletteOpen;

    private HotKeysContext? _hotKeysContext;
    private bool _sideMenuDrawerOpen = true;

    private ThemeManagerModel _themeManager = new();
 

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
    protected void SideMenuDrawerOpenChangedHandler(bool state)
    {
        _sideMenuDrawerOpen=state;
    }
    protected void ThemingDrawerOpenChangedHandler(bool state)
    {
        _themingDrawerOpen = state;
    }
    private async Task ThemeManagerChanged(ThemeManagerModel themeManager)
    {
        _themeManager = themeManager;

        _theme.Palette = _themeManager.IsDarkMode ? _darkPalette : _lightPalette;
        _theme.Palette.Primary = _themeManager.PrimaryColor;
        _theme.LayoutProperties.DefaultBorderRadius = _themeManager.BorderRadius + "px";
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