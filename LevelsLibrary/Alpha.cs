using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelsLibrary
{
    class alpha : Component
    {
        bool Fl;
        public alpha(bool fl)
        {
            Fl = fl;
        }
        public override void Update()
        {

            base.Update();
            if (Fl == false)
            {
                float alpha = Entity.GetGraphic<Image>().Alpha;
                alpha -= 0.0005f;
                Entity.GetGraphic<Image>().Alpha = alpha;
            }
            if (Fl == true)
            {
                float alpha = Entity.GetGraphic<Image>().Alpha;
                alpha += 0.0005f;
                Entity.GetGraphic<Image>().Alpha = alpha;
            }
        }
    }
}
