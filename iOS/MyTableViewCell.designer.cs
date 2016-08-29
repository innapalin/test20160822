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
	[Register ("MyTableViewCell")]
	partial class MyTableViewCell
	{
		[Outlet]
		UIKit.UILabel m_lbDesc { get; set; }

		[Outlet]
		UIKit.UILabel m_lbName { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (m_lbName != null) {
				m_lbName.Dispose ();
				m_lbName = null;
			}

			if (m_lbDesc != null) {
				m_lbDesc.Dispose ();
				m_lbDesc = null;
			}
		}
	}
}
