   M S B A M L   `   `   `  ����g  cMicrosoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91tSclr-namespace:Microsoft.Reporting.WebForms;assembly=Microsoft.ReportViewer.WebFormsMicrosoft.Reporting.WebForms  5      D @ProyekSDP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ProyekSDP	ProyekSDP 5         ProyekSDP.Admin   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      brvSclr-namespace:Microsoft.Reporting.WebForms;assembly=Microsoft.ReportViewer.WebForms     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:ProyekSDP     5        N� Title$  Admin��5	      $��685.5��6   $��1156.5��6$   .��5      � .+�5   
   � $��
0,10,10,10q�6   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF137EFF��6#    � Offset$ 0.017Q�65   � 5      $ 	#FFBBC5D1��6#   $ 1Q�65   5      .+�5      �� $��
Admin Page��6   $
��Left=�6)   $��	24,23,0,0q�6D   $	��Top=�6W   $	��238��6o   
�������$��24(�6�   $��44��6�   $��Segoe UI Semibold)�6�   �� 5      -   5         ��Name$ btnPageBarang��5      $��Daftar Barang��6,   $
��Left=�6D   $��	24,96,0,0q�6_   $	��Top=�6r   $	��189��6�   $��44��6�   6�   �� 5      -   5        $ btnPageUser��5      $��Daftar User��6*   $
��Left=�6@   $��
24,165,0,0q�6[   $	��Top=�6o   $	��189��6�   $��44��6�   6�   �� 5      -   5        $ 
btnlaporan��5      $��Laporan Transaksi��6)   $
��Left=�6E   $��
24,236,0,0q�6`   $	��Top=�6t   $	��189��6�   $��44��6�   6�   �� 5      -   5        $ btnreqsaldo��5      $��Konfirmasi Top Up��6*   $
��Left=�6F   $��
24,306,0,0q�6a   $	��Top=�6u   $	��189��6�   $��44��6�   6�   �� 5      -   5        $��Logout��5      $
��Left=�6&   $��
24,555,0,0q�6A   $	��Top=�6U   $	��189��6m   $��44��6y   6�   � 5      -   5         �Name$ 
gridbarang��5      $
��Left=�6'   $	��639��6B   $��
266,17,0,0q�6O   $	��Top=�6c   $	��870��6{   $y�Hidden=�6�   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dgvUser��5      $
��Left=�6,   $	��349��6G   $��	10,10,0,0q�6T   $	��Top=�6g   $	��850��6      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   	   
IsReadOnly	 . 6�   �� 5      $��Nama Barang:��6   $
��Left=�6/   $��
23,384,0,0q�6J   $	��Top=�6^   $��29��6v   $��86��6�   
 J� RenderTransformOrigin$
 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5       �� AngleX$ 1.432Q�6,   �� 5       T� 5!       T� X$ 0.475Q�61   5"      5$      �� 5%      -   5         ��Name$ text_nmbarang��5%      $
��Left=�61   $��29��6L   $��127,382,0,0q�6X    �� TextWrapping$
 Wrap=�6m   $	��Top=�6�   $	��225��6�   �� 5&      $��	Kategori:��6   $
��Left=�6,   $��
22,433,0,0q�6G   $	��Top=�6[   $��31��6s   $��61��6   �� 5'      -	   5         ��Name$ combo_kategori��5'      $
��Left=�63   $��127,435,0,0q�6N   $	��Top=�6c   $	��225��6{   $��29��6�   �� 5(      $��Merk:��6   $
��Left=�6(   $��
22,484,0,0q�6C   $	��Top=�6W   �� 5)      -
   5        $ 
combo_merk��5)      $
��Left=�6/   $��127,484,0,0q�6J   $	��Top=�6_   $	��225��6w   $��29��6�   �� 5*      -   5        $ 
text_harga��5*      $
��Left=�6.   $��29��6I   $��461,382,0,0q�6U   $
 Wrap=�6j   $	��Top=�6~   $	��225��6�   6�   �� 5+      $��Harga:��6   $
��Left=�6)   $��411,382,0,0q�6D   $	��Top=�6Y   �� 5,      -   5        $ 	text_stok��5,      $
��Left=�6-   $��29��6H   $��127,531,0,0q�6T   $
 Wrap=�6i   $	��Top=�6}   $	��225��6�   �� 5-      $��Stok:��6   $
��Left=�6(   $��
26,531,0,0q�6C   $	��Top=�6W   �� 5.      -   5        $ 
btn_insert��5.      $��Insert��6-   $
��Left=�6>   $��
22,590,0,0q�6Y   $	��Top=�6m   $	��118��6�   $
 	8.16,-0.6&�6�   $��39��6�   �� 5/      -   5        $ 
btn_update��5/      $��Update��6-   $
��Left=�6>   $��202,590,0,0q�6Y   $	��Top=�6n   $	��118��6�   $��39��6�   �� 50      -   5        $ 
btn_delete��50      $��Delete��6-   $
��Left=�6>   $��379,590,0,0q�6Y   $	��Top=�6n   $	��118��6�   $��39��6�   �� 51      -   5        $ 	btn_clear��51      $��Clear��6,   $��578,590,184,10q�6<   6T   �� 52      -   5         ��Name$ 	rtbgambar��52      $
��Left=�61   $��94��6L   $��411,463,0,0q�6X   $	��Top=�6m   $	��275��6�   . �53      /� .T�54      J� 55      56      �� 57      $#��Gambar Format base 64(Code) :��6   $
��Left=�6@   $��411,432,0,0q�6[   $	��Top=�6p   58      � 59      -   5        $ griduser��59      $
��Left=�6%   $	��576��6@   $��
267,23,0,0q�6M   $	��Top=�6a   $	��869��6y   $y�Hidden=�6�   .+�5:        -   5        $ dgvcustomer��5:      $
��Left=�60   $	��331��6K   $��	10,10,0,0q�6X   $	��Top=�6k   $	��849��6�   	 . ���	#FFF0F0F0$ * 6�   6�   �� 5;      -   5        $ tbcustomer_name��5;      $
��Left=�63   $��39��6N   $��120,363,0,0q�6Z   $
 Wrap=�6o   $	��Top=�6�   $	��288��6�    �� 
IsReadOnly . 6�   �� 5<      $��Nama Customer��6   $
��Left=�60   $��
10,363,0,0q�6K   $	��Top=�6_   $��39��6w   $	��105��6�   �� 5=      $��Saldo��6   $
��Left=�6(   $��
10,430,0,0q�6C   $	��Top=�6W   $��39��6o   $	��105��6{   �� 5>      -   5        $ tbcustomer_saldo��5>      $
��Left=�64   $��39��6O   $��120,430,0,0q�6[   $
 Wrap=�6p   $	��Top=�6�   $	��288��6�    . 6�   5?      � 5@      -   5        $ 	gridsaldo��5@      $
��Left=�6&   $	��576��6A   $��
267,23,0,0q�6N   $	��Top=�6b   $	��869��6z   $y�Hidden=�6�   .+�5A        -   5        $ dgvkonfirsaldo��5A      $
��Left=�63   $	��331��6N   $��	10,10,0,0q�6[   $	��Top=�6n   $	��849��6�   	 . $ * 6�   ���	#FFF0F0F06�   �� 5B      -   5        $ 
tbnamacust��5B      $
��Left=�6.   $��39��6I   $��120,363,0,0q�6U   $
 Wrap=�6j   $	��Top=�6~   $	��288��6�    . 6�   �� 5C      $��Nama Customer��6   $
��Left=�60   $��
10,363,0,0q�6K   $	��Top=�6_   $��39��6w   $	��105��6�   �� 5D      $��Saldo��6   $
��Left=�6(   $��
10,430,0,0q�6C   $	��Top=�6W   $��39��6o   $	��105��6{   �� 5E      -   5        $ 	btnterima��5E      $��Terima��6,   $
��Left=�6=   $��245,492,0,0q�6X   $	��Top=�6m   $��85��6�   $��36��6�   6�   �� 5F      -   5        $ btntolak��5F      $��Tolak��6+   $
��Left=�6;   $��120,492,0,0q�6V   $	��Top=�6k   $��85��6�   $��36��6�   6�   �� 5G      -   5        $ tbsaldo��5G      $
��Left=�6+   $��39��6F   $��120,430,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $	��288��6�    . 6�   5H      � 5I      -   5        $ gridlaporan��5I      $
��Left=�6(   $	��633��6C   $��
267,23,0,0q�6P   $	��Top=�6d   $	��869��6|   $y�Hidden=�6�   .+�5J      �� -   5        $ cblistcustomer��5J      $
��Left=�63   $��
123,10,0,0q�6N   $	��Top=�6b   $	��255��6z   $��36��6�   �� 5K      $��Nama Customer :��6   $
��Left=�62   $��	10,10,0,0q�6M   $	��Top=�6`   $��36��6x   $	��108��6�   �� 5L      -   5        $ btnloadlistcustomer��5L      $
��Load��66   $
��Left=�6E   $��
396,10,0,0q�6`   $	��Top=�6t   $��85��6�   $��36��6�   6�     5M      -   5        $ 
dgvLaporan��5M      $
��Left=�6/   $��
10,149,0,0q�6J   $	��Top=�6^   $	��850��6v   $ * 6�   	 . 6�   �� 5N      -    5         ��Name$ 
customerLb��5N      $��Nama : ��6,   $
��Left=�6>   $��
10,105,0,0q�6Y   $	��Top=�6m   �� 5O      -!   5        $ totalLb��5O      $��Total: ��6)   $
��Left=�6;   $��677,535,0,0q�6V   $	��Top=�6k   $	��182��6�   �� 5P      -"   5        $��Print��5P      $
��Left=�6)   $��597,538,0,0q�6D   $	��Top=�6Y   $��75��6q   6|   5Q      � 5R      -#   5        $ gridlaporanbarang��5R      $
��Left=�6.   $	��633��6I   $��
267,23,0,0q�6V   $	��Top=�6j   $	��869��6�   $y�Hidden=�6�    � RowDefinitions 5S      �� 5T      .+�5V        -$   5        $ dgbrg��5V      $
��Left=�6*   $	��284��6E   $��
10,136,0,0q�6R   $	��Top=�6f   $	��849��6~   $ * 6�   	 . 6�   (  "System.Windows.Controls.DatePicker  5W      -%   5          Name$ tglbrg��5W      $
��Left=�6-   $��	10,93,0,0q�6H   $	��Top=�6[   $	��192��6s   �� 5X      -&   5        $
 Load��5X      $
��Load��6'   $
��Left=�66   $��
225,95,0,0q�6Q   $	��Top=�6e   $��75��6}   6�   �� 5Y      -'   5        $ print��5Y      $��Print��6(   $
��Left=�68   $��383,438,0,0q�6S   $	��Top=�6h   $��74��6�   6�   �� 5Z      -(   5        $ Loadall��5Z      $��Load All��6*   $
��Left=�6=   $��
342,95,0,0q�6X   $	��Top=�6l   $��75��6�   6�   5\      �� 5^      -)   5        $ 	reportbrg��5^      $��Laporan Barang��6(   $
��Left=�6A   $��
24,377,0,0q�6\   $	��Top=�6p   $	��189��6�   $��44��6�   6�   5_      5`      5a      