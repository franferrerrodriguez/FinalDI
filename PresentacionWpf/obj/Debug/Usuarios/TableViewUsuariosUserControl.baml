   M S B A M L   `   `   `  ����  PresentacionWpf2    ,PresentacionWpf.TableViewUsuariosUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $
��1070��5      $	��842��6,   .��5      � -   5        $��GridTableViewUsuarios��5      ��5   
   �� 5	        �� Color$  	#FFF0F0F0��6   .+�5   
   �� -   5        $��
labelTitle��5      $
��Left=�6"   $��	44,10,0,0q�6=   $	��Top=�6P   $��36(�6h   $	��400��6v   �� 5   
   $��Filtro nombre:��6   $
��Left=�6)   $��	44,79,0,0q�6D   $	��Top=�6W   �� 5   
   -   5        $��textBoxFiltrarNombre��5      $
��Left=�6.   $��23��6I   $��
44,104,0,0q�6U    �� TextWrapping$
 Wrap=�6i   $	��Top=�6}   $	��220��6�   
�������6�   �� 5   
   $��Filtro email:��6   $
��Left=�6(   $��
44,136,0,0q�6C   $	��Top=�6W   �� 5   
   -   5        $��textBoxFiltrarEmail��5      $
��Left=�6-   $��23��6H   $��
44,157,0,0q�6T   $
 Wrap=�6h   $	��Top=�6|   $	��220��6�   
�������6�   �� 5   
   $��Filtro apellidos��6   $
��Left=�6+   $��
281,79,0,0q�6F   $	��Top=�6Z   �� 5   
   -   5        $��textBoxFiltrarApellidos��5      $
��Left=�61   $��23��6L   $��281,103,0,0q�6X   $
 Wrap=�6m   $	��Top=�6�   $	��220��6�   
�������6�   �� 5   
   $��Filtro documento:��6   $
��Left=�6,   $��281,136,0,0q�6G   $	��Top=�6\   �� 5   
   -   5        $��textBoxFiltrarDocumento��5      $
��Left=�61   $��23��6L   $��281,157,0,0q�6X   $
 Wrap=�6m   $	��Top=�6�   $	��220��6�   
�������6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGrid��5      $
��Left=�6#   $	��636��6>   $��
44,196,0,0q�6K   $	��Top=�6_   $	��978��6w      AutoGenerateColumns .   � Cursor$
 Hand��6�      
IsReadOnly . ��6�   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	UsuarioID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *	UsuarioID+  5      $ Email��6%    64   �� *Email+  5      $ Nombre��6%    65   �� *Nombre+  5      $ 	Apellidos��6%    68   �� *	Apellidos+  5      $ 	Documento��6%    68   �� *Dni+  5      $ 	Teléfono��6%    67   �� *
Telefono+  5      $ Código postal��6%    6<   �� *Codpos+  5      $ Fecha nacimiento��6%    6?   �� *Nacido+ �� StringFormat$ 
dd/MM/yyyy��5      �� 5    
   -   5        $��btnCancelar��5       $��Cancelar��6$   $
��Left=�67   $��922,103,0,0q�6R   $	��Top=�6g   $	��100��6   6�   5!      5"      