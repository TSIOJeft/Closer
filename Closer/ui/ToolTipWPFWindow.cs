using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Closer.ui;

public class ToolTipWPFWindow : Window
{
    private readonly TextBlock m_txtToDisplay = new TextBlock();
    private readonly DispatcherTimer m_timer = new DispatcherTimer();

    public ToolTipWPFWindow(string p_strStringToDisplay, int p_intXOnScreen = 0, int p_intYOnScreen = 0,
        double p_dblDurationInMilliSeconds = 1500)
    {
        if (p_intXOnScreen == 0 && p_intYOnScreen == 0)
        {
            p_intXOnScreen = System.Windows.Forms.Cursor.Position.X;
            p_intYOnScreen = System.Windows.Forms.Cursor.Position.Y;
        }

        Border b = new Border();
        b.Background = Brushes.White;
        b.BorderThickness = new Thickness(1);
        b.BorderBrush = Brushes.Gray;
        
        m_txtToDisplay.Text = p_strStringToDisplay;
        m_txtToDisplay.Foreground = new SolidColorBrush(Colors.Black);
        m_txtToDisplay.Margin = new Thickness(8);
        b.Child = m_txtToDisplay;
        Background = new SolidColorBrush(Colors.Gray);
        ShowInTaskbar = false;
        ResizeMode = System.Windows.ResizeMode.NoResize;
        Topmost = true;

        // Location on screen - As Set
        WindowStartupLocation = WindowStartupLocation.Manual;
        Left = p_intXOnScreen;
        Top = p_intYOnScreen;

        WindowStyle = WindowStyle.None;
        SizeToContent = SizeToContent.WidthAndHeight;

        Content = b;
        m_timer.Interval = TimeSpan.FromMilliseconds(p_dblDurationInMilliSeconds);
        m_timer.Tick += timer_Tick;
        m_timer.Start();
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        if (m_timer != null)
        {
            m_timer.Stop();
            m_timer.Tick -= timer_Tick;
        }

        Close();
    }
}