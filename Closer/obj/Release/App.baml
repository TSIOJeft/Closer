   M S B A M L   `   `   `  ���� G  C咫尺妙享, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CloserCloser      
Closer.App   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     &localclr-namespace:Closer     A =Wpf.Ui, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml    �� ShutdownMode$  OnLastWindowClose=� �� 	Resources  �� MergedDictionaries$  Wpf.Ui.Markup.ThemesDictionary   Theme&   Wpf.Ui.Markup.ControlsDictionary   SegoeFluentIcons  commonButton �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 �� Triggers
 P� Property P� Value  menuItemLabel �� ScaleX N� EnterActions �� TargetProperty W� From g� Duration  ListBox  transparentButton  
menuButton  NavigationItemSelectBack	 W� To W� EasingFunction/  )System.Windows.Media.Animation.CircleEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode N� ExitActions ! NavigationItemSelectIndicator  ListItemMouseOverBack 	 TransparentTextBox 
 TextBoxStyle ��Name �� RelativeSource �� Path �� Mode  GreyButtonBack  ListViewItemContainer :� RoutedEvent��    $ Light=�  %�  &	        &	 9     &	 �    '�� x    &	 �    &	 �    &	 �    &	 V    &	 ]    &	 e    &		 �    &	
 �    7 	 &	 �	    &	 m
    *�3/pack://application:,,,/font/#Segoe Fluent Icons)��� " ��.���  � ��
 ���� ��  � �� �#616161��  � ��$ 42����  � ��$ 14(���  � ��$
 Bold"���  �@�FocusVisualStyle Z� ��  �@�Tag$ collapse����  � �� �� " ��.R��� #��z��$ 5��._��� $��Stretch=�$��Center=�$��0 0 0 0q�	 P� 
 �@J�IsMouseOver . . ���  � �� �#388E3C��  � ��
 �������  �@�Tag$ Visible���� " ��.���  � z� �� $ 1Q�	 P� 
 � y�$ Visible=� �� .���� .��W� $ RenderTransform.ScaleX�$ 0X�$ 0:00:01D��� " ��.���  �@��BitmapScalingMode$ HighQuality=��� " ��	 P� 
 �@J�IsMouseOver . . ���  � ��
 ���� �� " ��.���  � ��
 ���� ��  � ��$ 0q���  � �� �� " ��.R��� $��Stretch=�$��Center=�$��0 0 0 0q��� " ��.���  � ��
 ���� ��  � �� �#000000��  � ��$ 42����  � ��$ 14(���  � ��$	 162����  �@�FocusVisualStyle Z� ��  �@�Tag$ collapse����  � �� �� " ��.R��� #��z��$ 5��._��� $��Stretch=�$��Center=�$��0 0 0 0q�	 P� 
 �@J�IsMouseOver . . ���  � �� �#F5F5F5��  �@�Tag$ Visible��P� 
 �@��
IsSelected . . ���  �@�Tag$ Visible���� " ��.���  � ��$ 0����  � �� �#EEEEEE	 P� 
 �@��
IsSelected .  �� .���� .��W� $ Width�$	 162X�$ 0:0:0.8D�   $ EaseOut=� �� .���� .��W� $ Width�$ 0X�$ 0:0:0.8D�   $ EaseOut=��� " ��.���  � ��$ 0����  � �� �#388E3C	 P� 
 �@��
IsSelected .  �� .���� .��W� $ Height�$ 20X�$ 0:0:0.5D�   $ EaseOut=� �� .���� .��W� $ Height�$ 0X�$ 0:0:0.5D�   $ EaseOut=��� " ��	 P� 
 �@J�IsMouseOver .  . ���  � �� �#FAFAFAP� 
 �@J�IsMouseOver . . ���  � �� �#EEEEEE�� " ���� " ��.���  � ��$ 0q���  � �� �� " ��.R��� #��z��$��1q�#��z��$ 5��._��� $ input��$��8 0 8 0q�$��Center=�8��  $��20(�$��0q�
������ ����  �� *TemplatedParent+$
 Text�$ TwoWay=�	 P� 
 �@J�IsMouseOver . . ���  � �� �#F5F5F5��  � �� �#BDBDBDP� 
 �@J�IsMouseOver .  . ���  � �� �#FAFAFA��  � �� �#F5F5F5�� " ��.���  � ��
 ���� ��  � �� �� " ��.R��� #��z��$ 5��._��� $��Stretch=�$��Center=�$��0q�	 P� 
 �@J�IsMouseOver . . ���  � �� �	#77E0E0E0�� " ��.���  � z� �� scaleTransform����  � z� T� translateTransform����  �@J�RenderTransformOrigin$ .5,.5&���  � ��
 ���� ��  � �� �� " ��.R��� 	 :� $ Loaded��[��� .���� .��W� $ Opacity�$ 0X�$ 1X�$ 0:0:0.5D�   $ 	EaseInOut=�W� $, &RenderTransform.(TranslateTransform.Y)�$ 50X�$ 0X�$ 0:0:0.5D�   $ EaseOut=�:� $! PreviewMouseRightButtonDown��.[��� .���� .��W� $- 'RenderTransform.(ScaleTransform.ScaleX)�$
 0.97X�$ 0:0:0.5D�   $ EaseOut=�W� $- 'RenderTransform.(ScaleTransform.ScaleY)�$
 0.97X�$ 0:0:0.5D�   $ EaseOut=�:� $ PreviewMouseRightButtonUp��.[��� .���� .��W� $- 'RenderTransform.(ScaleTransform.ScaleX)�$ 1X�$ 0:0:0.5D�   $ EaseOut=�W� $- 'RenderTransform.(ScaleTransform.ScaleY)�$ 1X�$ 0:0:0.5D�   $ EaseOut=�:� $ 
MouseLeave��.[��� .���� .��W� $- 'RenderTransform.(ScaleTransform.ScaleX)�$ 1X�$ 0:0:0.5D�   $ EaseOut=�W� $- 'RenderTransform.(ScaleTransform.ScaleY)�$ 1X�$ 0:0:0.5D�   $ EaseOut=�