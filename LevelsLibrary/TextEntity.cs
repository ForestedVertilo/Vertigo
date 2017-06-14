using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelsLibrary
{
    class TextEntity:Entity
    {
        public TextEntity()
        {
            SetHitbox(16, 16);
        }
        public override void Update()
        {
            base.Update();
            if (Overlap(96, 528, Tags.Player))
            {
                Scene.Add(new TextWithBox("1", Scene.CameraCenterX, Scene.CameraCenterY, false));
            }
            if (Overlap(X, Y, Tags.Player) )
            {
                Scene.Add(new TextWithBox("2", Scene.CameraCenterX, Scene.CameraCenterY, false));
            }
        }
    }
}
