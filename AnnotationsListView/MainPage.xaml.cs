using Syncfusion.DataSource;
using Syncfusion.SfPdfViewer.XForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AnnotationsListView
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            hamburgerButton.ImageSource = (FileImageSource)ImageSource.FromFile("hamburgericon.png");
            listView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
            {
                PropertyName = "PageNumber",
                KeySelector = (object obj) =>
                {
                    var item = (obj as IAnnotation);
                    return "PAGE " + item.PageNumber;
                },
            });
        }

        private void hamburgerButton_Clicked(object sender, EventArgs e)
        {
            navigationDrawer.ToggleDrawer();
        }

        private void listView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            double x = 0;
            double y = 0;

            if (e.ItemType != Syncfusion.ListView.XForms.ItemType.GroupHeader)
            {
                pdfViewer.AnnotationMode = AnnotationMode.None;

                IAnnotation annotation = e.ItemData as IAnnotation;
                pdfViewer.SelectAnnotation(annotation);                

                if (annotation is ShapeAnnotation shape)
                {
                    x = shape.Bounds.X;
                    y = shape.Bounds.Y;
                }
                else if (annotation is TextMarkupAnnotation textMarkup)
                {
                    x = textMarkup.Bounds[0].X;
                    y = textMarkup.Bounds[0].Y;
                }
                else if (annotation is FreeTextAnnotation freeText)
                {
                    x = freeText.Bounds.X;
                    y = freeText.Bounds.Y;
                }
                else if (annotation is InkAnnotation ink)
                {
                    x = ink.Bounds.X;
                    y = ink.Bounds.Y;
                }

                var points = pdfViewer.ConvertPagePointToScrollPoint(new Point(x, y), annotation.PageNumber);
                pdfViewer.VerticalOffset = (float)points.Y - 30;

                navigationDrawer.ToggleDrawer();
            }

        }
    }
}