using System;

using UIKit;

namespace test1.iOS
{
	public partial class MapViewController : UIViewController
	{
		//public MapViewController() : base("MapViewController", null)		// using XIB
		public MapViewController(IntPtr handle) : base(handle)				// using Storyboard
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


