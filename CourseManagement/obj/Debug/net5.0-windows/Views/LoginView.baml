   M S B A M L   `   `   `  ����K  GCourseManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:CourseManagement.CommonCourseManagement.Common  5      ?$clr-namespace:CourseManagement.ViewsCourseManagement.Views  5      I)clr-namespace:CourseManagement.ViewModelsCourseManagement.ViewModels  5	      &     CourseManagement.Views.LoginView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      5com%clr-namespace:CourseManagement.Common     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:CourseManagement.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      8vm)clr-namespace:CourseManagement.ViewModels     5	      -   5          �Name$
  this��5
       � Title$ 	LoginView��5      $	��360��5      $	��600��5       � AllowsTransparency$
 True��5      
������  � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5       � DataContext 5      0   *CourseManagement.ViewModels.LoginViewModel  5   
   .��5      �� $��5q�5   	   
������� �� CornerRadius$ 10��5   	    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5      	   
BlurRadius$	 5Q�5      
   	Direction$
 0Q�5         Opacity$	 0.3Q�5         ShadowDepth$ 0Q�5          Color$
 gray��5!      ._�5#   
   �  � RowDefinitions 5$      �� 5%      $
��1.8* �6    �� 5&      $��3* �6    �� 5'      $��60 �6    .+�5*      �� ���#007dfa$ 	10 10 0 0��6*   ._�5+      �� $��0,5,5,0q�5,      $��Right=�5-      $	��Top=�5.      ._�5/      �� $	����52         ControlWindowSizeBtn#��[  53      ��50      �� *CloseWindowsCommand+��51      ��  �� ElementName$
 this��53      54      55      �� 56      $��0,0,0,30q�6   $��Bottom=�6+   .+�57      �� $	��100��58      $	��100��59      $��0,0,0,10q�5:      $��Center=�5;      �� 5<      $��Center=�5=      $��18(�5>      
�������$��XXXXX管理平台��5@      5A      � 5C      $��1��5D      $
��30,0q�5E       +� FocusedElement 5F      �� $ userName�� 5H      �� 5I      �� 5J      �� 5K      �� 5L      �� 5M      .+�5O      �� -   5         ��Name$ userName��5P      $��0��5Q      $��Center=�5R      $��40(�5S      ��5T      �� *Login.UserName+.��65   .��5U   /    J� InputBindings 5V      �� 5W      
 �� Key$ Enter��5X       �� Command 5Y      �� *LoginCommand+ �� CommandParameter 5Z      �� $
 this��.��5[   -   5\      G� 5]      $��1��5^      $��Center=�5_      /   )CourseManagement.Common.PasswordBoxHelper   Attach$
 True��5`      $��40(�5b         Password 5a      �� *Login.Password+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� 5d      �� 5e      $ Enter��5f       5g      �� *LoginCommand+ 5h      �� $
 this��5j      �� 5k      $��2��5l      $��Center=�5m      ��5n      �� *Login.ValidationCode+.��6;   .��5o   /    5p      �� 5q      $ Enter��5r       5s      �� *LoginCommand+ 5t      �� $
 this��.��5u   -   5v      �� 5x      $��3��5y      
��� ���$��登录��5}      ��5{      �� *LoginCommand+��5|      �� $
 this��5}      �� 5      $��4��5�      $��20(�5�      $
��Bold"�5�      
���  ����5�      �� *ErrorMessage+5�      5�      5�      5�      