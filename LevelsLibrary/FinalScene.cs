using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelsLibrary
{
    public class FinalScene : Scene
    {
        public FinalScene()
        {
            Image img = Image.CreateRectangle(320, 240, Color.Black);
            AddGraphic(img);
            
        }
        public override void Update()
        {
            base.Update();
            Add(new FinalTextScene("КОНЕЦ!","Всем спасибо!"));
        }
    }
    class FinalTextScene : Entity
    {
        Text textBig, textSmall;
        public FinalTextScene(string a, string b)
        {
            X = Game.Instance.HalfWidth;
            Y = Game.Instance.HalfHeight;
            textSmall = new Text(b, 12);
            textSmall.CenterOrigin();
            textSmall.Color = Color.White;
            textBig = new Text(a, 20);
            textBig.CenterOrigin();
            textBig.Color = Color.Yellow;
        }
        public override void Update()
        {
            base.Update();
            AddGraphic(textBig,0,-10);
            AddGraphic(textSmall,0,10);
            RemoveSelf();
        }

    }
}
