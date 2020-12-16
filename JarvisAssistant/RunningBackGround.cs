using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;


namespace JarvisAssistant
{
    class RunningBackGround
    {
        protected SpeechConfig speechConfig = SpeechConfig.FromSubscription(Credential.subscriptionCode, Credential.region);
        protected SpeechRecognizer recognizer;
        protected AudioConfig audioConfig;
        protected SpeechSynthesizer synthesizer;

        public event TrueFalseDelegate FormVisibility;
        public event EventHandler ShowNotification;

        public RunningBackGround()
        {
            InitializeVoiceControl();

            var pharseList = PhraseListGrammar.FromRecognizer(recognizer);
            pharseList.AddPhrase("hey jarvis");


            recognizer.Recognized += Recognizer_Recognized;
            recognizer.Canceled += Recognizer_Canceled;
            speechConfig.EnableDictation(); 
         
        }

        private void Recognizer_Canceled(object sender, SpeechRecognitionCanceledEventArgs e)
        {
            MessageBox.Show(e.ErrorDetails); 
        }

        public void InitializeVoiceControl()
        {
            audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            recognizer = new SpeechRecognizer(speechConfig, audioConfig);
            synthesizer = new SpeechSynthesizer(speechConfig);
        }

        private void Recognizer_Recognized(object sender, SpeechRecognitionEventArgs e)
        {
            string text = e.Result.Text.ToLower();
            if (text.Contains(Orders.Greeting1) || text.Contains(Orders.Greeting2) || text.Contains(Orders.Greeting3))
            {
                synthesizer.SpeakTextAsync("Hi boss. I'm listening");

                if (ShowNotification != null)
                    ShowNotification(null, null);

                ListenAfterCalled listenAfterCalled = new ListenAfterCalled();
                listenAfterCalled.Starting();

                ChangeFormVisibility(listenAfterCalled.isShowing);

            }


        }

        private void ChangeFormVisibility(bool ob)
        {
            if (FormVisibility != null)
                FormVisibility(ob);
        }

       
        public void StartRecognizing()
        {

            recognizer.StartContinuousRecognitionAsync();
            //recognizer.StartKeywordRecognitionAsync(KeywordRecognitionModel.FromFile());

        }
    }
}
