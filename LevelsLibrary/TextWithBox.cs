using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelsLibrary
{
    public class TextWithBox : Entity
    {
        Text text;
        Text textEnter;
        Image box;
        bool textEnterVisible;
        public TextWithBox(string text_string,float x, float y, bool _textEnterVisible)
        {
            this.Layer = -10000;
            X = x;
            Y =y;
            textEnterVisible = _textEnterVisible;
             text = new Text(text_string, 10);
            textEnter = new Text("Press Enter", 7);
             box = new Image("Resources\\box.png");
            box.CenterOrigin();
            text.Color = Color.Black;
            textEnter.Color = Color.Black;
            textEnter.CenterOrigin();
            AddGraphic(box, 0, 76);
            if(textEnterVisible)
                AddGraphic(textEnter, box.Right-40, box.Bottom-10 );
            AddGraphic(text, box.Left + 10, box.Top + 5);

        }
        public override void Update()
        {
            base.Update();
            RemoveSelf();
            AddGraphic(box, 0, 76);
            if (textEnterVisible)
                AddGraphic(textEnter, box.Right-40, box.Bottom - 10);
            AddGraphic(text, box.Left + 10, box.Top + 5);
            

        }
    }
}
