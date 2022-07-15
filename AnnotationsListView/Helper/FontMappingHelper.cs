using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AnnotationsListView
{
    /// <summary>
    /// Represents the font text of the annotations
    /// </summary>
    public class FontMappingHelper
    {
        public static string FontFamily = Device.RuntimePlatform == Device.Android ? "Final_PDFViewer_Android_FontUpdate.ttf#" 
            : Device.RuntimePlatform == Device.iOS ? "Final_PDFViewer_IOS_FontUpdate" 
            : "/Assets/Fonts/Final_PDFViewer_UWP_FontUpdate.ttf#Final_PDFViewer_UWP_FontUpdate";

        public static string Underline = Device.RuntimePlatform == Device.Android ? "\uE70d" : Device.RuntimePlatform == Device.iOS ? "\uE70c" : "\uE721";
                
        public static string StrikeThrough = Device.RuntimePlatform == Device.Android ? "\uE711" : Device.RuntimePlatform == Device.iOS ? "\uE71e" : "\uE709";

        public static string Highlight = Device.RuntimePlatform == Device.Android ? "\uE715" : Device.RuntimePlatform == Device.iOS ? "\uE710" : "\uE70c";
                
        public static string Ink = Device.RuntimePlatform == Device.Android ? "\uE71d" : Device.RuntimePlatform == Device.iOS ? "\uE704" : "\uE704";

        public static string EditText = Device.RuntimePlatform == Device.Android ? "\uE71f" : Device.RuntimePlatform == Device.iOS ? "\uE700" : "\uE71A";
                
        public static string Rectangle = Device.RuntimePlatform == Device.Android ? "\uE710" : Device.RuntimePlatform == Device.iOS ? "\uE705" : "\uE70e";
        
        public static string Circle = Device.RuntimePlatform == Device.Android ? "\uE714" : Device.RuntimePlatform == Device.iOS ? "\uE71f" : "\uE717";
        
        public static string Line = Device.RuntimePlatform == Device.Android ? "\uE703" : Device.RuntimePlatform == Device.iOS ? "\uE717" : "\uE71b";
        
        public static string Arrow = Device.RuntimePlatform == Device.Android ? "\uE701" : Device.RuntimePlatform == Device.iOS ? "\uE712" : "\uE70a";

        public static string Polygon = Device.RuntimePlatform == Device.Android ? "\uE712" : Device.RuntimePlatform == Device.iOS ? "\uE70D" : "\uE715";

        //public static string Stamp = Device.RuntimePlatform == Device.Android ? "\uE703" : Device.RuntimePlatform == Device.iOS ? "\uE701" : "\uE705";

        //public static string Signature = Device.RuntimePlatform == Device.Android ? "\uE701" : Device.RuntimePlatform == Device.iOS ? "\uE702" : "\uE700";
                
        //public static string CloudFont =
        //    Device.RuntimePlatform == Device.Android ? "Font Poly Cloud icon.ttf#" :
        //   Device.RuntimePlatform == Device.iOS ? "Font Poly Cloud icon" : "/Assets/Fonts/Font Poly Cloud icon.ttf#Font Poly Cloud icon";
        //public static string EditTextFontFamily = Device.RuntimePlatform == Device.Android ?
        //    "Font size Font.ttf#" :

        //    Device.RuntimePlatform == Device.iOS ?

        //    "Font size Font" :

        //    "/Assets/Fonts/Font size Font.ttf#Font size Font";
    }
}
