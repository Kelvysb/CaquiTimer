using BControls;
using BGlobalization;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace CaquiTimer
{

    public partial class CaquiTimerMain : Window
    {

        #region Declarations
        private GlobalizationSource objGlobalizationSource = new GlobalizationSource();
        private System.Windows.Forms.NotifyIcon objTrayIcon;
        private System.Windows.Forms.ContextMenu objContextMenu;
        #endregion

        #region Constructor
        public CaquiTimerMain()
        {
            try
            {
                InitializeComponent();

                var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
                this.Left = desktopWorkingArea.Right - this.Width;
                this.Top = desktopWorkingArea.Bottom - this.Height;

                BMessage.sbInitialize((Brush)FindResource("BaseColor"),
                                      (Brush)FindResource("BackColor"),
                                      (Brush)FindResource("FontColorDark"),
                                      (Brush)FindResource("FontColor"),
                                      (FontFamily)FindResource("Font"),
                                      CaquiTimerBO.Instance.WorkDirectory + "\\Log");

                objContextMenu = new System.Windows.Forms.ContextMenu();

                objContextMenu.MenuItems.Add(GlobalizationSource.Open);
                objContextMenu.MenuItems[0].Click += mnuOpen_Click;

                objContextMenu.MenuItems.Add(GlobalizationSource.Pause);
                objContextMenu.MenuItems[1].Click += mnuPause_Click;

                objContextMenu.MenuItems.Add(GlobalizationSource.NextTask);
                objContextMenu.MenuItems[2].Click += mnuNextTask_Click;

                objContextMenu.MenuItems.Add(GlobalizationSource.Close);
                objContextMenu.MenuItems[3].Click += mnuClose_Click;
                
                objTrayIcon = new System.Windows.Forms.NotifyIcon();
                objTrayIcon.Icon = Properties.Resources.icon1;
                objTrayIcon.ContextMenu = objContextMenu;
                objTrayIcon.Visible = false;
                objTrayIcon.Text = GlobalizationSource.AppName;
                objTrayIcon.DoubleClick += mnuOpen_Click;

                UpdateTextValues();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadPage();
            }
            catch (Exception ex)
            {
                BMessage.Instance.fnErrorMessage(ex);
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MinimizeToTray();
            }
            catch (Exception ex)
            {
                BMessage.Instance.fnErrorMessage(ex);
            }
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            try
            {
                Maximize();
            }
            catch (Exception ex)
            {
                BMessage.Instance.fnErrorMessage(ex);
            }
        }

        private void mnuPause_Click(object sender, EventArgs e)
        {
            try
            {
                Pause();
            }
            catch (Exception ex)
            {
                BMessage.Instance.fnErrorMessage(ex);
            }
        }        

        private void mnuNextTask_Click(object sender, EventArgs e)
        {
            try
            {
                NextTask();
            }
            catch (Exception ex)
            {
                BMessage.Instance.fnErrorMessage(ex);
            }
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            try
            {
                CloseApp();
            }
            catch (Exception ex)
            {
                BMessage.Instance.fnErrorMessage(ex);
            }
        }
        #endregion

        #region Functions
        private void LoadPage()
        {
            try
            {



            }
            catch (Exception ex)
            {
                throw new Exception(GlobalizationSource.MsgError, ex);
            }
        }
      

        private void MinimizeToTray()
        {
            try
            {
                this.Hide();
                objTrayIcon.Visible = true;
            }
            catch (Exception ex)
            {
                throw new Exception(GlobalizationSource.MsgError, ex);
            }
        }

        private void Maximize()
        {
            try
            {
                this.Show();
                objTrayIcon.Visible = false;
            }
            catch (Exception ex)
            {
                throw new Exception(GlobalizationSource.MsgError, ex);
            }
        }

        private void Pause()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(GlobalizationSource.MsgError, ex);
            }
        }

        private void NextTask()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(GlobalizationSource.MsgError, ex);
            }
        }

        private void CloseApp()
        {
            try
            {
                if (BMessage.Instance.fnMessage(GlobalizationSource.MsgClose, GlobalizationSource.AppName, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(GlobalizationSource.MsgError, ex);
            }
        }

        private void UpdateTextValues()
        {
            try
            {
                BMessage.Instance.Yes = GlobalizationSource.Yes;
                BMessage.Instance.No = GlobalizationSource.No;
                BMessage.Instance.Cancel = GlobalizationSource.Cancel;
                BMessage.Instance.Ok = GlobalizationSource.Ok;

                btnMinimize.ToolTip = GlobalizationSource.Minimize;
                btnClose.ToolTip = GlobalizationSource.Close;
                btnConfig.ToolTip = GlobalizationSource.Configuration;
                objContextMenu.MenuItems[0].Text = GlobalizationSource.Open;
                objContextMenu.MenuItems[1].Text = GlobalizationSource.Pause;
                objContextMenu.MenuItems[2].Text = GlobalizationSource.NextTask;
                objContextMenu.MenuItems[3].Text = GlobalizationSource.Close;

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Properties
        public GlobalizationSource GlobalizationSource { get => objGlobalizationSource; }

        public string Test { get => "Teste"; }

        #endregion


    }



    public class GlobalizationSource
    {
        public GlobalizationSource()
        {
            try
            {
                BGLanguage.Initialize(".\\Globalization\\");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AppName { get => Properties.Resources.ResourceManager.GetString("AppName").ToString(); }
        public string Minimize { get => BGLanguage.Instance.GetValue("Minimize"); }
        public string Configuration { get => BGLanguage.Instance.GetValue("Configuration"); }
        public string MsgError { get => BGLanguage.Instance.GetValue("msgError"); }
        public string Open { get => BGLanguage.Instance.GetValue("Open"); }
        public string Close { get => BGLanguage.Instance.GetValue("Close"); }
        public string Pause { get => BGLanguage.Instance.GetValue("Pause"); }
        public string NextTask { get => BGLanguage.Instance.GetValue("NextTask"); }
        public string MsgClose { get => BGLanguage.Instance.GetValue("MsgClose"); }
        public string Yes { get => BGLanguage.Instance.GetValue("Yes"); }
        public string No { get => BGLanguage.Instance.GetValue("No"); }
        public string Ok { get => BGLanguage.Instance.GetValue("Ok"); }
        public string Cancel { get => BGLanguage.Instance.GetValue("Cancel"); }

    }
}
