   M S B A M L   `   `   `  ����J  FPresentacionWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PresentacionWpfPresentacionWpf  5      /    )PresentacionWpf.FichaProductosUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:PresentacionWpf     5      $
��1070��5      $	��842��6,     � 	Resources  5	         PresentacionWpf.List   	Productos��%   &	          5
   
   6   5      .��5      � -   5        $��GridFichaProductos��5       � DataContext 6%   ��  �� Source# [  ��5   
   �� 5       �� Color$ 	#FFF0F0F0��6   .+�5   
   �� -   5        $��
labelTitle��5      $
��Left=�6"   $��	44,10,0,0q�6=   $	��Top=�6P   $��36(�6h   $	��400��6v   �� 5   
   $�� ��6   $
��Left=�6   $��	44,79,0,0q�66   $	��Top=�6I   �� 5   
   $��Filtro por tipo:��6   $
��Left=�6+   $��	52,80,0,0q�6F   $	��Top=�6Y   �� 5   
   $��29��6   $	��Top=�6   $��52,104,798,0q�67    �� DisplayMemberPath$ Nombre��6e   $ �� IsSynchronizedWithCurrentItem$
 trueY�6�   
���������6M   �� 6�   �� 5   
   -   5        $��listViewArticulos��5      $
��Left=�6,   $	��672��6G   $��
47,160,0,0q�6T   $	��Top=�6h   $	��571��6�   $
 trueY�6�   
������� � Cursor$
 Hand��61  ��6�   ��  �� Path$ 	Articulos� �� View 5      �� 5      .P�5      �� $��ID��6%   	 �� Width$		 100��61   
 �� DisplayMemberBinding
 6=   �� *
ArticuloID+�� 5      $��Nombre��6%   $		 200��65   
 6A   �� *Nombre+�� 5      $��Marca��6%   $		 120��64   
 6@   �� *Marca+�� 5      $	��PVP��6%   $		 100��62   
 6>   �� *Pvp+5      5       �� 5"   
   -   5         ��Name$ btnCancelar��5"      $��Cancelar��6&   $
��Left=�69   $��939,104,0,0q�6T   $	��Top=�6i   $	��100��6�   6�   �� 5#   
   $
��Left=�6   $��639,211,0,0q�6+   $	��Top=�6@   $	��400��6X   ���	#FFB7B7B7$��1��6{   �� 5$   
   $��Datos del artículo��6   $
��Left=�6-   $��636,182,0,0q�6H   $	��Top=�6]    J� RenderTransformOrigin$ 0.014,0.646&�6u   �� 5%   
   $��ID��6   $
��Left=�6   $��636,217,0,0q�68   $	��Top=�6M   �� 5&   
   $
��Left=�6   $��24��6-   $��636,242,0,0q�69    �� TextWrapping$
 Wrap=�6N   $	��Top=�6b   $	��120��6z   {�.  
���������6�   �� *Articulos/ArticuloID+6�   �� 5'   
   $��Nombre��6   $
��Left=�6!   $��636,274,0,0q�6<   $	��Top=�6Q   �� 5(   
   $
��Left=�6   $��24��6-   $��636,299,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $	��186��6z   {�.  
���������6�   �� *Articulos/Nombre+6�   �� 5)   
   $��Marca��6   $
��Left=�6    $��849,274,0,0q�6;   $	��Top=�6P   �� 5*   
   $
��Left=�6   $��24��6-   $��849,299,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $	��186��6z   {�.  
���������6�   �� *Articulos/MarcaID+6�   �� 5+   
   $��Especificaciones��6   $
��Left=�6+   $��636,332,0,0q�6F   $	��Top=�6[   �� 5,   
   $
��Left=�6   $��24��6-   $��636,357,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $	��186��6z   {�.  
���������6�   �� *Articulos/Especificaciones+6�   �� 5-   
   $	��PVP��6   $
��Left=�6   $��849,332,0,0q�69   $	��Top=�6N   �� 5.   
   $
��Left=�6   $��24��6-   $��849,357,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $	��186��6z   {�.  
���������6�   �� *Articulos/Pvp+6�   �� 5/   
   $
��Left=�6   $	��100��60   $��703,494,0,0q�6=   $	��Top=�6R   $	��100��6j   � 50   
   -   5        $��wrapPanelSubArticulo��50      $
��Left=�60   $	��451��6K   $��636,381,0,0q�6X   $	��Top=�6m   $	��399��6�   51      52      