   M S B A M L   `   `   `  ����F  BMinesweeper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MinesweeperMinesweeper  5   	       Minesweeper.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Minesweeper     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
    � ColumnDefinitions 5   
   .+�5   
   �� -   5         ��Name$ sldr_GridSize��5      $
��Left=�6(   $��
60,164,0,0q�6C   $	��Top=�6W   $	��170��6o    � Maximum$ 50Q�6{    � Minimum$ 0Q�6�    �� TickPlacement$
 Both=�6�    �� TickFrequency$ 1Q�6�    �� IsSnapToTickEnabled . 6�   �� 5   
   $��	Grid Size��6   $
��Left=�6$   $��28��6?   $��
60,131,0,0q�6K   $	��Top=�6_   $	��170��6w   �� 5   
   -   5        	 ��Name$	 txb_GridSize��5      $
��Left=�6*   $��28��6E   $��
60,211,0,0q�6Q   $
��Wrap=�6e   $��9��6y   $	��Top=�6�   $	��170��6�   �� 5   
   -   5        $ 
sldr_Mines��5      $
��Left=�6%   $��278,164,0,0q�6@   $	��Top=�6U   $	��170��6m   $ 80Q�6y   $ 0Q�6�   $
 Both=�6�   $ 1Q�6�    . 6�   �� 5   
   -   5        
 ��Name$
 btn_NewGame��5      $��New Game��6&   $
��Left=�69   $��51��6T   $��501,143,0,0q�6`   $	��Top=�6u   $	��107��6�   6�   �� 5   
   $��Mines��6   $
��Left=�6    $��33��6;   $��278,131,0,0q�6G   $	��Top=�6\   $	��170��6t   �� 5   
   -   5        $	 	txb_Mines��5      $
��Left=�6'   $��28��6B   $��278,211,0,0q�6N   $
��Wrap=�6c   $��1��6w   $	��Top=�6�   $	��170��6�   5      5      