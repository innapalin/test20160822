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
	[Register ("MyViewController")]
	partial class MyViewController
	{
		[Outlet]
		UIKit.UITableView myTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (myTable != null) {
				myTable.Dispose ();
				myTable = null;
			}
		}
	}
}
