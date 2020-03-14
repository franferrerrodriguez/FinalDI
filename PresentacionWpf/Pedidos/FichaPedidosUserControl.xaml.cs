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
            listLinpeds = new List<Linped>();

            datePickerFecha.Text = DateTime.Now.Date.ToString();

            if (modo.Equals(Modos.Insertar))
            {
                btnAnadirArticulo.IsEnabled = false;
                btnQuitarArticulo.IsEnabled = false;
                textBoxPedidoId.Text = (pedidosNegocio.Max() + 1).ToString();
            }
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
            else
                try
                {
                    pedido = new Pedido(long.Parse(textBoxPedidoId.Text), long.Parse(textBoxUsuarioId.Text), datePickerFecha.SelectedDate.Value.Date, listLinpeds);
                    if (modo.Equals(Modos.Insertar))
                    {
                        MessageBox.Show(pedidosNegocio.InsertarPedido(pedido));
                        modo = Modos.Modificar;
                        textBoxPedidoId.IsEnabled = false;
                        datePickerFecha.IsEnabled = false;
                        btnAnadirArticulo.IsEnabled = true;
                        btnQuitarArticulo.IsEnabled = true;
                    }
                    else if (modo.Equals(Modos.Modificar))
                        MessageBox.Show(pedidosNegocio.ActualizarPedido(pedido));
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

                listLinpeds = pedidosNegocio.LeerLinped(pedido.PedidoID);

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
                    listLinpedsNegocio = LinpedNegocio.GenerarListLinped(listLinpeds);
                    listViewLineasPedido.ItemsSource = listLinpedsNegocio;
                    UpdateTotales();
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
                textBoxBi.Text = pedidosNegocio.CalcularBaseImponible(listLinpeds).ToString();
                textBoxIva.Text = pedidosNegocio.GetIva().ToString();
                textBoxTotalIva.Text = pedidosNegocio.CalcularTotalIva(listLinpeds).ToString();
                textBoxImporteTotal.Text = pedidosNegocio.CalcularImporteTotal(listLinpeds).ToString();
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

        public void AnyadirLineaArticulo(Articulo articulo)
        {
            if (pedido != null && articulo != null)
            {
                listLinpeds.Add(new Linped(pedido.PedidoID, listLinpeds.Count + 1, articulo.ArticuloID, articulo.Pvp ?? 0, 0));
                RefreshTable();
            }
        }

        private void BtnQuitarArticulo_Click(object sender, RoutedEventArgs e)
        {
            int index = listViewLineasPedido.SelectedIndex;
            if (index != -1)
            {
                List<Linped> tmpListLinped = new List<Linped>();
                int i = 0;
                int linea = 1;
                foreach (Linped linped in listLinpeds)
                {
                    if (!index.Equals(i))
                    {
                        linped.Linea = linea;
                        tmpListLinped.Add(linped);
                        linea++;
                    }
                    i++;
                }
                listLinpeds.Clear();
                listLinpeds = tmpListLinped;
                RefreshTable();
            }

        }

        private void TextBoxLineCantidad_LostFocus(object sender, RoutedEventArgs e)
        {
            List<LinpedNegocio> items = (List<LinpedNegocio>)listViewLineasPedido.ItemsSource;
            int i = 0;
            foreach (LinpedNegocio item in items)
            {
                listLinpeds[i].Cantidad = item.Cantidad;
                i++;
            }
            RefreshTable();
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