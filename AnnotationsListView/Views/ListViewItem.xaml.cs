using Syncfusion.SfPdfViewer.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnnotationsListView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewItem : ContentView
    {
        public ListViewItem()
        {
            InitializeComponent();
            BindingContextChanged += ListViewItem_BindingContextChanged;
        }

        private void ListViewItem_BindingContextChanged(object sender, EventArgs e)
        {
            if (BindingContext == null)
                return;

            annotationFontIcon.FontFamily = FontMappingHelper.FontFamily;

            if (BindingContext is ShapeAnnotation annotation)
            {
                annotationLabel.Text = annotation.ShapeAnnotationType.ToString();

                if (annotation.ShapeAnnotationType == ShapeAnnotationType.Line)
                {
                    annotationFontIcon.Text = FontMappingHelper.Line;
                }
                else if (annotation.ShapeAnnotationType == ShapeAnnotationType.Rectangle)
                {
                    annotationFontIcon.Text = FontMappingHelper.Rectangle;
                }
                else if (annotation.ShapeAnnotationType == ShapeAnnotationType.Circle)
                {
                    annotationFontIcon.Text = FontMappingHelper.Circle;
                }
                else if (annotation.ShapeAnnotationType == ShapeAnnotationType.Arrow)
                {
                    annotationFontIcon.Text = FontMappingHelper.Arrow;
                }
                else if (annotation.ShapeAnnotationType == ShapeAnnotationType.Polygon)
                {
                    annotationFontIcon.Text = FontMappingHelper.Polygon;
                }
            }
            else if (BindingContext is TextMarkupAnnotation textMarkup)
            {
                annotationLabel.Text = textMarkup.TextMarkupAnnotationType.ToString();
                if (textMarkup.TextMarkupAnnotationType == TextMarkupAnnotationType.Highlight)
                {
                    annotationFontIcon.Text = FontMappingHelper.Highlight;
                }
                else if (textMarkup.TextMarkupAnnotationType == TextMarkupAnnotationType.Strikethrough)
                {
                    annotationFontIcon.Text = FontMappingHelper.StrikeThrough;
                }
                else if (textMarkup.TextMarkupAnnotationType == TextMarkupAnnotationType.Underline)
                {
                    annotationFontIcon.Text = FontMappingHelper.Underline;
                }
            }
            else if (BindingContext is FreeTextAnnotation freeText)
            {
                annotationLabel.Text = "Free Text";
                annotationFontIcon.Text = FontMappingHelper.EditText;
            }
            else if (BindingContext is InkAnnotation ink)
            {
                annotationLabel.Text = "Ink";
                annotationFontIcon.Text = FontMappingHelper.Ink;
            }

            //else if (BindingContext is StampAnnotation stamp)
            //{
            //    annotationLabel.Text = $"{ToString(stamp)}";
            //    annotationFontIcon.FontFamily = FontMappingHelper.StampFont;
            //    annotationFontIcon.Text = FontMappingHelper.Stamp;
            //}
            //else if (BindingContext is HandwrittenSignature signature)
            //{
            //    annotationLabel.Text = $"{ToString(signature)}";
            //    annotationFontIcon.FontFamily = FontMappingHelper.SignatureFont;
            //    annotationFontIcon.Text = FontMappingHelper.Signature;
            //}
        }
    }
}