   M S B A M L   `   `   `  ����C  ?WolfCoin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WolfCoin.MVVVM.ViewWolfCoin.MVVVM.View  5      P LLoadingSpinnerControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControlLoadingSpinnerControl 5      "    WolfCoin.MVVVM.View.HomeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:WolfCoin.MVVVM.View     5      dloadingspinnercontrolBclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControl     5      .��5
      �   � ColumnDefinitions  5   
   �� 5      �� 5      .+�5   
   �� $��0��6   .+�5      �� $��Mine WolfCoin��6   
�������$��35(�5      $
��Left=�5      $��0,0,0,20q�5      �� 5      -   5        $��ViewWalletLabel��5      $��Wallet Balance: ��5      
�������$
��Left=�5      $��Center=�5      $��30(�5      $��0,25,0,0q�5      6(   *  $LoadingSpinnerControl.LoadingSpinner  5      -   5        $��LoadingSymbol��5   3   $��10,75,10,10q�6I      	IsLoading .  6^   �� 5      -   5        $��ViewMiningLabel��5      $�� ��5      
�������$
��Left=�5       $��Center=�5!      $��15(�5"      $��0,0,0,0q�5#      6'   5$      �� 5%   
    �� Orientation$ Vertical=�6   $��Right=�6,   $��1��6H   .+�5&      �� $	��375��6   $	��200��5'      $��Center=�5(      $��5,50,5,5q�5)      ��5*      �� 5+       �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 1,2&�6;   .��5,      �  � Color$ DarkGoldenrod��6'    � Offset$	 0.0Q�6=   � 5-      $ Black��6'   $ 1Q�65   5.       J� Clip 50      �� 51       �� RadiusX$ 10Q�6(   	 �� RadiusY$	 10Q�52   (   
 �� Rect$
 0,0,400,200�53   (   ._�57      � .+�58      �� -   5        $��ViewWalletButton��59       J� Opacity$ 0Q�5:   8   �� 5;      .+�5<      �� $��Update 
Your Wallet��6$   $��
20,10,10,0q�5=   $   
�������$��28(�5?   $   5@      �� 5A      $	��250��6   $	��250��5B      $��/Images/wallet.png��5C      $��Right=�5D      5F      5G      �� 5H      $	��375��6   $	��200��5I      $��Center=�5J      $��5,5,5,5q�5K   !   ��5L      �� 5M      $	 0,0&�6*   $	 1,2&�6;   .��5N      � $ DarkGoldenrod��6'   $	 0.0Q�6=   � 5O      $ Black��6'   $ 1Q�65   5P       5R      �� 5S      $ 10Q�6(   $	 10Q�5T   (   $
 0,0,400,200�5U   (   ._�5Y      � .+�5Z      �� -   5        $��
MineButton��5Z      $ 0Q�61   6=   �� 5[      .+�5\      �� $��Mine 
For WolfCoin��6$   $��
20,10,10,0q�5]   $   
�������$��28(�5_   $   5`      �� 5a      $	��250��6   $	��250��5b      $��/Images/mine.png��5c      $��Right=�5d      5f      5g      5l      5m      5n      