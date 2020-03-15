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

            List<SubProductoDinamico> list = new List<SubProductoDinamico>();
            list.Add(new SubProductoDinamico("Label 1", "textBox 1", "Label 1", "textBox 1"));
            list.Add(new SubProductoDinamico("Label 2", "textBox 2", "Label 2", "textBox 2"));
            GenerarLineaDinamica(list);
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
                // MessageBox.Show(articulo.ArticuloID);
            }
        }

        public void GenerarLineaDinamica(List<SubProductoDinamico> list)
        {
            foreach(SubProductoDinamico subProductoDinamico in list)
            {
                if (subProductoDinamico != null)
                {
                    if (subProductoDinamico.NombreLabelLeft != null && !subProductoDinamico.NombreLabelLeft.Equals(""))
                    {
                        Label labelLeft = new Label();
                        labelLeft.Margin = new Thickness(0, 8, 0, 0);
                        labelLeft.Width = 150;
                        labelLeft.Height = 24;
                        labelLeft.HorizontalAlignment = HorizontalAlignment.Left;
                        labelLeft.Content = subProductoDinamico.NombreLabelLeft;
                        pruebas.Children.Add(labelLeft);
                    }

                    if (subProductoDinamico.NombreLabelRight != null && !subProductoDinamico.NombreLabelRight.Equals(""))
                    {
                        Label labelRight = new Label();
                        labelRight.Margin = new Thickness(62, 8, 0, 0);
                        labelRight.Width = 187;
                        labelRight.Height = 24;
                        labelRight.HorizontalAlignment = HorizontalAlignment.Left;
                        labelRight.Content = subProductoDinamico.NombreLabelRight;
                        pruebas.Children.Add(labelRight);
                    }

                    if (subProductoDinamico.ValueTextBoxLeft != null && !subProductoDinamico.ValueTextBoxLeft.Equals(""))
                    {
                        TextBox textBoxLeft = new TextBox();
                        textBoxLeft.IsEnabled = false;
                        textBoxLeft.Margin = new Thickness(0, 0, 0, 0);
                        textBoxLeft.Background = new SolidColorBrush(Colors.White);
                        textBoxLeft.Width = 187;
                        textBoxLeft.Height = 24;
                        textBoxLeft.HorizontalAlignment = HorizontalAlignment.Left;
                        textBoxLeft.Text = subProductoDinamico.ValueTextBoxLeft;
                        pruebas.Children.Add(textBoxLeft);
                    }

                    if (subProductoDinamico.ValueTextBoxRight != null && !subProductoDinamico.ValueTextBoxRight.Equals(""))
                    {
                        TextBox textBoxRight = new TextBox();
                        textBoxRight.IsEnabled = false;
                        textBoxRight.Margin = new Thickness(25, 0, 0, 0);
                        textBoxRight.Background = new SolidColorBrush(Colors.White);
                        textBoxRight.Width = 187;
                        textBoxRight.Height = 24;
                        textBoxRight.HorizontalAlignment = HorizontalAlignment.Left;
                        textBoxRight.Text = subProductoDinamico.ValueTextBoxRight;
                        pruebas.Children.Add(textBoxRight);
                    }

                }
            }
        }
    }
}