using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelsLibrary
{
    enum Tags
    {
        Player,
        Wall,
        Exit,
        TextEntity
    }
    public class Global
    {
        public static List<Scene> Levels { get; set; } = new List<Scene>();
        public static List<Music> music { get; set; } = new List<Music>();
        public static int CurrentLevel { get; set; }


        static Global()
        {
            music.Add(new Music("Resources\\Music\\1st.wav"));
            music.Add(new Music("Resources\\Music\\2nd.wav"));
            music.Add(new Music("Resources\\Music\\3nd.wav"));
            Levels.Add(new FirstLevel());
            Levels.Add(new SecondLevel());
            Levels.Add(new ThirdLevel());
            CurrentLevel = 0;
            Music.GlobalVolume = 0.05f;
        }

        public static Scene GetLevel(int level)
        {
            return Levels[level];
        }
        public static Scene GetNextLevel()
        {
            CurrentLevel++;
            return Levels[CurrentLevel];
        }
        public static Scene GetCurrentLevel()
        {
            return Levels[CurrentLevel];
        }
        public static int Level()
        {
            return CurrentLevel;
        }
        public static void PlayMusic(int n_music)
        {
            music[n_music].Play();
        }
        public static void StopMusic(int n_music)
        {
            music[n_music].Pause();
        }
    }
}
