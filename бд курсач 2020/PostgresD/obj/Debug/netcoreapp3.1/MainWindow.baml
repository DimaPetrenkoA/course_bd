   M S B A M L   `   `   `  ����G  CBDcource2020, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BDcource2020BDcource2020  5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	       BDcource2020.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:BDcource2020     5   	   Rforms@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	     � WindowStyle$
  None=�5	   
   $��Century Gothic)�5
   	    � 
ResizeMode$ NoResize=�5   	   $��18(�5   	    � SizeToContent$ WidthAndHeight=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 
MainWindow��5   	   ���	#FFCF2222.��5      ]� $
��True��6   ���	#FFE8E8E8$	��519��6<   $	��918��6I   .+�5   
   � -   5        $	��Top=�5      $��40��6$   ���	#FFAA109C.+�5      �� -   5        $��btn_exit��5      $��0,0,0,0q�6%   $��36��66      MyButtonStyle#���   6A   ���	#00000000$��Right=�6�   .��5      �� $��exit.png��6   6,   5      �� 5      -   5        $��btn_minimize��5      $��0,0,36,0q�6)   $��36��6;   #���   6F   ���	#00000000$��Right=�6�   .��5      �� $��minimize.png��6   60   5      �� 5       �� Orientation$ 
Horizontal=�6   $
��Left=�62   $	��833��6M   .+�5      �� -   5        $��btn_left��5      $��25��6)   #���   64   ��5      �� 5        �� ImageSource$ 	left2.png��6%    j� Stretch$ Uniform=�6=   5"      �� 5#      -   5        $��status_text��5#      $��16(�6/   $
��Left=�6=   $��100/1��6X   $
��Wrap=�6e   $��Center=�6y   
�������6�   �� 5$      -   5        $��	btn_right��5$      $��25��6*   #���   65   ��5%      �� 5&      $ 	right.png��6%   $ Uniform=�6=   5(      �� 5)      -   5        $��btn_minimize_Copy��5)      $��search2.png��61   $��10 0 0 0q�6F   $��23��6Y   $
��Left=�6d   �� 5*      -   5        $��	tb_search��5*   8   $��
Поиск��6   $��8 0 0 0q�6'    �� TextWrapping$ NoWrap=�6I   $��Center=�6_   $	��140��6z   ���	#FFAA109C$��0q�6�   ���	#FFAAAAAA6�   5+      5,      � 5-   
   $��40��6   $��Bottom=�6   ���	#FFAA109C.+�5.      �� -	   5        $
��rect��5.      $��4��6$   $��40��6.   ���	#FF6181EE	 K� ZIndex$	 1��6K   $
��Left=�6\   $	��Top=�6w   �� 5/      -
   5        $��
btn_plants��5/      $��  Заводы��6'   $
��Left=�6:   $
��Left=�6\   #���   6w   $��Center=�6�   $��95��6�   $��40��6�   ���	#FFAA109C
�������$��2,0,0,0q�6  �� 50      -   5        $��
btn_orders��50      $��  Заказы��6'   $
��Left=�6:   $
��Left=�6\   #���   6w   $��Center=�6�   $��93��6�   $��40��6�   ���	#FFAA109C
�������$��	233,0,0,0q�6  �� 51      -   5        $��	btn_firms��51      $��  Заказчики��6&   $
��Left=�6<   $
��Left=�6^   #���   6y   $��Center=�6�   $	��118��6�   $��40��6�   $��	326,0,0,0q�6�   ���	#FFAA109C
�������6  �� 52      -   5        $��btn_country��52      $��  Страны��6(   $
��Left=�6;   $
��Left=�6]   #���   6x   $��Center=�6�   $��95��6�   $��40��6�   $��	637,0,0,0q�6�   ���	#FFAA109C
�������6  �� 53      -   5        $��btn_fuel��53      $��  Вид топлива��6%   $
��Left=�6=   $
��Left=�6_   #���   6z   $��Center=�6�   $	��136��6�   $��40��6�   $��97,0,0,0q�6�   ���	#FFAA109C
�������6  �� 54      -   5        $��btn_type��54      $)��#  Тип собственности��6%   $
��Left=�6C   $
��Left=�6e   #���   6�   $��Center=�6�   $	��193��6�   $��40��6�   $��	444,0,0,0q�6�   ���	#FFAA109C
�������6  �� 55      -   5        $��btn_back��55      $
��Left=�6&   $
��Left=�6H   #���   6c   $	��Top=�6�   $	��142��6�   $��40��6�   $��	776,0,0,0q�6�   ���	#FFAA109C
�������.��56      �� $ 
Horizontal=�6   .+�57      �� $��4 0 0 0q�6   $��	query.png��6-   $��34��6@   $��Uniform=�6K   �� 58      $��5 0 0 0q�6    $��Center=�61   Запросы6U   59      5:      5;      7  1System.Windows.Forms.Integration.WindowsFormsHost  5<   
   
   Child.
 5=      '  !System.Windows.Forms.DataGridView  -   5        dataGridView1��   EditMode$ EditOnKeystroke=�5=   �   5?      5@      5A      5C      