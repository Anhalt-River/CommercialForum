// Updated by XamlIntelliSenseFileGenerator 29.10.2023 15:12:11
#pragma checksum "..\..\..\..\Pages\StaffPages\ClientListPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "054DDAE1A8B25E091C53B782F5EDF3EE51AFB243CA16E8A6ABDAB86F2F78B26D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CommercialForum.Pages.StaffPages;
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


namespace CommercialForum.Pages.StaffPages
{


    /// <summary>
    /// ClientListPage
    /// </summary>
    public partial class ClientListPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector
    {


#line 25 "..\..\..\..\Pages\StaffPages\ClientListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackBut;

#line default
#line hidden


#line 35 "..\..\..\..\Pages\StaffPages\ClientListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView clientsList;

#line default
#line hidden


#line 74 "..\..\..\..\Pages\StaffPages\ClientListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HistoryBut;

#line default
#line hidden


#line 78 "..\..\..\..\Pages\StaffPages\ClientListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TraderProductsBut;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CommercialForum;component/pages/staffpages/clientlistpage.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\Pages\StaffPages\ClientListPage.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.BackBut = ((System.Windows.Controls.Button)(target));

#line 25 "..\..\..\..\Pages\StaffPages\ClientListPage.xaml"
                    this.BackBut.Click += new System.Windows.RoutedEventHandler(this.BackBut_Click);

#line default
#line hidden
                    return;
                case 2:
                    this.clientsList = ((System.Windows.Controls.ListView)(target));
                    return;
                case 3:
                    this.HistoryBut = ((System.Windows.Controls.Button)(target));

#line 74 "..\..\..\..\Pages\StaffPages\ClientListPage.xaml"
                    this.HistoryBut.Click += new System.Windows.RoutedEventHandler(this.HistoryBut_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.TraderProductsBut = ((System.Windows.Controls.Button)(target));

#line 78 "..\..\..\..\Pages\StaffPages\ClientListPage.xaml"
                    this.TraderProductsBut.Click += new System.Windows.RoutedEventHandler(this.TraderProductsBut_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Button UserDataBut;
    }
}

