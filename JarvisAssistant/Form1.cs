using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System.Diagnostics;
using System.Threading;

namespace JarvisAssistant
{
    public partial class myAssistant : Form
    {
        RunningBackGround voiceBackground;
   
        public myAssistant()
        {
            InitializeComponent();

            voiceBackground = new RunningBackGround();
            voiceBackground.StartRecognizing();
            voiceBackground.FormVisibility += VoiceBackground_FormVisibility;
            voiceBackground.ShowNotification += VoiceBackground_ShowNotification;

            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void VoiceBackground_ShowNotification(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(5000);
        }

        private void VoiceBackground_FormVisibility(bool b)
        {
            if (b == false)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;

            }
            else
            {
                //this.TopMost = true;
                this.ShowInTaskbar = true;

            }
        }
       
    }
}
