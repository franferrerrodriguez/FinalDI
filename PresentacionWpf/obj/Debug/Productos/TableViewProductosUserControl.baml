   M S B A M L   `   `   `  ����  PresentacionWpf3    -PresentacionWpf.TableViewProductosUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $
��1070��5      $	��842��6,   .��5      � -   5        $��GridTableViewProductos��5      ��5   
   �� 5	        �� Color$  	#FFF0F0F0��6   .+�5   
   �� -   5        $��
labelTitle��5      $
��Left=�6"   $��	44,10,0,0q�6=   $	��Top=�6P   $��36(�6h   $	��400��6v   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGrid��5      $
��Left=�6#   $	��636��6>   $��
44,196,0,0q�6K   $	��Top=�6_   $	��978��6w      AutoGenerateColumns .   � Cursor$
 Hand��6�      
IsReadOnly . ��6�   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
ArticuloID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *
ArticuloID+6X     5      $ Nombre��6%   $	 200 6P    65   �� *Nombre+6P     5      $	 Pvp��6%   $	 100 6J    62   �� *Pvp+6J     5      $ Especificaciones��6%   $	 400 6d    6?   �� *Especificaciones+6d   5      �� 5   
   -   5        $��btnCancelar��5      $��Cancelar��6$   $
��Left=�67   $��922,104,0,0q�6R   $	��Top=�6g   $	��100��6   6�   �� 5   
   $��Filtro nombre:��6   $
��Left=�6)   $��	44,79,0,0q�6D   $	��Top=�6W   �� 5   
   -   5         ��Name$ textBoxFiltrarNombre��5      $
��Left=�60   $��23��6K   $��
44,104,0,0q�6W   	 �� TextWrapping$
	 Wrap=�6k   $	��Top=�6   $	��220��6�   
�������6�   �� 5   
   $��Filtro tipo:��6   $
��Left=�6'   $��
44,136,0,0q�6B   $	��Top=�6V   �� 5   
   -   5        $��comboBoxFiltrarTipo��5      $
��Left=�6.   $��
44,157,0,0q�6I   $	��Top=�6]   $	��220��6u   $��29��6�   
�������
 �� SelectedValuePath$
 TipoArticuloID��6�    �� DisplayMemberPath$ Descripcion��6�   ��6�   �� 6�   5      5      