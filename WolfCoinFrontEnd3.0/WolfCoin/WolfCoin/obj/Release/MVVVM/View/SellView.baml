   M S B A M L   `   `   `  ���� C  ?WolfCoin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WolfCoin.MVVVM.ViewWolfCoin.MVVVM.View  "    WolfCoin.MVVVM.View.SellView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:WolfCoin.MVVVM.View     .��� .+��� ���#404040  �� CornerRadius$  10��._��  � RowDefinitions �� �� $	��150 ��� $	��150 ��� .+��� -   $��	SendLabel��$��Sell WolfCoins��
�������$��Center=�$	��Top=�$��30(�$��0,0,0,0q��� -   $��SendPopupTextName�����#404040
������� �� Padding$ 30q�$��Center=�$��1��Amount of WolfCoins to Sell�� -   $��AmountToSell��$��40��$	��140��$��Center=�$��1�����#303030
�������.���� -   $��SendPopupTextAmount�����#404040
�������$ 30q�$��Center=�$��2��Price Per Coin�� -   $��PricePerCoin��$��40��$	��140��$��Center=�$��2�����#303030
�������.���� -   $��btnSellSend��   
LoginTheme#��[  ���#303030
�������$��
50,10,50,0q�$��14(�$
��Sell��$��3��$	��100��$��50��