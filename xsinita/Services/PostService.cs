﻿using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Preferences;
using Android.Runtime;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using xsinita.Core.Interfaces;

namespace xsinita.Services
{
    [Preserve(AllMembers = true)]
    public class PostService : IPostService
    {
        private static readonly IMvxAndroidCurrentTopActivity Top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
        private static readonly Activity _act = Top.Activity;
        private string _returnMessage = string.Empty;

        public async Task<string> EnviarDadosAsync(string name, string category, string comment)
        {
            await Task.Factory.StartNew(() =>
             {
                 using (HttpClient httpClient = new HttpClient())
                 {
                     try
                     {
                         string filePath = string.Empty;

                         ISharedPreferences pref = PreferenceManager.GetDefaultSharedPreferences(_act);
                         var imagePerfil = new Java.IO.File(pref.GetString("imagePath", ""));
                         if (imagePerfil.Exists())
                             filePath = imagePerfil.AbsolutePath;

                         var url = "https://sinita-api.herokuapp.com/v1/comments";

                         httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "07acc5cd49845af720ab0a9d4dcb7dcd7f05c45d");
                         MultipartFormDataContent form = new MultipartFormDataContent();

                         FileStream fs = File.OpenRead(filePath);
                         var streamContent = new StreamContent(fs);

                         var imageContent = new ByteArrayContent(streamContent.ReadAsByteArrayAsync().Result);
                         imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                         var nameContent = new StringContent(name);
                         var categoryContent = new StringContent(category);
                         var commentContent = new StringContent(comment);
                         var iconPerfilContent = new StringContent("Null");
                         form.Add(nameContent, "name");
                         form.Add(categoryContent, "category");
                         form.Add(commentContent, "comment");
                         form.Add(iconPerfilContent, "icon_perfil");
                         form.Add(imageContent, "imagem", Regex.Replace(Path.GetFileName(filePath), "[-$#/|&_()123456789 ]", ""));
                         
                         var response = httpClient.PostAsync(url, form).Result;
                         if (response.StatusCode == (HttpStatusCode)201)
                             return _returnMessage = "Comentário enviando com Sucesso";
                         else
                             return _returnMessage = "Foto de perfil não encontrada ou não há conexão com a Internet";
                     }
                     catch (Exception ex)
                     {
                         string errorType = ex.GetType().ToString();
                         string errorMessage = errorType + ": " + ex.Message;
                         return _returnMessage = "Foto de perfil não encontrada ou não há conexão com a Internet";
                     }
                 }
             });
            return _returnMessage;
        }
    }
}