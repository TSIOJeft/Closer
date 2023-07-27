using System.Windows.Controls;
using System.Windows.Media;

namespace Closer.ui;

public partial class NoticeCardUserControl : UserControl
{
    public NoticeCardUserControl()
    {
        InitializeComponent();
        DataContext = this;
    }

    public string icon { get; set; }
    public string title { get; set; }
    public string summary { get; set; }
    private Brush _backColor;

    public Brush backColor
    {
        get { return _backColor; }
        set { _backColor = (Brush)new BrushConverter().ConvertFromString(value + ""); }
    }

    private Brush _textColor = (Brush)new BrushConverter().ConvertFromString("#212121");

    public Brush textColor
    {
        get { return _textColor; }
        set { _textColor = (Brush)new BrushConverter().ConvertFromString(value + ""); }
    }
}