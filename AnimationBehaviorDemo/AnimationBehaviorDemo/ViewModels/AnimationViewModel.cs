using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace AnimationBehaviorDemo.ViewModels
{
  public class AnimationViewModel : PageViewModelBase
  {
    public AnimationViewModel()
    {
      TogglePopup = new RelayCommand(DoTogglePopup);
    }
    public ICommand TogglePopup { get; private set; }

    private void DoTogglePopup()
    {
      IsPopupVisible = !IsPopupVisible;
    }

    private bool isPopupVisible;

    public bool IsPopupVisible
    {
      get { return isPopupVisible; }
      set { Set(() => IsPopupVisible, ref isPopupVisible, value); }
    }
  }
}
