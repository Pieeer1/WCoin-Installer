   M S B A M L   `   `   `  ����C  ?WolfCoin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WolfCoinWolfCoin  5   	   C&clr-namespace:WolfCoin.MVVVM.ViewModelWolfCoin.MVVVM.ViewModel  5   	       WolfCoin.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WolfCoin     5   	   <	viewModel&clr-namespace:WolfCoin.MVVVM.ViewModel     5   	   -   5        $	��600��5	   	   $	��920��6     � WindowStyle$
  None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency .  � Title$ WolfCoin��5   	    � DataContext 5      ,  &WolfCoin.MVVVM.ViewModel.MainViewModel  5   
   .��5      �� ���#404040 �� CornerRadius$ 10��5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5       � RowDefinitions 5       �� 5!      $��75 �6    �� 5$      .+�5'      �� $��Images\Wcoinlogo.png��6   $��Center=�5(      $
��Left=�5)      $��20,0,0,0q�5*      �� 5/      $��1��6   .+�51      	� $
��Home��6   $��50��52      
�������$��14(�54         MenuButtonTheme#��[  55      	 d� 	IsChecked$
	 TrueY�56      ��57      �� *HomeViewCommand+	� 58      -   5        $��Send WolfCoin��58      $��50��59      
�������$��14(�5;      #��[  5<      $	 FalseY�5=      ��5?      �� *SendViewCommand+	� 5A      $��Sell WolfCoin��6   $��50��5B      
�������$��14(�5D      #��[  5E      $	 FalseY�5F      ��5G      �� *SellViewCommand+	� 5I      $��Buy WolfCoin��6   $��50��5J      
�������$��14(�5L      #��[  5M      $	 FalseY�5N      ��5O      �� *BuyViewCommand+	� 5Q      -   5        $
��Quit��5Q      $��50��5R      
�������$��14(�5T      #��[  5U      $��	0,250,0,0q�5V      5W      5Z      �� 5[      $��1��6   
 �� Orientation$
 
Horizontal=�6)   .+�5\      �� -   5        $��WelcomeLabel��5`      $��	Welcome: ��5\      $��Center=�5]      $��50(�5^      
�������5`      5d      �� 5e      $��1��6   $��1��5f      $��10q�5g      ��5h      �� *CurrentView+5j      5o      5p      