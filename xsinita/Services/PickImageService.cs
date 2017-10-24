using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using xsinita.Core.Interfaces;

namespace xsinita.Services
{
    public class PickImageService : IPickImageService
    {
        private static readonly IMvxAndroidCurrentTopActivity Top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
        private static readonly Activity _act = Top.Activity;
        private static int PICK_IMAGE = 1234;
        public void PickImage()
        {
            Intent i = new Intent(Intent.ActionPick, Android.Provider.MediaStore.Images.Media.InternalContentUri);
            
            //_act.StartActivityForResult(Intent.CreateChooser(i, "Selecione uma imagem"), PICK_IMAGE);
            
        }

        


        
    }
}