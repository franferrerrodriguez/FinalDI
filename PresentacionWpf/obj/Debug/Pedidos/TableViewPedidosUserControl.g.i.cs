﻿#pragma checksum "..\..\..\Pedidos\TableViewPedidosUserControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0D8EE5BDEB5865531DC0C9474EED214CFAB9C450"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace PresentacionWpf {
    
    
    /// <summary>
    /// TableViewPedidosUserControl
    /// </summary>
    public partial class TableViewPedidosUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\Pedidos\TableViewPedidosUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridPedidos;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Pedidos\TableViewPedidosUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelTitle;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Pedidos\TableViewPedidosUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Pedidos\TableViewPedidosUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancelar;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Pedidos\TableViewPedidosUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxUsuarioId;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Pedidos\TableViewPedidosUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxUsuarioNombre;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pedidos\TableViewPedidosUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAnadirUsuario;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pedidos\TableViewPedidosUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnQuitarUsuario;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Pedidos\TableViewPedidosUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerFechaInicio;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Pedidos\TableViewPedidosUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerFechaFin;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PresentacionWpf;component/pedidos/tableviewpedidosusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pedidos\TableViewPedidosUserControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.GridPedidos = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.labelTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 12 "..\..\..\Pedidos\TableViewPedidosUserControl.xaml"
            this.dataGrid.GotFocus += new System.Windows.RoutedEventHandler(this.DataGrid_GotFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\Pedidos\TableViewPedidosUserControl.xaml"
            this.btnCancelar.Click += new System.Windows.RoutedEventHandler(this.BtnCancelar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.textBoxUsuarioId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.textBoxUsuarioNombre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnAnadirUsuario = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Pedidos\TableViewPedidosUserControl.xaml"
            this.btnAnadirUsuario.Click += new System.Windows.RoutedEventHandler(this.BtnAnadirUsuario_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnQuitarUsuario = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Pedidos\TableViewPedidosUserControl.xaml"
            this.btnQuitarUsuario.Click += new System.Windows.RoutedEventHandler(this.BtnQuitarUsuario_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.datePickerFechaInicio = ((System.Windows.Controls.DatePicker)(target));
            
            #line 26 "..\..\..\Pedidos\TableViewPedidosUserControl.xaml"
            this.datePickerFechaInicio.CalendarClosed += new System.Windows.RoutedEventHandler(this.DatePickerFechaInicio_CalendarClosed);
            
            #line default
            #line hidden
            return;
            case 10:
            this.datePickerFechaFin = ((System.Windows.Controls.DatePicker)(target));
            
            #line 28 "..\..\..\Pedidos\TableViewPedidosUserControl.xaml"
            this.datePickerFechaFin.CalendarClosed += new System.Windows.RoutedEventHandler(this.DatePickerFechaFin_CalendarClosed);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
