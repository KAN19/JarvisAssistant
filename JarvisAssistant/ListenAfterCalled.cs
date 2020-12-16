using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System.Diagnostics;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;



namespace JarvisAssistant
{
    class ListenAfterCalled : RunningBackGround
    {
        public bool isShowing { get; set; } = true;

        bool isDone = false;
        int timeSpeaking = 2;
        private Capture capture = new Capture(0);

        PhraseListGrammar pharseList;
        public ListenAfterCalled()
        {
            InitializeVoiceControl();
            loadmyMyGrammarList(); 


        }

        private void loadmyMyGrammarList()
        {
            pharseList = PhraseListGrammar.FromRecognizer(recognizer);
            pharseList.AddPhrase(Orders.Hide1);
            pharseList.AddPhrase(Orders.Hide2);
            pharseList.AddPhrase(Orders.Hide3);
            pharseList.AddPhrase(Orders.Show1);
            pharseList.AddPhrase(Orders.Show2);
            pharseList.AddPhrase(Orders.OpenChrome1);
            pharseList.AddPhrase(Orders.OpenChrome2);
            pharseList.AddPhrase(Orders.OpenExplorer1);
            pharseList.AddPhrase(Orders.OpenExplorer2);
            pharseList.AddPhrase(Orders.OpenNotepad1);
            pharseList.AddPhrase(Orders.OpenNotepad2);
            pharseList.AddPhrase(Orders.Time1);
            pharseList.AddPhrase(Orders.Time2);
     
        }

        public void Starting()
        {
            var result = recognizer.RecognizeOnceAsync();
            string text = result.Result.Text.ToLower();

            ExecuteCommands(text);
            if (isDone == true)
            {
               
                timeSpeaking = 2;
            }

        }

        private void ExecuteCommands(string str)
        {
            isDone = true;
            timeSpeaking--;
            if (str.Contains(Orders.OpenChrome1) || str.Contains(Orders.OpenChrome2))
            {
                synthesizer.SpeakTextAsync("Ok boss!");
                Process.Start("chrome", "https://www.google.com/");
            }
            else if (str.Contains(Orders.Hide2) || str.Contains(Orders.Hide1) || str.Contains(Orders.Hide3))
            {
                synthesizer.SpeakTextAsync("Leaving now!");
                isShowing = false;
            }
            else if (str.Contains(Orders.Show1) || str.Contains(Orders.Show2))
            {
                synthesizer.SpeakTextAsync("I'm here!");
                isShowing = true;
            }
            else if (str.Contains(Orders.OpenExplorer1) || str.Contains(Orders.OpenExplorer2))
            {
                synthesizer.SpeakTextAsync("On my way, sir!");
                Process.Start("explorer");
            }
            else if (str.Contains(Orders.OpenNotepad1) || str.Contains(Orders.OpenNotepad2))
            {
                synthesizer.SpeakTextAsync("Right away!");
                Process.Start("notepad");
            }
            else if (str.Contains(Orders.Time1) || str.Contains(Orders.Time2))
            {
                string timeString = DateTime.Now.ToLongTimeString();
                synthesizer.SpeakTextAsync(timeString);
            }
            else if (str.Contains(Orders.Music1) || str.Contains(Orders.Music2))
            {
                Process.Start("explorer", "https://www.youtube.com/watch?v=T0sHaz4H9MQ");
            }
            else if (str == "")
            {
                isDone = false;
                if (timeSpeaking != 0)
                    this.Starting();
            }
            else
            {
                synthesizer.SpeakTextAsync("I don't understand!");
                isDone = false;
                if (timeSpeaking != 0)
                    this.Starting();
            }
        }

      
    }
}
