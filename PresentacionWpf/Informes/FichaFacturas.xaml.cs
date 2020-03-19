using Capa_entidades;
using CapaNegocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using static Utils.Utilities;

namespace PresentacionWpf
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class FichaFacturas : UserControl
    {
        public Modos modo;
        private MainWindow mainWindow;
        private UserControl userControlParent;
        private TableViewUsuariosUserControl tableViewUsuariosUserControl;
        private FixedDocument doc;

        private Pedido pedido;
        private PedidosNegocio pedidosNegocio;
        private ProductosNegocio productosNegocio;
        private UsuariosNegocio usuariosNegocio;
        private Usuario usuarioEmpresa;
        private Usuario usuarioCliente;
        private List<Linped> listLinpeds;

        public FichaFacturas(Modos modo, Window windowParent = null, UserControl userControlParent = null)
        {
            InitializeComponent();
            this.modo = modo;
            mainWindow = (MainWindow)windowParent;
            this.userControlParent = userControlParent;
            tableViewUsuariosUserControl = (TableViewUsuariosUserControl)userControlParent;
            UtilsControl.SetTitulo(modo, labelTitle, "facturas");

            pedidosNegocio = new PedidosNegocio();
            productosNegocio = new ProductosNegocio();
            usuariosNegocio = new UsuariosNegocio();

            // Que se seleccione de la tabla
            pedido = pedidosNegocio.LeerPedido(3L);

            usuarioEmpresa = LoginWindow.GetUsuarioLogado();
            usuarioCliente = usuariosNegocio.LeerUsuario(pedido.UsuarioID);
            listLinpeds = pedidosNegocio.LeerLinped(pedido.PedidoID);
        }

        public IDocumentPaginatorSource Document
        {
            get { return _viewer.Document; }
            set { _viewer.Document = value; }
        }

        public void Header(FixedPage fp)
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("", ""));
            data.Add(new KeyValuePair<string, string>("FACTURAS", "Página 1 de 1"));
            data.Add(new KeyValuePair<string, string>("____________________________", "____________________________"));

            // Create the Grid
            Grid myGrid = new Grid();
            myGrid.Width = 795;
            myGrid.Height = 60;
            myGrid.HorizontalAlignment = HorizontalAlignment.Left;
            myGrid.VerticalAlignment = VerticalAlignment.Top;
            // myGrid.ShowGridLines = true;

            //////////////// HEADER ////////////////
            // COLUMNS 
            ColumnDefinition colDef1 = new ColumnDefinition();
            colDef1.Width = new GridLength(50, GridUnitType.Pixel);
            ColumnDefinition colDef2 = new ColumnDefinition();
            ColumnDefinition colDef3 = new ColumnDefinition();
            colDef3.Width = new GridLength(50, GridUnitType.Pixel);
            ColumnDefinition colDef4 = new ColumnDefinition();
            ColumnDefinition colDef5 = new ColumnDefinition();
            colDef5.Width = new GridLength(50, GridUnitType.Pixel);
            myGrid.ColumnDefinitions.Add(colDef1);
            myGrid.ColumnDefinitions.Add(colDef2);
            myGrid.ColumnDefinitions.Add(colDef3);
            myGrid.ColumnDefinitions.Add(colDef4);
            myGrid.ColumnDefinitions.Add(colDef5);

            int n = 0;
            for (int i = 0; i < n; i++)
                data.Add(new KeyValuePair<string, string>("", ""));
            foreach (KeyValuePair<string, string> header in data)
            {
                RowDefinition rowDef = new RowDefinition();
                myGrid.RowDefinitions.Add(rowDef);
                // Add the second text cell to the Grid
                TextBlock txt1 = new TextBlock();
                txt1.Text = header.Key;
                txt1.FontSize = n == 1 ? 16 : 12;
                txt1.FontWeight = n == 1 ? FontWeights.Bold : FontWeights.Regular;
                Grid.SetRow(txt1, n);
                Grid.SetColumn(txt1, 1);
                myGrid.Children.Add(txt1);

                // Add the second text cell to the Grid
                TextBlock txt2 = new TextBlock();
                txt2.Text = header.Value;
                txt2.FontSize = n == 1 ? 16 : 12;
                txt2.FontWeight = n == 1 ? FontWeights.Bold : FontWeights.Regular;
                Grid.SetRow(txt2, n);
                Grid.SetColumn(txt2, 3);
                myGrid.Children.Add(txt2);

                n++;
            }

            // Add the Grid as the Content of the Parent Window Object
            fp.Children.Add(myGrid);
        }

        public void Encabezado(FixedPage fp)
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>(usuarioCliente.Nombre, ""));
            data.Add(new KeyValuePair<string, string>(!string.IsNullOrEmpty(usuarioCliente.Calle) ? usuarioCliente.Calle : usuarioCliente.Calle2, ""));
            Provincia provinciaCliente = usuariosNegocio.LeerProvincia(usuarioCliente.ProvinciaID);
            data.Add(new KeyValuePair<string, string>(provinciaCliente.Nombre, ""));
            data.Add(new KeyValuePair<string, string>(usuarioCliente.Dni, ""));
            Localidad localidadCliente = usuariosNegocio.LeerLocalidad(usuarioCliente.ProvinciaID, usuarioCliente.PuebloID);
            data.Add(new KeyValuePair<string, string>(localidadCliente.Nombre, ""));
            data.Add(new KeyValuePair<string, string>(usuarioCliente.Codpos, ""));
            data.Add(new KeyValuePair<string, string>("", ""));
            data.Add(new KeyValuePair<string, string>(usuarioEmpresa.Nombre, pedido.PedidoID.ToString()));
            data.Add(new KeyValuePair<string, string>(!string.IsNullOrEmpty(usuarioEmpresa.Calle) ? usuarioEmpresa.Calle : usuarioEmpresa.Calle2, pedido.Fecha.ToString()));
            Provincia provinciaEmpresa = usuariosNegocio.LeerProvincia(usuarioEmpresa.ProvinciaID);
            data.Add(new KeyValuePair<string, string>(provinciaEmpresa.Nombre, ""));
            data.Add(new KeyValuePair<string, string>(usuarioEmpresa.Dni, ""));
            Localidad localidadEmpresa = usuariosNegocio.LeerLocalidad(usuarioEmpresa.ProvinciaID, usuarioEmpresa.PuebloID);
            data.Add(new KeyValuePair<string, string>(localidadEmpresa.Nombre, ""));
            data.Add(new KeyValuePair<string, string>(usuarioEmpresa.Codpos, ""));

            // Create the Grid
            Grid myGrid = new Grid();
            myGrid.Width = 795;
            myGrid.Height = 280;
            myGrid.HorizontalAlignment = HorizontalAlignment.Left;
            myGrid.VerticalAlignment = VerticalAlignment.Top;
            // myGrid.ShowGridLines = true;

            //////////////// HEADER ////////////////
            // COLUMNS 
            ColumnDefinition colDef1 = new ColumnDefinition();
            colDef1.Width = new GridLength(50, GridUnitType.Pixel);
            ColumnDefinition colDef2 = new ColumnDefinition();
            ColumnDefinition colDef3 = new ColumnDefinition();
            colDef3.Width = new GridLength(50, GridUnitType.Pixel);
            ColumnDefinition colDef4 = new ColumnDefinition();
            ColumnDefinition colDef5 = new ColumnDefinition();
            colDef5.Width = new GridLength(50, GridUnitType.Pixel);
            myGrid.ColumnDefinitions.Add(colDef1);
            myGrid.ColumnDefinitions.Add(colDef2);
            myGrid.ColumnDefinitions.Add(colDef3);
            myGrid.ColumnDefinitions.Add(colDef4);
            myGrid.ColumnDefinitions.Add(colDef5);

            int n = 4;
            for(int i = 0; i < n; i++)
                data.Add(new KeyValuePair<string, string>("", ""));
            foreach (KeyValuePair<string, string> header in data)
            {
                RowDefinition rowDef = new RowDefinition();
                myGrid.RowDefinitions.Add(rowDef);
                // Add the second text cell to the Grid
                TextBlock txt1 = new TextBlock();
                txt1.Text = header.Key;
                txt1.FontSize = n == 1 ? 16 : 12;
                txt1.FontWeight = n == 1 ? FontWeights.Bold : FontWeights.Regular;
                Grid.SetRow(txt1, n);
                Grid.SetColumn(txt1, 1);
                myGrid.Children.Add(txt1);
                
                // Add the second text cell to the Grid
                TextBlock txt2 = new TextBlock();
                txt2.Text = header.Value;
                txt2.FontSize = n == 1 ? 16 : 12;
                txt2.FontWeight = n == 1 ? FontWeights.Bold : FontWeights.Regular;
                Grid.SetRow(txt2, n);
                Grid.SetColumn(txt2, 3);
                myGrid.Children.Add(txt2);

                n++;
            }

            // Add the Grid as the Content of the Parent Window Object
            fp.Children.Add(myGrid);
        }

        public void Lineas(FixedPage fp)
        {
            List<string[]> data = new List<string[]>();
            string[] header = { "ID", "1", "1", "1", "1" };
            data.Add(header);
            for (int i = 0; i < 25; i++)
            {
                string[] s = { "1", "1", "1", "1", "1" };
                data.Add(s);
            }

            // Create the Grid
            Grid myGrid = new Grid();
            myGrid.Width = 795;
            myGrid.Height = 1000;
            myGrid.HorizontalAlignment = HorizontalAlignment.Left;
            myGrid.VerticalAlignment = VerticalAlignment.Top;
            // myGrid.ShowGridLines = true;

            //////////////// HEADER ////////////////
            // COLUMNS 
            ColumnDefinition colDef1 = new ColumnDefinition();
            colDef1.Width = new GridLength(50, GridUnitType.Pixel);
            ColumnDefinition colDef2 = new ColumnDefinition();
            ColumnDefinition colDef3 = new ColumnDefinition();
            ColumnDefinition colDef4 = new ColumnDefinition();
            ColumnDefinition colDef5 = new ColumnDefinition();
            ColumnDefinition colDef6 = new ColumnDefinition();
            ColumnDefinition colDef7 = new ColumnDefinition();
            colDef7.Width = new GridLength(50, GridUnitType.Pixel);
            myGrid.ColumnDefinitions.Add(colDef1);
            myGrid.ColumnDefinitions.Add(colDef2);
            myGrid.ColumnDefinitions.Add(colDef3);
            myGrid.ColumnDefinitions.Add(colDef4);
            myGrid.ColumnDefinitions.Add(colDef5);
            myGrid.ColumnDefinitions.Add(colDef6);
            myGrid.ColumnDefinitions.Add(colDef7);

            int n = 12;
            for(int i = 0; i < n; i++)
            {
                string[] s = { "", "", "", "", "" };
                data.Add(s);
            }
            foreach (string[] s in data)
            {
                RowDefinition rowDef = new RowDefinition();
                myGrid.RowDefinitions.Add(rowDef);

                TextBlock txt1 = new TextBlock();
                txt1.Text = s[0];
                txt1.FontSize = n == 1 ? 16 : 12;
                txt1.FontWeight = n == 1 ? FontWeights.Bold : FontWeights.Regular;
                Grid.SetRow(txt1, n);
                Grid.SetColumn(txt1, 1);
                myGrid.Children.Add(txt1);

                TextBlock txt2 = new TextBlock();
                txt2.Text = s[1];
                txt2.FontSize = n == 1 ? 16 : 12;
                txt2.FontWeight = n == 1 ? FontWeights.Bold : FontWeights.Regular;
                Grid.SetRow(txt2, n);
                Grid.SetColumn(txt2, 2);
                myGrid.Children.Add(txt2);

                TextBlock txt3 = new TextBlock();
                txt3.Text = s[2];
                txt3.FontSize = n == 1 ? 16 : 12;
                txt3.FontWeight = n == 1 ? FontWeights.Bold : FontWeights.Regular;
                txt3.TextAlignment = TextAlignment.Center;
                Grid.SetRow(txt3, n);
                Grid.SetColumn(txt3, 3);
                myGrid.Children.Add(txt3);

                TextBlock txt4 = new TextBlock();
                txt4.Text = s[3];
                txt4.FontSize = n == 1 ? 16 : 12;
                txt4.FontWeight = n == 1 ? FontWeights.Bold : FontWeights.Regular;
                txt4.TextAlignment = TextAlignment.Right;
                Grid.SetRow(txt4, n);
                Grid.SetColumn(txt4, 4);
                myGrid.Children.Add(txt4);

                TextBlock txt5 = new TextBlock();
                txt5.Text = s[4];
                txt5.FontSize = n == 1 ? 16 : 12;
                txt5.FontWeight = n == 1 ? FontWeights.Bold : FontWeights.Regular;
                txt5.TextAlignment = TextAlignment.Right;
                Grid.SetRow(txt5, n);
                Grid.SetColumn(txt5, 5);
                myGrid.Children.Add(txt5);

                n++;
            }

            // Add the Grid as the Content of the Parent Window Object
            fp.Children.Add(myGrid);
        }

        /// <summary>
        /// Crea un documento de manera dinámica mediante objetos.
        /// </summary>
        /// <param name="tam"></param>
        private void CrearDocumento(Size tam)
        {
            doc.DocumentPaginator.PageSize = tam;
            FixedPage fp = new FixedPage
            {
                Width = doc.DocumentPaginator.PageSize.Width,
                Height = doc.DocumentPaginator.PageSize.Height
            };

            Header(fp);
            Encabezado(fp);
            Lineas(fp);

            //Añadimos la página al documento
            PageContent pc = new PageContent();
            ((IAddChild)pc).AddChild(fp);
            doc.Pages.Add(pc);

            // Creamos un textblock para imprimerlo
            /*TextBlock blk = new TextBlock
            {
                Text = "Esto es el texto que se impimirá",
                FontFamily = new FontFamily("Arial"),
                FontSize = 12,
                FontStretch = FontStretches.Expanded,
                FontStyle = FontStyles.Italic,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(200, 400, 50, 10),
                Padding = new Thickness(2)
            };
            fp.Children.Add(blk);

            //Añadimos la página al documento
            PageContent pc = new PageContent();
            ((IAddChild)pc).AddChild(fp);
            doc.Pages.Add(pc);

            // Añadimos una segunda página
            FixedPage fp2 = new FixedPage
            {
                Width = doc.DocumentPaginator.PageSize.Width,
                Height = doc.DocumentPaginator.PageSize.Height
            };
            TextBlock page2Text = new TextBlock();
            page2Text.Text = "No es la primera hoja";
            page2Text.FontSize = 40;
            page2Text.Margin = new Thickness(96);
            fp2.Children.Add(page2Text);

            PageContent page2Content = new PageContent();
            ((IAddChild)page2Content).AddChild(fp2);
            doc.Pages.Add(page2Content);*/
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            doc = new FixedDocument();
            PrintDialog pd = new PrintDialog();
            CrearDocumento(new Size(pd.PrintableAreaWidth, pd.PrintableAreaHeight));
            // asignamos el documento al viewer
            Document = doc;
            pd = null;

            // Eliminamos la ventana de búsqueda
            DocumentViewer dv1 = LogicalTreeHelper.FindLogicalNode(this, "_viewer") as DocumentViewer;
            ContentControl cc = dv1.Template.FindName("PART_FindToolBarHost", dv1) as ContentControl;
            cc.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Desde esta función imprimimos sin usar el DocumentViewer. Usamos el cuadro de dialogo para imprimir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Print_Click(object sender, RoutedEventArgs e)
        {
            // Seleccionamos una impresora y obtenemos su configuración
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == true)
            {
                // el documento se crea al cargar el formulario.
                pd.PrintDocument(doc.DocumentPaginator, "Mi documento");
            }
        }

    }

    public static class FixedDocumentExtended
    {

        public static void AddPages(this FixedDocument fixedDocument)
        {
            var enumerator = fixedDocument.Resources.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var pageContent = ((DictionaryEntry)enumerator.Current).Value as PageContent;
                if (pageContent != null)
                {
                    fixedDocument.Pages.Add(pageContent);
                }
            }
        }
    }

}