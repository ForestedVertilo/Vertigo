using Otter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelsLibrary
{
    public class StartScene : Scene
    {
        public StartScene() : base()
        {
            Add(new MenuText());
        }
    }
    
    class MenuText : Entity
    {
        RichText text1, text2;
        Image point = Image.CreateCircle(5, Color.Red);
        Image vertigo_name = new Image("Resources\\Vertrigo.png");

        public MenuText() : base()
        {
            this.Layer = -10000;
            text1 = new RichText("{waveRateY:10}{waveAmpY:1}Start!", 20);
            text2 = new RichText("{waveRateY:7}{waveAmpY:1}Load", 20);
            Text textSave = new Text("Insert - save", 10);
            Text textPause = new Text("Pause - pause",10);
            text1.Color = Color.Green;
            text2.Color = Color.Black;
            textSave.Color = Color.Black;
            textPause.Color = Color.Black;
            textSave.CenterOrigin();
            textPause.CenterOrigin();
            text1.CenterOrigin();
            text2.CenterOrigin();
            point.CenterOrigin();
            vertigo_name.CenterOrigin();
            AddGraphic(vertigo_name, Game.Instance.HalfWidth, 40);
            AddGraphic(textSave,Game.Instance.HalfWidth,220);
            AddGraphic(textPause, Game.Instance.HalfWidth,230);
            AddGraphic(text1, Game.Instance.HalfWidth, Game.Instance.HalfHeight - 20+20);
            AddGraphic(text2, Game.Instance.HalfWidth, Game.Instance.HalfHeight + 20+20);
            AddGraphic(point, text1.Left - 10, text1.Y + 4);
        }


        int choose = 1;
        
        public override void Update()
        {
            base.Update();
           

            if (Input.KeyPressed(Key.W) || Input.KeyPressed(Key.S))
            {
                if (choose == 1)
                {
                    RemoveGraphic(point);
                    AddGraphic(point, text2.Left - 10, text2.Y + 4);
                    choose = 2;
                }
                else if (choose == 2)
                {
                    RemoveGraphic(point);
                    AddGraphic(point, text1.Left - 10, text1.Y + 4);
                    choose = 1;
                }
            }

            if (Input.KeyPressed(Key.Return))
            {
                if (choose == 1)
                {
                    Game.SwitchScene(Global.GetCurrentLevel());
                }
                else if (choose == 2)
                {
                    using (FileStream fl_save = File.OpenRead("test.txt"))
                    {
                        byte[] textSave = new byte[fl_save.Length];
                        fl_save.Read(textSave, 0, textSave.Length);
                        string[] _textsave = System.Text.Encoding.Default.GetString(textSave).Split(Convert.ToChar(" "));
                        Global.ClearLevel();
                        Global.X = float.Parse(_textsave[1]);
                        Global.Y = float.Parse(_textsave[2]);
                        Global.SaveInput = true;
                        Game.SwitchScene(Global.GetLevel(int.Parse(_textsave[0])));
                    }
                }
            }

        }
    }

}
