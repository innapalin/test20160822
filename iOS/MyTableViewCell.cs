using System;

using Foundation;
using UIKit;

namespace test1.iOS
{
	public partial class MyTableViewCell : UITableViewCell
	{
		protected MyTableViewCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public void updateUI(test1.MyClass.Todo todo)
		{
			m_lbName.Text = todo.Name;
			m_lbDesc.Text = todo.Desc;
		}
	}
}
