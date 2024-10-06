using CommunityToolkit.Mvvm.ComponentModel;
using JSiniDevTool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSiniDevTool.ViewModels.Base {
  public class ViewModelBase : ObservableObject {



    private IList<MenuInfo>? _menus;
    public IList<MenuInfo>? Menus {
      get => _menus;
      set => SetProperty(ref _menus, value);
    }


    public OptionInfo Option {
      get => App.g_option;
    }




    /*
		protected virtual void RaisePropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }


    public event PropertyChangedEventHandler PropertyChanged;
    */
  }
}
