   M S B A M L   `   `   `  ����L  HSimpleContactBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:SimpleContactBook.ViewsSimpleContactBook.Views  5      0    *SimpleContactBook.Views.ContactDetailsView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:SimpleContactBook.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5      � y�6   �� *SelectedContact+   SelectedContactConverter  �� 	Converter#  [   � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      �� 5      $	��100 �6#   .+�5      �� $��0��5      $��5q�5      $
��Left=�5      .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Center=�6!   .+�5!      �� $��5q�5"      $��Center=�5#      $��Center=�5$      ��5%      �� *SelectedContact.Name+ �� FallbackValue$
 NULL�� �� Mode$ TwoWay=�y�5&      �� *
IsEditMode+  IsEditConverter#  [ �� 5(      $��Center=�5)      $��24(�5+      ��5*      �� *SelectedContact.Name+$
 NULL��y�5,      �� *IsDisplayMode+#  [ 5-      �� 5.      ��6   �� *UpdateCommand+ d� 	IsChecked 6A   �� *SelectedContact.IsFavorite+5/      � 50      $	��125��6   $	��125��6#   .+�51      �� $	��125��52      $	��125��53      ��54      �� *SelectedContact.ImagePath+  DefaultContactImage# [  �� TargetNullValue# [ �� 56      $��Right=�57      $��Bottom=�58      $��Browse��5:      $��DemiBold"�5;      
���   ���59      �� *BrowseImageCommand+y�5=      �� *
IsEditMode+#  [ 5>      5?      �� 5A      $��1��5B      $��Bottom=�5C      $ 
Horizontal=�5D      .+�5E      �� $��90��5F      $��40��5G      $��5q�5H      ��5I      �� *SaveCommand+y�5J      �� *
IsEditMode+#  [ ��5K      �� 5L      $ 
Horizontal=�6%   .+�5M      �� $��/Resources/saveIcon.png��6$   �� 5N      $
��Save��6$   $
��Bold"�63   5O      5Q      5R      5S      �� 5V   
   $��1��6   $��5q�6"   .+�5W      �� .+�5X      �� ._�5Y      �� $��Phone��5Z      $
��Bold"�5[      ���	#FFF5F7F95\      5]      �� 5_      .+�5a      �� $
��Home��6   �� 5b      ��6   �� *!SelectedContact.PhoneNumbers[0]+$	 N/A��y�6c   �� *IsDisplayMode+#  [ �� 5c      ��6   �� *!SelectedContact.PhoneNumbers[0]+$	 N/A��$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�y�6�   �� *
IsEditMode+#  [ �� 5g      $
��Cell��6   �� 5h      ��6   �� *!SelectedContact.PhoneNumbers[1]+$	 N/A��y�6c   �� *IsDisplayMode+#  [ �� 5i      ��6   �� *!SelectedContact.PhoneNumbers[1]+$	 N/A��$ TwoWay=�$ PropertyChanged=�y�6�   �� *
IsEditMode+#  [ 5j      5k      5l      �� 5o   
   $��2��6   $��5q�6"   .+�5p      �� .+�5q      �� ._�5r      �� $��Emails��5s      $
��Bold"�5t      ���	#FFF5F7F95u      5v      �� 5x      .+�5z      �� $��Personal��6   �� 5{      ��6   �� *SelectedContact.Emails[0]+$	 N/A��y�6]   �� *IsDisplayMode+#  [ �� 5|      ��6   �� *SelectedContact.Emails[0]+$	 N/A��$ TwoWay=�$ PropertyChanged=�y�6�   �� *
IsEditMode+#  [ �� 5      $
��Work��6   �� 5�      ��6   �� *SelectedContact.Emails[1]+$	 N/A��y�6]   �� *IsDisplayMode+#  [ �� 5�      ��6   �� *SelectedContact.Emails[1]+$	 N/A��$ TwoWay=�$ PropertyChanged=�y�6�   �� *
IsEditMode+#  [ 5�      5�      5�      �� 5�   
   $��3��6   $��5q�6"   .+�5�      �� .+�5�      �� ._�5�      �� $��	Locations��5�      $
��Bold"�5�      ���	#FFF5F7F95�      5�      �� 5�      .+�5�      �� $
��Home��6   �� 5�      ��6   �� *SelectedContact.Locations[0]+$	 N/A��y�6`   �� *IsDisplayMode+#  [ �� 5�      ��6   �� *SelectedContact.Locations[0]+$	 N/A��$ TwoWay=�$ PropertyChanged=�y�6�   �� *
IsEditMode+#  [ �� 5�      $
��Work��6   �� 5�      ��6   �� *SelectedContact.Locations[1]+$	 N/A��y�6`   �� *IsDisplayMode+#  [ �� 5�      ��6   �� *SelectedContact.Locations[1]+$	 N/A��$ TwoWay=�$ PropertyChanged=�y�6�   �� *
IsEditMode+#  [ 5�      5�      5�      5�      5�      