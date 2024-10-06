using JSiniDevTool.Models;
using JSiniDevTool.ViewModels.Base;
using JSiniDevTool.Views;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace JSiniDevTool.ViewModels {
  public class MainWindowViewModel : ViewModelBase {






    public MainWindowViewModel() {
      Menus = [
                new (){Title = "Tool", View= new ToolPage()},
                new (){Title = "Option", View = new OptionPage()}
            ];



    }






  }
}
