   M S B A M L   `   `   `  ����J  FPresentacionWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PresentacionWpfPresentacionWpf  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      4    .PresentacionWpf.FichaEstadisticasPedidosDiaMes   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:PresentacionWpf     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      $
��1070��5      $	��842��6,   .��5	      � -   5        $(��"GridFichaEstadisticasPedidosDiaMes��5	      ��5
   
   �� 5        �� Color$  	#FFF0F0F0��6   .+�5   
   �� -   5        $��
labelTitle��5      $
��Left=�6"   $��	44,10,0,0q�6=   $	��Top=�6P   $��36(�6h   $	��800��6v   �� 5   
   $��Filtro mes:��6   $
��Left=�6&   $��	44,79,0,0q�6A   $	��Top=�6T   �� 5   
   -   5        $��comboBoxPedidosMes��5      $
��Left=�6-   $��
44,103,0,0q�6H   $	��Top=�6\   $	��220��6t   
�������6�   �� 5   
   $��Filtro año:��6   $
��Left=�6&   $��
280,79,0,0q�6A   $	��Top=�6U   �� 5   
   -   5        $��comboBoxPedidosAnyo��5      $
��Left=�6.   $��280,103,0,0q�6I   $	��Top=�6^   $	��220��6v   
�������6�   �� 5   
   -   5         ��Name$ btnRefrescar��5      $��	Refrescar��6'   $
��Left=�6;   $��806,104,0,0q�6V   $	��Top=�6k   $	��100��6�   6�   �� 5   
   -   5        $��btnCancelar��5      $��Cancelar��6$   $
��Left=�67   $��922,104,0,0q�6R   $	��Top=�6g   $	��100��6   6�   #  LiveCharts.Wpf.CartesianChart  5   
   -   5          Name$ graficoPedidosDiaMes��5      ���	#FFFDFAFA$��0��6R   $��10,196,10,10q�6b   &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$
 None=�6x      AxisX 5        LiveCharts.Wpf.Axis     MaxValue$	 100Q�6      MinValue$ 0Q�6*      Title$ Nº de pedidos��67      	Separator 5        LiveCharts.Wpf.Separator  5      {�.  	   Step$	 10Q�6:   5      
   AxisY
 5         -   5          Name$ g3_eje_y��5       $ Días del mes��6-    5!        5"      {�.  $	 1Q�6:   5$      5&      5(      5)      