   M S B A M L   `   `   `  ����J  FCommercialForum, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CommercialForum.PagesCommercialForum.Pages  5      '    !CommercialForum.Pages.ProductPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:CommercialForum.Pages     5        N� Title$  ProductPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $	��100 �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $	��100 �6   .+�5   
   �� $��1��6   .+�5      �� $'��!Страница продукта��6      
TitleBlock#��[  61   5      �� 5   
   $��1��6   $��1��6"   .+�5      ��  �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6   .+�5      �� 
������ $	��100��66   $	��100��6B   .��5       �� -   5         ��Name$ Product_Image��5        $&�� /Materials/Images/image_fail.png��67   5!      �� 5#      $ Vertical=�6!   .+�5$      �� $ 
Horizontal=�6%   .+�5%      �� $��Name: ��6(   �� 5&      -   5         ��Name$ Product_NameBlock��5&   (   $��Unknown_name��6C   5'      �� 5)      $ 
Horizontal=�6%   .+�5*      �� $��Cost: ��6(   �� 5+      -   5        $ Product_CostBlock��5+   (   $��Unknown_cost��6C   5,      �� 5.      $ 
Horizontal=�6%   .+�5/      �� $��Is available: ��6(   �� 50      -   5         ��Name$ AvailableCheckBox��50   '    d� 	IsChecked$
 TrueY�6B   {�.   d� IsThreeState .  $��20��6z   	 � 	Resources	 51   "   
 �� 
TargetType �� Property �� Value��%^   '��       �� 52   &   "
 ��6,   .�53   *   ��  �@��CornerRadius$ 2��6I   54   '   55   #   56      57      �� 59      $ 
Horizontal=�6%   .+�5:      �� $��Trader: ��6(   �� 5;      -   5        $ Product_TraderBlock��5;   (   $��Unknown_name��6E   5<      5=      5>      �� 5@      $ 
Horizontal=�6   $
��Auto��66   .+�5A      �� $��Description:��6    �� 5B      -   5        $ Product_DescBox��5B       $	��100��69   $	��400��6I   $
��Wrap=�6U   $��Unknown description��6i   5C      5D      5E      �� 5G   
   $��2��6   $��1��6"   $ 
Horizontal=�62   .+�5H      �� -   5         ��Name$ OrderBut��5H      .��5I      �� $��В корзину��6   5J      �� 5L      -   5        $ 
DeOrderBut��5L      ���	#FFD28C8C$y�Visible=�6Y   .��5M      �� $&�� Убрать из корзины��6   5N      5O      5P      5Q      