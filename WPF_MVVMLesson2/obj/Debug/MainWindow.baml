   M S B A M L   `   `   `  ����J  FWPF_MVVMLesson2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPF_MVVMLesson2WPF_MVVMLesson2  5   	        WPF_MVVMLesson2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WPF_MVVMLesson2     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5	   	   ��    Locator �� Source# [   �� Path$
 Main�.��5
      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��* �6   .+�5   
   �� ��6   �� *
CtrModules+��5      �� 5      .R�5      �� $��5q�6!   
�������6,   5      ��5      �� 5      .R�5      �� $��5q�6   $��25��6(   ��5      �� *Name+��5      ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" �$ DataContext.OpenCommand���5      �� *Name+5!      5#      �� 5&   
   $��1��6   $��5q�6)   ��64   �� *Page+�� 5(   
   $��2��6   $��5q�6%   .+�5)      �� $��50(�62   
��� �����6   �� *
TestName+6@   �� 5+      $��20(�68   $��0 50 0 0q�6F   
��� �����6   �� *CtrModule.Name+6X   �� 5-      $��10(�6<   $��0 20 0 0q�6J   
��� �����6   �� *CtrModules[0].Name+6\   �� 5.      $��10(�6<   $��0 20 0 0q�6J   
��� �����6   �� *CtrModules[1].Name+6\   �� 5/      $��10(�6<   $��0 20 0 0q�6J   
��� �����6   �� *CtrModules[2].Name+6\   50      51      52      