#r "C:\Program Files\workspacer\workspacer.Shared.dll"
#r "C:\Program Files\workspacer\plugins\workspacer.Bar\workspacer.Bar.dll"
#r "C:\Program Files\workspacer\plugins\workspacer.ActionMenu\workspacer.ActionMenu.dll"
#r "C:\Program Files\workspacer\plugins\workspacer.FocusIndicator\workspacer.FocusIndicator.dll"

using System;
using workspacer;
using workspacer.Bar;
using workspacer.Bar.Widgets;
using workspacer.ActionMenu;
using workspacer.FocusIndicator;

Action<IConfigContext> doConfig = (IConfigContext context) =>
{
    // Uncomment to switch update branch (or to disable updates)
    //context.Branch = Branch.None;
    var fontSize = 9;
    var barHeight = 19;
    var fontName = "Cascadia Code PL";
    var background = new Color(0x0, 0x0, 0x0);

    context.CanMinimizeWindows = false;

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
            new TimeWidget(1000, "HH:mm:ss dd-MMM-yyyy"),
        }
    });
    context.AddFocusIndicator();
    var actionMenu = context.AddActionMenu();

    context.WorkspaceContainer.CreateWorkspaces("1", "2", "3");
};
return doConfig;