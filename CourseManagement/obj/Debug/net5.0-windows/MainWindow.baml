   M S B A M L   `   `   `  ����K  GCourseManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CourseManagementCourseManagement  5      ?$clr-namespace:CourseManagement.ViewsCourseManagement.Views  5      !    CourseManagement.MainWindow   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:CourseManagement     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      5view$clr-namespace:CourseManagement.Views     5        � Title$  课程管理系统��5	      $
��1250��5
      $	��800��5       � AllowsTransparency$
 True��5      $��微软雅黑)�5      $��12(�5      $��
ExtraLight"�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5      ��5      Z�  � 	Resources 5         tb_mouse_over �� ImageSource  ButtonStyle1 �� 
TargetType �� Property �� Value	 �� 
TargetType
 ��Name J� SnapsToDevicePixels ��Name��%�  &	        &	 :     �� 5   
   $&  /Assets/images/internet_grey.png��6+   �� 5   
   " ��6%   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 �����6+   �� 5       � ��$ 20(�6)   �� 5       � ��$ 0q�60   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 1q�6(   �� 5        � �� 5!      �� 5"      "	 ��6&   .R�5#      �� $
 border��5$      #��z��5%      #��z��5&      #��z��5'      $
 true��5(      ._�5)      �� $ contentPresenter��5*   !   #��z��5+   !   #��z��5,   !   #��z��5-   !   $|�False��5.   !   $
��True��5/   !   # z 50   !   51      52      54      55      56      .��58      �� -   5        $��5q�59   	   
������� �� CornerRadius$ 10��5;   	    J� Effect 5=   
   3  -System.Windows.Media.Effects.DropShadowEffect  5>         
BlurRadius$ 5Q�5?         	Direction$ 0Q�5@         Opacity$	 0.3Q�5A         ShadowDepth$ 0Q�5B         Color$
 Gray��5C      ._�5E   
   � .+�5F      �� $	��200��5G      $	��Top=�5H      ���#007dfa$ 	10 10 0 0��5J      �� 5L      $��0,5,5,0q�5M      $��Right=�5N      $	��Top=�5O       �� Orientation$ 
Horizontal=�5P      .+�5Q      �� -   5        $	����5S        ControlWindowSizeBtn#��[ 5T      �� 5U      -   5        $	����5W      #��[ 5X      �� 5Y      -   5        $	����5[      #��[ 5\      5]      � 5_      $��50,20q�6    � RowDefinitions 5`      �� 5a      $��65 �6$   �� 5b      $��35 �6$   �� 5c      .+�5e      �� $
��Left=�5f      $��Center=�5g      $ 
Horizontal=�5h      .+�5i      �� $��40��5j      $��40��5k      $��/assets/images/logo.ico��5l      �� 5m      $��15,0,0,0q�6!   .+�5n      �� $��20(�5o      
�������$��教育课程管理平台��5q      �� 5r      $��10(�5s      ���	#88dddddd$��Education Manager Plant��5u      5v      5w      �� 5y      $��Right=�5z      $��Center=�5{      $ 
Horizontal=�5|      .+�5}      �� $��Center=�6   $��Center=�6:   ._�5~      �� $��/assets/icons/#iconfont)�5      $��25(�5�      
�������$	����5�      5�      �� 5�      $��30��5�      $��30��5�      $��10,0,0,0q�5�      $
��Fill=�5�      ��5�      �� *UserInfo.Avatar+ J� Clip 5�      @� 5�       @� Center$ 15 15&�5�   !    @� RadiusX$ 15Q�5�   !    @� RadiusY$ 15Q�5�   !   5�      �� 5�      -   5         ��Name$ 	siderUser��5�      $��10,0,0,0q�5�      #���  5�      ��5�      �� *UserInfo.UserName+ �� FallbackValue$
 NULL��5�      5�      �� 5�      $��1��5�      $
��Left=�5�      $��Center=�5�      $ 
Horizontal=�5�      .+�5�      	� $��HomePageView��5�      $��首页��5�       d� 	IsChecked$
 TrueY�5�        	NavButton#��[ 5�      ��5�      �� *TabSwitchCommand+5�      	� 5�      $��AboutUsPageView��5�      $��关于我们��5�      #��[ 5�      ��5�      �� *TabSwitchCommand+5�      	� 5�      $��CoursePageView��5�      $��课程中心��5�      #��[ 5�      ��5�      �� *TabSwitchCommand+5�      	� 5�      $��诚聘英才��5�      #��[ 5�      ��5�      �� *TabSwitchCommand+��5�      ��  �� RelativeSource ��  �� Mode$
 Self=� �� Path$ Content�5�      	� 5�      $��个人中心��5�      #��[ 5�      ��5�      �� *TabSwitchCommand+��5�      ��  �� $
 Self=�$ Content�5�      5�      �� 5�      $��1��5�      $	��300��5�      $��Right=�5�        SearchBoxStyle#���  5�      ��5�      �� *
SearchText+�� 5�      $��2��6!   ��6.   �� *CurrentContent+5�      (   "CourseManagement.Views.SidebarView  5�      -   5           Name$  	SiderView��5�      $	��350��5�      $��
-800,0,0,0q�5�      $��Right=�5�      $y�Hidden=�5�      ! � DataContext! 5�      �� 5�      5�      5�      5�      