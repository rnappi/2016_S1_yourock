   M S B A M L   `   `   `  ����B  >Yourock, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Yourock.PagesYourock.Pages  5          Yourock.Pages.Login   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Yourock.Pages     5        N� Title$  Login��5	      $	��900��6   $	��570��6!    � 	Resources 5
         TextBox.Static.Border �� Color  TextBox.MouseOver.Border  TextBox.Focus.Border  LoginTextBox �� 
TargetType �� Property �� Value-  'System.Windows.Input.KeyboardNavigation �� 
TargetType ��Name J� SnapsToDevicePixels	 �� CornerRadius
 �� Padding ��Name �� Triggers P� Property P� Value �� 
TargetName �� Triggers ]� 
Conditions �� Property �� Value  
login_fail �� TargetProperty �� 
TargetName<  6System.Windows.Media.Animation.EasingThicknessKeyFrame p� KeyTime p� Value  LoginPasswordBox  btn_login_fail9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value��%_  &	        &	 #     &	 F     &	 i     7   7  7  &	 �    &	 �    7   7  7  &	     �� 5   
   $ 	#FFABAdB3��68   �� 5   
   $ 	#FF7EB4EA��6;   �� 5   
   $ 	#FF569DE5��67   �� 5   
   " ��6%   .�5      ��  � ��# � ��6+   �� 5       � ��8   6,   �� 5       � ��# � ��6+   �� 5       � ��$ 1q�60   �� 5       �@ TabNavigation$
 None=�6A   �� 5       � ��$
 Left=�6;   �� 5       �@�FocusVisualStyle 61   Z� �� 5       �@J�	AllowDrop . 6*   �� 5       �@��PanningMode$ VerticalFirst=�69   �� 5       �@��IsFlicksEnabled .  67   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   #��z��61   #��z��6]   #��z��6�    . $	 5��6�   $

 10,0q�6�   ._�5      �� $ PART_ContentHost��6+   |�.  $��Hidden=�6W   $��Hidden=�6~   $��Center=�6�   $��0q�6�   $��Center=�6�   $
��10,0q�6�   5       5      P� 5        � {� .  . �5!   "   �� $ border��6<    �@J�Opacity$
 0.56Q�6P   5"      P� 5#       �@J�IsMouseOver . . �5$   "   �� $ border��6@   8   � ��6T   5%      P� 5&       �@J�IsKeyboardFocused . . �5'   "   �� $ border��6@   8   � ��6T   5(      5*      5,       5-      ]� 5.       5/      �� 50      + �@��#IsInactiveSelectionHighlightEnabled . 6S   �� 51       �@��IsSelectionActive .  6A   ./�53      ��  �@��SelectionBrush# � /�67   54      56      �� 57   
   .��58      r� $ (FrameworkElement.Margin)�6/   $ frmLogin��6e   .	�59        $ 0��6*   $ 305,230,305,201q�66     5:      $ 0:0:0.1��6*   $ 325,230,305,201q�6<     5;      $ 0:0:0.2��6*   $ 285,230,305,201q�6<     5<      $ 0:0:0.3��6*   $ 310,230,305,201q�6<     5=      $ 0:0:0.4��6*   $ 300,230,305,201q�6<     5>      $ 0:0:0.5��6*   $ 305,230,305,201q�6<   5?      5@      �� 5A   
   " G�6)   .�5B      ��  �@G�PasswordChar$	 ●��6-   �� 5C       � ��# � ��6+   �� 5D       � ��8   6,   �� 5E       � ��# � ��6+   �� 5F       � ��$ 1q�60   �� 5G       �@ TabNavigation$
 None=�6A   �� 5H       � ��$
 Left=�6;   �� 5I       �@�FocusVisualStyle 61   Z� �� 5J       �@J�	AllowDrop . 6*   �� 5K       �@��PanningMode$ VerticalFirst=�69   �� 5L       �@��IsFlicksEnabled .  67   �� 5M       � �� 5N      �� 5O      " G�6&   .R�5P      �� $ border��6!   #��z��61   #��z��6]   #��z��6�    . $

 10,0q�6�   $��Center=�6�   $��35��6   $	 5��6  ._�5Q      �� $ PART_ContentHost��6+   |�.  $��Hidden=�6W   $��Hidden=�6~   $��Center=�6�   5R       5S      P� 5T       � {� .  . �5U   "   �� $ border��6<    �@J�Opacity$
 0.56Q�6P   5V      P� 5W       �@J�IsMouseOver . . �5X   "   �� $ border��6@   8   � ��6T   5Y      P� 5Z       �@J�IsKeyboardFocused . . �5[   "   �� $ border��6@   8   � ��6T   5\      5^      5`       5a      ]� 5b       5c      �� 5d      + �@G�#IsInactiveSelectionHighlightEnabled . 6S   �� 5e       �@G�IsSelectionActive .  6A   ./�5g      ��  �@G�SelectionBrush# � /�67   5h      5j      �� 5k   
   .��5l      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ btnLogin��6�   .\�5m        $ 0��6'   $ 0Q�63     5n      $ 0:0:0.3��6'   $ 66Q�69   5o      5p      5q       � Triggers 5r      :� 5s   
    :� RoutedEvent$ FrameworkElement.Loaded��6   5t       N� 
Background 5v      �� 5w   
    �� ImageSource$, &/Yourock;component/images/bg_login.jpg��6    j� Stretch$ UniformToFill=�6J   .��5y      � .+�5z   
   �� -   5         ��Name$ frmLogin��5z      $��305,230,305,204q�6#   $	��290��6<   .+�5{      �� -   5          ��Name$  txtLogin��5{      $��35��6(   $��0q�64   ! �� MaxLines$! 1��6H   "" �� VerticalScrollBarVisibility$" Disabled=�6U   #���  6|   ���	#FF575757$��
Myriad Pro)�6�   
�������
# �� Top$# 26��6�   $	��290��6  $ � UseLayoutRounding$ .  $��Italic$�62  ��6�   Z� 62  G� 5|      -   5        % G�Name$% txtPassword��5|      $# 94��6/   $	��290��6?   #���  6K   $��35��6v   ���	#FF575757$��0q�6�   $��Center=�6�   
�������$��
Myriad Pro)�6�   $��Italic$�6  ��6�   Z� 6  �� 5}      -   5        & ��Name$& label��5}      $��Login��6#   $	��290��63   $# 0��6?   
�������$��Center=�6a   $��Center=�6~   $��
Myriad Pro)�6�   $��13.333(�6�   �� 5~      -   5        $& 
label_Copy��5~      $��Password��6(   $	��290��6;   $# 68��6G   
�������$��Center=�6j   $��Center=�6�   $��
Myriad Pro)�6�   $��13.333(�6�   5      �� 5�   
   -   5        ' ��Name$' btnLogin��5�      $��LOG IN��6#   $��35��64   $��400,0,400,159q�6@   $��Bottom=�6W   $��0q�6r   $	��100��6�     
btnDefault#���  6�   ���	#FFD0B03A
�������$��Myriad Pro Light)�6�   $��16(�6�   ( J� RenderTransformOrigin$( 0.5,0.5&�6$  z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      �� 5�   
   -   5        ) ��Name$) image��5�      $��305,63,305,0q�6   $.��(/Yourock;component/images/login_logo.png��65   $
��None=�6g   $	��135��6v   $	��Top=�6�   �� 5�   
   -   5        $ pnlErrorMessage��5�      $��53��6*   $��305,0,305,141q�66   $��Bottom=�6M   ���	#FFCF1D1D$y�Hidden=�6   .+�5�      �� -	   5        * ��Name$* 	textBlock��5�      $
��Wrap=�6+   $��Login ou senha inválida.��6?   $
# 17.4��6_   
�������$��Myriad Pro Light)�6�   $��14.667(�6�   $	��290��6�   $��Center=�6�   + �� TextAlignment$+ Center=�6�   5�      5�      5�      