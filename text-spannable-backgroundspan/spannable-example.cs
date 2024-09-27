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
         BackgroundSpan  redSpan;

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
                Text = "UnAttach Red Span",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(button);
            button.Clicked += (s, e) =>
            {
                if(redSpan.BackgroundColorDefined)
                {
                    Spannable.DetachSpan(textTarget, redSpan );
                    Spannable.BuildSpannedText(textTarget );
                }

            };

            var builder = BackgroundSpanBuilder.Initialize();
            builder.WithBackgroundColor(Color.Red);
            redSpan = builder.Build();
            Spannable.AttachSpan(textTarget, redSpan, 3,6);
            Spannable.AttachSpan(textTarget, redSpan, 8,10);

            //Inline Example

             //Builder
            Spannable.AttachSpan(textTarget, BackgroundSpanBuilder.Initialize().WithBackgroundColor(Color.Green).Build(), 0,2);


            //Factory
            Spannable.AttachSpan(textTarget, BackgroundSpan.CreateWithBackgroundColor(Color.Blue), 11,15);
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
