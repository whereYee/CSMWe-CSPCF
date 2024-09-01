using Akequ.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Plugin.Additional
{
    class MusicManager : Room
    {
        public static void NetMusic(string url, Action<AudioClip> action)
        {
            AudioType type = AudioType.MPEG;
            string ty = url.Substring(url.LastIndexOf("."), url.Length - url.LastIndexOf("."));
            if (ty == "mp3" || ty == "MP3") type = AudioType.MPEG;
            if (ty == "wav" || ty == "WAV") type = AudioType.WAV;
            if (ty == "ogg" || ty == "OGG") type = AudioType.OGGVORBIS;
            ScriptHelper.DownloadClip(url, type, action);
        }

        public static void LoadMusic(string url, Action<AudioClip> action)
        {
            AudioType type = AudioType.MPEG;
            string ty = url.Substring(url.LastIndexOf("."), url.Length - url.LastIndexOf("."));
            if (ty == "mp3" || ty == "MP3") type = AudioType.MPEG;
            if (ty == "wav" || ty == "WAV") type = AudioType.WAV;
            if (ty == "ogg" || ty == "OGG") type = AudioType.OGGVORBIS;
            ScriptHelper.LoadClip(url, type, action);
        }
    }
}
