using Capa_entidades;
using CapaNegocio;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;
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
                comboBoxPedidosTipo.ItemsSource = productosNegocio.LeerTiposArticulos();
                comboBoxPedidosTipo.SelectedIndex = 0;
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
            SeriesCollection serie = new SeriesCollection();
            serie.Add(new PieSeries
            {
                Title = "Juan",
                Values = new ChartValues<double> { 10 },
                Stroke = System.Windows.Media.Brushes.HotPink,
                Fill = System.Windows.Media.Brushes.HotPink
            });
            serie.Add(new PieSeries
            {
                Title = "Mario",
                Values = new ChartValues<double> { 60 },
                Stroke = System.Windows.Media.Brushes.Green,
                Fill = System.Windows.Media.Brushes.Green
            });
            serie.Add(new PieSeries
            {
                Title = "Ana",
                Values = new ChartValues<double> { 30 },
                Stroke = System.Windows.Media.Brushes.Aquamarine,
                Fill = System.Windows.Media.Brushes.Aquamarine
            });

            graficoPedidosTipo.Series = serie;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Close()
        {
            if (userControlParent != null && typeof(TableViewUsuariosUserControl).Equals(userControlParent.GetType()))
            {
                TableViewUsuariosUserControl uc = (TableViewUsuariosUserControl)userControlParent;
                mainWindow.SetUserControlChildren(userControlParent);
            }
            else
                mainWindow.SetUserControlChildren(userControlParent);
        }

    }
}