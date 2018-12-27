/*
 *
 * NOTICE 
 * COMPILATION REQUIRES YOU TO DOWNLOAD THE ROBOT THIN FONT
 * GET IT HERE: https://github.com/google/fonts/blob/master/apache/roboto/Roboto-Thin.ttf
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;
using CefSharp;
using System.IO;

namespace Leopard
{
    public partial class LeopardBrowser : Form
    {
        public static string AssemblyDirectory = Application.StartupPath;
        private bool backEnabled = false,forwardEnabled = false;
        private Random random = new Random();
        private readonly ChromiumWebBrowser browser;

        public bool currPageIsError = false;

        public LeopardBrowser()
        {
            InitializeComponent();
            Text = "Loading Leopard";
            browser = new ChromiumWebBrowser("www.google.com")
            {
                Dock = DockStyle.Fill,
            };
            this.content.Panel2.Controls.Add(browser);
            browser.IsBrowserInitializedChanged += OnIsBrowserInitializedChanged;
            browser.LoadingStateChanged += OnLoadingStateChanged;
            browser.ConsoleMessage += OnBrowserConsoleMessage;
            browser.StatusMessage += OnBrowserStatusMessage;
            browser.TitleChanged += OnBrowserTitleChanged;
            browser.AddressChanged += OnBrowserAddressChanged;
            browser.LoadError += OnLoadFailed;
        }

        private void LeopardBrowser_Load(object sender, EventArgs e)
        {
            AssemblyDirectory = Application.StartupPath;
            //Set up icons (if they exist, else use the ugly error icon)
            if (File.Exists(AssemblyDirectory + @"\Theme\no_back.png")) {
                back.Image = Image.FromFile(AssemblyDirectory + @"\Theme\no_back.png");
            } else {
                back.Image = Properties.Resources.error;
            }

            if (File.Exists(AssemblyDirectory + @"\Theme\no_forward.png")) {
                forward.Image = Image.FromFile(AssemblyDirectory + @"\Theme\no_forward.png");
            } else {
                forward.Image = Properties.Resources.error;
            }

            if (File.Exists(AssemblyDirectory + @"\Theme\home.png")) {
                home.Image = Image.FromFile(AssemblyDirectory + @"\Theme\home.png");
            } else {
                home.Image = Properties.Resources.error;
            }

            if (File.Exists(AssemblyDirectory + @"\Theme\refresh.png")) {
                refresh.Image = Image.FromFile(AssemblyDirectory + @"\Theme\refresh.png");
            } else {
                refresh.Image = Properties.Resources.error;
            }
        }

        private void OnIsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs e)
        {
            if (e.IsBrowserInitialized)
            {
                var b = ((ChromiumWebBrowser)sender);

                this.InvokeOnUiThreadIfRequired(() => b.Focus());
            }
        }

        private void OnBrowserConsoleMessage(object sender, ConsoleMessageEventArgs args)
        {
            //DisplayOutput(string.Format("Line: {0}, Source: {1}, Message: {2}", args.Line, args.Source, args.Message));
        }

        private void OnBrowserStatusMessage(object sender, StatusMessageEventArgs args)
        {
            //this.InvokeOnUiThreadIfRequired(() => statusLabel.Text = args.Value);
        }

        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            SetCanGoBack(args.CanGoBack);
            SetCanGoForward(args.CanGoForward);

            this.InvokeOnUiThreadIfRequired(() => SetIsLoading(!args.CanReload));
        }

        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => Text = args.Title + " - Leopard");
        }

        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs args)
        {
            if (currPageIsError==false) {
                this.InvokeOnUiThreadIfRequired(() => url.Text = args.Address);
            }
        }

        private void SetCanGoBack(bool canGoBack)
        {
            if(canGoBack == true)
            {
                if (File.Exists(AssemblyDirectory + @"\Theme\back.png")) {
                    back.Image = Image.FromFile(AssemblyDirectory + @"\Theme\back.png");
                } else {
                    back.Image = Properties.Resources.error;
                }
            } else {
                if (File.Exists(AssemblyDirectory + @"\Theme\no_back.png")) {
                    back.Image = Image.FromFile(AssemblyDirectory + @"\Theme\no_back.png");
                } else {
                    back.Image = Properties.Resources.error;
                }
            }
        }

        private void SetCanGoForward(bool canGoForward)
        {
            if (canGoForward == true)
            {
                if (File.Exists(AssemblyDirectory + @"\Theme\back.png")) {
                    back.Image = Image.FromFile(AssemblyDirectory + @"\Theme\back.png");
                } else {
                    back.Image = Properties.Resources.error;
                }
            }
            else
            {
                if (File.Exists(AssemblyDirectory + @"\Theme\no_back.png")) {
                    back.Image = Image.FromFile(AssemblyDirectory + @"\Theme\no_back.png");
                } else {
                    back.Image = Properties.Resources.error;
                }
            }
        }

        private void SetIsLoading(bool isLoading)
        {
            if (isLoading==false) {
                toolTip1.SetToolTip(refresh,"Stop loading the webpage.");
                if (File.Exists(AssemblyDirectory + @"\Theme\refresh.png")) {
                    refresh.Image=Image.FromFile(AssemblyDirectory + @"\Theme\refresh.png");
                } else {
                    refresh.Image = Properties.Resources.error;
                }
            } else {
                toolTip1.SetToolTip(refresh, "Refresh the webpage.");
                if (File.Exists(AssemblyDirectory + @"\Theme\stop_load.png")) {
                    refresh.Image = Image.FromFile(AssemblyDirectory + @"\Theme\stop_load.png");
                } else {
                    refresh.Image = Properties.Resources.error;
                }
            }
        }

        private void url_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            LoadUrl(url.Text);
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (backEnabled)
            {
                browser.Back();
            }
        }

        private void forward_Click(object sender, EventArgs e)
        {
            if (forwardEnabled)
            {
                browser.Forward();
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            LoadUrl(url.Text);
        }

        private void home_Click(object sender, EventArgs e)
        {
            LoadUrl("http://www.google.com");
        }

        private void LoadUrl(string url)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                currPageIsError = false;
                browser.Load(url);
            }
        }

        private void OnLoadFailed(object sender, LoadErrorEventArgs e)
        {
            CefErrorCode errorCode = e.ErrorCode;
            string url = e.FailedUrl;
            string errorText = e.ErrorText;

            string Header = "", Description = "";
            bool show = false;

            //for dev purposes
            Console.WriteLine("ERROR WHILE LOADING: "+errorCode+", TEXT: "+errorText +" at \""+url+"\"");

            #region SettingTheMessage

            if (errorCode==CefErrorCode.NetworkChanged)
            {
                show = true;
                Header = "Network Changed";
                Description = "A network change was detected";
            }
            if (errorCode == CefErrorCode.ConnectionTimedOut)
            {
                show = true;
                Header = "The Server Took Too Long To Respond";
                Description = "The connection timed out";
            }
            if (errorCode == CefErrorCode.ConnectionReset)
            {
                show = true;
                Header = "Connection Reset";
                Description = "The connection reset";
            }
            if (errorCode == CefErrorCode.NameNotResolved)
            {
                show = true;
                Header = "Page Not Found";
                Description = "The webpage specified doesn't exist.";
            }
            if (errorCode == CefErrorCode.OutOfMemory)
            {
                show = true;
                Header = "Out of Memory";
                Description = "There wasn't enough RAM to complete the operation";
            }

            #endregion

            //IF WE SHOW THE CODE (BECAUSE THERE ARE ERROR CODES WHICH ARE NOT ERRORS, SUCH AS NO CACHE)

            if (show == true) {
                //Create the html code
                //Maybe make it look nicer? idk im too lazy to do the html and css.
                string htmlCrap = "<html><head><title>" + Header + "</title><style>.description{font-family: 'Segoe UI', Tahoma, sans-serif;}p,h1{font-family: 'Segoe UI', Tahoma, sans-serif;}</style></head><body><h1>" + Header + "</h1><br><p class=\"description\">" + Description + "</p><br><p>" + errorText + "</p></body></html>";
                //generate a random url (so people cant make the site on purpose to mess up the error pages if the user has internet and can load the page successfully)
                string urlThatDoesntExist = "http://" + GenerateRandomString(128) + "." + GenerateRandomString(3);
                //Load that crap on the screen
                currPageIsError = true;
                browser.LoadHtml(htmlCrap, urlThatDoesntExist);

            } else {
                currPageIsError = false;
            }
        }

        private void LeopardBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            browser.Dispose();
            Cef.Shutdown();
        }

        public string GenerateRandomString(int length)
        {
            var chars = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            var stringChars = new char[length];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
    }
}
