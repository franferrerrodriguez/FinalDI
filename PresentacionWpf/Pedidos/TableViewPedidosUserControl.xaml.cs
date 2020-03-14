using Capa_entidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Utils;
using static Utils.Utilities;

namespace PresentacionWpf
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class TableViewPedidosUserControl : UserControl
    {
        public Modos modo;
        private MainWindow mainWindow;
        private UserControl userControlParent;
        private PedidosNegocio pedidosNegocio;
        private List<Pedido> listPedidos;
        public Pedido pedido;

        public TableViewPedidosUserControl(Modos modo, Window windowParent = null, UserControl userControlParent = null)
        {
            InitializeComponent();
            this.modo = modo;
            mainWindow = (MainWindow)windowParent;
            this.userControlParent = userControlParent;
            UtilsControl.SetTitulo(modo, labelTitle, "pedidos");
            mainWindow.SetStatusException();

            datePickerFechaInicio.Text = DateTime.Now.AddYears(-20).ToString();
            datePickerFechaFin.Text = DateTime.Now.ToString();
            
            try
            {
                pedidosNegocio = new PedidosNegocio();
                listPedidos = pedidosNegocio.LeerPedidos();
                RefreshTable(listPedidos);
            }
            catch (Exception e)
            {
                mainWindow.SetStatusException(e);
            }

        }

        public void SetUsuario(string id, string nombre)
        {
            textBoxUsuarioId.Text = id;
            textBoxUsuarioNombre.Text = nombre;
            Filtrar();
        }

        private void DatePickerFechaInicio_CalendarClosed(object sender, RoutedEventArgs e)
        {
            Filtrar();
        }

        private void DatePickerFechaFin_CalendarClosed(object sender, RoutedEventArgs e)
        {
            Filtrar();
        }

        public void Filtrar()
        {
            DateTime fechaInicio = datePickerFechaInicio.SelectedDate.Value.Date;
            DateTime fechaFin = datePickerFechaFin.SelectedDate.Value.Date;
            try
            {
                RefreshTable(pedidosNegocio.LeerPedidosPorFiltro(listPedidos, textBoxUsuarioId.Text, fechaInicio, fechaFin));
            }
            catch (Exception e)
            {
                mainWindow.SetStatusException(e);
            }
        }

        public void RefreshTable(List<Pedido> listPedidos = null)
        {
            if (listPedidos == null)
            {
                try
                {
                    listPedidos = pedidosNegocio.LeerPedidos();
                    this.listPedidos = listPedidos;
                }
                catch (Exception e)
                {
                    mainWindow.SetStatusException(e);
                }
            }

            if (listPedidos != null)
            {
                dataGrid.DataContext = listPedidos;
            }

        }

        private void DataGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            pedido = (Pedido)dataGrid.CurrentCell.Item;
            
            if (modo.Equals(Modos.Modificar))
            {
                mainWindow.SetUserControlChildren(new FichaPedidosUserControl(Modos.Modificar, mainWindow, this));
            }
            else if (modo.Equals(Modos.Eliminar))
            {
                if (Utilities.ConfirmDialog("Eliminar pedido", $"¿Está seguro que desea eliminar el pedido (ID: { pedido.PedidoID } - Total líneas: { pedido.ListLinped.Count })?"))
                {
                    try
                    {
                        MessageBox.Show(pedidosNegocio.EliminarPedido(pedido));
                        RefreshTable();
                    }
                    catch (Exception ex)
                    {
                        mainWindow.SetStatusException(ex);
                    }
                }
            }
            else if (modo.Equals(Modos.Consultar))
            {
                /*if (formParent.GetType().Equals(typeof(FacturaForm)))
                {
                    FacturaForm f = new FacturaForm(pedido);
                    f.Show();
                }*/
            }
        }

        private void BtnAnadirUsuario_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.SetUserControlChildren(new TableViewUsuariosUserControl(Modos.Seleccionar, mainWindow, this));
        }

        private void BtnQuitarUsuario_Click(object sender, RoutedEventArgs e)
        {
            textBoxUsuarioId.Text = "";
            textBoxUsuarioNombre.Text = "";
            Filtrar();
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