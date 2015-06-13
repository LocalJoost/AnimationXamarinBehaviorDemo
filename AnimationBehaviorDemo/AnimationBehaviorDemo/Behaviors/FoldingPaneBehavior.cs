using System;
using Xamarin.Forms;

namespace AnimationBehaviorDemo.Behaviors
{
  public class FoldingPaneBehavior : Behavior<View>
  {
    private View associatedObject;

    private double unfoldingHeight;

    // This stuff could be properties as well!
    private const double HeightFraction = 0.6;
    private const double WidthFraction = 0.8;
    private const int FoldOutTime = 750;
    private const int FoldInTime = 500;

    protected override void OnAttachedTo(View bindable)
    {
      base.OnAttachedTo(bindable);
      associatedObject = bindable;
      bindable.BindingContextChanged += (sender, e) =>
          BindingContext = associatedObject.BindingContext;
    }

    protected override void OnDetachingFrom(View bindable)
    {
      associatedObject = null;
      base.OnDetachingFrom(bindable);
    }

    #region ViewHasAppeared Attached Dependency Property

    public static readonly BindableProperty ViewHasAppearedProperty =
      BindableProperty.Create<FoldingPaneBehavior, bool>(p => p.ViewHasAppeared, false, BindingMode.OneWay, propertyChanged: OnViewHasAppearedChanged);

    public bool ViewHasAppeared
    {
      get
      {
        return (bool)GetValue(ViewHasAppearedProperty);
      }
      set
      {
        SetValue(ViewHasAppearedProperty, value);
      }
    }

    private static void OnViewHasAppearedChanged(BindableObject bindable, bool oldValue, bool newValue)
    {
      var thisObj = bindable as FoldingPaneBehavior;
      if (thisObj != null && newValue)
      {
        thisObj.Init();
      }
    }

    #endregion

    #region IsPopupVisible Attached Dependency Property
    public static readonly BindableProperty IsPopupVisibleProperty =
       BindableProperty.Create<FoldingPaneBehavior, bool>(t => t.IsPopupVisible,
       default(bool), BindingMode.OneWay,
       propertyChanged: OnIsPopupVisibleChanged);

    public bool IsPopupVisible
    {
      get
      {
        return (bool)GetValue(IsPopupVisibleProperty);
      }
      set
      {
        SetValue(IsPopupVisibleProperty, value);
      }
    }

    private static void OnIsPopupVisibleChanged(BindableObject bindable, bool oldValue, bool newValue)
    {
      var thisObj = bindable as FoldingPaneBehavior;
      if (thisObj != null)
      {
        thisObj.AnimatePopup(newValue);
      }
    }
    #endregion

    private void Init()
    {
      var p = associatedObject.ParentView;
      unfoldingHeight = Math.Round(p.Height * HeightFraction, 2);
      associatedObject.WidthRequest = Math.Round(p.Width * WidthFraction , 2);
      associatedObject.HeightRequest = 0;
      associatedObject.IsVisible = false;
    }

    private void AnimatePopup(bool show)
    {
      if (show)
      {
        associatedObject.IsVisible = true;
        Animate(0, unfoldingHeight, FoldOutTime);
      }
      else
      {
        Animate(unfoldingHeight, 0, FoldInTime);
      }
    }

    private void Animate(double start, double end, uint runningTime)
    {
      var animation = new Animation(
        d => associatedObject.HeightRequest = d, start, end, Easing.SpringOut);

      animation.Commit(associatedObject, "Unfold", length: runningTime, 
        finished: (d, b) =>
      {
        if (associatedObject.Height.Equals(0))
        {
          associatedObject.IsVisible = false;
        }
      });
    }
  }
}
