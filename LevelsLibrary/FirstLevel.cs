using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace LevelsLibrary
{
    public class FirstLevel : Scene
    {
       
        public FirstLevel() : base()
        {

            string pathProject = "Resources\\ProjectLab.oep", pathLevel = "Resources\\Level1.oel";
            OgmoProject ogmo = new OgmoProject(pathProject);
            ogmo.RegisterTag(Tags.Wall, "Wall");
            ogmo.LoadLevelFromFile(pathLevel, this);
            Global.PlayMusic(Global.CurrentLevel);
        }
        TextWithBox tmp;
        public override void Update()
        {
            base.Update();
             tmp = new TextWithBox("Найди выход с этой странной деревни!\n", CameraCenterX, CameraCenterY, false);
            if (Timer > 0 && Timer < 250)
               Add(tmp);
            if (Timer > 450 && Timer < 600)
            {
                tmp = new TextWithBox("Хм, совсем никого нету...", CameraCenterX, CameraCenterY, false);
                Add(tmp);
            }
            if (Timer > 800 && Timer < 1000)
            {
                tmp = new TextWithBox("Надо быстрее добраться до гавани!", CameraCenterX, CameraCenterY, false);
                Add(tmp);
            }

        }
    }
    
  

   
    
    
}

