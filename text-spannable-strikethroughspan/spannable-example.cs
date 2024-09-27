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
         StrikethroughSpan  greenStrikethrough;

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
                Text = "UnAttach Green Line Span",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(button);
            button.Clicked += (s, e) =>
            {
                if(greenStrikethrough.StrikethroughColorDefined)
                {
                    Spannable.DetachSpan(textTarget, greenStrikethrough );
                    Spannable.BuildSpannedText(textTarget );
                }

            };

            var builder = StrikethroughSpanBuilder.Initialize();
            builder.WithStrikethroughColor(Color.Green);


            greenStrikethrough = builder.Build();
            Spannable.AttachSpan(textTarget, greenStrikethrough, 3,6);
            Spannable.AttachSpan(textTarget, greenStrikethrough, 10,15);

            //Inline Example
            Spannable.AttachSpan(textTarget, StrikethroughSpanBuilder.Initialize()
                                  .WithStrikethroughColor(Color.Blue)
                                  .WithStrikethroughHeight(4.0f)
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
