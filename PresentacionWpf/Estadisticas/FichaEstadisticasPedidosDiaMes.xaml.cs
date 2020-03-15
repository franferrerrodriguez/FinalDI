using Capa_entidades;
using CapaNegocio;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;
using Utils;
using static Utils.Utilities;

namespace PresentacionWpf
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class FichaEstadisticasPedidosDiaMes : UserControl
    {
        public Modos modo;
        private MainWindow mainWindow;
        private UserControl userControlParent;
        private string[] meses;
        private string[] anos;
        private int mes;
        private int ano;

        public FichaEstadisticasPedidosDiaMes(Modos modo, Window windowParent = null, UserControl userControlParent = null)
        {
            InitializeComponent();
            this.modo = modo;
            mainWindow = (MainWindow)windowParent;
            this.userControlParent = userControlParent;
            UtilsControl.SetTitulo(modo, labelTitle, "pedidos por días del mes");
            mainWindow.SetStatusException();
            
            // Seteamos los meses
            meses = GetMeses();
            comboBoxPedidosMes.ItemsSource = meses;
            comboBoxPedidosMes.SelectedIndex = DateTime.Now.Month - 1;
            mes = comboBoxPedidosMes.SelectedIndex + 1;

            // Seteamos los años
            anos = GetAnos();
            comboBoxPedidosAnyo.ItemsSource = anos;
            comboBoxPedidosAnyo.SelectedIndex = 0;
            ano = Convert.ToInt32(comboBoxPedidosAnyo.SelectedItem.ToString());

            // GRÁFICO BARCHART
            RefreshChart();
        }

        private void RefreshChart()
        {
            SeriesCollection serie = new SeriesCollection();
            g2_eje_x.MaxValue = 5;

            // Creo una serie con dos COLUMNAS
            serie.Add(new ColumnSeries
            {
                Title = "2017",
                Values = new ChartValues<double> { 10, 50, 39, 10, 100 }
            });
            serie.Add(new ColumnSeries
            {
                Title = "2018",
                Values = new ChartValues<double> { 23, 44, 50, 5, 100 }
            });

            g2_eje_x.Labels = new[] { "Maria", "Juan", "Pedro", "Jairo", "Mario" };
            graficoPedidosDiaMes.Series = serie;
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