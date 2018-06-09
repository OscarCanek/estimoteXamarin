using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace estimoteXamarin.Droid
{
    class ObservingErrorHandler : Java.Lang.Object, Kotlin.Jvm.Functions.IFunction1
    {
        public Java.Lang.Object Invoke(Java.Lang.Object throwable)
        {
            Log.Debug("app", $"MyErrorHandler, {throwable}");

            return null;
        }
    }
}