using Otter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelsLibrary
{

    public class Player : Entity
    {
        enum Animation_Walk
        {
            WalkUp,
            WalkDown,
            WalkRight,
            WalkLeft,
            StopUp,
            StopDown,
            StopLeft,
            StopRight
        }
        Spritemap<Animation_Walk> spritemap = new Spritemap<Animation_Walk>("Resources\\character.png",12,12);
        public Player(float x, float y) : base(x, y)
        {
            this.Layer = -10000;
            spritemap.Add(Animation_Walk.WalkDown, "0,1,2,1", 8);
            spritemap.Add(Animation_Walk.WalkLeft, "3,4,5,4", 8);
            spritemap.Add(Animation_Walk.WalkRight, "6,7,8,7", 8);
            spritemap.Add(Animation_Walk.WalkUp, "9,10,11,10", 8);
            spritemap.Add(Animation_Walk.StopDown, "1", 1);
            spritemap.Add(Animation_Walk.StopLeft, "4", 1);
            spritemap.Add(Animation_Walk.StopRight, "7", 1);
            spritemap.Add(Animation_Walk.StopUp, "10", 1);
            spritemap.Play(Animation_Walk.StopDown);
            AddGraphic(spritemap);
            SetHitbox(12, 12, Tags.Player);
            
        }

        bool text_win = true;
        public override void Update()
        {
            if (Global.SaveInput == true)
            {
                X = Global.X;
                Y = Global.Y;
                Global.SaveInput = false;
            }
            base.Update();

            if (text_win != false)
            {
                if (Input.KeyDown(Key.Up) || Input.KeyDown(Key.W))
                {
                    if (!Overlap(X, Y - 2, Tags.Wall) && this.Timer % 2 == 0)
                        Y -= 4;
                    spritemap.Play(Animation_Walk.WalkUp, false);

                }
                else if (Input.KeyDown(Key.Down) || Input.KeyDown(Key.S))
                {
                    if (!Overlap(X, Y + 2, Tags.Wall) && this.Timer % 2 == 0)
                        Y += 4;
                    spritemap.Play(Animation_Walk.WalkDown, false);

                }
                else if (Input.KeyDown(Key.Left) || Input.KeyDown(Key.A))
                {
                    if (!Overlap(X - 2, Y, Tags.Wall) && this.Timer % 2 == 0)

                        X -= 4;
                    spritemap.Play(Animation_Walk.WalkLeft, false);

                }
                else if (Input.KeyDown(Key.Right) || Input.KeyDown(Key.D))
                {
                    if (!Overlap(X + 2, Y, Tags.Wall) && this.Timer % 2 == 0)
                        X += 4;
                    spritemap.Play(Animation_Walk.WalkRight, false);

                }
                Scene.CenterCamera(X, Y);
                if (Input.KeyReleased(Key.Up) || Input.KeyReleased(Key.W))
                    spritemap.Play(Animation_Walk.StopUp);
                if (Input.KeyReleased(Key.Down) || Input.KeyReleased(Key.S))
                    spritemap.Play(Animation_Walk.StopDown);
                if (Input.KeyReleased(Key.Left) || Input.KeyReleased(Key.A))
                    spritemap.Play(Animation_Walk.StopLeft);
                if (Input.KeyReleased(Key.Right) || Input.KeyReleased(Key.D))
                    spritemap.Play(Animation_Walk.StopRight);

            }

            if (Overlap(X, Y, Tags.Exit))
            {
                text_win = false;
                spritemap.Stop();
                if (Input.KeyPressed(Key.Return))
                {

                    Global.StopMusic(Global.CurrentLevel);
                    Game.SwitchScene(Global.GetNextLevel());
                    Global.PlayMusic(Global.CurrentLevel);
                    RemoveSelf();
                }
            }
            if (Input.KeyPressed(Key.Pause))
            {
                Game.AddScene(new PauseMenuScene(Scene.CameraCenterX, Scene.CameraCenterY));
            }
            if (Input.KeyPressed(Key.Insert))
                using (FileStream fl_save = new FileStream("test.txt", FileMode.Create))
                {
                    string _textSave = Global.CurrentLevel + " " + X + " " + Y;
                    byte[] textSave = System.Text.Encoding.Default.GetBytes(_textSave);
                    fl_save.Write(textSave, 0, textSave.Length);
                }   
        }

    }
   
    class PauseMenuScene : Scene
    {
        public PauseMenuScene(float x, float y)
        {
            Add(new PauseMenu(x,y));
        }
        public override void Update()
        {
            base.Update();
            if (Input.KeyPressed(Key.Pause))
                Game.RemoveScene();
            if (Input.KeyPressed(Key.Q))
            { Game.SwitchScene(new StartScene());
                Global.ClearLevel();
            }

        }
    }
    class PauseMenu : Entity
    {
        public PauseMenu(float x, float y)
        {
            Image backgr = Image.CreateRectangle(320, 240, Color.White);
            AddGraphic(backgr);
            Text textmenu = new Text("Paused", 20);
            Text textMenu = new Text("Q - Menu", 10);
            textmenu.Color = Color.Black;
            textMenu.Color = Color.Black;
            textmenu.SetPosition(Game.Instance.HalfWidth, Game.Instance.HalfHeight);
            textMenu.SetPosition(Game.Instance.HalfWidth,15);
            textmenu.CenterOrigin();
            textMenu.CenterOrigin();
            AddGraphic(textmenu);
            AddGraphic(textMenu);

        }
        
    }
}
