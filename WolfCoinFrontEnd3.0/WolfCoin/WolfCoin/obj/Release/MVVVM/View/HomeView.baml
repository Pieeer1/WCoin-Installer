   M S B A M L   `   `   `  ���� C  ?WolfCoin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WolfCoin.MVVVM.ViewWolfCoin.MVVVM.View  P LLoadingSpinnerControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControlLoadingSpinnerControl "    WolfCoin.MVVVM.View.HomeView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:WolfCoin.MVVVM.View     dloadingspinnercontrolBclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControl     .���   � ColumnDefinitions  �� �� .+��� $��0��.+��� $��Mine WolfCoin��
�������$��35(�$
��Left=�$��0,0,0,20q��� -   $��ViewWalletLabel��$��Wallet Balance: ��
�������$
��Left=�$��Center=�$��30(�$��0,25,0,0q�*  $LoadingSpinnerControl.LoadingSpinner  -   $��LoadingSymbol��$��10,75,10,10q�   	IsLoading .  �� $-��'How Many Coins Would you Like to Mine? ��
�������$��Center=�$��Center=�$��15(��� -   $��AmountToMineTextBox�����#303030
�������$��	10,0,10,0q�$��25(�$��50��$��35�� �� TextAlignment$ Center=��� -   $��ViewMiningLabel��$�� ��
�������$
��Left=�$��Center=�$��15(�$��0,0,0,0q���  �� Orientation$ Vertical=�$��Right=�$��1��.+��� $	��375��$	��200��$��Center=�$��5,50,5,5q�����  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,2&�.���  � Color$ DarkGoldenrod�� � Offset$	 0.0Q�� $ Black��$ 1Q� J� Clip �� 	 �� RadiusX$	 10Q�
 �� RadiusY$
 10Q� �� Rect$ 0,0,400,200�._�� .+��� -   $��ViewWalletButton�� J� Opacity$ 0Q��� .+��� $��Update 
Your Wallet��$��
20,10,10,0q�
�������$��28(��� $	��250��$	��250��$��/Images/wallet.png��$��Right=��� $	��375��$	��200��$��Center=�$��5,5,5,5q����� $	 0,0&�$	 1,2&�.��� $ DarkGoldenrod��$	 0.0Q�� $ Black��$ 1Q� �� $	 10Q�$
 10Q�$ 0,0,400,200�._�� .+��� -   $��
MineButton��$ 0Q��� .+��� $��Mine 
For WolfCoin��$��
20,10,10,0q�
�������$��28(��� $	��250��$	��250��$��/Images/mine.png��$��Right=�