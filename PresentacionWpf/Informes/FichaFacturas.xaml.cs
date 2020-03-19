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
        private int totalLines = 25;

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
            pedido = pedidosNegocio.LeerPedido(1L);

            usuarioEmpresa = LoginWindow.GetUsuarioLogado();
            usuarioCliente = usuariosNegocio.LeerUsuario(pedido.UsuarioID);
            listLinpeds = pedidosNegocio.LeerLinped(pedido.PedidoID);
        }

        public IDocumentPaginatorSource Document
        {
            get { return _viewer.Document; }
            set { _viewer.Document = value; }
        }

        public void DocumentTitle(FixedPage fp, string title, int page, int totalPages)
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("", ""));
            data.Add(new KeyValuePair<string, string>(title, string.Format("Página {0} de {1}", page, totalPages)));
            data.Add(new KeyValuePair<string, string>("", ""));

            // GRID
            Grid myGrid = new Grid();
            myGrid.Width = 795;
            myGrid.Height = 60;
            myGrid.HorizontalAlignment = HorizontalAlignment.Left;
            myGrid.VerticalAlignment = VerticalAlignment.Top;
            // myGrid.ShowGridLines = true;
            
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

                TextBlock txt1 = new TextBlock();
                txt1.Text = header.Key;
                txt1.FontSize = 15;
                txt1.FontWeight = FontWeights.Bold;
                Grid.SetRow(txt1, n);
                Grid.SetColumn(txt1, 1);
                myGrid.Children.Add(txt1);

                TextBlock txt2 = new TextBlock();
                txt2.Text = header.Value;
                txt2.FontSize = 15;
                txt2.FontWeight = FontWeights.Bold;
                txt2.TextAlignment = TextAlignment.Right;
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
            data.Add(new KeyValuePair<string, string>("CLIENTE", ""));
            data.Add(new KeyValuePair<string, string>(string.Format("Nombre: {0}", usuarioCliente.Nombre), ""));
            data.Add(new KeyValuePair<string, string>(string.Format("Dirección: {0}", !string.IsNullOrEmpty(usuarioCliente.Calle) ? usuarioCliente.Calle : usuarioCliente.Calle2), ""));
            Provincia provinciaCliente = usuariosNegocio.LeerProvincia(usuarioCliente.ProvinciaID);
            data.Add(new KeyValuePair<string, string>(string.Format("Provincia: {0}", provinciaCliente.Nombre), ""));
            data.Add(new KeyValuePair<string, string>(string.Format("Documento: {0}", usuarioCliente.Dni), ""));
            Localidad localidadCliente = usuariosNegocio.LeerLocalidad(usuarioCliente.ProvinciaID, usuarioCliente.PuebloID);
            data.Add(new KeyValuePair<string, string>(string.Format("Localidad: {0}", localidadCliente.Nombre), ""));
            data.Add(new KeyValuePair<string, string>(string.Format("CP: {0}", usuarioCliente.Codpos), ""));
            data.Add(new KeyValuePair<string, string>("", ""));
            data.Add(new KeyValuePair<string, string>("EMPRESA", ""));
            data.Add(new KeyValuePair<string, string>(string.Format("Nombre: {0}", usuarioEmpresa.Nombre), string.Format("Código factura: {0}", pedido.PedidoID.ToString())));
            data.Add(new KeyValuePair<string, string>(string.Format("Dirección: {0}", !string.IsNullOrEmpty(usuarioEmpresa.Calle) ? usuarioEmpresa.Calle : usuarioEmpresa.Calle2), string.Format("Fecha factura: {0}", pedido.Fecha.ToString())));
            Provincia provinciaEmpresa = usuariosNegocio.LeerProvincia(usuarioEmpresa.ProvinciaID);
            data.Add(new KeyValuePair<string, string>(string.Format("Provincia: {0}", provinciaEmpresa.Nombre), ""));
            data.Add(new KeyValuePair<string, string>(string.Format("Documento: {0}", usuarioEmpresa.Dni), ""));
            Localidad localidadEmpresa = usuariosNegocio.LeerLocalidad(usuarioEmpresa.ProvinciaID, usuarioEmpresa.PuebloID);
            data.Add(new KeyValuePair<string, string>(string.Format("Localidad: {0}", localidadEmpresa.Nombre), ""));
            data.Add(new KeyValuePair<string, string>(string.Format("CP: {0}", usuarioEmpresa.Codpos), ""));

            // GRID
            Grid myGrid = new Grid();
            myGrid.Width = 795;
            myGrid.Height = 280;
            myGrid.HorizontalAlignment = HorizontalAlignment.Left;
            myGrid.VerticalAlignment = VerticalAlignment.Top;
            // myGrid.ShowGridLines = true;
            
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
                txt1.FontSize = 12;
                txt1.FontWeight = FontWeights.Regular;
                Grid.SetRow(txt1, n);
                Grid.SetColumn(txt1, 1);
                myGrid.Children.Add(txt1);
                
                // Add the second text cell to the Grid
                TextBlock txt2 = new TextBlock();
                txt2.Text = header.Value;
                txt2.FontSize = 12;
                txt2.FontWeight = FontWeights.Regular;
                Grid.SetRow(txt2, n);
                Grid.SetColumn(txt2, 3);
                myGrid.Children.Add(txt2);

                n++;
            }

            // Add the Grid as the Content of the Parent Window Object
            fp.Children.Add(myGrid);
        }

        public void Lineas(FixedPage fp, List<Linped> linpeds)
        {
            List<string[]> data = new List<string[]>();
            string[] header = { "Línea", "Descripción", "Cantidad", "Importe Bruto", "Importe Total" };
            data.Add(header);
            
            foreach(Linped linped in linpeds)
            {
                string[] s = { linped.Linea.ToString(), linped.ArticuloID, linped.Cantidad.ToString(),
                    string.Format("{0} €", linped.Importe.ToString()), string.Format("{0} €", 
                    (linped.Cantidad * linped.Importe).ToString()) };
                data.Add(s);
            }

            for(int a = linpeds.Count; a < totalLines; a++)
            {
                string[] s = { "", "", "", "", "" };
                data.Add(s);
            }

            // GRID
            Grid myGrid = new Grid();
            myGrid.Width = 795;
            myGrid.Height = 1000;
            myGrid.HorizontalAlignment = HorizontalAlignment.Left;
            myGrid.VerticalAlignment = VerticalAlignment.Top;
            // myGrid.ShowGridLines = true;
            
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
            bool first = true;
            foreach (string[] s in data)
            {
                RowDefinition rowDef = new RowDefinition();
                myGrid.RowDefinitions.Add(rowDef);

                TextBlock txt1 = new TextBlock();
                txt1.Text = s[0];
                txt1.FontSize = 12;
                txt1.FontWeight = first ? FontWeights.Bold : FontWeights.Regular;
                Grid.SetRow(txt1, n);
                Grid.SetColumn(txt1, 1);
                myGrid.Children.Add(txt1);

                TextBlock txt2 = new TextBlock();
                txt2.Text = s[1];
                txt2.FontSize = 12;
                txt2.FontWeight = first ? FontWeights.Bold : FontWeights.Regular;
                Grid.SetRow(txt2, n);
                Grid.SetColumn(txt2, 2);
                myGrid.Children.Add(txt2);

                TextBlock txt3 = new TextBlock();
                txt3.Text = s[2];
                txt3.FontSize = 12;
                txt3.FontWeight = first ? FontWeights.Bold : FontWeights.Regular;
                txt3.TextAlignment = TextAlignment.Center;
                Grid.SetRow(txt3, n);
                Grid.SetColumn(txt3, 3);
                myGrid.Children.Add(txt3);

                TextBlock txt4 = new TextBlock();
                txt4.Text = s[3];
                txt4.FontSize = 12;
                txt4.FontWeight = first ? FontWeights.Bold : FontWeights.Regular;
                txt4.TextAlignment = TextAlignment.Right;
                Grid.SetRow(txt4, n);
                Grid.SetColumn(txt4, 4);
                myGrid.Children.Add(txt4);

                TextBlock txt5 = new TextBlock();
                txt5.Text = s[4];
                txt5.FontSize = 12;
                txt5.FontWeight = first ? FontWeights.Bold : FontWeights.Regular;
                txt5.TextAlignment = TextAlignment.Right;
                Grid.SetRow(txt5, n);
                Grid.SetColumn(txt5, 5);
                myGrid.Children.Add(txt5);

                first = false;
                n++;
            }

            // Add the Grid as the Content of the Parent Window Object
            fp.Children.Add(myGrid);
        }

        public void Pie(FixedPage fp, TotalesFactura totalesFactura)
        {
            List<string[]> data = new List<string[]>();
            string[] header = { "Base Imponible", "I.V.A. (%)", "Total I.V.A.", "Total Factura" };
            data.Add(header);

            string[] s1 = { string.Format("{0} €", totalesFactura.BaseImponible.ToString()),
                string.Format("{0} %", totalesFactura.Iva.ToString()),
                string.Format("{0} €", totalesFactura.TotalIva.ToString()),
                string.Format("{0} €", totalesFactura.TotalFactura.ToString()) };
            data.Add(s1);

            // GRID
            Grid myGrid = new Grid();
            myGrid.Width = 795;
            myGrid.Height = 1100;
            myGrid.HorizontalAlignment = HorizontalAlignment.Left;
            myGrid.VerticalAlignment = VerticalAlignment.Top;
            // myGrid.ShowGridLines = true;

            // COLUMNS 
            ColumnDefinition colDef1 = new ColumnDefinition();
            colDef1.Width = new GridLength(50, GridUnitType.Pixel);
            ColumnDefinition colDef2 = new ColumnDefinition();
            ColumnDefinition colDef3 = new ColumnDefinition();
            ColumnDefinition colDef4 = new ColumnDefinition();
            ColumnDefinition colDef5 = new ColumnDefinition();
            ColumnDefinition colDef6 = new ColumnDefinition();
            colDef6.Width = new GridLength(50, GridUnitType.Pixel);
            myGrid.ColumnDefinitions.Add(colDef1);
            myGrid.ColumnDefinitions.Add(colDef2);
            myGrid.ColumnDefinitions.Add(colDef3);
            myGrid.ColumnDefinitions.Add(colDef4);
            myGrid.ColumnDefinitions.Add(colDef5);
            myGrid.ColumnDefinitions.Add(colDef6);

            int n = 32;
            for (int i = 0; i < n; i++)
            {
                string[] s = { "", "", "", "", "" };
                data.Add(s);
            }
            bool first = true;
            foreach (string[] s in data)
            {
                RowDefinition rowDef = new RowDefinition();
                myGrid.RowDefinitions.Add(rowDef);

                TextBlock txt1 = new TextBlock();
                txt1.Text = s[0];
                txt1.FontSize = 12;
                txt1.FontWeight = first ? FontWeights.Bold : FontWeights.Regular;
                txt1.TextAlignment = TextAlignment.Center;
                Grid.SetRow(txt1, n);
                Grid.SetColumn(txt1, 1);
                myGrid.Children.Add(txt1);
                
                TextBlock txt2 = new TextBlock();
                txt2.Text = s[1];
                txt2.FontSize = 12;
                txt2.FontWeight = first ? FontWeights.Bold : FontWeights.Regular;
                txt2.TextAlignment = TextAlignment.Center;
                Grid.SetRow(txt2, n);
                Grid.SetColumn(txt2, 2);
                myGrid.Children.Add(txt2);

                TextBlock txt3 = new TextBlock();
                txt3.Text = s[2];
                txt3.FontSize = 12;
                txt3.FontWeight = first ? FontWeights.Bold : FontWeights.Regular;
                txt3.TextAlignment = TextAlignment.Center;
                Grid.SetRow(txt3, n);
                Grid.SetColumn(txt3, 3);
                myGrid.Children.Add(txt3);

                TextBlock txt4 = new TextBlock();
                txt4.Text = s[3];
                txt4.FontSize = 12;
                txt4.FontWeight = first ? FontWeights.Bold : FontWeights.Regular;
                txt4.TextAlignment = TextAlignment.Center;
                Grid.SetRow(txt4, n);
                Grid.SetColumn(txt4, 4);
                myGrid.Children.Add(txt4);

                first = false;
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
            List<List<Linped>> tmpList1 = new List<List<Linped>>();
            List<Linped> tmpList2 = new List<Linped>();
            int cont1 = 0;
            int cont2 = 0;
            foreach(Linped linped in listLinpeds)
            {
                if(cont1 == totalLines || listLinpeds.Count == cont2 + 1)
                {
                    cont1 = 0;
                    tmpList1.Add(tmpList2);
                    tmpList2 = new List<Linped>();
                }

                tmpList2.Add(linped);

                cont1++;
                cont2++;
            }

            for(int i = 0; i <= listLinpeds.Count / totalLines; i++)
            {
                int n1 = (listLinpeds.Count / totalLines) + 1;
                doc.DocumentPaginator.PageSize = tam;
                FixedPage fp = new FixedPage
                {
                    Width = doc.DocumentPaginator.PageSize.Width,
                    Height = doc.DocumentPaginator.PageSize.Height
                };

                DocumentTitle(fp, "FACTURAS", i + 1, listLinpeds.Count / totalLines + 1);
                Encabezado(fp);
                Lineas(fp, tmpList1[i]);

                Pie(fp, new TotalesFactura(pedidosNegocio.CalcularBaseImponible(listLinpeds), pedidosNegocio.GetIva(), pedidosNegocio.CalcularTotalIva(listLinpeds), pedidosNegocio.CalcularImporteTotal(listLinpeds)));

                //Añadimos la página al documento
                PageContent pc = new PageContent();
                ((IAddChild)pc).AddChild(fp);
                doc.Pages.Add(pc);
            }

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