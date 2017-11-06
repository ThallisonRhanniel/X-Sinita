using System;
using Android.App;
using Android.Runtime;
using MvvmCross.Binding.Droid.Target;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using Refractored.Controls;
using Com.Squareup.Picasso;



namespace xsinita.MvxBindings
{
    [Preserve(AllMembers = true)]
    public class MvxPicassoUrlBinding : MvxAndroidTargetBinding
    {
        private static readonly IMvxAndroidCurrentTopActivity Top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
        private readonly Activity _act = Top.Activity;

        public MvxPicassoUrlBinding(object target) : base(target)
        {
        }

        public override Type TargetType
        {
            get { return typeof(string); }
        }

        protected override void SetValueImpl(object target, object value)
        {
            if (value == null) return;
            var circleView = (CircleImageView)target;
            Picasso.With(_act)
                .Load(value.ToString())
                .Resize(300, 200)
                .CenterInside()
                .Into(circleView);
        }
       
    }
}