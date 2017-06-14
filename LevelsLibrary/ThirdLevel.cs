using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelsLibrary
{
    public class ThirdLevel:Scene
    {
        public ThirdLevel()
        {
            string pathProject = "Resources\\ProjectLab.oep", pathLevel = "Resources\\Level3.oel";
            OgmoProject ogmo1 = new OgmoProject(pathProject);
            ogmo1.RegisterTag(Tags.Wall, "Wall");
            ogmo1.LoadLevelFromFile(pathLevel, this);
        }
        TextWithBox tmp;
        public override void Update()
        {
            base.Update();
            tmp = new TextWithBox("ЧЕРТ!!!\n", CameraCenterX, CameraCenterY, false);
            if (Timer > 0 && Timer < 100)
                Add(tmp);
            if (Timer > 200 && Timer < 400)
            {
                tmp = new TextWithBox("В какой Житомир я попала!", CameraCenterX, CameraCenterY, false);
                Add(tmp);
            }
            if (Timer > 500 && Timer < 700)
            {
                tmp = new TextWithBox("Мне кажеться, что где-то тут\nесть маяк...", CameraCenterX, CameraCenterY, false);
                Add(tmp);
            }
        }
    }
}
