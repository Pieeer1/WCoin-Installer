   M S B A M L   `   `   `  ����C  ?WolfCoin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WolfCoinWolfCoin  5   	   P LLoadingSpinnerControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControlLoadingSpinnerControl 5   	       WolfCoin.LoginPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WolfCoin     5   	   dloadingspinnercontrolBclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControl     5   	   -   5          � Title$  Login��5	   	   $	��450��6   $	��400��6$    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency .  J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ local:LoginPage.Login��5      69    J� InputBindings 5      �� 5   
    �� Command$ local:LoginPage.Login��6   
	 �� Key$	 Enter��65   .��5      �� ���#404040
 �� CornerRadius$
 10��5      ._�5   
   �  � RowDefinitions 5      �� 5      $��75 �6    �� 5      .+�5       �� $��Images\Wcoinlogo.png��6   $��Center=�5!      $��Center=�5"      $��0,0,0,0q�5#      �� 5%      $��1��6   .+�5&      �� $��Login��6   
�������$��Center=�5(      $��Center=�5)      $��20(�5*      �� 5+      $��	50,0,50,0q�6   61   �� 5,      $��Username��6   
�������$��Center=�5.      $��Center=�5/      $��14(�50      $��0,20,0,0q�51      �� 52      -   5        $��txtUsername��52      ���#303030
�������$��	50,0,50,0q�55      $��18(�56      �� 57      $��Password��6   
�������$��Center=�59      $��Center=�5:      $��14(�5;      $��0,5,0,0q�5<      G� 5=      -   5        $��txtPassword��5=      ���#303030
�������$��	50,0,50,0q�5@      $��18(�5A      �� 5B      -   5        $��	btnSubmit��5B         
LoginTheme#��[  5C      ���#303030
�������$��
50,20,50,0q�5F      $��14(�5G      $��Submit��5H      6*   �� 5J      -   5        $��btnCreateAccount��5J      #��[  5K      ���#303030
�������$��
50,20,50,0q�5N      $��14(�5O      $��Create an Account��5P      65   *  $LoadingSpinnerControl.LoadingSpinner  5Q      -   5        $��loadingSymbol��5Q   7   $��10q�6L      	IsLoading .  6X   �� 5R      -   5        $��
ErrorLabel��5R      $�� ��6+   $��Center=�66   $��15(�6S   
���  ��6a   	� 5S      -	   5        $
��Quit��5S      $��50��5T      
�������$��14(�5V        MenuButtonTheme#��[ 5W      $��0,20,0,0q�5X      5Y      5[      5\      5]      5^      