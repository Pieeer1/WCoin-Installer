   M S B A M L   `   `   `  ���� C  ?WolfCoin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WolfCoin.MVVVM.ViewWolfCoin.MVVVM.View  !    WolfCoin.MVVVM.View.BuyView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:WolfCoin.MVVVM.View     .��� .+��� ���#404040  �� CornerRadius$  10��._��  � RowDefinitions �� $��50 ��� �� ��  � ColumnDefinitions �� �� .+��� -   $��	SendLabel��$��Buy WolfCoins��
�������$��Center=�$	��Top=�$��30(�$��0,0,0,0q��� -   $��SendPopupTextName�����#404040
������� �� Padding$ 30q�$��Center=�$��1��Amount of WolfCoins to Buy�� -   $��SendPopUpInput��$��40��$	��140��$��Center=�$��1�����#303030
�������.���� -   $��SendPopupTextAmount�����#404040
�������$ 30q�$��Center=�$��2��Price Per Coin�� -   $��SendPopUpInputAmount��$��40��$	��140��$��Center=�$��2�����#303030
�������.���� -   $��
btnBuySend��   
LoginTheme#��[  ���#303030
�������$��
50,10,50,0q�$��14(�$	��Buy��$��3��$	��100��$��50���� -   $��CardNumberText�����#404040
�������$ 30q�$��Center=�$��1��$��1��Card Number�� -   $��CardNumberValue��$��40��$	��140��$��Center=�$��1�����#303030
�������$��1���� -	   $��CVCText�����#404040
�������$ 30q�$��Center=�$��2��$��1��CVC�� -
   $��CVCValue��$��40��$	��140��$��Center=�$��2�����#303030
�������$��1���� -   $��ExpirationText�����#404040
�������$ 30q�$��Center=�$��3��$��1��
Expiration�� -   $��ExpirationValueMonth��$��40��$��40��$
��Left=�$��3�����#303030
�������$��1��$��	100,0,0,0q��� -   $��ExpirationValueYear��$��40��$��40��$��Right=�$��3�����#303030
�������$��1��$��	0,0,100,0q�