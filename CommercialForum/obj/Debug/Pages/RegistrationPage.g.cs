﻿#pragma checksum "..\..\..\Pages\RegistrationPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FF4B8D60EEBD2C057DB4E2350C20954AB789DA578546ADE3CDF7BDCF282258CB"
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
    /// RegistrationPage
    /// </summary>
    public partial class RegistrationPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\Pages\RegistrationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backBut;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Pages\RegistrationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmailBox;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Pages\RegistrationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordBox;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Pages\RegistrationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FNameBox;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Pages\RegistrationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LNameBox;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Pages\RegistrationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PatronymicBox;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Pages\RegistrationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button regBut;
        
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
            System.Uri resourceLocater = new System.Uri("/CommercialForum;component/pages/registrationpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\RegistrationPage.xaml"
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
            this.backBut = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\Pages\RegistrationPage.xaml"
            this.backBut.Click += new System.Windows.RoutedEventHandler(this.backBut_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.EmailBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\..\Pages\RegistrationPage.xaml"
            this.EmailBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.EmailBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PasswordBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.FNameBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 51 "..\..\..\Pages\RegistrationPage.xaml"
            this.FNameBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NameBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LNameBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 56 "..\..\..\Pages\RegistrationPage.xaml"
            this.LNameBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NameBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.PatronymicBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 61 "..\..\..\Pages\RegistrationPage.xaml"
            this.PatronymicBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NameBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.regBut = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\Pages\RegistrationPage.xaml"
            this.regBut.Click += new System.Windows.RoutedEventHandler(this.regBut_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

