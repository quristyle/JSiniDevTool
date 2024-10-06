using JSiniDevTool.ViewModels;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


using System.Windows.Shapes;



using Microsoft.Win32;




namespace JSiniDevTool.Views {
  /// <summary>
  /// OptionPage.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class OptionPage : UserControl {
    public OptionPage() {
      InitializeComponent();
      this.DataContext = new OptionViewModel();

      this.Loaded += OptionPage_Loaded;

    }

    private void OptionPage_Loaded(object sender, RoutedEventArgs e) {

      Debug.WriteLine("OptionPage_Loaded");

    }



    /*
     * 
     * ----------------------------------
추가된 값:3
----------------------------------
HKLM\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection\DisableRealtimeMonitoring: 0x00000001
HKLM\SOFTWARE\WOW6432Node\Policies\Microsoft\Windows Defender\Real-Time Protection\DisableRealtimeMonitoring: 0x00000001
HKU\S-1-5-21-3022617783-1859189491-856441561-1001\Software\Microsoft\Windows\CurrentVersion\Group Policy Objects\{F5149586-7B96-4B7C-BA7C-70986F558BFB}Machine\Software\Policies\Microsoft\Windows Defender\Real-Time Protection\DisableRealtimeMonitoring: 0x00000001


     */

    private void ToggleButton_Click_1(object sender, RoutedEventArgs e) {
      bool isRTok = (bool)RealTime_protection.IsChecked;
      if( isRTok) {
        RegistryKey reg = Registry.LocalMachine.CreateSubKey("SOFTWARE")
          .CreateSubKey("Policies")
          .CreateSubKey("Microsoft")
          .CreateSubKey("Windows Defender")
          .CreateSubKey("Real-Time Protection");

        reg.SetValue("DisableRealtimeMonitoring", 0x00000001, RegistryValueKind.DWord);

        //DisableRealtimeMonitoring: 0x00000001

        //HKLM\SOFTWARE\WOW6432Node\Policies\Microsoft\Windows Defender\Real-Time Protection
      }
      else {
        RegistryKey reg = Registry.LocalMachine.CreateSubKey("SOFTWARE")
          .CreateSubKey("Policies")
          .CreateSubKey("Microsoft")
          .CreateSubKey("Windows Defender")
          .CreateSubKey("Real-Time Protection");

        reg.SetValue("DisableRealtimeMonitoring", 0x00000000, RegistryValueKind.DWord);

      }
    }













    //컴퓨터\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Defender\Spynet                  dword SpyNetReporting












  }
}
