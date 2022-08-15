using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;

using Tizen.NUI.Text.Spans;
using Tizen.NUI.Constants;
using Tizen.NUI.Text;


namespace TextComponentsTest
{
    class Example : NUIApplication
    {
         FontSpan  boldAndItalicSpan;

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


            // Normal textTarget
            TextEditor textTarget = new TextEditor
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                // EnableMarkup = true,
                // MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            view.Add(textTarget);

            var button = new Button
            {
                Text = "UnAttach Bold Span",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(button);
            button.Clicked += (s, e) =>
            {
                if(boldAndItalicSpan.SlantDefined)
                {
                    Spannable.DetachSpan(textTarget, boldAndItalicSpan );
                    Spannable.BuildSpannedText(textTarget );
                }

            };

            var builder = FontSpanBuilder.Initialize();
            builder.WithFontWeight(FontWeightType.ExtraBold)
                   .WithFontSlant(FontSlantType.Italic);


            boldAndItalicSpan = builder.Build();
            Spannable.AttachSpan(textTarget, boldAndItalicSpan, 3,6);
            Spannable.AttachSpan(textTarget, boldAndItalicSpan, 10,15);

            //Inline Example
            Spannable.AttachSpan(textTarget, FontSpanBuilder.Initialize()
                                                    .WithFamilyName("Arial")
                                                    .WithFontWeight(FontWeightType.Thin)
                                                    .WithFontWidth(FontWidthType.ExtraCondensed)
                                                    .WithFontSlant(FontSlantType.Italic)
                                                    .WithFontSize(40)
                                                    .Build(),
                                                 0,2);
            Spannable.BuildSpannedText(textTarget );



        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
