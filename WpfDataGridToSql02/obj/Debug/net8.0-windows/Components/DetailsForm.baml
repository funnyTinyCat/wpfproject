   M S B A M L   `   `   `  ����M  IWpfDataGridToSql02, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:WpfDataGridToSql02.ComponentsWpfDataGridToSql02.Components  5      P LLoadingSpinnerControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControlLoadingSpinnerControl 5      /    )WpfDataGridToSql02.Components.DetailsForm   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:WpfDataGridToSql02.Components     5      dloadingspinnercontrolBclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControl     5        � 	Resources  5
          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �  � IsSharedSizeScope$
 True��6    5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      � $��0��6    � ColumnDefinitions 5       �� 5!      $
��auto �6'    z� SharedSizeGroup$ Label��64   �� 5"      $��* �6'   $	��250��61   .+�5%      �� $��0��5&      $��Username��5'      $
��Bold"�5(      �� 5*      $��1��5+      $��20 0 0 0q�5-      ��5,      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�5-      5/      � 51      $��1��6   $��0 20 0 0q�6     52      �� 53      $
��auto �6'   $ Label��64   �� 54      $
��auto �6'   .+�57      �� $��0��58      $��Is Subscribed?��59      $
��Bold"�5:      �� 5<      $��1��5=      $��Center=�5?      $��20 0 0 0q�5@       d� 	IsChecked 5>      �� *IsSubscribed+5@      5B      � 5D      $��2��6   $��0 20 0 0q�6     5E      �� 5F      $
��auto �6'   $ Label��64   �� 5G      $
��auto �6'   .+�5J      �� $��0��5K      $��
Is Member?��5L      $
��Bold"�5M      �� 5O      $��1��5P      $��Center=�5R      $��20 0 0 0q�5S       5Q      �� *
IsMember+5S      5U      5W      � 5Y   
   $��1��5Z      $��0 30 0 0q�6   .+�5\      �� $��Submit��5^      $��0 0 5 0q�5`      ��5]      �� *SubmitCommand+{�5_      �� *	CanSubmit+5`      �� 5b      $��0 0 5 0q�5c      $��Cancel��5e        ButtonSecondary#��[ 5f      ��5d      �� *CancelCommand+5f      *  $LoadingSpinnerControl.LoadingSpinner  5g         Diameter$ 25Q�5i         	Thickness$ 2Q�5j      	   	IsLoading	 5h      �� *IsSubmitting+5j      5k      �� 5m   
   $��2��6   $��0 15 0 0q�5n        ErrorMessage#��[ 5o      ��5p      �� *ErrorMessage+y�5q      �� *HasErrorMessage+
 �� 	Converter#
 [  5r      5s      