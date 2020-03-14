using Capa_entidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Utils;
using static Utils.Utilities;

namespace PresentacionWpf
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class FichaPedidosUserControl : UserControl
    {
        public Modos modo;
        private MainWindow mainWindow;
        private UserControl userControlParent;
        private TableViewPedidosUserControl tableViewUsuariosUserControl;
        private PedidosNegocio pedidosNegocio;
        private ProductosNegocio productosNegocio;
        private UsuariosNegocio usuariosNegocio;
        private Pedido pedido;
        private List<Linped> listLinpeds;
        private List<LinpedNegocio> listLinpedsNegocio;

        public FichaPedidosUserControl(Modos modo, Window windowParent = null, UserControl userControlParent = null)
        {
            InitializeComponent();
            this.modo = modo;
            mainWindow = (MainWindow)windowParent;
            this.userControlParent = userControlParent;
            tableViewUsuariosUserControl = (TableViewPedidosUserControl)userControlParent;
            UtilsControl.SetTitulo(modo, labelTitle, "pedidos");
            mainWindow.SetStatusException();

            pedidosNegocio = new PedidosNegocio();
            productosNegocio = new ProductosNegocio();
            usuariosNegocio = new UsuariosNegocio();
            
            datePickerFecha.Text = DateTime.Now.Date.ToString();

            if(modo.Equals(Modos.Insertar))
                textBoxPedidoId.Text = (pedidosNegocio.Max() + 1).ToString();
            else if (modo.Equals(Modos.Modificar))
                Cargar(tableViewUsuariosUserControl.pedido);
        }

        private void BtnGenerarUsuarioId_Click(object sender, RoutedEventArgs e)
        {
            textBoxPedidoId.Text = (pedidosNegocio.Max() + 1).ToString();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPedidoId.Text))
                MessageBox.Show("Debe seleccionar un Id de pedido antes de poder crear el pedido.");
            else if (string.IsNullOrEmpty(textBoxUsuarioId.Text))
                MessageBox.Show("Debe seleccionar un usuario antes de poder crear el pedido.");
            else if (listLinpeds.Count.Equals(0))
                MessageBox.Show("Debe introducir al menos una línea de artículo antes de poder crear el pedido.");
            else
                try
                {
                    if (modo.Equals(Modos.Insertar))
                        MessageBox.Show(pedidosNegocio.InsertarPedido(new Pedido(long.Parse(textBoxPedidoId.Text), long.Parse(textBoxUsuarioId.Text), datePickerFecha.SelectedDate.Value.Date, listLinpeds)));
                    else if (modo.Equals(Modos.Modificar))
                        MessageBox.Show(pedidosNegocio.ActualizarPedido(new Pedido(long.Parse(textBoxPedidoId.Text), long.Parse(textBoxUsuarioId.Text), datePickerFecha.SelectedDate.Value.Date, listLinpeds)));
                }
                catch (Exception ex)
                {
                    mainWindow.SetStatusException(ex);
                }
        }

        public void Cargar(Pedido pedido)
        {
            try
            {
                this.pedido = pedido;

                textBoxPedidoId.IsEnabled = false;
                datePickerFecha.IsEnabled = false;
                btnGenerarUsuarioId.IsEnabled = false;
                btnAnadirUsuario.IsEnabled = false;
                btnQuitarUsuario.IsEnabled = false;

                textBoxPedidoId.Text = pedido.PedidoID.ToString();
                datePickerFecha.SelectedDate = pedido.Fecha;
                textBoxUsuarioId.Text = pedido.UsuarioID.ToString();
                Usuario usuario = usuariosNegocio.LeerUsuario(pedido.UsuarioID);
                textBoxUsuarioNombre.Text = usuario.Nombre;

                RefreshTable();
            }
            catch (Exception e)
            {
                mainWindow.SetStatusException(e);
            }
        }

        private void RefreshTable()
        {
            if(pedido != null)
            {
                try
                {
                    listLinpeds = pedidosNegocio.LeerLinped(pedido.PedidoID);
                    listLinpedsNegocio = LinpedNegocio.GenerarListLinped(listLinpeds);
                    lvDataBinding.ItemsSource = listLinpeds;
                    // UpdateTotales();
                }
                catch (Exception e)
                {
                    mainWindow.SetStatusException(e);
                }
            }
        }

        private void UpdateTotales()
        {
            try
            {
                //textBoxBiUsuarioFichaPedidosForm.Text = pedidosNegocio.CalcularBaseImponible(listLinpeds).ToString();
                //textBoxIvaUsuarioFichaPedidosForm.Text = pedidosNegocio.GetIva().ToString();
                //textBoxTotalIvaUsuarioFichaPedidosForm.Text = pedidosNegocio.CalcularTotalIva(listLinpeds).ToString();
                //textBoxImporteTotalUsuarioFichaPedidosForm.Text = pedidosNegocio.CalcularImporteTotal(listLinpeds).ToString();
            }
            catch (Exception e)
            {
                mainWindow.SetStatusException(e);
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
        }

        private void BtnAnadirArticulo_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.SetUserControlChildren(new TableViewProductosUserControl(Modos.Seleccionar, mainWindow, this));
        }

        private void BtnQuitarArticulo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("QUITAR ARTÍCULO");
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Close()
        {
            if (userControlParent != null && typeof(TableViewPedidosUserControl).Equals(userControlParent.GetType()))
            {
                TableViewPedidosUserControl uc = (TableViewPedidosUserControl)userControlParent;
                mainWindow.SetUserControlChildren(userControlParent);
            }
            else
                mainWindow.SetUserControlChildren(userControlParent);
        }


    }
}