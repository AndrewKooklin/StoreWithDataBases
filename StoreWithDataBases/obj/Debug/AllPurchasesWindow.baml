   M S B A M L   `   `   `  ����M  IStoreWithDataBases, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:StoreWithDataBasesStoreWithDataBases  5   	   +    %StoreWithDataBases.AllPurchasesWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:StoreWithDataBases     5   	   -   5          � Title$  AllPurchasesWindow��5   	   $	��250��5	   	   $	��530��5
   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgAllPurchasesClients��5      $ �� IsSynchronizedWithCurrentItem$
 TrueY�5         SelectionMode$ Single=�5         AutoGenerateColumns .     
IsReadOnly .  $��2q�5      ��5      �� 	   Columns	 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      -   5        tcId��,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��5%   %      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 5&   %      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5$   %   �� *Id+5'   %     5(      -   5        tcEMail��$
 E-Mail��5*   %   $	 110 5+   %    5)   %   �� *EMail+5+   %     5,      -   5        tcProductCode��$
 Код продукта��5.   %   $ 85 5/   %    5-   %   �� *ProductCode+5/   %     50      -   5        tcProductName��$+
 %Наименование товара��52   %   $	 142 53   %    51   %   �� *ProductName+53   %   56      �� 58   
   -   5        $��1��58      $��Добавить��59      $	��Top=�5:      $��15(�5;      $��SemiBold"�5<      $��25��5=      $��85��5>      $��10, 10, 10, 0q�5?       � Cursor$
 Hand��5A      5B      �� 5C   
   -   5        $��1��5C      $��Удалить��5D      $	��Top=�5E      $��15(�5F      $��SemiBold"�5G      $��25��5H      $��85��5I      $��18, 60, 20, 10q�5J      $
 Hand��5L      5M      5N      5O      