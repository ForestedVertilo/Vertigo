using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelsLibrary
{
    class Exit : Entity
    {
        public Exit(float x, float y) : base(x, y)
        {
            SetHitbox(16, 16, Tags.Exit);

        }
        public override void Update()
        {
            base.Update();
            if (Overlap(X, Y, Tags.Player) && Global.CurrentLevel == 0)
            {
                TextWithBox tmp = new TextWithBox("Ты отправляешься в город Нью-Солари!\n", Scene.CameraCenterX, Scene.CameraCenterY, true);
                Scene.Add(tmp);
                Scene.Pause();
            }
            if (Overlap(X, Y, Tags.Player) && Global.CurrentLevel == 1)
            {
                TextWithBox tmp = new TextWithBox("Тут я скроюсь от сессии...", Scene.CameraCenterX, Scene.CameraCenterY, true);
                Scene.Add(tmp);
                Scene.Pause();
            }
            if (Overlap(X, Y, Tags.Player) && Global.CurrentLevel == 2)
                Game.SwitchScene(new FinalScene());
        }
    }
}
