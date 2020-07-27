using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace PrepAndroid.Activities
{
    [Activity(Label = "AddProspect")]
    public class AddProspect : Activity
    {
        private EditText edtFullName, edtPhone, edtEmail;
        private Button btnSend;
        protected void OnCreateAsync(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AddProspect);
            edtFullName = FindViewById<EditText>(Resource.Id.edtFullName);
            edtPhone = FindViewById<EditText>(Resource.Id.edtPhone);
            edtEmail = FindViewById<EditText>(Resource.Id.edtEmail);
            btnSend = FindViewById<Button>(Resource.Id.btnSend);
            btnSend.Click += async delegate 
            {

                Prospects prospects = new Prospects();
                prospects.Email = edtEmail.Text;
                prospects.Phone = edtPhone.Text;
                prospects.FullName = edtFullName.Text;
                prospects.ContactDate = Convert.ToDateTime(DateTime.Now.ToShortTimeString());

                HttpClient client = new HttpClient();
                string url = "";
                var uri = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response;
                var json = JsonConvert.SerializeObject(prospects);
                var content = new StringContent(json, Encoding.UTF8, "applcation/json");
                response = await client.PostAsync(uri, content);
                Clear();

                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    Toast.MakeText(this,"The prospect was added",ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "The prospect was not added", ToastLength.Long).Show();
                }
            };
        }

        void Clear()
        {
            edtEmail.Text = "";
            edtFullName.Text = "";
            edtPhone.Text = "";
        }
    }
}