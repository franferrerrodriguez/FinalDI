using PresentacionWpf;
using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using Utils;
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
        System.Windows.Documents.FixedDocument doc;

        public FichaFacturas(Modos modo, Window windowParent = null, UserControl userControlParent = null)
        {
            InitializeComponent();
            this.modo = modo;
            mainWindow = (MainWindow)windowParent;
            this.userControlParent = userControlParent;
            tableViewUsuariosUserControl = (TableViewUsuariosUserControl)userControlParent;
            UtilsControl.SetTitulo(modo, labelTitle, "facturas");
        }

        public IDocumentPaginatorSource Document
        {
            get { return _viewer.Document; }
            set { _viewer.Document = value; }
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


            // Create the Grid
            Grid myGrid = new Grid();
            myGrid.Width = 250;
            myGrid.Height = 100;
            myGrid.HorizontalAlignment = HorizontalAlignment.Left;
            myGrid.VerticalAlignment = VerticalAlignment.Top;
            myGrid.ShowGridLines = true;

            // Define the Columns
            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();
            ColumnDefinition colDef3 = new ColumnDefinition();
            myGrid.ColumnDefinitions.Add(colDef1);
            myGrid.ColumnDefinitions.Add(colDef2);
            myGrid.ColumnDefinitions.Add(colDef3);

            // Define the Rows
            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();
            RowDefinition rowDef4 = new RowDefinition();
            myGrid.RowDefinitions.Add(rowDef1);
            myGrid.RowDefinitions.Add(rowDef2);
            myGrid.RowDefinitions.Add(rowDef3);
            myGrid.RowDefinitions.Add(rowDef4);

            // Add the first text cell to the Grid
            TextBlock txt1 = new TextBlock();
            txt1.Text = "2005 Products Shipped";
            txt1.FontSize = 20;
            txt1.FontWeight = FontWeights.Bold;
            Grid.SetColumnSpan(txt1, 3);
            Grid.SetRow(txt1, 0);

            // Add the second text cell to the Grid
            TextBlock txt2 = new TextBlock();
            txt2.Text = "Quarter 1";
            txt2.FontSize = 12;
            txt2.FontWeight = FontWeights.Bold;
            Grid.SetRow(txt2, 1);
            Grid.SetColumn(txt2, 0);

            // Add the third text cell to the Grid
            TextBlock txt3 = new TextBlock();
            txt3.Text = "Quarter 2";
            txt3.FontSize = 12;
            txt3.FontWeight = FontWeights.Bold;
            Grid.SetRow(txt3, 1);
            Grid.SetColumn(txt3, 1);

            // Add the fourth text cell to the Grid
            TextBlock txt4 = new TextBlock();
            txt4.Text = "Quarter 3";
            txt4.FontSize = 12;
            txt4.FontWeight = FontWeights.Bold;
            Grid.SetRow(txt4, 1);
            Grid.SetColumn(txt4, 2);

            // Add the sixth text cell to the Grid
            TextBlock txt5 = new TextBlock();
            Double db1 = new Double();
            db1 = 50000;
            txt5.Text = db1.ToString();
            Grid.SetRow(txt5, 2);
            Grid.SetColumn(txt5, 0);

            // Add the seventh text cell to the Grid
            TextBlock txt6 = new TextBlock();
            Double db2 = new Double();
            db2 = 100000;
            txt6.Text = db2.ToString();
            Grid.SetRow(txt6, 2);
            Grid.SetColumn(txt6, 1);

            // Add the final text cell to the Grid
            TextBlock txt7 = new TextBlock();
            Double db3 = new Double();
            db3 = 150000;
            txt7.Text = db3.ToString();
            Grid.SetRow(txt7, 2);
            Grid.SetColumn(txt7, 2);

            // Total all Data and Span Three Columns
            TextBlock txt8 = new TextBlock();
            txt8.FontSize = 16;
            txt8.FontWeight = FontWeights.Bold;
            txt8.Text = "Total Units: " + (db1 + db2 + db3).ToString();
            Grid.SetRow(txt8, 3);
            Grid.SetColumnSpan(txt8, 3);

            // Add the TextBlock elements to the Grid Children collection
            myGrid.Children.Add(txt1);
            myGrid.Children.Add(txt2);
            myGrid.Children.Add(txt3);
            myGrid.Children.Add(txt4);
            myGrid.Children.Add(txt5);
            myGrid.Children.Add(txt6);
            myGrid.Children.Add(txt7);
            myGrid.Children.Add(txt8);

            // Add the Grid as the Content of the Parent Window Object
            fp.Children.Add(myGrid);

            // Creamos un textblock para imprimerlo
            TextBlock blk = new TextBlock
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
            doc.Pages.Add(page2Content);

        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            doc = new System.Windows.Documents.FixedDocument();
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

        /// <summary>
        /// Impresión leyendo el documento creado en xaml.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintButton2_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Documents.FixedDocument doc = Application.LoadComponent(new Uri("/FixedDocument.xaml", UriKind.Relative)) as System.Windows.Documents.FixedDocument;
            doc.AddPages();
            Document = doc;
        }
    }
    public static class FixedDocumentExtended
    {
        public static void AddPages(this System.Windows.Documents.FixedDocument fixedDocument)
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

