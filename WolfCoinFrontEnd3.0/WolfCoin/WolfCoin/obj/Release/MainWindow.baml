   M S B A M L   `   `   `  ���� C  ?WolfCoin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WolfCoinWolfCoin  C&clr-namespace:WolfCoin.MVVVM.ViewModelWolfCoin.MVVVM.ViewModel      WolfCoin.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:WolfCoin     <	viewModel&clr-namespace:WolfCoin.MVVVM.ViewModel     -   $	��600��$	��920��  � WindowStyle$
  None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�
������  � AllowsTransparency .  � Title$ WolfCoin�� � DataContext ,  &WolfCoin.MVVVM.ViewModel.MainViewModel  .���� ���#404040 �� CornerRadius$ 10��._��  � ColumnDefinitions �� $	��200 ���  � RowDefinitions �� $��75 ��� .+��� $��Images\Wcoinlogo.png��$��Center=�$
��Left=�$��20,0,0,0q��� $��1��.+�	� $
��Home��$��50��
�������$��14(�   MenuButtonTheme#��[  	 d� 	IsChecked$
	 TrueY����� *HomeViewCommand+	� $��Send WolfCoin��$��50��
�������$��14(�#��[  $	 FalseY����� *SendViewCommand+	� $��Sell WolfCoin��$��50��
�������$��14(�#��[  $	 FalseY����� *SellViewCommand+	� $��Buy WolfCoin��$��50��
�������$��14(�#��[  $	 FalseY����� *BuyViewCommand+	� -   $
��Quit��$��50��
�������$��14(�#��[  $��	0,250,0,0q��� $��1��
 �� Orientation$
 
Horizontal=�.+��� -   $��WelcomeLabel��$��	Welcome: ��$��Center=�$��50(�
��������� $��1��$��1��$��10q����� *CurrentView+