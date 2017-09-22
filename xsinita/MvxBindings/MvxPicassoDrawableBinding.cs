using System;
using Android.App;
using Android.Runtime;
using Com.Squareup.Picasso;
using MvvmCross.Binding.Droid.Target;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using Refractored.Controls;

namespace xsinita.MvxBindings
{
    [Preserve(AllMembers = true)]
    public class MvxPicassoDrawableBinding : MvxAndroidTargetBinding
    {
        private static readonly IMvxAndroidCurrentTopActivity _top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
        private readonly Activity _act = _top.Activity;

        public MvxPicassoDrawableBinding(object target) : base(target)
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
            var imagem = _act.Resources.GetIdentifier(Convert.ToString(value), "drawable", _act.PackageName);
            Picasso.With(_act)
                .Load(imagem)
                .Resize(300, 200)
                .CenterInside()
                .Into(circleView);
        }
    }
}