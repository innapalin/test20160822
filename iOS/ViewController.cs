using System;

using UIKit;

namespace test1.iOS
{
	public partial class ViewController : UIViewController
	{
		int count = 1;

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Perform any additional setup after loading the view, typically from a nib.
			Button.AccessibilityIdentifier = "myButton";
			Button.TouchUpInside += delegate
			{
				var title = string.Format("{0} clicks!", count++);
				Button.SetTitle(title, UIControlState.Normal);
			};

			//btnConfirm.TouchUpInside += delegate
			btnConfirm.TouchUpInside += (sender, e) =>  
			{
				Button.SetTitle("Hi", UIControlState.Normal);
			};

			// set segue
			Button.TouchUpInside += (sender, e) =>
			{
				PerformSegue("moveToMap", this);
			};

			btnConfirm.TouchUpInside += (sender, e) =>
			{
				PerformSegue("moveToWeb", this);
			};

			btnTable.TouchUpInside += (sender, e) =>
			{
				PerformSegue("moveToTableView", this);
			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			if ("moveToMap" == segue.Identifier)
			{
				var dest = segue.DestinationViewController as MapViewController;
				dest.Title = "MAP";
			}
			else if ("moveToWeb" == segue.Identifier) 
			{
				var dest = segue.DestinationViewController as WebViewController;
				dest.Title = "WEB";
			}
			else if ("moveToTableView" == segue.Identifier)
			{
				var dest = segue.DestinationViewController as MyViewController;
				dest.Title = "TABLEVEIW";
			}
		}
	}
}
