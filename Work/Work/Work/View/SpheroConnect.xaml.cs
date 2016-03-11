using RobotKit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Work.View
{
    public partial class SpheroConnect : ContentPage
    {
        public const string ConnectedToSpehro = "Conntect To Sphero";
        public const string ConnectingToSphero = "Connecting To Sphero {0}";
        public const string NotConnectedToSphero = "Not Connected {0}";

        Sphero my_robot = null;

        public SpheroConnect()
        {
            InitializeComponent();
        }

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    base.OnNavigatedTo(e);

        //    SetUpConnection();
        //    Application app = Application.Current;
        //}

        //protected override void OnNavigatedFrom(NavigationEventArgs e)
        //{
        //    base.OnNavigatedFrom(e);

        //    ShutDownRobotConnection();

        //    Application app = Application.Current;
        //}

        public void SetUpConnection()
        {
            SpheroName.Text = NotConnectedToSphero;

            RobotProvider provider = RobotProvider.GetSharedProvider();
            provider.DiscoveredRobotEvent += DicsoveredRobot;
            provider.NoRobotsEvent += NoRobotsDiscovered;
            provider.ConnectedRobotEvent += RobotConnected;
            provider.FindRobots();
        }
        private void ShutDownRobotConnection()
        {
            if (my_robot != null)
            {
                my_robot.SensorControl.StopAll();
                my_robot.Sleep();
                //ConnectionToggle.OffContent = "Disconnected";
                SpheroName.Text = NotConnectedToSphero;
            }
        }
        private void DicsoveredRobot(object sender, Robot robot)
        {
            Debug.WriteLine(string.Format("Discovered \"{0}\"", robot.BluetoothName));

            if (my_robot == null)
            {
                RobotProvider provider = RobotProvider.GetSharedProvider();
                provider.ConnectRobot(robot);

                //ConnectionToggle.IsToggled = IsEnabled;
                //ConnectionToggle.OnContent = "Connected";
                my_robot = (Sphero)robot;
                SpheroName.Text = string.Format(ConnectedToSpehro, robot.BluetoothName);
            }
        }

        private void NoRobotsDiscovered(object sender, EventArgs e)
        {
            Debug.WriteLine("No Sphero Paired");
            DisplayAlert("Alert", "No Sphero Paired", "OK");
        }
        private void RobotConnected(object sender, Robot robot)
        {
            Debug.WriteLine(string.Format("Connected to {0}", robot));
            //ConnectionToggle.OnContent = "Connected";

            my_robot.SetRGBLED(255, 255, 255);
            SpheroName.Text = string.Format(ConnectedToSpehro, robot.BluetoothName);

        }
       void ConnectionToggle_Toggled(object sender, ToggledEventArgs args)
        {
            Debug.WriteLine("Connection Toggled: ");
            //ConnectionToggle.OnContent = "Connecting...";
            if(args.Value)
            {
                SetUpConnection();
            }
            else
            {
                ShutDownRobotConnection();
            }
            //if (args.Value)
            //{
            //    if (my_robot == null)
            //    {
            //        SetUpConnection();
            //    }
            //    else
            //    {
            //        ShutDownRobotConnection();
            //    }
            //}

        }
        private void OnCollisionDetected(object sender, CollisionData data)
        {
            Debug.WriteLine("Grab collected");
        }
    }
}

