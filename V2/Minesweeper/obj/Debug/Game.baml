   M S B A M L   `   `   `  ����F  BMinesweeper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MinesweeperMinesweeper  5   	       Minesweeper.Game   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Minesweeper     5   	     � Title$
  Game��5   	   $	��450��6   $	��800��6#    � WindowState$ 	Maximized=�5	   	   .��5
      � -   5        $��mainGrid��5
       � ShowGridLines .   � ColumnDefinitions 5   
   �� 5      $��20 �6   6,    � RowDefinitions 5   
   �� 5      $��20 �6   6*   �� 5      $
��auto �6   6,   .+�5   
   �� -   5         ��Name$ btn_Menu��5      $��10q�6#   $��10,10,-89,10q�60   $��1��6F   
���   �.��6~   Menu6�   �� 5   
   -   5        $ btn_NewGame��5      $��10q�6&   $��115,10,-194,10q�63   $��1��6L   $
��Left=�6Y   $	��100��6t   
���   �.��6�   	NewGame6�   �� 5   
   -   5        $ btn_flag��5      $��10q�6#   $��220,10,-299,10q�60   $��1��6I   $
��Left=�6V   $	��100��6q   
���   �
�������.��6�   Flag6�   �� 5   
   -   5         ��Name$ lbl_Mine_Guesses��5      $��325,10,-463,10q�6*   $��1��6B   6Q   5      5      