   M S B A M L   `   `   `  ����J  FCommercialForum, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:CommercialForum.Pages.ProductPages"CommercialForum.Pages.ProductPages  5      8    2CommercialForum.Pages.ProductPages.ProductEditPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:CommercialForum.Pages.ProductPages     5        N� Title$  ProductEditPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $	��100 �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $	��100 �6   .+�5   
   �� $��1��6   .+�5      �� $3��-Редактирование продукта��6      
TitleBlock#��[  67   5      �� 5   
   $��1��6   $��1��6"   .+�5      ��  �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6   .+�5      �� -   5         ��Name$ ProductImageBut��5      
������ $	��100��6O   $	��100��6[   .��5       �� -   5         ��Name$ Product_Image��5        $&�� /Materials/Images/image_fail.png��67   5!      �� 5#      $ Vertical=�6!   .+�5$      �� $ 
Horizontal=�6%   .+�5%      �� $��Name: ��6(   �� 5&      -   5         ��Name$ Product_NameBox��5&   &   5'      �� 5)      $ 
Horizontal=�6%   .+�5*      �� $��Cost: ��6(   �� 5+      -   5        $ Product_CostBox��5+   &   5,      �� 5.      $ 
Horizontal=�6%   .+�5/      �� $��Is available: ��6(   �� 50      -   5         ��Name$ AvailableCheckBox��50   '    d� 	IsChecked$
 TrueY�6B   	 d� IsThreeState	 .  $��20��6h   
 � 	Resources
 51   "    �� 
TargetType �� Property �� Value��%^   '��       �� 52   &   " ��6,   .�53   *   ��  �@��CornerRadius$ 2��6I   54   '   55   #   56      57      �� 59      $ 
Horizontal=�6%   .+�5:      �� $��Categories:��6(   �� 5;      -   5        $ CategoryChooseBut��5;   %   $��50��6@   ���	#FFD9FFCF.��5<   "   �� $��Choose��6,   5=      5>      5?      5@      �� 5B      $ 
Horizontal=�6   $
��Auto��66   .+�5C      �� $��Description:��6    �� 5D      -   5        $ Product_DescBox��5D      $	��100��67   $	��400��6G    �� TextWrapping$
 Wrap=�6S   5E      5F      5G      �� 5I   
   $��2��6   $��1��6"   $ 
Horizontal=�62   .+�5J      �� -   5        $ EditBut��5J      .��5K      �� $$��Отредактировать��6   5L      �� 5O      -	   5        $ DiscontinieBut��5O      .��5P      �� $"��Снять с продажи��6   5Q      �� 5S      -
   5        $ 	DeleteBut��5S      ���	#FFD28C8C.��5T      �� $��Удалить��6   5U      5V      5W      5X      