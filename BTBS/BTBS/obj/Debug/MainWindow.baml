   M S B A M L   `   `   `  ����?  ;BTBS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BTBSBTBS  5   	       BTBS.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:BTBS     5   	     � Title$  
MainWindow��5   	   $	��500��6   $	��850��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��3* �6   .+�5   
   �� $
��Auto=�6   .��5      ��  �� Orientation$ Vertical=�6   $��10q�60   
�������.+�5      �� .��6   	File Path6#   �� 5      -   5        $��FilePathBox��5   ,    �� 
IsReadOnly . �� 5      -   5        $��BrowseFilesButton��5      $��Browse Folders��62   6K   �� 5      $��20��6   6*   �� 5      .��6   Com Ports Settings6,   �� 5      .��6   Select port:6&   �� 5      -   5        $��	PortsList��5      6.   �� 5      .��6   
Baud rate:6$   �� 5      -   5        $��BaudRateBox��5      $
��9600��6-   �� 5      .��6   Parity bit:6%   �� 5      -   5        $��	ParityBox��5      .@�5      �� $
��None��6#   �� 5       $	��Odd��6#   �� 5!      $
��Even��6#   �� 5"      $
��Mark��6#   �� 5#      $��Space��6#   5$      �� 5'      .��6   #!Data bits (shouldn't be changed):6;   �� 5(      -   5        $��DataBitsBox��5(      {�.  .��6?   86B   �� 5)      -   5        $��ChangeDataBits��5)       d� 	IsChecked$ FalseY�61   $��Change data bits��6�   �� 5+      .��6   Number of stop bits:6.   �� 5,      -   5        $��
StopBitBox��5,      .@�5.      �� $��1��6#   �� 5/      $��2��6#   �� 50      $	��1.5��6#   51      �� 53      $��20��6   6*   �� 55      -	   5        $��
SendButton��55      .��6D   Send6J   56      57      �� 59   
   $��1��6   $
��Auto=�6'   $
��Auto=�6J   .��5:      �� -
   5        $��ImageStackPanel��5:      $ Vertical=�61   $��10q�6H    �� CanVerticallyScroll .  �� CanHorizontallyScroll . 5<      5=      5?      5@      