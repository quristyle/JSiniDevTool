using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using JSiniDevTool.ViewModels.Base;

namespace JSiniDevTool.Models {
  public class MenuInfo : ObservableObject {

    private string _title;
    public string Title {
      get { return _title; }
      set { SetProperty(ref _title, value); }
    }

    
    private bool _isFixed;
    /// <summary>
    /// 하나의 문서만 열리지의 여부
    /// </summary>
    public bool IsFixed {
      get { return _isFixed; }
      set { SetProperty(ref _isFixed, value); }
    }

    private UserControl _view;
    public UserControl View { get => _view;
      set { SetProperty(ref _view, value); }
    }



  }



}
