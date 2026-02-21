# create-annotation-list-view-in-xamarin
This example demonstrates how to create an annotation list view and navigate to them on the selection using our Syncfusion&reg; PDF Viewer.

## Sample

```xaml
<ContentPage.Resources>
    <ResourceDictionary>
        <local:ImageSourceConverter x:Key="ImageSourceConverter"/>
    </ResourceDictionary>
</ContentPage.Resources>

<navigationdrawer:SfNavigationDrawer x:Name="navigationDrawer" DrawerFooterHeight="0" DrawerHeaderHeight="50">
    <navigationdrawer:SfNavigationDrawer.ContentView>
        <code>
        . . .
        . . .
        <code>
    </navigationdrawer:SfNavigationDrawer.ContentView>        
    <navigationdrawer:SfNavigationDrawer.DrawerHeaderView>
        <code>
        . . .
        . . .
        <code>
    </navigationdrawer:SfNavigationDrawer.DrawerHeaderView>        
    <navigationdrawer:SfNavigationDrawer.DrawerContentView>
        <listView:SfListView BackgroundColor="White" x:Name="listView" AllowGroupExpandCollapse="True"
                                ItemTapped="listView_ItemTapped"
                                BindingContext="{x:Reference Name=pdfViewer}"
                                ItemsSource="{Binding Annotations}">
            <listView:SfListView.GroupHeaderTemplate>
                <DataTemplate>
                    <code>
                    . . .
                    . . .
                    <code>
                </DataTemplate>
            </listView:SfListView.GroupHeaderTemplate>
            <listView:SfListView.ItemTemplate>
                <DataTemplate>
                    <ViewCell>
                        <local:ListViewItem />
                    </ViewCell>
                </DataTemplate>
            </listView:SfListView.ItemTemplate>
        </listView:SfListView>
    </navigationdrawer:SfNavigationDrawer.DrawerContentView>
</navigationdrawer:SfNavigationDrawer>

C#:

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

public class ImageSourceConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if ((bool)value)
            return ImageSource.FromResource("AnnotationsListView.Assets.Expand.png");
        else
            return ImageSource.FromResource("AnnotationsListView.Assets.Collapse.png");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

ListViewItem:

<ContentView.Content>
    <StackLayout HeightRequest="40" Orientation="Horizontal">
        <Label x:Name="annotationFontIcon" Margin="10,0,0,0" VerticalOptions="Center" InputTransparent="true" BackgroundColor="Transparent" TextColor="#0076FF" FontSize="16"/>
        <Label x:Name="annotationLabel" FontSize="Medium" TextColor="Black" Padding="10,0,0,0" VerticalOptions="Center"/>
    </StackLayout>
</ContentView.Content>

C#:

BindingContextChanged += ListViewItem_BindingContextChanged;

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
}
```