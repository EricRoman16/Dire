using System.Collections.Generic;
using System.IO;
using System.Media;

namespace Dire
{
    public static class AudioPlayer
    {
        static Dictionary<int, string> Sounds = new Dictionary<int, string>()
        {
            {1, @".\Stronger.wav" },
            {2, @".\TypingSound.wav" }
        };

        public static void PlayMusic()
        {
            SoundPlayer SongPlayer = new SoundPlayer();
            SongPlayer.SoundLocation = Sounds[1];
            SongPlayer.PlayLooping();
        }
        public static SoundPlayer PlayTypingSound() // gonna need to work on this
        {
            SoundPlayer TypePlayer = new SoundPlayer();
            TypePlayer.SoundLocation = Sounds[2];
            return TypePlayer;
        }
    }
}
