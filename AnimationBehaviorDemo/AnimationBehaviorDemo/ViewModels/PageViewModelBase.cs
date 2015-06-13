using GalaSoft.MvvmLight;

namespace AnimationBehaviorDemo.ViewModels
{
  public class PageViewModelBase : ViewModelBase, IPageViewModelBase
  {
    public virtual void OnViewAppearing()
    {
      ViewHasAppeared = true;
    }

    public virtual void OnViewDisappearing()
    {
      ViewHasAppeared = false;

    }

    private bool viewHasAppeared;
    public bool ViewHasAppeared
    {
      get { return viewHasAppeared; }
      set { Set(() => ViewHasAppeared, ref viewHasAppeared, value); }
    }
  }
}
