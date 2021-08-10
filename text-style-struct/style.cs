using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace TextComponentsTest
{
    class Example : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        public void Initialize()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            View view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);

            // Label title
            TextLabel titleLabel = new TextLabel
            {
                Text = " /* Text Label PropertyMap Test */ ",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 12.0f,
                BackgroundColor = Color.CadetBlue,
            };
            view.Add(titleLabel);



            // FontStyle
            TextLabel fontStyleLabel = new TextLabel
            {
                Text = "FontStyle Lorem ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };

            fontStyleLabel.FontFamily = "BreezeSans";
            view.Add(fontStyleLabel);

            var fontStyle = new Tizen.NUI.Text.FontStyle();
            fontStyle.Width = FontWidthType.Condensed;
            fontStyle.Weight = FontWeightType.Light;
            fontStyle.Slant = FontSlantType.Italic;
            fontStyleLabel.SetFontStyle(fontStyle);

            Tizen.Log.Error("NUI", "width : " + fontStyle.Width + "\n");
            Tizen.Log.Error("NUI", "weight : " + fontStyle.Weight + "\n");
            Tizen.Log.Error("NUI", "slant : " + fontStyle.Slant + "\n");

            Tizen.NUI.Text.FontStyle getStyle = fontStyleLabel.GetFontStyle();
            Tizen.Log.Error("NUI", "get width : " + getStyle.Width + "\n");
            Tizen.Log.Error("NUI", "get weight : " + getStyle.Weight + "\n");
            Tizen.Log.Error("NUI", "get slant : " + getStyle.Slant + "\n");


            TextField fontStyleField = new TextField
            {
                Text = "FontStyle TextField",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };

            fontStyleField.FontFamily = "BreezeSans";
            view.Add(fontStyleField);

            fontStyleField.SetFontStyle(fontStyle);

            getStyle = fontStyleField.GetFontStyle();
            Tizen.Log.Error("NUI", "get field width : " + getStyle.Width + "\n");
            Tizen.Log.Error("NUI", "get field weight : " + getStyle.Weight + "\n");
            Tizen.Log.Error("NUI", "get field slant : " + getStyle.Slant + "\n");

            
            TextEditor fontStyleEditor = new TextEditor
            {
                Text = "FontStyle TextEditor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };

            fontStyleEditor.FontFamily = "BreezeSans";
            view.Add(fontStyleEditor);

            fontStyleEditor.SetFontStyle(fontStyle);

            getStyle = fontStyleEditor.GetFontStyle();
            Tizen.Log.Error("NUI", "get editor width : " + getStyle.Width + "\n");
            Tizen.Log.Error("NUI", "get editor weight : " + getStyle.Weight + "\n");
            Tizen.Log.Error("NUI", "get editor slant : " + getStyle.Slant + "\n");


            var button = new Button
            {
                Text = "set font style",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(button);

            var style = new Tizen.NUI.Text.FontStyle();
            style.Width = FontWidthType.Expanded;
            style.Weight = FontWeightType.ExtraBold;
            style.Slant = FontSlantType.Normal;

            button.Clicked += (s, e) =>
            {
                fontStyleLabel.SetFontStyle(style);
                fontStyleField.SetFontStyle(style);
                fontStyleEditor.SetFontStyle(style);
                
                Tizen.Log.Error("NUI", "set width : " + fontStyleLabel.GetFontStyle().Width + "\n");
                Tizen.Log.Error("NUI", "set weight : " + fontStyleField.GetFontStyle().Weight + "\n");
                Tizen.Log.Error("NUI", "set slant : " + fontStyleEditor.GetFontStyle().Slant + "\n");
            };

            fontStyleField.TextChanged += (s, e) =>
            {
                fontStyleField.SetInputFontStyle(fontStyle);

                Tizen.Log.Error("NUI", "set input field width : " + fontStyleField.GetInputFontStyle().Width + "\n");
                Tizen.Log.Error("NUI", "set input field width : " + fontStyleField.GetInputFontStyle().Weight + "\n");
                Tizen.Log.Error("NUI", "set input field width : " + fontStyleField.GetInputFontStyle().Slant + "\n");
            };

            fontStyleEditor.TextChanged += (s, e) =>
            {
                fontStyleEditor.SetInputFontStyle(fontStyle);

                Tizen.Log.Error("NUI", "set input editor width : " + fontStyleEditor.GetInputFontStyle().Width + "\n");
                Tizen.Log.Error("NUI", "set input editor width : " + fontStyleEditor.GetInputFontStyle().Weight + "\n");
                Tizen.Log.Error("NUI", "set input editor width : " + fontStyleEditor.GetInputFontStyle().Slant + "\n");
            };


            // Underline
            TextLabel underlineLabel = new TextLabel
            {
                Text = "Underline Lorem ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };

            view.Add(underlineLabel);

            PropertyMap underlineMap = new PropertyMap();
            underlineMap = underlineLabel.Underline;


            var underline = new Tizen.NUI.Text.Underline();
            underline.Enable = true;
            underline.Color = new Color("#3498DB");
            underline.Height = 2.0f;

            Tizen.Log.Error("NUI", "struct enable : " + underline.Enable + "\n");
            Tizen.Log.Error("NUI", "struct height : " + underline.Height + "\n");
            underlineLabel.SetUnderline(underline);

            Tizen.Log.Error("NUI", "get struct enable : " + underlineLabel.GetUnderline().Enable + "\n");
            Tizen.Log.Error("NUI", "get struct color : " + underlineLabel.GetUnderline().Color.R + ", " + underlineLabel.GetUnderline().Color.G + ", " + underlineLabel.GetUnderline().Color.B + ", " + underlineLabel.GetUnderline().Color.A + "\n");
            Tizen.Log.Error("NUI", "get struct height : " + underlineLabel.GetUnderline().Height + "\n");


            // Underline
            TextField underlineField = new TextField
            {
                Text = "Underline Lorem ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            view.Add(underlineField);

            underlineField.SetUnderline(underline);

            // Underline
            TextEditor underlineEditor = new TextEditor
            {
                Text = "Underline Editor ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(underlineEditor);

            underlineEditor.SetUnderline(underline);

            Tizen.Log.Error("NUI", "get editor enable : " + underlineEditor.GetUnderline().Enable + "\n");
            Tizen.Log.Error("NUI", "get editor color : " + underlineEditor.GetUnderline().Color.R + ", " + underlineEditor.GetUnderline().Color.G + ", " + underlineEditor.GetUnderline().Color.B + ", " + underlineEditor.GetUnderline().Color.A + "\n");
            Tizen.Log.Error("NUI", "get editor height : " + underlineEditor.GetUnderline().Height + "\n");


            // Shadow
            TextLabel shadowLabel = new TextLabel
            {
                Text = "Shadow Lorem ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            view.Add(shadowLabel);

            var shadowStruct = new Tizen.NUI.Text.Shadow();
            shadowStruct.BlurRadius = 5.0f;
            shadowStruct.Color = new Color("#F1C40F");
            shadowStruct.Offset = new Vector2(3, 3);
            shadowLabel.SetShadow(shadowStruct);

            Tizen.Log.Error("NUI", "get shadow label color : " + shadowLabel.GetShadow().Color.R + ", " + shadowLabel.GetShadow().Color.G + ", " + shadowLabel.GetShadow().Color.B + ", " + shadowLabel.GetShadow().Color.A + "\n");
            Tizen.Log.Error("NUI", "get shadow label offset : " + shadowLabel.GetShadow().Offset.X + ", " + shadowLabel.GetShadow().Offset.Y + "\n");
            Tizen.Log.Error("NUI", "get shadow label blurRadius : " + shadowLabel.GetShadow().BlurRadius + "\n");

            // Shadow
            TextField shadowField = new TextField
            {
                Text = "Shadow Field ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(shadowField);
            shadowField.SetShadow(shadowStruct);

            Tizen.Log.Error("NUI", "get shadow field color : " + shadowField.GetShadow().Color.R + ", " + shadowField.GetShadow().Color.G + ", " + shadowField.GetShadow().Color.B + ", " + shadowField.GetShadow().Color.A + "\n");
            Tizen.Log.Error("NUI", "get shadow field offset : " + shadowField.GetShadow().Offset.X + ", " + shadowField.GetShadow().Offset.Y + "\n");
            Tizen.Log.Error("NUI", "get shadow field blurRadius : " + shadowField.GetShadow().BlurRadius + "\n");

            // Shadow
            TextEditor shadowEditor = new TextEditor
            {
                Text = "Shadow Editor ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(shadowEditor);
            shadowEditor.SetShadow(shadowStruct);

            Tizen.Log.Error("NUI", "get shadow editor color : " + shadowEditor.GetShadow().Color.R + ", " + shadowEditor.GetShadow().Color.G + ", " + shadowEditor.GetShadow().Color.B + ", " + shadowEditor.GetShadow().Color.A + "\n");
            Tizen.Log.Error("NUI", "get shadow editor offset : " + shadowEditor.GetShadow().Offset.X + ", " + shadowEditor.GetShadow().Offset.Y + "\n");
            Tizen.Log.Error("NUI", "get shadow editor blurRadius : " + shadowEditor.GetShadow().BlurRadius + "\n");


            // Outline
            TextLabel outlineLabel = new TextLabel
            {
                Text = "Outline Lorem ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };

            PropertyMap outline = new PropertyMap();
            outline.Add("width", new PropertyValue(2.0f));            // float
            outline.Add("color", new PropertyValue(Color.CadetBlue)); // Color
            outlineLabel.Outline = outline;

            view.Add(outlineLabel);



            // Label title
            TextLabel titleLabel2 = new TextLabel
            {
                Text = " /* Text Field PropertyMap Test */ ",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 12.0f,
                BackgroundColor = Color.CadetBlue,
            };
            view.Add(titleLabel2);



            // HiddenInputSettings
            TextField passwordField = new TextField
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                MaxLength = 20,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                
                PlaceholderText = "HiddenInputSettings",
                PlaceholderTextFocused = "HiddenInputSettings Focused",
            };

            PropertyMap hiddenMap = new PropertyMap();
            hiddenMap.Add(HiddenInputProperty.Mode, new PropertyValue((int)HiddenInputModeType.ShowLastCharacter));
            //hiddenMap.Add(HiddenInputProperty.Mode, new PropertyValue((int)HiddenInputModeType.HideCount));
            //hiddenMap.Add(HiddenInputProperty.ShowLastCharacterDuration, new PropertyValue(500));
            //hiddenMap.Add(HiddenInputProperty.SubstituteCount, new PropertyValue(10));
            //hiddenMap.Add(HiddenInputProperty.SubstituteCharacter, new PropertyValue(0x23));
            passwordField.HiddenInputSettings = hiddenMap;

            view.Add(passwordField);


            // Placeholder
            TextField placeholderField = new TextField
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };

            PropertyMap placeholderMap = new PropertyMap();
            placeholderMap.Add("text", new PropertyValue("Placeholder TextField"));
            placeholderMap.Add("textFocused", new PropertyValue("Placeholder TextField Focused"));
            placeholderMap.Add("color", new PropertyValue(Color.CadetBlue));
            placeholderMap.Add("fontFamily", new PropertyValue("Serif"));
            placeholderMap.Add("pointSize", new PropertyValue(25.0f));
            placeholderField.Placeholder = placeholderMap;

            view.Add(placeholderField);



            // SelectionHandleImage
            TextField selectionHandleField = new TextField
            {
                Text = "Selection Handle Image L, R",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                PointSize = 25.0f,
                BackgroundColor = Color.White,

                GrabHandleImage = "handle_down.png",
            };

            // Normal
            PropertyMap imageLeftMap = new PropertyMap();
            imageLeftMap.Add("filename", new PropertyValue("handle_downleft.png"));
            selectionHandleField.SelectionHandleImageLeft = imageLeftMap;

            PropertyMap imageRightMap = new PropertyMap();
            imageRightMap.Add("filename", new PropertyValue("handle_downright.png"));
            selectionHandleField.SelectionHandleImageRight = imageRightMap;

            // Pressed
            PropertyMap pressedImageLeftMap = new PropertyMap();
            pressedImageLeftMap.Add("filename", new PropertyValue("handle_downleft_pressed.png"));
            selectionHandleField.SelectionHandlePressedImageLeft = pressedImageLeftMap;

            PropertyMap pressedImageRightMap = new PropertyMap();
            pressedImageRightMap.Add("filename", new PropertyValue("handle_downright_pressed.png"));
            selectionHandleField.SelectionHandlePressedImageRight = pressedImageRightMap;

            // Marker?
            PropertyMap markerImageLeftMap = new PropertyMap();
            markerImageLeftMap.Add("filename", new PropertyValue("handle_marker.png"));
            selectionHandleField.SelectionHandleMarkerImageLeft = markerImageLeftMap;

            PropertyMap markerImageRightMap = new PropertyMap();
            markerImageRightMap.Add("filename", new PropertyValue("handle_marker.png"));
            selectionHandleField.SelectionHandleMarkerImageRight = markerImageRightMap;

            view.Add(selectionHandleField);


            // Input Style
            TextField inputStyleField = new TextField
            {
                Text = "Input Style is works fine?",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(inputStyleField);

            inputStyleField.TextChanged += (s, e) =>
            {
                inputStyleField.InputFontFamily = "Ubuntu Mono";
                PropertyMap inputFontStyle = new PropertyMap();
                inputFontStyle.Add("width", new PropertyValue("condensed"));  // width:  condensed, semiCondensed, normal, semiExpanded, expanded
                inputFontStyle.Add("weight", new PropertyValue("light"));     // weight: thin, light, normal, regular, medium, bold
                inputFontStyle.Add("slant", new PropertyValue("normal"));    // slant:  normal, roman, italic, oblique
                inputStyleField.InputFontStyle = inputFontStyle;

                inputStyleField.InputPointSize = 15.0f;
            };


            // compare 1
            TextLabel compare1 = new TextLabel
            {
                Text = "FONT STYLE COMPARE",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };

            compare1.FontFamily = "BreezeSans";
            PropertyMap expanded = new PropertyMap();
            expanded.Add("width", new PropertyValue("expanded"));  // width:  condensed, semiCondensed, normal, semiExpanded, expanded
            compare1.FontStyle = expanded;

            view.Add(compare1);


            // compare 2
            TextLabel compare2 = new TextLabel
            {
                Text = "FONT STYLE COMPARE",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };

            compare2.FontFamily = "BreezeSans";
            PropertyMap condensed = new PropertyMap();
            condensed.Add("width", new PropertyValue("condensed"));  // width:  condensed, semiCondensed, normal, semiExpanded, expanded
            compare2.FontStyle = condensed;

            view.Add(compare2);


            // compare 3
            TextLabel compare3 = new TextLabel
            {
                Text = "FONT STYLE COMPARE",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };

            compare3.FontFamily = "BreezeSans";
            PropertyMap bold = new PropertyMap();
            bold.Add("weight", new PropertyValue("bold"));     // weight: thin, light, normal, regular, medium, bold
            compare3.FontStyle = bold;

            view.Add(compare3);


            // compare 4
            TextLabel compare4 = new TextLabel
            {
                Text = "FONT STYLE COMPARE",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };

            compare4.FontFamily = "BreezeSans";
            PropertyMap light = new PropertyMap();
            light.Add("weight", new PropertyValue("light"));     // weight: thin, light, normal, regular, medium, bold
            compare4.FontStyle = light;

            view.Add(compare4);

        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
