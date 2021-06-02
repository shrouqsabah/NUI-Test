using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

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

            // Normal field
            TextField field = new TextField
            {
                Text = "Text Field Changed",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                MaxLength = 20,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };

            field.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
                field.Text = "Field";
            };

            view.Add(field);


            // Need to implement layout editor
            TextEditor editor = new TextEditor
            {
                Text = "Text Editor Changed",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };

            editor.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Editor Text Changed[" + e.TextEditor.Text + "] \n");
                editor.Text = "Editor";
            };

            view.Add(editor);


            // Normal field
            TextField field2 = new TextField
            {
                Text = "Text Field",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                MaxLength = 20,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };

            field2.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
            };

            view.Add(field2);


            // Need to implement layout editor
            TextEditor editor2 = new TextEditor
            {
                Text = "Text Editor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 300,

                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };

            editor2.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Editor Text Changed[" + e.TextEditor.Text + "] \n");
            };

            view.Add(editor2);

            window.Add(view);
        }


        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
