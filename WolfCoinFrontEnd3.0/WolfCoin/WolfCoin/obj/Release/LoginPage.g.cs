#pragma checksum "..\..\LoginPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AC691669F5FDC1B5C157F582E460580B1CD0F2CDF68F13D28014830EAD6DAABF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LoadingSpinnerControl;
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
using WolfCoin;


namespace WolfCoin {
    
    
    /// <summary>
    /// LoginPage
    /// </summary>
    public partial class LoginPage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 50 "..\..\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUsername;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtPassword;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSubmit;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreateAccount;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel FactorStack;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox factor0;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox factor1;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox factor2;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox factor3;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVerify;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ErrorLabel;
        
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
            System.Uri resourceLocater = new System.Uri("/WolfCoin;component/loginpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LoginPage.xaml"
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
            
            #line 15 "..\..\LoginPage.xaml"
            ((WolfCoin.LoginPage)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 17 "..\..\LoginPage.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.SubmitEnter);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtUsername = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 5:
            this.btnSubmit = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\LoginPage.xaml"
            this.btnSubmit.Click += new System.Windows.RoutedEventHandler(this.BtnSubmit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnCreateAccount = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\LoginPage.xaml"
            this.btnCreateAccount.Click += new System.Windows.RoutedEventHandler(this.BtnCreateAccount_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.FactorStack = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.factor0 = ((System.Windows.Controls.TextBox)(target));
            
            #line 93 "..\..\LoginPage.xaml"
            this.factor0.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TypeNumericValidation);
            
            #line default
            #line hidden
            
            #line 94 "..\..\LoginPage.xaml"
            this.factor0.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.PasteNumericValidation));
            
            #line default
            #line hidden
            return;
            case 9:
            this.factor1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 103 "..\..\LoginPage.xaml"
            this.factor1.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TypeNumericValidation);
            
            #line default
            #line hidden
            
            #line 104 "..\..\LoginPage.xaml"
            this.factor1.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.PasteNumericValidation));
            
            #line default
            #line hidden
            return;
            case 10:
            this.factor2 = ((System.Windows.Controls.TextBox)(target));
            
            #line 113 "..\..\LoginPage.xaml"
            this.factor2.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TypeNumericValidation);
            
            #line default
            #line hidden
            
            #line 114 "..\..\LoginPage.xaml"
            this.factor2.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.PasteNumericValidation));
            
            #line default
            #line hidden
            return;
            case 11:
            this.factor3 = ((System.Windows.Controls.TextBox)(target));
            
            #line 123 "..\..\LoginPage.xaml"
            this.factor3.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TypeNumericValidation);
            
            #line default
            #line hidden
            
            #line 124 "..\..\LoginPage.xaml"
            this.factor3.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.PasteNumericValidation));
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnVerify = ((System.Windows.Controls.Button)(target));
            
            #line 134 "..\..\LoginPage.xaml"
            this.btnVerify.Click += new System.Windows.RoutedEventHandler(this.BtnVerify_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.ErrorLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            
            #line 143 "..\..\LoginPage.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

