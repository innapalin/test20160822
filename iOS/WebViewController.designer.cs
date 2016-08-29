// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace test1.iOS
{
	[Register ("WebViewController")]
	partial class WebViewController
	{
		[Outlet]
		UIKit.NSLayoutConstraint _btnGoConstraint { get; set; }

		[Outlet]
		UIKit.UIButton btnGo { get; set; }

		[Outlet]
		UIKit.UITextField textField { get; set; }

		[Outlet]
		UIKit.UIWebView webView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_btnGoConstraint != null) {
				_btnGoConstraint.Dispose ();
				_btnGoConstraint = null;
			}

			if (btnGo != null) {
				btnGo.Dispose ();
				btnGo = null;
			}

			if (textField != null) {
				textField.Dispose ();
				textField = null;
			}

			if (webView != null) {
				webView.Dispose ();
				webView = null;
			}
		}
	}
}
