   M S B A M L   `   `   `  ����?  ;KEMA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:KEMA.Views
KEMA.Views  5      )clr-namespace:KEMA.ModelsKEMA.Models  5      $    KEMA.Views.ModifyEquipmentView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:KEMA.Views     5      ,modelsclr-namespace:KEMA.Models     5      $
��Auto��5	      $	��400��5
      .��5      �   � ColumnDefinitions  5   
   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��0* �6   .+�5   
   �� $��0��6   $��1��6$   $��Serial Number:��61    �� TextAlignment$
 Left=�6G   $��5,5,5,5q�6\   �� 5   
   $��1��6   $��1��6   $��5,5,5,10q�6e   ��6/   ��  �� Path$ Item.serial_number� �� Mode$ TwoWay=�6e   �� 5   
   $��0��6   $��2��6$   $��Description:��61   $
 Left=�6E   $��5,5,5,5q�6Z   �� 5   
   $��2��6   $��1��6   $��5,5,5,10q�6c   ��6/   �� $ Item.description�$ TwoWay=�6c   �� 5    
   $��0��6   $��3��6$   $��
Condition:��61   $
 Left=�6C   $��5,5,5,5q�6X   �� 5!   
   $��1��6   $��3��6$   $��5,5,5,25q�5"   =    �� 
IsEditable$
 True��6O    �� Text 5!   1   �� $ Item.condition�$ TwoWay=���5"      �� $ CategoryList�6O   5%      5&      