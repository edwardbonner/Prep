using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using PrepAndroid.Activities;

namespace PrepAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button btnAdd, btnUpdate, btnDelete;
        protected void OnCreateAsync(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            btnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);
            btnAdd.Click += delegate { StartActivity(typeof(AddProspect)); };
            btnUpdate.Click += delegate { StartActivity(typeof(UpdateProspect)); };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}