   M S B A M L   `   `   `  ����M  IStoreWithDataBases, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:StoreWithDataBasesStoreWithDataBases  5   	   &     StoreWithDataBases.ClientsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:StoreWithDataBases     5   	   -   5          � Title$  Clients��5   	   $	��350��5	   	   $	��650��5
   	   
������� � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��4* �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	dgClients��5      $ �� IsSynchronizedWithCurrentItem$
 TrueY�5         SelectionMode$ Single=�5         AutoGenerateColumns .     
IsReadOnly .  $��2q�5      ��5      �� 	   Columns	 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      -   5        tcId��,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��5&   %      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 5'   %      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5%   %   �� *Id+5(   %     5)      -   5        
tcLastName��$
 Фамилия��5+   %   $ 80 5,   %    5*   %   �� *
LastName+5,   %     5-      -   5        tcFirstName��$
 Имя��5/   %   $ 80 50   %    5.   %   �� *	FirstName+50   %     51      -   5        tcFathersName��$
 Отчество��53   %   $ 90 54   %    52   %   �� *FathersName+54   %     55      -   5        tcPhoneNumber��$
 Телефон��57   %   $ 80 58   %    56   %   �� *PhoneNumber+58   %     59      -   5        tcEMail��$
 E-Mail��5;   %   $	 139 5<   %    5:   %   �� *EMail+5<   %   5>      �� 5@   
   -	   5        $��1��5@      $��Добавить��5A      $	��Top=�5B      $��15(�5C      $��SemiBold"�5D      $��25��5E      $��85��5F      $��10, 10, 10, 0q�5G       � Cursor$
 Hand��5H      5J      �� 5K   
   -
   5        $��1��5K      $��Удалить��5L      $	��Top=�5M      $��15(�5N      $��SemiBold"�5O      $��25��5P      $��85��5Q      $��18, 60, 20, 10q�5R      $
 Hand��5S      5U      �� 5V   
   -   5        $��1��5V      $	��Top=�5W      $��15(�5X      $��SemiBold"�5Y      $��50��5Z      $��85��5[      $��18, 110, 20, 10q�5\      $
 Hand��5]      ��5_      �� 5`      $#��Покупки клиента��6   $
��Wrap=�63   5a      5c      �� 5d   
   -   5        $��1��5d      $	��Top=�5e      $��15(�5f      $��SemiBold"�5g      $��50��5h      $��85��5i      $��18, 180, 20, 10q�5j      $
 Hand��5k      ��5m      �� 5n      $��Все покупки��6   $
��Wrap=�6/   5o      5q      5r      5s      