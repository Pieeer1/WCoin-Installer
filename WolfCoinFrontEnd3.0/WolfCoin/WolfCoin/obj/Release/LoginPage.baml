   M S B A M L   `   `   `  ���� C  ?WolfCoin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WolfCoinWolfCoin  P LLoadingSpinnerControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControlLoadingSpinnerControl     WolfCoin.LoginPage   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:WolfCoin     dloadingspinnercontrolBclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControl     -     � Title$  Login��$	��575��$	��400�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�
������  � AllowsTransparency .  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$ local:LoginPage.Login�� J� InputBindings ��  �� Command$ local:LoginPage.Login��
	 �� Key$	 Enter��.���� ���#404040
 �� CornerRadius$
 10��._��  � RowDefinitions �� $��75 ��� .+��� $��Images\Wcoinlogo.png��$��Center=�$��Center=�$��0,0,0,0q��� $��1��.+��� $��Login��
�������$��Center=�$��Center=�$��20(��� $��	50,0,50,0q��� $��Username��
�������$��Center=�$��Center=�$��14(�$��0,20,0,0q��� -   $��txtUsername�����#303030
�������$��	50,0,50,0q�$��18(��� $��Password��
�������$��Center=�$��Center=�$��14(�$��0,5,0,0q�G� -   $��txtPassword�����#303030
�������$��	50,0,50,0q�$��18(��� -   $��	btnSubmit��   
LoginTheme#��[  ���#303030
�������$��
50,20,50,0q�$��14(�$��Submit���� -   $��btnCreateAccount��#��[  ���#303030
�������$��
50,20,50,0q�$��14(�$��Create an Account���� -   $��FactorStack�� �� Orientation$ 
Horizontal=�$��Center=�$��15q�$y�Hidden=�{�.  .+��� -   $��factor0�����#303030
�������$��	10,0,10,0q�$��50��$��55�� �� TextAlignment$ Center=�$��25(��� -	   $��factor1�����#303030
�������$��	10,0,10,0q�$��25(�$��50��$��55��$ Center=��� -
   $��factor2�����#303030
�������$��	10,0,10,0q�$��25(�$��50��$��55��$ Center=��� -   $��factor3�����#303030
�������$��	10,0,10,0q�$��25(�$��50��$��55��$ Center=��� -   $��	btnVerify��#��[  ���#303030
�������$��
50,20,50,0q�$��14(�$��Verify��$y�Hidden=�{�.  �� -   $��
ErrorLabel��$�� ��$��Center=�$��15(�
���  ��$
��auto��$
��auto��	� -   $
��Quit��$��50��
�������$��14(�  MenuButtonTheme#��[ $��0,0,0,0q�