   M S B A M L   `   `   `  ����J  FCommercialForum, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:CommercialForum.Pages.StaffPages CommercialForum.Pages.StaffPages  5      5    /CommercialForum.Pages.StaffPages.ClientListPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:CommercialForum.Pages.StaffPages     5        N� Title$  ClientListPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $	��160 �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $	��100 �6   .+�5   
   �� $��0��6   $��0��6%   .+�5      �� -   5         ��Name$ BackBut��5      
������ $��80��6?   $��80��6J   .��5      �� $ ��/Materials/Images/Back.png��6   5      5      �� 5   
   $��1��6   .+�5      �� $#��Список клиентов��6      
TitleBlock#��[  6/   5       �� 5"   
   $��1��6   $��0��6"   $��2��62   $��2��6C   .+�5#      �� -   5         ��Name$ clientsList��5#      $��Visible=�6,   $	��500��6_   $y�Visible=�5$      $	��300��6,   $��Stretch=�69   $��Stretch=�6^   $��Center=�5%      
������  � 	Resources 5&       �� 
TargetType �� Property �� Value��%�   '��       'b� P     �� 5'      " ��6   .�5(      ��  � �� �	#FFD9FFCF67   5)      �� 5+      " b�6   .�5,      ��  � �� �	#FFD9FFCF67   5-      5.      ��5/      �� 50      .R�51      �� $��5q�6!   ._�52      �� 	 �� Orientation$	 Vertical=�6)   $��Stretch=�6@   $��Stretch=�6^   $��5q�6z   .+�53   "   �� $	 
Horizontal=�6-   $��10, 5, 5, 5q�6F   .+�54   &   �� $��
0, 0, 0, 0q�60   $��20(�6[   ��6D   �� *FName+6[   �� 55   &   $��
5, 0, 0, 0q�60   $��20(�6[   ��6D   �� *LName+6[   �� 56   &   $��
5, 0, 0, 0q�60   $��20(�6`   ��6D   �� *
Patronymic+6`   57   #   �� 59   "   $	 
Horizontal=�6-   .+�5:   &   �� $��1q�60   $��Email: ��6;   $��20(�6J   �� 5;   &   $��1q�60   $��20(�6R   ��6;   �� *Email+6R   5<   #   �� 5>   "   $	 
Horizontal=�6-   .+�5?   &   �� $��1q�60   $��Role: ��6;   $��20(�6I   �� 5@   &   $��1q�60   $��20(�6Q   ��6;   �� *Role+6Q   5A   #   5B      5C      5D      5F      5G      �� 5I   
   $��1��6   $��2��6"   $��2��62   $	 Vertical=�6C   .+�5J      �� -   5        $ 
HistoryBut��5J      $��0, 10, 0, 10q�6B   .��5K      �� $#��История покупок��6   5L      �� 5N      -   5        $ TraderProductsBut��5N      $��0, 10, 0, 10q�6P   .��5O      �� $#��Товары продавца��6   5P      5Q      5R      5S      