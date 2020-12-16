using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System.Diagnostics;

namespace JarvisAssistant
{
    public static class Orders
    {
        public static string Greeting1 = "hey jarvis";
        public static string Greeting2 = "jarvis";
        public static string Greeting3 = "hey";

        public static string Hide1 = "run background";
        public static string Hide2 = "background";
        public static string Hide3 = "run"; 

        public static string Show1 = "show off";
        public static string Show2 = "show";

        public static string OpenChrome1 = "open chrome";
        public static string OpenChrome2 = "chrome";

        public static string OpenExplorer1 = "open explorer";
        public static string OpenExplorer2 = "explorer";

        public static string OpenNotepad1 = "open notepad";
        public static string OpenNotepad2 = "notepad";

        public static string Time1 = "time";
        public static string Time2 = "what time is it";

        public static string Music1 = "play music"; 
        public static string Music2 = "music"; 

    }
}
