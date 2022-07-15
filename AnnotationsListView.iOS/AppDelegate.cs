using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Foundation;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.SfNavigationDrawer.XForms.iOS;
using Syncfusion.SfPdfViewer.XForms.iOS;
using Syncfusion.SfRangeSlider.XForms.iOS;
using Syncfusion.XForms.iOS.EffectsView;
using UIKit;

namespace AnnotationsListView.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            List<Assembly> assembliesToInclude = new List<Assembly>();

            //Now, add all the assemblies that your app uses
            assembliesToInclude.Add(typeof(SfPdfDocumentViewRenderer).GetTypeInfo().Assembly);

            assembliesToInclude.Add(typeof(SfRangeSliderRenderer).GetTypeInfo().Assembly);
            new SfNavigationDrawerRenderer();
            SfListViewRenderer.Init();
            SfEffectsViewRenderer.Init();  
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
