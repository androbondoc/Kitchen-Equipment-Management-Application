   M S B A M L   `   `   `  ����?  ;KEMA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:KEMA.Views.LoginKEMA.Views.Login  5   	        KEMA.Views.Login.LoginView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:KEMA.Views.Login     5   	     � Title$  Login��5   	   $	��250��5	   	   $	��400��5
   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $.��(Kitchen Equipment Management Application��6   $��0��6D   $��0��6Q   $��3��6a   $��15(�6u   $��Center=�6�   $��Center=�6�   �� 5   
   $��1��6   $��	Username:��6    $
��Left=�64   $	��Top=�6O   $��	31,40,0,0q�6g   $��2��6z   �� 5   
   $��1��6   $��1��6   $��	Password:��6-   $
��Left=�6A   $	��Top=�6\   $��	34,47,0,0q�6t   $��2��6�   �� 5   
   -   5         ��Name$ usernameTextBox��5      $��1��6P   $��3��6]   $��	76,9,76,0q�6q   $��38��6�   $��Center=�6�   $��Center=�6�   ��6+   �� *UserID+ �� Mode$ TwoWay=�6�   G� 5   
   -   5         G�Name$ passwordPasswordBox��5      $��2��63   $��3��6@   $��
77,15,76,5q�6T   $��Center=�6i   $��Center=�6�   �� 5   
   -   5         ��Name$ LoginButton��5      $��1��6�   $��3��6�   $��Login��6�   $��67,10,10,10q�6�   $��2��6�   ��6&   �� *Click_LoginCommand+��6M   ��  �� ElementName$ passwordPasswordBox��6�   �� 5   
   -   5        $ SetupButton��5      $��0��6M   $��3��6]   $��Sign Up��6j   $��10,10,83,10q�6|   $��2��6�   	 J� RenderTransformOrigin$	 0.5,0.5&�6�   ��6&   �� *Click_SetupCommand+z�5      V� 5       .~�5!      �� �� 5"      
 �� AngleY$
 -0.365Q�6$   �� 5#      T� 5$       T� Y$ -0.527Q�6)   5%      5'      5(      5)      