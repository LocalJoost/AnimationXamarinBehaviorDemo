using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimationBehaviorDemo.ViewModels;
using Xamarin.Forms;

namespace AnimationBehaviorDemo
{
  public partial class StartPage : ContentPage
  {
    public StartPage()
    {
      InitializeComponent();
      BindingContext = new AnimationViewModel();
    }

    protected override void OnAppearing()
    {
      Context.OnViewAppearing();
      base.OnAppearing();
    }

    protected override void OnDisappearing()
    {
      Context.OnViewDisappearing();
      base.OnDisappearing();
    }

    private IPageViewModelBase Context
    {
      get { return (IPageViewModelBase)BindingContext; }
    }
  }
}
