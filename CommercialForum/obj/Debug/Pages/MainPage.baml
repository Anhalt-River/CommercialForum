   M S B A M L   `   `   `  ����J  FCommercialForum, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CommercialForum.PagesCommercialForum.Pages  5      $    CommercialForum.Pages.MainPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:CommercialForum.Pages     5        N� Title$  MainPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $	��100 �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $	��100 �6   .+�5   
   �� -   5         ��Name$ menuBut��5      
������ $
��Auto��6;   $
��Auto��6H   $��0q�6l   .��5      �� $)��#/Materials/Images/Main_img/menu.png��6   5      �� 5   
   $��1��6   $��0��6%   $��2��62   $
��Left=�5      $	��Top=�60   $��5q�6H   .+�5      �� -   5        $��
MenuCanvas��5      $��10q�6'   .+�5      �� -   5        $��	MenuBoard��5   -   $��2q�6   $��70��6>   $
��Auto��6J   ._�5       ��  �� Orientation$ 
Horizontal=�6!   .+�5!      �� -   5        $ MyProfileBut��5!   !   
������ $
��Auto��6P   $
��Auto��6]   .��5"      �� $,��&/Materials/Images/Main_img/Profile.png��6$    � ToolTip 5$      �� 5%   "   $��Мой профиль��6,   5'      �� 5)      -   5        $ TradingPlatformBut��5)   !   
������ $
��Auto��6V   $
��Auto��6c   .��5*      �� $(��"/Materials/Images/Main_img/Buy.png��6$    5,      �� 5-   "   $'��!Торговая площадка��6,   5/      �� 51      -   5        $ 	BasketBut��51   !   
������ $
��Auto��6M   $
��Auto��6Z   .��52      �� $2��,/Materials/Images/Main_img/Shopping_cart.png��6$    54      �� 55   "   $��Корзина��6,   57      �� 59      -   5        $ PurchaseHistoryBut��59   !   
������ $
��Auto��6V   $
��Auto��6c   .��5:      �� $,��&/Materials/Images/Main_img/History.png��6$    5<      �� 5=   "   $#��История покупок��6,   5?      �� 5A      -   5        $ 
BalanceBut��5A   !   
������ $
��Auto��6N   $
��Auto��6[   .��5B      �� $*��$/Materials/Images/Main_img/Money.png��6$    5D      �� 5E   "   $��Баланс��6,   5G      �� 5I      -	   5        $ TraderListBut��5I   !   
������ $
��Auto��6Q   $
��Auto��6^   $y�Visible=�6l   .��5J      �� $1��+/Materials/Images/Main_img/PutUpForSale.png��6$    5L      �� 5M   "   $��Мои товары��6,   5O      �� 5Q      -
   5        $ ClientListBut��5Q   !   
������ $
��Auto��6Q   $
��Auto��6^   $y�Visible=�6l   .��5R      �� $.��(/Materials/Images/Main_img/Employees.png��6$    5T      �� 5U   "   $#��Список клиентов��6,   5W      �� 5Y      -   5        $ LeaveBut��5Y   !   
������ $
��Auto��6L   $
��Auto��6Y   .��5Z      �� $*��$/Materials/Images/Main_img/Leave.png��6$    5\      �� 5]   "   $ ��Деавторизация��6,   5_      5a      5b      5c      5d      �� 5f   
   $��1��6   $y�	Collapsed=�6%   .+�5g      �� $%��Главная страница��6      
TitleBlock#��[  60   5h      �� 5j   
   $��0��6   $��2��6"   .+�5k       � -   5          �Name$ BalanceFrame��5k        � NavigationUIVisibility$ Hidden=�6*   5l      �� 5n   
   $��0��6   $��1��6%   $��3��62   $��2��6F   .+�5o       � -   5        $ MainPage_localFrame��5o      $ Hidden=�61   5p      5q      5r      