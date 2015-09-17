
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Views;

namespace MvvmLightHelp.Droid
{
    [Activity(Label = "Product Details", ParentActivity=typeof(MainActivity))]			
    public class DetailsActivity : ActivityBase
    {
        public const string PageKey = "DetailsActivity";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
        }
    }
}

