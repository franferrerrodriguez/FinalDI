   M S B A M L   `   `   `  ����  PresentacionWpf1    +PresentacionWpf.TableViewPedidosUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $
��1070��5      $	��842��6,   .��5      � -   5        $��GridTableViewPedidos��5      ��5   
   �� 5	        �� Color$  	#FFF0F0F0��6   .+�5   
   �� -   5        $��
labelTitle��5      $
��Left=�6"   $��	44,10,0,0q�6=   $	��Top=�6P   $��36(�6h   $	��400��6v   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGrid��5      $
��Left=�6#   $	��636��6>   $��
44,196,0,0q�6K   $	��Top=�6_   $	��978��6w      AutoGenerateColumns .   � Cursor$
 Hand��6�      
IsReadOnly . ��6�   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ PedidoID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 300 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *
PedidoID+6T     5      $ 	UsuarioID��6%   $	 300 6V    68   �� *	UsuarioID+6V     5      $ Fecha��6%   $	 300 6N    64   �� *Fecha+6N   5      �� 5   
   -   5        $��btnCancelar��5      $��Cancelar��6$   $
��Left=�67   $��922,104,0,0q�6R   $	��Top=�6g   $	��100��6   6�   �� 5   
   $��Filtrar por usuario:��6   $
��Left=�6/   $��	47,75,0,0q�6J   $	��Top=�6]    J� RenderTransformOrigin$ -0.112,-0.145&�6u   �� 5   
   -   5        	 ��Name$	 textBoxUsuarioId��5      $
��Left=�6,   $��23��6G   $��
47,104,0,0q�6S   
 �� TextWrapping$

 Wrap=�6g   $	��Top=�6{   $	��130��6�   
�������{�.  ��6�   �� *Nombre+ �� Mode$ TwoWay=�6�   �� 5   
   -   5        $	 textBoxUsuarioNombre��5      $
��Left=�60   $��23��6K   $��195,104,0,0q�6W   $

 Wrap=�6l   $	��Top=�6�   $	��300��6�   
�������{�.  ��6�   �� *Nombre+$ TwoWay=�6�   �� 5   
   -   5         ��Name$ btnAnadirUsuario��5      $��Añadir��6+   $
��Left=�6<   $��500,104,0,0q�6W   $	��Top=�6l   $��65��6�   $��23��6�   $��10(�6�   $��Normal"�6�   6�   �� 5   
   -   5        $ btnQuitarUsuario��5      $��Quitar��6+   $
��Left=�6<   $��570,104,0,0q�6W   $	��Top=�6l   $��65��6�   $��23��6�   $��10(�6�   $��Normal"�6�   6�   �� 5   
   $��Fecha inicio:��6   $
��Left=�6(   $��
44,136,0,0q�6C   $	��Top=�6W   (  "System.Windows.Controls.DatePicker  5   
   -	   5          Name$ datePickerFechaInicio��5      $
��Left=�64   $��
47,155,0,0q�6O   $	��Top=�6c   $	��217��6{   
���   �
���   �   IsTodayHighlighted .  
�������   Text 6�   �� *Nacido+ �� StringFormat$ {0:yyyy-MM-dd hh:mm:ss}��6  �� 5   
   $��
Fecha fin:��6   $
��Left=�6%   $��281,136,0,0q�6@   $	��Top=�6U     5   
   -
   5        $ datePickerFechaFin��5      $
��Left=�61   $��284,157,0,0q�6L   $	��Top=�6a   $	��217��6y   
���   �
���   � .  
������� 6�   �� *Nacido+$ {0:yyyy-MM-dd hh:mm:ss}��6  5      5      