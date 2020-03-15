using Capa_entidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Utils;
using static Utils.Utilities;

namespace PresentacionWpf
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class FichaProductosUserControl : UserControl
    {
        public Modos modo;
        private MainWindow mainWindow;
        private UserControl userControlParent;
        private TableViewUsuariosUserControl tableViewUsuariosUserControl;
        private ProductosNegocio productosNegocio;

        public FichaProductosUserControl(Modos modo, Window windowParent = null, UserControl userControlParent = null)
        {
            InitializeComponent();
            this.modo = modo;
            mainWindow = (MainWindow)windowParent;
            this.userControlParent = userControlParent;
            tableViewUsuariosUserControl = (TableViewUsuariosUserControl)userControlParent;
            UtilsControl.SetTitulo(modo, labelTitle, "productos");
            mainWindow.SetStatusException();

            productosNegocio = new ProductosNegocio();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.SetUserControlChildren(userControlParent);
        }

        private void ListViewArticulos_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Articulo articulo = (Articulo)(sender as ListView).SelectedItem;
            
            if (articulo != null)
            {
                try
                {
                    List<SubProductoDinamico> list = new List<SubProductoDinamico>();
                    switch (articulo.TipoArticuloID)
                    {
                        case 1:
                            Tv tv = productosNegocio.LeerTv(articulo.ArticuloID);
                            list.Add(new SubProductoDinamico("Panel", tv.Panel, "Pantalla", tv.Pantalla.ToString()));
                            list.Add(new SubProductoDinamico("Resolucion", tv.Resolucion, "HdReadyFullHd", tv.Hdreadyfullhd));
                            list.Add(new SubProductoDinamico("Tdt", tv.Tdt ? "Sí" : "No"));
                            break;
                        case 2:
                            Memoria memoria = productosNegocio.LeerMemoria(articulo.ArticuloID);
                            list.Add(new SubProductoDinamico("Tipo", memoria.Tipo));
                            break;
                        case 3:
                            Camara camara = productosNegocio.LeerCamara(articulo.ArticuloID);
                            list.Add(new SubProductoDinamico("Resolucion", camara.Resolucion, "Sensor", camara.Sensor));
                            list.Add(new SubProductoDinamico("Tipo", camara.Tipo, "Factor", camara.Factor));
                            list.Add(new SubProductoDinamico("Objetivo", camara.Objetivo, "Pantalla", camara.Pantalla));
                            list.Add(new SubProductoDinamico("Zoom", camara.Zoom));
                            break;
                        case 4:
                            Objetivo objetivo = productosNegocio.LeerObjetivo(articulo.ArticuloID);
                            list.Add(new SubProductoDinamico("Tipo", objetivo.Tipo, "Montura", objetivo.Montura));
                            list.Add(new SubProductoDinamico("Focal", objetivo.Focal, "Apertura", objetivo.Apertura));
                            list.Add(new SubProductoDinamico("Especiales", objetivo.Especiales));
                            break;
                    }
                    GenerarLineaDinamica(list);
                }
                catch (Exception ex)
                {
                    mainWindow.SetStatusException(ex);
                }
            }
        }

        public void GenerarLineaDinamica(List<SubProductoDinamico> list)
        {
            wrapPanelSubArticulo.Children.Clear();
            foreach (SubProductoDinamico subProductoDinamico in list)
            {
                if (subProductoDinamico != null)
                {
                    Label labelLeft = new Label();
                    labelLeft.Name = "labelLeft";
                    labelLeft.Margin = new Thickness(0, 8, 0, 0);
                    labelLeft.Width = 150;
                    labelLeft.Height = 24;
                    labelLeft.HorizontalAlignment = HorizontalAlignment.Left;
                    labelLeft.Content = subProductoDinamico.NombreLabelLeft;
                    if (subProductoDinamico.NombreLabelLeft == null || subProductoDinamico.NombreLabelLeft.Equals(""))
                        labelLeft.Visibility = Visibility.Hidden;
                    wrapPanelSubArticulo.Children.Add(labelLeft);

                    Label labelRight = new Label();
                    labelRight.Margin = new Thickness(62, 8, 0, 0);
                    labelRight.Width = 187;
                    labelRight.Height = 24;
                    labelRight.HorizontalAlignment = HorizontalAlignment.Left;
                    labelRight.Content = subProductoDinamico.NombreLabelRight;
                    if (subProductoDinamico.NombreLabelRight == null || subProductoDinamico.NombreLabelRight.Equals(""))
                        labelRight.Visibility = Visibility.Hidden;
                    wrapPanelSubArticulo.Children.Add(labelRight);

                    TextBox textBoxLeft = new TextBox();
                    textBoxLeft.IsEnabled = false;
                    textBoxLeft.Margin = new Thickness(0, 0, 0, 0);
                    textBoxLeft.Background = new SolidColorBrush(Colors.White);
                    textBoxLeft.Width = 187;
                    textBoxLeft.Height = 24;
                    textBoxLeft.HorizontalAlignment = HorizontalAlignment.Left;
                    textBoxLeft.Text = subProductoDinamico.ValueTextBoxLeft;
                    if (subProductoDinamico.NombreLabelLeft == null || subProductoDinamico.NombreLabelLeft.Equals(""))
                        textBoxLeft.Visibility = Visibility.Hidden;
                    wrapPanelSubArticulo.Children.Add(textBoxLeft);

                    TextBox textBoxRight = new TextBox();
                    textBoxRight.IsEnabled = false;
                    textBoxRight.Margin = new Thickness(25, 0, 0, 0);
                    textBoxRight.Background = new SolidColorBrush(Colors.White);
                    textBoxRight.Width = 187;
                    textBoxRight.Height = 24;
                    textBoxRight.HorizontalAlignment = HorizontalAlignment.Left;
                    textBoxRight.Text = subProductoDinamico.ValueTextBoxRight;
                    if (subProductoDinamico.NombreLabelRight == null || subProductoDinamico.NombreLabelRight.Equals(""))
                        textBoxRight.Visibility = Visibility.Hidden;
                    wrapPanelSubArticulo.Children.Add(textBoxRight);

                }
            }
        }
    }
}