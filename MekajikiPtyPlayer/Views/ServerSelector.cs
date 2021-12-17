using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using MekajikiPtyPlayer.Connection;
using Terminal.Gui;

namespace MekajikiPtyPlayer.Views
{
    public class ServerSelector : Window
    {
        private Label setupLabel;
        private Label ipLabel;
        private TextField ipField;
        private Label usernameLabel;
        private TextField usernameField;
        private Label otpLabel;
        private TextField otpField;
        private Button connectButton;

        public ServerSelector()
        {
            setupLabel = new Label("Connect to your Mekajiki server")
            {
                X = Pos.Center(),
                Y = 2
            };
            ipLabel = new Label("Server IP:")
            {
                X = Pos.Left(setupLabel),
                Y = Pos.Bottom(setupLabel) + 1
            };
            ipField = new TextField()
            {
                X = Pos.Right(ipLabel),
                Y = Pos.Bottom(setupLabel) + 1,
                Width = 20
            };
            usernameLabel = new Label("Username:")
            {
                X = ipLabel.X,
                Y = Pos.Bottom(ipLabel)+1
            };
            usernameField = new TextField()
            {
                X = Pos.Right(usernameLabel),
                Y = usernameLabel.Y,
                Width = 20 //its annoying ik
            };
            otpLabel = new Label("OTP:")
            {
                X = usernameLabel.X,
                Y = Pos.Bottom(usernameLabel)+1
            };
            otpField = new TextField()
            {
                X = Pos.Right(otpLabel),
                Y = otpLabel.Y,
                Width = 6
            };
            connectButton = new Button("Connect")
            {
                X = Pos.Center(),
                Y = Pos.Bottom(otpField)+1
            };
            connectButton.Clicked += () => Task.Run(ConnectButtonOnClicked);
            
            Add(setupLabel);
            Add(ipLabel);
            Add(ipField);
            Add(usernameLabel);
            Add(usernameField);
            Add(otpLabel);
            Add(otpField);
            Add(connectButton);
        }

        private async Task ConnectButtonOnClicked()
        {
            if (Uri.TryCreate("https://" + ipField.Text.ToString(), UriKind.Absolute, out var ip))
            {
                if (otpField.Text.Length != 6 && otpField.Text.ToByteArray().Cast<char>().Any(x => !char.IsDigit(x)))
                {
                    MessageBox.ErrorQuery(8, 5, "Error", "Invalid OTP", "OK");
                    return;
                }
                
                Ping p = new Ping();
                PingReply reply = await p.SendPingAsync(ip.Host);
                if (reply.Status != IPStatus.Success)
                {
                    MessageBox.ErrorQuery(8, 5, "Error while connecting", reply.Status.ToString(), "OK");
                    return;
                }

                string token = await Api.GetTokenAsync(ip, usernameField.ToString(), otpField.ToString());
            }
            else
            {
                MessageBox.ErrorQuery(8, 5, "Error while connecting", "Malformed IP", "OK");
            }
        }
    }
}