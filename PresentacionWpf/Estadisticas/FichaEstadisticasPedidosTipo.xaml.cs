using Capa_entidades;
using CapaNegocio;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static Utils.Utilities;

namespace PresentacionWpf
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class FichaEstadisticasPedidosTipo : UserControl
    {
        public Modos modo;
        private MainWindow mainWindow;
        private UserControl userControlParent;
        private ProductosNegocio productosNegocio;
        private List<TipoArticulo> listTiposArticulos;
        private List<Articulo> listArticulos;

        public FichaEstadisticasPedidosTipo(Modos modo, Window windowParent = null, UserControl userControlParent = null)
        {
            InitializeComponent();
            this.modo = modo;
            mainWindow = (MainWindow)windowParent;
            this.userControlParent = userControlParent;
            UtilsControl.SetTitulo(modo, labelTitle, "pedidos por tipo");
            mainWindow.SetStatusException();

            productosNegocio = new ProductosNegocio();

            try
            {
                listTiposArticulos = productosNegocio.LeerTiposArticulos();
                listArticulos = productosNegocio.LeerArticulos();
            }
            catch (Exception e)
            {
                mainWindow.SetStatusException(e);
            }

            // GRÁFICO PIECHART
            RefreshChart();
        }

        private void RefreshChart()
        {
            try
            {
                SeriesCollection serie = new SeriesCollection();
                List<SolidColorBrush> colors = new List<SolidColorBrush>(new SolidColorBrush[] { Brushes.Green, Brushes.HotPink, Brushes.Aquamarine, Brushes.Red });

                int i = 0;
                foreach (TipoArticulo tipoArticulo in listTiposArticulos)
                {
                    if (tipoArticulo.TipoArticuloID != 0)
                    {
                        serie.Add(new PieSeries
                        {
                            Title = tipoArticulo.Descripcion + "s",
                            Values = new ChartValues<double> { productosNegocio.LeerArticulosPorFiltro(listArticulos, "", tipoArticulo.TipoArticuloID).Count },
                            Stroke = colors[i],
                            Fill = colors[i]
                        });
                        i++;
                    }
                }

                graficoPedidosTipo.Series = serie;
            }
            catch (Exception e)
            {
                mainWindow.SetStatusException(e);
            }
        }

        private void BtnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            RefreshChart();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Close()
        {
            mainWindow.SetUserControlChildren(userControlParent);
        }

    }
}