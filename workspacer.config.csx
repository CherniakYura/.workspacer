#r "C:\Program Files\workspacer\workspacer.Shared.dll"
#r "C:\Program Files\workspacer\plugins\workspacer.Bar\workspacer.Bar.dll"
#r "C:\Program Files\workspacer\plugins\workspacer.ActionMenu\workspacer.ActionMenu.dll"
#r "C:\Program Files\workspacer\plugins\workspacer.FocusIndicator\workspacer.FocusIndicator.dll"
#r "C:\Program Files\workspacer\plugins\workspacer.TitleBar\workspacer.TitleBar.dll"

using System;
using workspacer;
using workspacer.Bar;
using workspacer.Bar.Widgets;
using workspacer.ActionMenu;
using workspacer.FocusIndicator;
using workspacer.TitleBar;

Action<IConfigContext> doConfig = (IConfigContext context) =>
{
    // Uncomment to switch update branch (or to disable updates)
    //context.Branch = Branch.None;
    var fontSize = 9;
    var barHeight = 19;
    var fontName = "Cascadia Code PL";
    var background = new Color(0x0, 0x0, 0x0);

    context.CanMinimizeWindows = true;

    var titleBarPluginConfig = new TitleBarPluginConfig(new TitleBarStyle(showTitleBar: false, showSizingBorder: false));
    context.AddTitleBar(titleBarPluginConfig);

    context.AddBar(new BarPluginConfig()
    {
        FontSize = fontSize,
        BarHeight = barHeight,
        FontName = fontName,
        DefaultWidgetBackground = background,
        LeftWidgets = () => new IBarWidget[]
        {
            new WorkspaceWidget()
        },
        RightWidgets = () => new IBarWidget[]
        {
            new TimeWidget(5000, "HH:mm:ss dd-MMM-yyyy"),
        }
    });
    context.AddFocusIndicator(new FocusIndicatorPluginConfig(){
        BorderSize = 2,
    });
    var actionMenu = context.AddActionMenu();
    context.WindowRouter.AddFilter((window) => !window.Title.Contains("Media viewer"));
    context.WindowRouter.AddRoute((window) => window.Title.Contains("Microsoft Teams") ? context.WorkspaceContainer["3"] : null);

    KeyModifiers mod = KeyModifiers.Alt;
    context.Keybinds.Unsubscribe(mod, Keys.Left);
    context.Keybinds.Unsubscribe(mod, Keys.Right);

    context.WorkspaceContainer.CreateWorkspaces("1", "2", "3", "4");
};
return doConfig;
