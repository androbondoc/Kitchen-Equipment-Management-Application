   M S B A M L   `   `   `  ����?  ;KEMA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:KEMA.Views
KEMA.Views  5   	       KEMA.Views.MainView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:KEMA.Views     5   	   -   5          � Title$.  (Kitchen Equipment Management Application��5   	   $	��400��5	   	   $	��600��5
   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��14(�6!   $��0,5,10,0q�6/   $��Right=�6\   ��6A   �� *	Greetings+6\   �� 5   
   $��0��6   $	��500��6   $
��Left=�6*   ._�5      �� -   5        $��MainMenuItemsControl��5      ��68   �� *
MainMenu+��5      �� 5      .R�5      � 5      ��5      �� 5      .R�5      �� $	��100��6!   $��28��6-   $��0q�5       � Cursor$
 Hand��61   ��5      �� ��61   ��  �� ElementName$ MainMenuItemsControl�� �� Path$# DataContext.SwitchMenuCommand���6�   �� 5      5!      5"      � 5#   
   $��1��6    � ColumnDefinitions 5$      �� 5%      $
��Auto �6#   �� 5&      $	��49* �6#   �� 5'      $
��351* �6#   .+�5)      �� $��0��6   ���	#FFFFFFB9$��	0,10,98,0q�6<   $��2��6O   ._�5*      �  5+      �� 5,      $
��Auto �6(   �� 5-      $
��Auto �6(   �� 5.      .+�50      �� -   5        $��MenuItemsControl��50   #   ��6<   �� *CurrentMenu+��51      �� 52      .R�53   "   �� $	��100��6)   $��28��65   ��54   %   �� ��69   �� $ MenuItemsControl��$# DataContext.SwitchViewCommand���6�   �� 55      57      58      59      �� 5:      $��10,10,10,10q�6   $��1��62   $��2��6g   ��6B   �� *CurrentViewModel+6g   5;      5<      5=      