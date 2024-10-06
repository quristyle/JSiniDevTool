using JSiniDevTool.Models;
using System.Configuration;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Text;
using System.Windows;
using System.Xml.Serialization;
using System.Xml;
using System.Security.Principal;
using System.Diagnostics;

namespace JSiniDevTool {
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application {
    private void Application_Startup(object sender, StartupEventArgs e) {


      g_main = new();
      LoadConfig();
      g_main.initLoad();
      g_main.ShowDialog();

      return;

      if (!App.IsAdministrator()) {

        string aaa = "";

        if(e.Args.Length > 0 && e.Args[0] == "admin_restart") {
          App.Current.Shutdown();
        }

        MessageBox.Show("not admin");

        // Restart and run as admin
        /*
        var exeName = AppDomain.CurrentDomain.FriendlyName;// Process.GetCurrentProcess().MainModule.FileName;
        ProcessStartInfo startInfo = new ProcessStartInfo(exeName+".exe");
        startInfo.UseShellExecute = true;
        startInfo.Verb = "runas";
        startInfo.Arguments = "admin_restart";
        Process.Start(startInfo);
        App.Current.Shutdown();
        */
        AdminModeRestart();
      }
      else {

        if (e.Args.Length > 0 && e.Args[0] == "admin_restart") {
          MessageBox.Show(e.Args[0]);
        }


        g_main = new();
        LoadConfig();
        g_main.initLoad();
        g_main.ShowDialog();

      }
    }



    public static bool IsAdministrator() {
      WindowsIdentity identity = WindowsIdentity.GetCurrent();
      WindowsPrincipal principal = new WindowsPrincipal(identity);
      return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }

    public static void AdminModeRestart() {
      var exeName = AppDomain.CurrentDomain.FriendlyName;// Process.GetCurrentProcess().MainModule.FileName;
      ProcessStartInfo startInfo = new ProcessStartInfo(exeName + ".exe");
      startInfo.UseShellExecute = true;
      startInfo.Verb = "runas";
      startInfo.Arguments = "admin_restart";
      Process.Start(startInfo);
      App.Current.Shutdown();
    }



    public static MainWindow g_main;
    public static OptionInfo g_option;








    /// <summary> 설정파일 xml 전체경로 </summary>
    static string cfgPath = @"config.xml";
    public static string CfgPath {
      get {
        return AppDomain.CurrentDomain.BaseDirectory + "/" + cfgPath;
      }
    }
    /// <summary> 설정파일 xml싱크. </summary>
    public static XmlSerializer m_serializer = new XmlSerializer(typeof(OptionInfo));

    public static bool IsRealExit;


    public static int configLoadCount = 0;

    /// <summary>
    /// 설정정보 로드
    /// </summary>
    public static void LoadConfig() {

      if (File.Exists(App.CfgPath)) {
        bool isError = false;

        using (FileStream fs = File.OpenRead(App.CfgPath)) {

          try {
            App.g_option = App.m_serializer.Deserialize(fs) as OptionInfo;
          }
          catch {
            Console.WriteLine("config xml load error");
            isError = true;
          }
        }

        if (isError) {
          //File.Delete(Program.CfgPath);
          File.Copy(AppDomain.CurrentDomain.BaseDirectory + "/config_bk.xml", App.cfgPath, true);
        }
      }
      else {
        App.g_option = new OptionInfo();
      }

      if (App.g_option == null) {
        configLoadCount++;
        if (configLoadCount < 3) {
          LoadConfig();
          Thread.Sleep(1000);
        }
      }


    }


    /// <summary>
    /// 설정정보 저장.
    /// </summary>
    public static void SaveConfig() {

      if (!File.Exists(App.CfgPath)) {
        File.Create(App.CfgPath).Close();
      }

      using (XmlTextWriter xtw = new XmlTextWriter(App.CfgPath, Encoding.UTF8)) {
        App.m_serializer.Serialize(xtw, App.g_option);
        xtw.Flush();
        xtw.Close();
      }

    }



































  }

}
