using Android.Views;

namespace MvvmLightHelp.Droid
{
    public static class CountToVisibilityConverter
    {
        public static ViewStates Convert(int count)
        {
            return count > 0 ? ViewStates.Gone : ViewStates.Visible;
        }
    }
}

