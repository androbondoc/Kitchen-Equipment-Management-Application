   M S B A M L   `   `   `  ����?  ;KEMA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:KEMA.Views
KEMA.Views  5      )clr-namespace:KEMA.ModelsKEMA.Models  5          KEMA.Views.ModifySiteView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:KEMA.Views     5      ,modelsclr-namespace:KEMA.Models     5      $	��227��5	      $	��362��5
      .��5      �   � ColumnDefinitions  5   
   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��0��6   $��1��6$   $��Description:��61    �� TextAlignment$
 Left=�6E   $��5q�6Z   �� 5   
   $��28��6   $��1��6   $��1��6+   $��5,5,10,5q�6o   ��6;   ��  �� Path$ Item.description� �� Mode$ TwoWay=�6o   �� 5    
   $��0��6   $��2��6$   $��Active:��61   $
 Left=�6@   $��5q�6U   �� 5!   
   $��1��6   $��2��6#   $�� ��60   $
��Left=�6]   $��5q�6x   $��Center=�6�    d� 	IsChecked 6;   �� *Item.active+6�   �� 5"   
   $��0��6   $��3��6%   .+�5#      �� $��Registered Equipment(s):��6   $
 Left=�68   $��5q�6M   5$      �� 5&   
   -   5         ��Name$ listBoxItem��5&   1   $��4��6   $��5,5,10,4q�6    �� SelectionMode$ Multiple=�5'   0   $��2��6y   $��4��6�   ��6   �� *Items+��5(      �� 5)      .R�5*      � .+�5+      �� $��SerialNumber: ��6$   �� 5,      $��60��6C   ��6$   �� *serial_number+6C   �� 5-      $�� | Description: ��6$   �� 5.      ��6$   �� *description+5/      50      ��52      �� 53       �� 
TargetType" ��6   .�54      �� 	 �� Property	 �@��
IsSelected
 �� Value
 63   �� *
IsSelected+55      58      �� 59   
   $��(Select 1 or more)��6   $
 Left=�6.   $��10(�6C   $��2,7,85,5q�6Q   $��3��6c   $��1��6p   5;      5<      