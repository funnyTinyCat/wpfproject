   M S B A M L   `   `   `  ����M  IWpfDataGridToSql02, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:WpfDataGridToSql02.ComponentsWpfDataGridToSql02.Components  5      +    %WpfDataGridToSql02.Components.Details   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:WpfDataGridToSql02.Components     5      .��5	      � .+�5
   
   ��   �� Padding$  20q�5         BorderPrimary#��[  5      $��1q�5       J� SnapsToDevicePixels$
 True��5       �� CornerRadius$ 5��5      ._�5      � .+�5      � ��5      �� 5       �� 
TargetType" �6    .�5      ��  �� Property � y� �� Value$ 	Collapsed=�6;    �� Triggers 5      �� 5   "    �� Binding 6.   �� *HasSelectedSome+ �� Value	 False6R   .a�5   &   ��  � y�$ Visible=�6C   5   #   5      .+�5      �� $��0��5      $��12(�5      $:��4Please select a YouTube viewer to see their details.��5      $��WrapWithOverflow=�5       5"      � 5$      	 � IsSharedSizeScope$
	 True��6   ��5&      �� 5'      " �6    .�5(      ��  � y�$ 	Collapsed=�6;    5)      �� 5*   "    6.   �� *HasSelectedSome+ True6R   .a�5+   &   ��  � y�$ Visible=�6C   5,   #   5.      
 � RowDefinitions
 51      �� 52      $
��auto �6$   �� 53      $
��auto �6$   �� 54      $
��auto �6$   .+�57      �� $��0��58      $��24(�59      ��5:      �� *
Username+� 5<      $��1��6   $��0 20 0 0q�6$    � ColumnDefinitions 5=      �� 5>      $
��auto �6+    z� SharedSizeGroup$ Label��68   �� 5?      $
��auto �6+   .+�5B      �� $��0��5C      $��Is Subscribed?��5D      $
��Bold"�5E      �� 5G      $��1��5H      $��20 0 0 0q�5J      ��5I      �� *IsSubscribedDisplay+5J      5L      � 5N      $��2��6   $��0 20 0 0q�6$    5O      �� 5P      $
��auto �6+   $ Label��68   �� 5Q      $
��auto �6+   .+�5T      �� $��0��5U      $��
Is Member?��5V      $
��Bold"�5W      �� 5Y      $��1��5Z      $��20 0 0 0q�5\      ��5[      �� *IsMemberDisplay+5\      5^      5`      5a      5b      5c      5d      