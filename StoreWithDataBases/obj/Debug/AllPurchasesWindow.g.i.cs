﻿#pragma checksum "..\..\AllPurchasesWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8542C1566D7A1D9DF75A05ED0A495B425670310380C0A95CC584475F67AD5217"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using StoreWithDataBases;
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


namespace StoreWithDataBases {
    
    
    /// <summary>
    /// AllPurchasesWindow
    /// </summary>
    public partial class AllPurchasesWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\AllPurchasesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgAllPurchasesClients;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\AllPurchasesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn tcId;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\AllPurchasesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn tcEMail;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\AllPurchasesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn tcProductCode;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\AllPurchasesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn tcProductName;
        
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
            System.Uri resourceLocater = new System.Uri("/StoreWithDataBases;component/allpurchaseswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AllPurchasesWindow.xaml"
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
            
            #line 12 "..\..\AllPurchasesWindow.xaml"
            ((StoreWithDataBases.AllPurchasesWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.AllPurchasesWindow_Loaded);
            
            #line default
            #line hidden
            
            #line 13 "..\..\AllPurchasesWindow.xaml"
            ((StoreWithDataBases.AllPurchasesWindow)(target)).Unloaded += new System.Windows.RoutedEventHandler(this.AllPurchasesWindow_Unloaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dgAllPurchasesClients = ((System.Windows.Controls.DataGrid)(target));
            
            #line 31 "..\..\AllPurchasesWindow.xaml"
            this.dgAllPurchasesClients.CurrentCellChanged += new System.EventHandler<System.EventArgs>(this.CurrentCell_Changed);
            
            #line default
            #line hidden
            
            #line 32 "..\..\AllPurchasesWindow.xaml"
            this.dgAllPurchasesClients.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.CellEdit_Ending);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tcId = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 4:
            this.tcEMail = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 5:
            this.tcProductCode = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 6:
            this.tcProductName = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 7:
            
            #line 64 "..\..\AllPurchasesWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BAddProduct_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 75 "..\..\AllPurchasesWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BDeleteProduct_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

