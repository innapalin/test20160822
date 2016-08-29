using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace test1.Droid
{
	[Activity(Label = "test1", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			//Button button = FindViewById<Button>(Resource.Id.myButton);

			//button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

			var btnMap = FindViewById<Button>(Resource.Id.Main_btnMap);
			btnMap.Click += (sender, e) =>
			{
				StartActivity(typeof(MapActivity));
			};

			var btnWeb = FindViewById<Button>(Resource.Id.Main_btnWeb);
			btnWeb.Click += (sender, e) =>
			{
				//StartActivity(typeof(WebActivity));
				Intent webActivity = new Intent(this,typeof(WebActivity));

				webActivity.PutExtra("url", "https://www.google.com.tw");

				StartActivity(webActivity);
			};

			var btnTableView = FindViewById<Button>(Resource.Id.Main_btnTableView);
			btnTableView.Click += (sender, e) =>
			{
				StartActivity(typeof(MyListActivity));
			};
		}
	}
}


