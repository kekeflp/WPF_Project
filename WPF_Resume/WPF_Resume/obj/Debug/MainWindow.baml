   M S B A M L   `   `   `  ����E  AWPF_Resume, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WPF_Resume
WPF_Resume  5      3clr-namespace:WPF_Resume.ViewsWPF_Resume.Views  5      =#clr-namespace:WPF_Resume.ViewModelsWPF_Resume.ViewModels  5	          WPF_Resume.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:WPF_Resume     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      0viewsclr-namespace:WPF_Resume.Views     5      2vm#clr-namespace:WPF_Resume.ViewModels     5	        � Title$  
MainWindow��5
      $
��1000��5      $	��736��5       � WindowStartupLocation$ CenterScreen=�5       � WindowState$ 	Maximized=�5      .��5      ��  �� Padding$ 3q�6   ._�5   
   �  � RowDefinitions 5      �� 5      $��80 �6    �� 5      $��* �6    �� 5      $	��250 �6    �� 5      $��20 �6    .+�5      �� $��0��6   ���#5392dc._�5      �� $
��Left=�5      $��Center=�5       �� Orientation$ 
Horizontal=�5      .+�5      �� $��30��5      $��	20,0,20,0q�5         	LogoImage#��[  5       �� 5!      $
��Left=�5"      $��Center=�5#      $��30(�5$      
�������$��简历浏览系统��5&      5'      5(      �� 5)      -   5         ��Name$ 
ResumeList��5*      $��1��5+      $��10,20q�5,      $
��Left=�5-      $��0q�5.        ListBoxItemStyle#���  5/      $��Disabled=�51      ��50      �� *ItemVM+��52      �� 53      .R�54      �  � Orientation$ Vertical=�6$   55      57      � 58      $��2��6    � ColumnDefinitions 59      �� 5:      $��2* �6'   �� 5;      $��3* �6'   .+�5>      �� $��0��5?      $��	0,0,10,10q�5@      ���#9fb2b8$��1q�5B      ._�5C      �  5D      �� 5E      $��30 �6,   �� 5F      .+�5H      �� ���#79b86d._�5I      �� $��0��5J   !   $��20,0,0,0q�5K   !   $
��Left=�5L   !   $��Center=�5M   !   $��16(�5N   !   $
��Bold"�5O   !   
�������$��基本信息��5Q   !   5R      � 5S      $��1��6    5T      �� 5U   "   �� 5V   "   �� 5W   "   �� 5X   "   �� 5Y   "   �� 5Z   "   �� 5[   "   �� 5\   "   �� 5]   "    5_      �� 5`   "   $��10 �63   �� 5a   "   �� 5b   "   $��50 �63   �� 5c   "   �� 5d   "   $��10 �63   .+�5f      �� $��1��5g   !   $��1��5h   !   $ 
Horizontal=�5i   !   .+�5j   "   ��   MyTb#��[ 6,   $��	姓名：��6J   �� 5k   "   $��Center=�6,   �� 5l   "   $��Center=�6,   ��6G   �� 	 �� ElementName$	 
ResumeList��
 �� Path$
 SelectedItem.Person.Name�5m      �� 5n      $��3��5o   !   $��1��5p   !   $ 
Horizontal=�5q   !   .+�5r   "   �� #��[ 6,   $��	性别：��6J   �� 5s   "   $��Center=�6,   ��6G   �� $	 
ResumeList��$ 
 SelectedItem.Person.Gender�  	GenderCvr �� 	Converter# [ 5t      �� 5u      $��5��5v   !   $��1��5w   !   $ 
Horizontal=�5x   !   .+�5y   "   �� #��[ 6,   $��出生年月：��6J   �� 5z   "   $��Center=�6,   ��6G   �� $	 
ResumeList��$"
 SelectedItem.Person.Birthday� �� StringFormat$ {0:d}��5{      �� 5|      $��7��5}   !   $��1��5~   !   $ 
Horizontal=�5   !   .+�5�   "   �� #��[ 6,   $��	学历：��6J   �� 5�   "   $��Center=�6,   ��6G   �� $	 
ResumeList��$-
 'SelectedItem.Person.EducationExperience�5�      �� 5�      $��1��5�   !   $��3��5�   !   $ 
Horizontal=�5�   !   .+�5�   "   �� #��[ 6,   $��	专业：��6J   �� 5�   "   $��Center=�6,   ��6G   �� $	 
ResumeList��$(
 "SelectedItem.Person.WorkExperience�5�      �� 5�      $��3��5�   !   $��3��5�   !   $ 
Horizontal=�5�   !   .+�5�   "   �� #��[ 6,   $��毕业学校：��6J   �� 5�   "   $��Center=�6,   ��6G   �� $	 
ResumeList��$ 
 SelectedItem.Person.School�5�      �� 5�      $��5��5�   !   $��3��5�   !   $ 
Horizontal=�5�   !   .+�5�   "   �� #��[ 6,   $��	住址：��6J   �� 5�   "   $��Center=�6,   ��6G   �� $	 
ResumeList��$!
 SelectedItem.Person.Address�5�      �� 5�      $��7��5�   !   $��3��5�   !   $ 
Horizontal=�5�   !   .+�5�   "   �� #��[ 6,   $��	电话：��6J   �� 5�   "   $��Center=�6,   ��6G   �� $	 
ResumeList��$%
 SelectedItem.Person.PhoneNumber�5�      5�      5�      5�      �� 5�      $��1��5�      $��	0,0,10,10q�5�      ���#9fb2b8$��1q�5�      ._�5�      �  5�      �� 5�      $��30 �6,   �� 5�      .+�5�      �� ���#79b86d._�5�      �� $��0��5�   !   $��20,0,0,0q�5�   !   $
��Left=�5�   !   $��Center=�5�   !   $��16(�5�   !   $
��Bold"�5�   !   
�������$��个人经历��5�   !   5�      &   System.Windows.Controls.DataGrid  5�      $��1��5�         AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     GridLinesVisibility$
 None=�5�      ��5�      �� $	 
ResumeList��$
 SelectedItem.Experiences�   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�   "   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 5�   %      Header$ 开始时间��5�   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�   %   �� *	StartDate+$ {0:d}��5�   %     5�   "   $	 150 5�   %   $ 结束时间��5�   %    5�   %   �� *	EndDate+$ {0:d}��5�   %     5�   "   $	 150 5�   %   $ 地点��5�   %    5�   %   �� *
Location+ �� FallbackValue$
 NULL��5�   %   5�      5�      5�      5�      �� 5�      $��3��6   ���#cccccc._�5�      �� $��Center=�5�      $��Center=�5�      ���#939393$��版权所有��5�      5�      5�      5�      5�      