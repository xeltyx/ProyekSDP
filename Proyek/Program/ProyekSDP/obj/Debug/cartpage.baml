   M S B A M L   `   `   `  ����D  @ProyekSDP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ProyekSDP	ProyekSDP  5          ProyekSDP.cartpage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:ProyekSDP     5        N� Title$  MainMenu��5      $��615.5��6   $��538.5��6&    J� Opacity$ 0.975Q�65   .��5
      � 
�������$��Right=�6   $
��1372��6:   $��-382,-60,-374,0q�6G    � ColumnDefinitions 5   
   �� 5      .+�5   
   �� $
��Left=�6   $	��105��6+   $	��Top=�68   $
��1379��6P   $��Gambarhalaman.png��6]    J� RenderTransformOrigin$ 0.504,0.466&�6x   $
��Fill=�6�   $��	0,0,-10,0q�6�   �� 5   
   $��Alterna��6   $
��Left=�6"   $��5,-4,0,0q�6=   $	��Top=�6O   $��55��6g   $	��177��6s   $��Segoe Script)�6   $��36(�6�   �� 5   
   $
��Tech��6   $
��Left=�6   $��	98,40,0,0q�6:   $	��Top=�6M   $��60��6e   $	��154��6q   $��Georgia)�6}   $��48(�6�   �� 5   
   -   5         ��Name$ menubtn��5      $�� ��6"   $��Center=�6-   $��Center=�6H   $��1317,10,10,546q�6e   $��42��6}   $��43��6�   ���	#FF9999FF��5      �� 5       �� ImageSource$ menuicon.png��6    j� Stretch$ Uniform=�68   5      � 5   
   -   5         �Name$ menugrid��5      $
��Left=�6!   $	��598��6<   $��
1096,0,0,0q�6I   $	��Top=�6]   $	��276��6u   ���	#FF7777FB$y�Hidden=�6�   .+�5      �� -   5         ��Name$ 	userLabel��5      $��Optimum Pride��6'   $
��Left=�6?   $	��Top=�6Z   $��49��6r   $	��154��6~   $��20(�6�   $��Center=�6�   $��50,0,0,0q�6�   �� 5      $
��Left=�6   $	��368��64   $��0,90,0,0q�6A   $	��Top=�6S   $	��276��6k   .+�5      �� -   5        $ Homebtn��5      $��  Home��6*   $��59��6;   $
��Left=�6G   $��20(�6i   $��0q�6w   	 � Cursor$
	 Hand��6�   ���	#00707070���	#FF9696FA$	��0,1q�6�   6�   �� 5       -   5        $��  My Profile��5       $��59��60   $
��Left=�6<   $��20(�6^   $��0q�6l   $
	 Hand��6w   ���	#00707070���	#FF9696FA$	��0,1q�6�   6�   �� 5!      $��  Cart��6   $��59��6*   $
��Left=�66   $��20(�6X   $
	 Hand��6f   ���	#00707070���	#FF9696FA$	��0,1q�6�   �� 5"      -   5        $��  Tokoku��5"      $��59��6,   $
��Left=�68   $��20(�6Z   $��0q�6h   $
	 Hand��6s   ���	#00707070���	#FF9696FA$	��0,1q�6�   6�   5#      �� 5$      $
��Left=�6   $��49��6/   $	��Top=�6;   $��49��6S   $��person-icon.png��6^   �� 5%      -   5        $ 	logoutbtn��5%      $��  Logout��6(   $
��Left=�6;   $��20(�6]   $
	 Hand��6k   ���	#00707070���	#FFE68FA7$	��0,1q�6�   $��	0,538,0,0q�6�   6�   5&      &   System.Windows.Controls.DataGrid  5'   
   -   5        
  Name$
 dgvCart��5'      $
��Left=�6$   $	��265��6?   $��
10,135,0,0q�6L   $	��Top=�6`   $
��1021��6x      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�      
IsReadOnly . 6�   �� 5(   
   -	   5        $��Checkout��5(      $
��Left=�6$   $��914,427,0,0q�6?   $	��Top=�6T   $	��117��6l   $��38��6x   6�   �� 5)   
   -
   5        $ 	lbl_total��5)      $��Label��6#   $
��Left=�63   $��778,433,0,0q�6N   $	��Top=�6c   $	��106��6{   �� 5*   
   -   5         ��Name$ alamat��5*      $
��Left=�6"   $��22��6=   $��377,437,0,0q�6I    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��348��6�   �� 5+   
   -   5        $ lbl_total_Copy��5+      $��Alamat: ��6(   $
��Left=�6;   $��319,433,0,0q�6V   $	��Top=�6k   $��58��6�   5-      5.      