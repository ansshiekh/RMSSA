   M S B A M L   `   `   `  ����@  <RMSSA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:RMSSARMSSA  5   	       RMSSA.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:RMSSA     5   	     � Title$  LoginWindow��5   	   $	��450��6   $	��800��6*    � WindowStyle$
 None=�66   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      .+�5   
   �� -   5         ��Name$ back_btn��5      $
��Back��6#   $
��Left=�62   $��	10,10,0,0q�6M   $	��Top=�6`   $��75��6x   6�   �� 5   
   -   5        $ 	login_btn��5      $��Login��6$   $��1��64   $
��Left=�6D   $��112,216,0,0q�6_   $	��Top=�6t   $��75��6�   6�   �� 5   
   -   5        $ 
signup_btn��5      $��Sign Up��6%   $��1��67   $
��Left=�6G   $��244,216,0,0q�6b   $	��Top=�6w   $��75��6�   6�   �� 5   
   -   5         ��Name$ username_box��5      $��1��6(   $
��Left=�68   $��24��6S   $��
112,87,0,0q�6_    �� TextWrapping$
 Wrap=�6s   $��username��6�   $	��Top=�6�   $	��207��6�   �� 5   
   -   5        $ password_box��5      $��1��6(   $
��Left=�68   $��24��6S   $��112,127,0,0q�6_   $
 Wrap=�6t   $��password��6�   $	��Top=�6�   $	��207��6�   �� 5   
   $��For Testing Purpose��6   $
��Left=�6.   $��
129,41,0,0q�6I   $	��Top=�6]   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ UserDataGrid��5      $
��Left=�6)   $	��281��6D   $��
10,111,0,0q�6Q   $	��Top=�6e   $	��376��6}   5      5      