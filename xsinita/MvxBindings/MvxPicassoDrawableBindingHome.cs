using System;
using Android.App;
using Android.Runtime;
using Com.Squareup.Picasso;
using MvvmCross.Binding.Droid.Target;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using Android.Widget;


namespace xsinita.MvxBindings
{
    [Preserve(AllMembers = true)]
    public class MvxPicassoDrawableBindingHome : MvxAndroidTargetBinding
    {
        private static readonly IMvxAndroidCurrentTopActivity _top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
        private readonly Activity _act = _top.Activity;

        public MvxPicassoDrawableBindingHome(object target) : base(target)
        {
        }

        public override Type TargetType
        {
            get { return typeof(string); }
        }

        protected override void SetValueImpl(object target, object value)
        {
            if (value == null) return;
            var imageView = (ImageView)target;
            var imagem = _act.Resources.GetIdentifier(value.ToString(), "drawable", _act.PackageName);
            Picasso.With(_act)
                .Load(imagem)
                .Resize(250,150)
                .CenterInside()
                .Into(imageView);
        }
    }
}