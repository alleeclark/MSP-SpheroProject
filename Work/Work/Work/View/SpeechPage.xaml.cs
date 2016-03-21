using Microsoft.ProjectOxford.SpeechRecognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Work.View
{

    public partial class SpeechPage : ContentPage
    {
        public bool MicrophoneClientShortPharse { get; set; }
        string _recoLanguage = "en-us";
        private const string ShortWaveFile = @"";
        private DataRecognitionClient _dataClient;
        private MicrophoneRecognitionClient _micClient;
        string _subscriptionkey;
        public SpeechPage()
        {
            InitializeComponent();

        }

        public string SubscriptionKey
        {
            get
            {
                return _subscriptionkey;
            }
            set
            {
                _subscriptionkey = value;
                OnPropertyChanged<string>();
            }
        }
        private readonly string SubscriptionKeyFileName = "Subscription.txt";
        private readonly string MessageforKey = "Paste your subscription key here";

        private void Initalize()
        {
            MicrophoneClientShortPharse = true;
            SubscriptionKey = getSubscriptionKeyFromFile();
        }

        private void ToText(object sender, EventArgs args)
        {
            DataRecognitionClient client;
            var count = 0;
            //SpeechRecognitionMode recoMode;

            // SpeechRecognizer speechRecognizer = new SpeechRecognizer();
            //SpeechRecgnitionTopicConstraint topicConstraint = new SpeechRecgnitionTopicConstraint
        }

         private string getSubscriptionKeyFromFile()
        {
            string subscriptionkey = null;

            using (IsolatedStorageFile iostore )


                return subscriptionkey;
        }
    }
}
