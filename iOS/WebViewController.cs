using System;

using UIKit;
using Foundation;

namespace test1.iOS
{
	public partial class WebViewController : UIViewController
	{
		//public WebViewController() : base("WebViewController", null)		// using XIB
		public WebViewController(IntPtr handle) : base(handle)				// using Storyboard
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			webView.LoadRequest(new NSUrlRequest(new NSUrl(@"https://www.google.com.tw")));
			// Note : 
			webView.ScalesPageToFit = true;

			btnGo.TouchUpInside += (sender, e) =>
			{
				// first responder

				if (textField.IsFirstResponder)
				{
					textField.ResignFirstResponder();
				}

				_btnGoConstraint.Constant = 0;

				webView.LoadRequest(new NSUrlRequest(new NSUrl(textField.Text)));
			};
			//textField

			UIKeyboard.Notifications.ObserveWillChangeFrame((sender, args) =>
			{
				_btnGoConstraint.Constant = args.FrameEnd.Height;
			});
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}