using System;
using Android.App;
using Android.Runtime;
using Com.Squareup.Picasso;
using Java.IO;
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
            dynamic imagem = null;

            if (value.ToString().StartsWith("/"))
                imagem = new File(value.ToString());  //Se for a imagem da galeria.
            else
                imagem = _act.Resources.GetIdentifier(value.ToString(), "drawable", _act.PackageName);
            Picasso.With(_act)
                .Load(imagem)
                .Resize(300, 200)
                .CenterInside()
                .Into(circleView);
        }
    }
}