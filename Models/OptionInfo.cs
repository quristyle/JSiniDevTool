using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;
using JSiniDevTool.ViewModels.Base;

namespace JSiniDevTool.Models {
  public class OptionInfo : ObservableObject {
    private double _mainWidth;
    public double MainWidth {
      get { return _mainWidth; }
      set { SetProperty(ref _mainWidth, value); }
    }


    private double _mainHeight;
    public double MainHeight {
      get { return _mainHeight; }
      set { SetProperty(ref _mainHeight, value); }
    }


    private bool _isDarkThema;

    public bool IsDarkThema {
      get { return _isDarkThema; }
      set { SetProperty(ref _isDarkThema, value); }
    }

    public double Top { get => _top; set => _top = value; }
    public double Left { get => _left; set => _left = value; }

    private double _top;
    private double _left;


  }



}
