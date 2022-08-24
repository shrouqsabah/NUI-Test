using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;

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


            //string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. labelbalelele";
            //s/tring text = "Loremipsumdolorsitametcon secteturadipiscingelitseddoeiusmodtemporincididuntutlaboreetdoloremagnaaliqua.";
            //string text = "Loremipsumdolorsitametconsecteturadipiscingelitseddoeiusmodtemporincididuntutlaboreetdoloremagnaaliqua.Loremipsumdolorsitametconsecteturadipiscingelitseddoeiusmodtemporincididuntutlaboreetdoloremagnaaliqua";
            string text = "مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم";
            //string text = "23456789A223456789B323456789C423456789D523456789E623456789F723456789G823456789H92345678900234567890123456789022345678903234567890";


            var label = NewTextLabel(text, true);
            //var label = NewTextField(text, true);
            //var label = NewTextEditor(text, true);

            //label.EllipsisPosition = EllipsisPosition.Start;
            //label.EllipsisPosition = EllipsisPosition.Middle;

            view.Add(label);

            var button = new Button
            {
                Text = "get geometry of label",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(button);
            button.Clicked += (s, e) =>
            {
                PrintGeometry(label, "Main Label First line", 0);
                PrintGeometry(label, "Main Label 3rd line", 2);
                //PrintGeometry(label, "Main Label Last line", label.LineCount-1); //Ellipsis case when need to re-check

            };


            TextLabel label2 = new TextLabel
            {
                Text = "<b>V</b>ery short text for geometry test Very short text for geom etry test geometry test geop",
                MultiLine = true,
                EnableMarkup = true,
                //WidthSpecification = LayoutParamPolicies.MatchParent,
                WidthSpecification = 476,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
                LineWrapMode = LineWrapMode.Character,
            };
            view.Add(label2);

            var button2 = new Button
            {
                Text = "get geometry of label2",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(button2);
            button2.Clicked += (s, e) =>
            {
                PrintGeometry(label2, "Ref Label First line", 0);
                PrintGeometry(label2, "Ref Label Last line", label2.LineCount-1);
            };


            var button3 = new Button
            {
                Text = "Change text and get geometry",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(button3);
            button3.Clicked += (s, e) =>
            {
                label.Text = "Very short text for geometry test";
                PrintGeometry(label2, "Main2 Label First line", 0);
                PrintGeometry(label2, "Main2 Label Last line", label2.LineCount-1);
            };

            var button4 = new Button
            {
                Text = "Restore",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(button4);
            button4.Clicked += (s, e) =>
            {
                label.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
                PrintGeometry(label2, "Main Label First line", 0);
                PrintGeometry(label2, "Main Label Last line", label2.LineCount-1);
            };
        }

        public TextLabel NewTextLabel(string text, bool ellipsis)
        {
            TextLabel label = new TextLabel
            {
                Text = text,
                //EnableMarkup = true,
                Ellipsis = ellipsis,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                //HeightSpecification = 90,
                HeightSpecification = 140,
                //HeightSpecification = 40,
                //HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
                LineWrapMode = LineWrapMode.Character,
                //LineWrapMode = LineWrapMode.Word,
                //EllipsisPosition = EllipsisPosition.Start,
                //EllipsisPosition = EllipsisPosition.Middle,
            };
            return label;
        }

        public TextField NewTextField(string text, bool ellipsis)
        {
            TextField field = new TextField
            {
                Text = text,
                //EnableMarkup = true,
                Ellipsis = ellipsis,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
                //EllipsisPosition = EllipsisPosition.Start,
                //EllipsisPosition = EllipsisPosition.Middle,
            };
            return field;
        }

        public TextEditor NewTextEditor(string text, bool ellipsis)
        {
            TextEditor editor = new TextEditor
            {
                Text = text,
                //EnableMarkup = true,
                Ellipsis = ellipsis,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 140,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
                //EllipsisPosition = EllipsisPosition.Start,
                //EllipsisPosition = EllipsisPosition.Middle,
            };
            return editor;
        }

        public void PrintGeometry(TextLabel label, string title, int lineIndex)
        {
            Tizen.Log.Error("NUI", "[ " + title + " ] ============================\n");
            //Tizen.Log.Error("NUI", "label line[" + label.LineCount + "] size[" + label.Size.Width + ", " + label.Size.Height + "] \n");

            Tizen.Log.Error("NUI", "text length[" + label.Text.Length + "] \n");

            List<Size2D> sizeList = TextGeometry.GetLineSize(label, lineIndex);

            List<Position2D> positionList = TextGeometry.GetLinePosition(label, lineIndex);

            Tizen.Log.Error("NUI", "sizeList count[" + sizeList.Count + "] \n");
            for (int i = 0 ; i < sizeList.Count ; i ++)
            {
                Tizen.Log.Error("NUI", "item[" + i + "] width[" + sizeList[i].Width + "] height[" + sizeList[i].Height + "] \n");
            }

            Tizen.Log.Error("NUI", "positionList count[" + positionList.Count + "] \n");
            for (int i = 0 ; i < positionList.Count ; i ++)
            {
                Tizen.Log.Error("NUI", "item[" + i + "] X[" + positionList[i].X + "] Y[" + positionList[i].Y + "] \n");
            }

            Tizen.Log.Error("NUI", "\n");
        }

        public void PrintGeometry(TextField label, string title, int lineIndex)
        {
            Tizen.Log.Error("NUI", "[ " + title + " ] ============================\n");
            //Tizen.Log.Error("NUI", "label line[" + label.LineCount + "] size[" + label.Size.Width + ", " + label.Size.Height + "] \n");

            Tizen.Log.Error("NUI", "text length[" + label.Text.Length + "] \n");

            List<Size2D> sizeList = TextGeometry.GetLineSize(label, lineIndex);

            List<Position2D> positionList = TextGeometry.GetLinePosition(label, lineIndex);

            Tizen.Log.Error("NUI", "sizeList count[" + sizeList.Count + "] \n");
            for (int i = 0 ; i < sizeList.Count ; i ++)
            {
                Tizen.Log.Error("NUI", "item[" + i + "] width[" + sizeList[i].Width + "] height[" + sizeList[i].Height + "] \n");
            }

            Tizen.Log.Error("NUI", "positionList count[" + positionList.Count + "] \n");
            for (int i = 0 ; i < positionList.Count ; i ++)
            {
                Tizen.Log.Error("NUI", "item[" + i + "] X[" + positionList[i].X + "] Y[" + positionList[i].Y + "] \n");
            }

            Tizen.Log.Error("NUI", "\n");
        }

        public void PrintGeometry(TextEditor label, string title, int lineIndex)
        {
            Tizen.Log.Error("NUI", "[ " + title + " ] ============================\n");
            //Tizen.Log.Error("NUI", "label line[" + label.LineCount + "] size[" + label.Size.Width + ", " + label.Size.Height + "] \n");

            Tizen.Log.Error("NUI", "text length[" + label.Text.Length + "] \n");

            List<Size2D> sizeList = TextGeometry.GetLineSize(label, lineIndex);

            List<Position2D> positionList = TextGeometry.GetLinePosition(label, lineIndex);

            Tizen.Log.Error("NUI", "sizeList count[" + sizeList.Count + "] \n");
            for (int i = 0 ; i < sizeList.Count ; i ++)
            {
                Tizen.Log.Error("NUI", "item[" + i + "] width[" + sizeList[i].Width + "] height[" + sizeList[i].Height + "] \n");
            }

            Tizen.Log.Error("NUI", "positionList count[" + positionList.Count + "] \n");
            for (int i = 0 ; i < positionList.Count ; i ++)
            {
                Tizen.Log.Error("NUI", "item[" + i + "] X[" + positionList[i].X + "] Y[" + positionList[i].Y + "] \n");
            }

            Tizen.Log.Error("NUI", "\n");
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
