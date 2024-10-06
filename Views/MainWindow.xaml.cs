using AvalonDock;
using AvalonDock.Layout;
using JSiniDevTool.ViewModels;
using JSiniDevTool.Views;
using JSiniDevTool.Views.Common;
using MaterialDesignThemes.Wpf;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace JSiniDevTool {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {

    readonly AvalonDock.Themes.Vs2013DarkTheme _dockTheme = new();
    readonly AvalonDock.Themes.Vs2013LightTheme _lightTheme = new();

    public MainWindow() {
      InitializeComponent();
      this.DataContext = new MainWindowViewModel();

      this.Closing += MainWindow_Closing;

    }

    private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e) {

      App.g_option.Top = this.Top;
      App.g_option.Left = this.Left;
      App.g_option.MainWidth = this.Width;
      App.g_option.MainHeight = this.Height;
      App.g_option.IsDarkThema = (dockManager.Theme == _dockTheme);
      App.SaveConfig();
    }

    private void DockManager_DocumentClosing(object sender, DocumentClosingEventArgs e) {


      //if (MessageBox.Show("Are you sure you want to close the document?", "AvalonDock Sample", MessageBoxButton.YesNo) == MessageBoxResult.No)
       // e.Cancel = true;


    }

    private void OnLayoutRootPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
      var activeContent = ((LayoutRoot)sender).ActiveContent;
      if (e.PropertyName == "ActiveContent") {
        Debug.WriteLine(string.Format("ActiveContent-> {0}", activeContent));
      }
    }



    private void AddTwoDocuments_click(object sender, RoutedEventArgs e) {
      var firstDocumentPane = dockManager.Layout.Descendents().OfType<LayoutDocumentPane>().FirstOrDefault();
      if (firstDocumentPane != null) {
        LayoutDocument doc = new() {
          Title = "Test1"
        };
        firstDocumentPane.Children.Add(doc);

        LayoutDocument doc2 = new() {
          Title = "Test2"
        };
        firstDocumentPane.Children.Add(doc2);
      }

    }



    private void MenuToggleButton_OnClick(object sender, RoutedEventArgs e)
        => SearchBox.Focus();

    private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
      DragMove();
    }


    private void MenuList_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e) {


      var menu = (e.Source as ListBox).SelectedItem as JSiniDevTool.Models.MenuInfo;

      var firstDocumentPane = dockManager.Layout.Descendents().OfType<LayoutDocumentPane>().FirstOrDefault();
      if (firstDocumentPane != null) {
        LayoutDocument doc = new() {
          Title = menu.Title ,
          Content = menu.View
        };



        firstDocumentPane.Children.Add(doc);

        dockManager.ActiveContent = doc;

      }
    }

    internal void initLoad() {

      this.Width = App.g_option.MainWidth;
      this.Height = App.g_option.MainHeight;

      this.Top = App.g_option.Top;
      this.Left = App.g_option.Left;

      ModifyTheme(App.g_option.IsDarkThema);

      DarkModeToggleButton.IsChecked = App.g_option.IsDarkThema;

      AdminModeToggleButton.IsChecked = App.IsAdministrator();




      }


    public void ModifyTheme(bool isDarkTheme) {
      var paletteHelper = new PaletteHelper();
      var theme = paletteHelper.GetTheme();

      theme.SetBaseTheme(isDarkTheme ? BaseTheme.Dark : BaseTheme.Light);
      paletteHelper.SetTheme(theme);

      dockManager.Theme = isDarkTheme ? _dockTheme : _lightTheme;

    }

    private async void MenuPopupButton_OnClick(object sender, RoutedEventArgs e) {


      var messageDialog = new MessageDialog {
        Message = { Text = "Application Exit?" }
      };

     object?result =  await DialogHost.Show(messageDialog, "RootDialog");

      if ((bool)result == true) { this.Close(); }


    }

    private void MenuDarkModeButton_Click(object sender, RoutedEventArgs e) {
      ModifyTheme(DarkModeToggleButton.IsChecked == true);
      
      App.g_option.IsDarkThema = (DarkModeToggleButton.IsChecked == true);
    }

    private void FlowDirectionButton_Click(object sender, RoutedEventArgs e) {

    }

    private async void ControlsEnabledToggleButton_Click(object sender, RoutedEventArgs e) {
      var isAdmin = App.IsAdministrator();

      if (AdminModeToggleButton.IsChecked == true && !isAdmin ) {
        var messageDialog = new MessageDialog {
          Message = { Text = "restart of Administrator mode?" }
        };

        object? result = await DialogHost.Show(messageDialog, "RootDialog");

        if ((bool)result == true) {

          App.AdminModeRestart();

        }
      }

    }



    private void Button_Click(object sender, RoutedEventArgs e) {
    }

    private void Button_Click_1(object sender, RoutedEventArgs e) {
      if (this.WindowState == WindowState.Maximized) {
        this.WindowState = WindowState.Normal;
      }
      else {
        this.WindowState = WindowState.Maximized;
      }
    }

    private void Button_Click_2(object sender, RoutedEventArgs e) {

      if (this.WindowState == WindowState.Minimized) {
        this.WindowState = WindowState.Normal;
      }
      else {
        this.WindowState = WindowState.Minimized;
      }
    }

  }
}