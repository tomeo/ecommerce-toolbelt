﻿#pragma checksum "..\..\..\UserControls\CoverImageDownloader.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ABD74C9BB9BA70EADA9CBFF1B239D55384D8075F"
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


namespace Toolbelt.UserControls {
    
    
    /// <summary>
    /// CoverImageDownloader
    /// </summary>
    public partial class CoverImageDownloader : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\UserControls\CoverImageDownloader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtExportFileBrowse;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\UserControls\CoverImageDownloader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnExportFileBrowse;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\UserControls\CoverImageDownloader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnGetImages;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\UserControls\CoverImageDownloader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtProductIds;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\UserControls\CoverImageDownloader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtEans;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\UserControls\CoverImageDownloader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtLog;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\UserControls\CoverImageDownloader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image CoverImage;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\UserControls\CoverImageDownloader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ProgressContainer;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\UserControls\CoverImageDownloader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar ProgressBar;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\UserControls\CoverImageDownloader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TxtStatus;
        
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
            System.Uri resourceLocater = new System.Uri("/Toolbelt;component/usercontrols/coverimagedownloader.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\CoverImageDownloader.xaml"
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
            this.TxtExportFileBrowse = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.BtnExportFileBrowse = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\UserControls\CoverImageDownloader.xaml"
            this.BtnExportFileBrowse.Click += new System.Windows.RoutedEventHandler(this.ExportFileBrowse_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnGetImages = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\UserControls\CoverImageDownloader.xaml"
            this.BtnGetImages.Click += new System.Windows.RoutedEventHandler(this.Run);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TxtProductIds = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TxtEans = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TxtLog = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.CoverImage = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.ProgressContainer = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.ProgressBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 10:
            this.TxtStatus = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

