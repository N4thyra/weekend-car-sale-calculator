   M S B A M L   `   `   `  ����  weekend_sale_calc"    weekend_sale_calc.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Car Price Calculator��5   	    � 
ResizeMode$ NoResize=�6&   $	��553��6<   $	��525��6I   .��5      � -   5         �Name$ Window��5      $��0,0,0,-1q�6   $	��500��6-   .+�5	   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5	   /      AutoGenerateColumns .  $��Center=�6A   $	��250��6^   $
��-3,0q�6k   $	��top=�6y   $	��525��6�      Columns 5
      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$   Název modelu��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6=   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *Model+  5      $ Datum prodeje��6%   $	 150 6<    6H   �� *Date+	 �� StringFormat$	 {0:dd.MM.yyyy}��  5      $
 Cena��6%   $	 120 63    6?   �� *Price+$	 {0:N0},-��  5      $	 DPH��6%   $ * 62    6<   �� *Tax+5      �� 5   
   -   5        $��Load XML & Calculate!��5      $��Center=�65   $	��Top=�6R   $	��198��6j   $��16(�6�   $��33��6�   $��160,264,161,0q�6�     5   
   -   5        $ 
resultGrid��5   /    .  $��Center=�6C   $	��150��6`   $��	0,340,0,0q�6m   $��Center=�6�   $	��276��6�   $��Center=�6�   $��Center=�6�    5        5      $$   Název modelu
  Cena bez DPH��6%   $	 132 6Q   
   HeaderStringFormat$
  ��6�    6]   �� *ModelAndPrice+$	 {0:N0}��6�     5      $ 
Cena s DPH��6%   $ * 69    6C   �� *PriceWithTax+$	 {0:N0}��5      �� 5   
   $��R E S U L T S
��6   $��Center=�6-   $��185,311,184,0q�6J   $	��Top=�6a   $��16(�6y   $	��150��6�   $��30��6�   $��Center=�6�   $��
ExtraBlack"�6�   $��	Condensed&�6�   5      5      