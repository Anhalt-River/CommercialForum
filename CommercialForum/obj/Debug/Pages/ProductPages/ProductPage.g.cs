﻿#pragma checksum "..\..\..\..\Pages\ProductPages\ProductPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8D2A57B6C6F8008DFC02C52AB54DB02FBBA7C204BEF45FFE1A8792D738138348"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CommercialForum.Pages;
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


namespace CommercialForum.Pages {
    
    
    /// <summary>
    /// ProductPage
    /// </summary>
    public partial class ProductPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\..\Pages\ProductPages\ProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ProductImageBut;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Pages\ProductPages\ProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Product_Image;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Pages\ProductPages\ProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Product_NameBlock;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Pages\ProductPages\ProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Product_CostBlock;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Pages\ProductPages\ProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox AvailableCheckBox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Pages\ProductPages\ProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Product_TraderBlock;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Pages\ProductPages\ProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Product_DescBox;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\Pages\ProductPages\ProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OrderBut;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\Pages\ProductPages\ProductPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeOrderBut;
        
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
            System.Uri resourceLocater = new System.Uri("/CommercialForum;component/pages/productpages/productpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\ProductPages\ProductPage.xaml"
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
            this.ProductImageBut = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\..\Pages\ProductPages\ProductPage.xaml"
            this.ProductImageBut.Click += new System.Windows.RoutedEventHandler(this.ProductImageBut_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Product_Image = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.Product_NameBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.Product_CostBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.AvailableCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.Product_TraderBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.Product_DescBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.OrderBut = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\..\Pages\ProductPages\ProductPage.xaml"
            this.OrderBut.Click += new System.Windows.RoutedEventHandler(this.OrderBut_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.DeOrderBut = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\..\Pages\ProductPages\ProductPage.xaml"
            this.DeOrderBut.Click += new System.Windows.RoutedEventHandler(this.DeOrderBut_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

