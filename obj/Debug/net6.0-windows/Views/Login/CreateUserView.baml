   M S B A M L   `   `   `  ����?  ;KEMA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:KEMA.Views.LoginKEMA.Views.Login  5   	   %    KEMA.Views.Login.CreateUserView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:KEMA.Views.Login     5   	     � Title$  New User��5   	   $	��400��5	   	   $	��350��5
   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $	��59* �6   �� 5      $
��116* �6   .+�5   
   �� $��0��6   $��First Name:��6    $
��Left=�66   $��Center=�6Q   $��26��6l   $��70��6x   �� 5   
   $��1��6   $��0��6   $��
Last Name:��6-   $
��Left=�6B   $��Center=�6]   $��26��6x   $��68��6�   �� 5   
   $��2��6   $��0��6   $��
User Type:��6-   $
��Left=�6B   $��Center=�6]   $��26��6x   $��64��6�   �� 5   
   $��3��6   $��0��6   $��Email Address:��6-   $
��Left=�6F   $��Center=�6a   $��26��6|   $��87��6�   �� 5   
   $��4��6   $��0��6   $��	Username:��6-   $
��Left=�6A   $��Center=�6\   $��26��6w   $��66��6�   �� 5    
   $��5��6   $��0��6   $��	Password:��6-   $
��Left=�6A   $��Center=�6\   $��26��6w   $��62��6�   �� 5!   
   $��6��6   $��Confirm password:��6   $
��Left=�69   $��Center=�6T   $��26��6o   $	��110��6{   �� 5#   
   $��0��6   $��1��6   $��10,10,10,10q�6X   ��6/   �� *	FirstName+ �� Mode$ TwoWay=�6X   �� 5$   
   $��1��6   $��1��6   $��10,10,10,10q�6W   ��6/   �� *
LastName+$ TwoWay=�6W   �� 5%   
   $��2��6   $��1��6    $��10,10,10,10q�6�    �� 
IsEditable$
 True��6�    �� Text 60   ��  �� Path$ UserType�$ TwoWay=���6\   �� $ CategoryList�6�   �� 5&   
   $��3��6   $��1��6   $��10,10,10,10q�6[   ��6/   �� *EmailAddress+$ TwoWay=�6[   �� 5'   
   -   5        $��userIDTextBox��5'   /   $��4��6   $��1��6   $��10,10,10,10q�6j   ��6D   �� *UserID+$ TwoWay=�6j   �� 5(   
   -   5        $��PasswordTextBox��5(   /   $��5��6   $��1��6   $��10,10,10,10q�6m   ��6F   �� *
Password+$ TwoWay=�6m   �� 5)   
   -   5        $��ConfirmTextBox��5)   /   $��6��6   $��1��6   $��10,10,10,10q�6l   ��6E   �� *	Confirm+$ TwoWay=�6l   �� 5*   
   $��7��6   $��1��6   $��Add new user��6X   $��10,10,10,10q�6o   ��6.   �� *Click_AddUserCommand+6o   5+      5,      