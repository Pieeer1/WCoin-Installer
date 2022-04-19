﻿#pragma checksum "..\..\..\..\MVVVM\View\HomeView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "83A5A3C9ABFEF12D028B13D7F7D99C2780ACC63D"
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
using WolfCoin.MVVVM.View;


namespace WolfCoin.MVVVM.View {
    
    
    /// <summary>
    /// HomeView
    /// </summary>
    public partial class HomeView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\MVVVM\View\HomeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ViewWalletLabel;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\MVVVM\View\HomeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LoadingSpinnerControl.LoadingSpinner LoadingSymbol;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\MVVVM\View\HomeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AmountToMineTextBox;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\MVVVM\View\HomeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ViewMiningLabel;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\MVVVM\View\HomeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ViewWalletButton;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\..\MVVVM\View\HomeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MineButton;
        
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
            System.Uri resourceLocater = new System.Uri("/WolfCoin;component/mvvvm/view/homeview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MVVVM\View\HomeView.xaml"
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
            this.ViewWalletLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.LoadingSymbol = ((LoadingSpinnerControl.LoadingSpinner)(target));
            return;
            case 3:
            this.AmountToMineTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\..\..\MVVVM\View\HomeView.xaml"
            this.AmountToMineTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TypeNumericValidation);
            
            #line default
            #line hidden
            
            #line 45 "..\..\..\..\MVVVM\View\HomeView.xaml"
            this.AmountToMineTextBox.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.PasteNumericValidation));
            
            #line default
            #line hidden
            return;
            case 4:
            this.ViewMiningLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.ViewWalletButton = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\..\MVVVM\View\HomeView.xaml"
            this.ViewWalletButton.Click += new System.Windows.RoutedEventHandler(this.ViewWalletButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.MineButton = ((System.Windows.Controls.Button)(target));
            
            #line 107 "..\..\..\..\MVVVM\View\HomeView.xaml"
            this.MineButton.Click += new System.Windows.RoutedEventHandler(this.MineButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

