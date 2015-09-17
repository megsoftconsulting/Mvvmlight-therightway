using Android.Views;

namespace MvvmLightHelp.Droid
{
    public static class CountToInvisibilityConverter
    {
        public static ViewStates Convert(int count)
        {
            return count > 0 ? ViewStates.Visible : ViewStates.Gone;
        }
    }
}

