   M S B A M L   `   `   `  ����?  ;KEMA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:KEMA.Views
KEMA.Views  5   	   1clr-namespace:KEMA.ViewModelsKEMA.ViewModels  5   	   !    KEMA.Views.ModifyItemWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:KEMA.Views     5   	   4
viewModelsclr-namespace:KEMA.ViewModels     5   	   -   5        $��EIWindow��5	   	   $	��300��5   	   $	��800��6     � SizeToContent$  WidthAndHeight=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title 5
   	   �� *	TitleText+.��5      � $
��Auto��6   $
��Auto��6    � RowDefinitions 5   
   �� 5      �� 5      $
��Auto �6   .+�5   
   �� -   5        $��ConCon1��5      $��0��6(   ��65   ��  � 	Resources 5       �� DataType.  (KEMA.ViewModels.ModifyEquipmentViewModel$   KEMA.Views.ModifyEquipmentView � DataContext)  #KEMA.ViewModels.ModifySiteViewModel   KEMA.Views.ModifySiteView��%�   (��       5      *, +)(�� @     5      *, +)�� 5      "  6   .R�5         60   �� 5      �� 5      "  6   .R�5         6+   �� 5      5      5      � 5   
   $��1��6   $
��Auto��6   $
��Auto��6)    � ColumnDefinitions 5       �� 5!      �� 5"      $
��Auto �6#   �� 5#      �� 5$      $
��Auto �6#   �� 5%      .+�5'      �� $��28��6   $	��120��6!   $��1��6-   $��10q�6^   $
��Bold"�6j   ��6=   �� *OkButtonText+��6|   �� *SaveCommand+��6�   ��  �� ElementName$ EIWindow���� 5(      $��28��6   $	��120��6!   $��3��6-   $��Cancel��6=   $��10q�6N   $
��Bold"�6Z   ��6l   �� *CloseCommand+��6�   �� $ EIWindow��5)      5*      5+      