﻿#pragma checksum "..\..\..\page\DeviceEditPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4DA9DCAF7F01D4E877C46362DC2D01BBC801E1A6CDF6B0DA4C60BB57973EC4C7"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Closer.page;
using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Wpf.Ui;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.AutoSuggestBoxControl;
using Wpf.Ui.Controls.BreadcrumbControl;
using Wpf.Ui.Controls.ContentDialogControl;
using Wpf.Ui.Controls.IconElements;
using Wpf.Ui.Controls.IconSources;
using Wpf.Ui.Controls.MessageBoxControl;
using Wpf.Ui.Controls.Navigation;
using Wpf.Ui.Controls.NumberBoxControl;
using Wpf.Ui.Controls.SnackbarControl;
using Wpf.Ui.Controls.ThumbRateControl;
using Wpf.Ui.Controls.TitleBarControl;
using Wpf.Ui.Controls.TreeGridControl;
using Wpf.Ui.Controls.VirtualizingControls;
using Wpf.Ui.Controls.Window;
using Wpf.Ui.Converters;
using Wpf.Ui.Markup;


namespace Closer.page {
    
    
    /// <summary>
    /// DeviceEditPage
    /// </summary>
    public partial class DeviceEditPage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 62 "..\..\..\page\DeviceEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DeviceName;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\page\DeviceEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DeviceType;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\page\DeviceEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider DeviceTypeSlider;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\page\DeviceEditPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DeviceToken;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/咫尺妙享;component/page/deviceeditpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\page\DeviceEditPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 13 "..\..\..\page\DeviceEditPage.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 25 "..\..\..\page\DeviceEditPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.min_window);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 29 "..\..\..\page\DeviceEditPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.max_window);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 34 "..\..\..\page\DeviceEditPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.close_window);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 46 "..\..\..\page\DeviceEditPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.save_task_bu);
            
            #line default
            #line hidden
            
            #line 46 "..\..\..\page\DeviceEditPage.xaml"
            ((System.Windows.Controls.Button)(target)).PreviewMouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.import_right_click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DeviceName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.DeviceType = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.DeviceTypeSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 68 "..\..\..\page\DeviceEditPage.xaml"
            this.DeviceTypeSlider.AddHandler(System.Windows.Controls.Primitives.Thumb.DragCompletedEvent, new System.Windows.Controls.Primitives.DragCompletedEventHandler(this.DeviceTypeSliderDragCompleted));
            
            #line default
            #line hidden
            return;
            case 9:
            this.DeviceToken = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

