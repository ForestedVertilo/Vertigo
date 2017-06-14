using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelsLibrary
{
    public class TimerText:Entity 
    {
        Text textTimer;
        public TimerText(float texttimer, float x, float y)
        {
            X = x;
            Y = y;
            string _text = $"{texttimer /100}";
            textTimer = new Text(_text, 16);
            textTimer.Color = Color.Black;

        }

        public override void Update()
        {
            base.Update();
            RemoveSelf();
            AddGraphic(textTimer);
        }
    }
}
