﻿namespace ScottPlot.Plottables;

public class Crosshair : IPlottable, IRenderLast
{
    public HorizontalLine HorizontalLine { get; } = new();
    public VerticalLine VerticalLine { get; } = new();

    public Coordinates Position { get => new(X, Y); set { X = value.X; Y = value.Y; } }
    public double X { get => VerticalLine.X; set => VerticalLine.X = value; }
    public double Y { get => HorizontalLine.Y; set => HorizontalLine.Y = value; }

    // These properties set styling for both axis lines at once
    public float FontSize { set { HorizontalLine.LabelFontSize = value; VerticalLine.LabelFontSize = value; } }
    public bool FontBold { set { HorizontalLine.LabelBold = value; VerticalLine.LabelBold = value; } }
    public string FontName { set { HorizontalLine.LabelFontName = value; VerticalLine.LabelFontName = value; } }
    public Color TextColor { set { HorizontalLine.LabelFontColor = value; VerticalLine.LabelFontColor = value; } }
    public Color TextBackgroundColor { set { HorizontalLine.LabelBackgroundColor = value; VerticalLine.LabelBackgroundColor = value; } }
    public Color LineColor { set { HorizontalLine.LineColor = value; VerticalLine.LineColor = value; } }
    public float LineWidth { set { HorizontalLine.LineWidth = value; VerticalLine.LineWidth = value; } }
    public LinePattern LinePattern { set { HorizontalLine.LinePattern = value; VerticalLine.LinePattern = value; } }

    [Obsolete("Assign values to LineColor, LineWidth, or LinePattern properties to set style for both lines. " +
        "HorizontalLine and VerticalLine have properties that can be set individually as well.", true)]
    public LineStyle LineStyle { get; set; } = new();

    [Obsolete("Use TextColor and TextBackgroundColor instead", true)]
    public Color FontColor;

    public bool IsVisible { get; set; } = true;
    public IAxes Axes { get; set; } = new Axes();
    public IEnumerable<LegendItem> LegendItems => HorizontalLine.LegendItems.Concat(VerticalLine.LegendItems);
    public AxisLimits GetAxisLimits() => new(X, X, Y, Y);

    public virtual void Render(RenderPack rp)
    {
        if (!IsVisible)
            return;

        HorizontalLine.Axes = Axes;
        HorizontalLine.Render(rp);

        VerticalLine.Axes = Axes;
        VerticalLine.Render(rp);
    }

    public void RenderLast(RenderPack rp)
    {
        if (!IsVisible)
            return;

        HorizontalLine.Axes = Axes;
        HorizontalLine.RenderLast(rp);

        VerticalLine.Axes = Axes;
        VerticalLine.RenderLast(rp);
    }
}
