   M S B A M L   `   `   `  ����G  CBDcource2020, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BDcource2020BDcource2020  5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	       BDcource2020.QueryWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:BDcource2020     5   	   Rforms@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	     � WindowStyle$
  None=�5	   
   $��Century Gothic)�5
   	    � 
ResizeMode$ NoResize=�5   	   $��18(�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ QueryWindow��5   	   $	��479��6   $	��918��5   	   ���	#FFCF2222.��5      ]� $
��True��6   .+�5   
   � -   5        $	��Top=�5      $��40��6$   ���	#FFAA109C.+�5      �� -   5        $��btn_exit��5      $��0,0,0,0q�6%   $��36��66      MyButtonStyle#���   6A   ���	#00000000$��Right=�6�   .��5      �� $��exit.png��6   6,   5      �� 5      -   5        $��btn_minimize��5      $��0,0,36,0q�6)   $��36��6;   #���   6F   ���	#00000000$��Right=�6�   .��5      �� $��minimize.png��6   60   5      �� 5      $
��Left=�6   $��10,0,0,0q�63   $��Запросы��6E   $
��Wrap=�6T   $��Center=�6h   
�������6�   �� 5      -   5         ��Name$ 	btn_excel��5      $��Экспорт в Excel��6(   $
��Left=�6B   #���   6d   ���	#FFAA109C
�������$��
680,0,84,0q�6�   5      � 5   
   $	��240��6   $��Right=�6   ���	#FF141948.+�5      �� .��5      �� .+�5      �� -   5        $��
btn_orders��5      $��  Заказы��6/   $
��Left=�6B   $
��Left=�6d   #���   6   $	��223��6�   $��40��6�   ���	#FFAA109C
�������6�   �� 5       -   5        $��
btn_plants��5       $��  Заводы��6/   $
��Left=�6B   $
��Left=�6d   #���   6   $	��222��6�   $��40��6�   ���	#FFAA109C
�������6�   �� 5!      -   5        $��
btn_client��5!      $��  Заказчики��6/   $
��Left=�6E   $
��Left=�6g   #���   6�   $	��221��6�   $��40��6�   ���	#FFAA109C
�������6�   �� 5"      -   5        $��btn_orders_bigger_V��5"      $,��&  Заказы объём больше��68   $
��Left=�6X   $
��Left=�6z   #���   6�   $	��224��6�   $��40��6�   ���	#FFAA109C
�������6   �� 5#      -	   5        $��btn_orders_smaller_V��5#      $,��&  Заказы объём меньше��69   $
��Left=�6Y   $
��Left=�6{   #���   6�   $	��222��6�   $��40��6�   ���	#FFAA109C
�������6  �� 5$      -
   5        $��btn_orders_by_last_months��5$      $,��&  Заказы за пр. месяцы��6>   $
��Left=�6_   $
��Left=�6�   #���   6�   $	��222��6�   $��40��6�   ���	#FFAA109C
�������6  �� 5%      -   5        $��btn_orders_by_last_years��5%      $(��"  Заказы за пр. года��6=   $
��Left=�6\   $
��Left=�6~   #���   6�   $	��219��6�   $��40��6�   ���	#FFAA109C
�������6  �� 5&      -   5        $ ��btn_plants_wiithout_orders��5&      $*��$  Заводы без заказов��6?   $
��Left=�6^   $
��Left=�6�   #���   6�   $	��221��6�   $��40��6�   ���	#FFAA109C
�������6  �� 5'      -   5        $ ��btn_clients_without_orders��5'      $,��&  Клиенты без заказов��6?   $
��Left=�6_   $
��Left=�6�   #���   6�   $	��217��6�   $��40��6�   ���	#FFAA109C
�������6  �� 5(      -   5        $*��$btn_clients_without_orders_left_join��5(      $/��)  Клиенты без заказов v2��6I   $
��Left=�6l   $
��Left=�6�   #���   6�   $	��223��6�   $��40��6�   ���	#FFAA109C
�������6  �� 5)      -   5        $��btn_avg_V_orders��5)      $'��!  ср. объём заказов��65   $
��Left=�6T   $
��Left=�6v   #���   6�   $	��223��6�   $��40��6�   ���	#FFAA109C
�������6�   �� 5*      -   5        $��btn_sum_V_orders��5*      $!��  сумма заказов��65   $
��Left=�6P   $
��Left=�6r   #���   6�   $	��223��6�   $��40��6�   ���	#FFAA109C
�������6�   �� 5+      -   5        $��btn_orders_sum_V_bigger��5+      $,��&  заказы объём больше��6<   $
��Left=�6]   $
��Left=�6   #���   6�   $	��223��6�   $��40��6�   ���	#FFAA109C
�������6  �� 5,      -   5        $��btn_orders_V_fuels_like��5,      $(��"  заказы по топливу��6<   $
��Left=�6[   $
��Left=�6}   #���   6�   $	��223��6�   $��40��6�   ���	#FFAA109C
�������6  �� 5-      -   5        $ ��btn_orders_by_mounth_index��5-      $-��'  кол-во заказов за пр.��6?   $
��Left=�6b   $
��Left=�6�   #���   6�   $	��223��6�   $��40��6�   ���	#FFAA109C
�������6	  �� 5.      -   5        $��btn_avg_orders��5.      $��  ср. заказы��63   $
��Left=�6K   $
��Left=�6m   #���   6�   $	��223��6�   $��40��6�   ���	#FFAA109C
�������6�   �� 5/      -   5        $��btn_avg_orders_bigger��5/      $'��!  ср. заказы больше��6:   $
��Left=�6Y   $
��Left=�6{   #���   6�   $	��223��6�   $��40��6�   ���	#FFAA109C
�������6   �� 50      -   5        $��btn_avg_orders_bigger2��50      $)��#  ср. заказы больше 2��6;   $
��Left=�6\   $
��Left=�6~   #���   6�   $	��223��6�   $��40��6�   ���	#FFAA109C
�������6  �� 51      -   5        $��btn_podzapros_itog��51      $+��%  итоговый подзапрос��67   $
��Left=�6W   $
��Left=�6y   #���   6�   $	��223��6�   $��40��6�   ���	#FFAA109C
�������6�   �� 52      -   5        $��	btn_union��52      $��  объединение��6.   $
��Left=�6G   $
��Left=�6i   #���   6�   $	��223��6�   $��40��6�   ���	#FFAA109C
�������6�   �� 53      -   5        $��btn_in��53      $+��%  покупатели недавно��6+   $
��Left=�6K   $
��Left=�6m   #���   6�   $	��223��6�   $��40��6�   ���	#FFAA109C
�������6�   �� 54      -   5        $��
btn_not_in��54      $'��!  покупатели давно��6/   $
��Left=�6M   $
��Left=�6o   #���   6�   $	��223��6�   $��40��6�   ���	#FFAA109C
�������6�   �� 55      -   5        $��btn_case��55      $-��'  активные покупатели��6-   $
��Left=�6N   $
��Left=�6p   #���   6�   $	��223��6�   $��40��6�   ���	#FFAA109C
�������6�   �� 56      -   5        $��
btn_charts��56      $��  графики��6/   $
��Left=�6D   $
��Left=�6f   #���   6�   $	��223��6�   $��40��6�   ���	#FFAA109C
�������6�   58      59      5:      7  1System.Windows.Forms.Integration.WindowsFormsHost  5;   
      Child. 5<      '  !System.Windows.Forms.DataGridView  -   5        dataGridView1��   ReadOnly$
 True��5<   8   5>      5?      5@      5B      