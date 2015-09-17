using System;
using Android.Views;

namespace MvvmLightHelp.Droid
{
    public static class BoolToVisibileConverter
    {
        static bool ConvertBack(ViewStates viewState)
        {
            return viewState == ViewStates.Visible;
        }

        static ViewStates Convert(bool visible)
        {
            return visible ? ViewStates.Visible : ViewStates.Gone;
        }
    }
}

