using Capa_entidades;
using CapaNegocio;
using LiveCharts;
using LiveCharts.Helpers;
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
    public partial class FichaEstadisticasPedidosDiaMes : UserControl
    {
        public Modos modo;
        private MainWindow mainWindow;
        private UserControl userControlParent;
        private PedidosNegocio pedidosNegocio;
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

            pedidosNegocio = new PedidosNegocio();

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

        private void ComboBoxPedidosMes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mes = comboBoxPedidosMes.SelectedIndex + 1;
            RefreshChart();
        }

        private void ComboBoxPedidosAnyo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ano = Convert.ToInt32(comboBoxPedidosAnyo.SelectedItem.ToString());
            RefreshChart();
        }

        private void RefreshChart()
        {

            if(comboBoxPedidosAnyo.SelectedIndex != -1 && comboBoxPedidosAnyo.SelectedIndex != -1)
            {
                try
                {
                    SeriesCollection serie = new SeriesCollection();
                    int numDays = DateTime.DaysInMonth(new DateTime(ano, 1, 1).Year, new DateTime(9999, mes, 1).Month);
                    string[] days = new string[numDays];
                    for (int i = 0; i < numDays; i++)
                        days[i] = (i + 1).ToString();
                    g3_eje_y.MaxValue = days.Length;

                    DateTime fechaInicio = new DateTime(ano, mes, 1);
                    DateTime fechaFin = new DateTime(ano, mes, days.Length);

                    double[] puntos = pedidosNegocio.LeerPedidosEntreFechas(fechaInicio, fechaFin);
                    serie.Add(new RowSeries
                    {
                        Title = "Nº PEDIDOS:",
                        Values = puntos.AsChartValues()
                    });

                    g3_eje_y.Labels = days;
                    graficoPedidosDiaMes.Series = serie;
                }
                catch (Exception e)
                {
                    mainWindow.SetStatusException(e);
                }
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