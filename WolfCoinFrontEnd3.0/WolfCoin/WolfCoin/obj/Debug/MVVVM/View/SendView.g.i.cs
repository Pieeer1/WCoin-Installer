﻿#pragma checksum "..\..\..\..\MVVVM\View\SendView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "065C097933976C890AC62CF32ADE45094A8C9881"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
using WolfCoin.MVVVM.View;


namespace WolfCoin.MVVVM.View {
    
    
    /// <summary>
    /// SendView
    /// </summary>
    public partial class SendView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\MVVVM\View\SendView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label SendLabel;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\MVVVM\View\SendView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SendPopupTextName;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\MVVVM\View\SendView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SendPopUpInput;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\MVVVM\View\SendView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SendPopupTextAmount;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\MVVVM\View\SendView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SendPopUpInputAmount;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\MVVVM\View\SendView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSubmitSend;
        
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
            System.Uri resourceLocater = new System.Uri("/WolfCoin;component/mvvvm/view/sendview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MVVVM\View\SendView.xaml"
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
            this.SendLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.SendPopupTextName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.SendPopUpInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.SendPopupTextAmount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.SendPopUpInputAmount = ((System.Windows.Controls.TextBox)(target));
            
            #line 63 "..\..\..\..\MVVVM\View\SendView.xaml"
            this.SendPopUpInputAmount.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TypeNumericValidation);
            
            #line default
            #line hidden
            
            #line 64 "..\..\..\..\MVVVM\View\SendView.xaml"
            this.SendPopUpInputAmount.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.PasteNumericValidation));
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnSubmitSend = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\..\MVVVM\View\SendView.xaml"
            this.btnSubmitSend.Click += new System.Windows.RoutedEventHandler(this.BtnSubmitSendClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

