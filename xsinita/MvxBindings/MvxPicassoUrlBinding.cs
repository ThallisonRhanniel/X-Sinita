﻿using System;
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
        static readonly IMvxAndroidCurrentTopActivity _top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
        private readonly Activity _act = _top.Activity;

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
            var imagem = value.ToString();
            Picasso.With(_act)
                .Load(imagem)
                .Resize(300, 200)
                .CenterInside()
                .Into(circleView);
        }
    }
}