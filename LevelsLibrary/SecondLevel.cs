using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelsLibrary
{
    public class SecondLevel:Scene
    {
        public SecondLevel():base()
        {
            string pathProject = "Resources\\ProjectLab.oep", pathLevel = "Resources\\Level2.oel";
            OgmoProject ogmo1 = new OgmoProject(pathProject);
            ogmo1.RegisterTag(Tags.Wall, "Wall");
            ogmo1.LoadLevelFromFile(pathLevel, this);
        }
        TextWithBox tmp;
        public override void Update()
        {
            base.Update();
            tmp = new TextWithBox("Вау! С помощью дешевой анимации\nя попала на остров!", CameraCenterX, CameraCenterY, false);
            if (Timer > 0 && Timer < 250)
                Add(tmp);
            if (Timer > 450 && Timer < 550)
            {
                tmp = new TextWithBox("Это чудо!", CameraCenterX, CameraCenterY, false);
                Add(tmp);
            }
            if (Timer > 700 && Timer < 1000)
            {
                tmp = new TextWithBox("Где-то на этом острове есть пещера\nкоторая мне поможет скрыться\nот проблем в жизни.", CameraCenterX, CameraCenterY, false);
                Add(tmp);
            }
        }

    }
}
