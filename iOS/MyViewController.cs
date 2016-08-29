using System;
using System.Linq;
using System.Collections.Generic;

using UIKit;
using Security;
using Foundation;

using Debug = System.Diagnostics.Debug;


namespace test1.iOS
{
	public partial class MyViewController : UIViewController
	{
		//public MyViewController() : base("MyViewController", null)
		public MyViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			ShowTable();
		}

		private void ShowTable() 
		{
			var list = new List<test1.MyClass.Todo>();
			list.Add(new test1.MyClass.Todo { Name = "name1", Desc = "Desc1"});
			list.Add(new test1.MyClass.Todo { Name = "name2", Desc = "Desc2" });
			list.Add(new test1.MyClass.Todo { Name = "name3", Desc = "Desc3" });
			list.Add(new test1.MyClass.Todo { Name = "name4", Desc = "Desc4" });
			list.Add(new test1.MyClass.Todo { Name = "name5", Desc = "Desc5" });


			var todoSource = new TodoSource(list);
			myTable.Source = todoSource;

			todoSource.TodoSelected += (object sender, TodoSelectedEventArgs e) =>
			{ 
				Debug.WriteLine($"Name:{e.selectedTodo.Name}; Description:{e.selectedTodo.Desc}");
			};

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		class TodoSource : UITableViewSource
		{
			private List<test1.MyClass.Todo> Todos { get; set; }
			public event EventHandler<TodoSelectedEventArgs> TodoSelected;

			const string MyTableViewCellID = "MyTableViewCell";

			public TodoSource(IEnumerable<test1.MyClass.Todo> source)
			{
				Todos = new List<test1.MyClass.Todo>();
				Todos.AddRange(source);
			}

			public override nint RowsInSection(UITableView tableview, nint section)
			{
				//throw new NotImplementedException();
				return Todos.Count;
			}

			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				//throw new NotImplementedException();

				MyTableViewCell cell = tableView.DequeueReusableCell(MyTableViewCellID) as MyTableViewCell;

				var todo = Todos[indexPath.Row];
				cell.updateUI(todo);

				return cell;
			}

			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				//base.RowSelected(tableView, indexPath);

				tableView.DeselectRow(indexPath, true);

				var todo = Todos[indexPath.Row];

				EventHandler<TodoSelectedEventArgs> handler = TodoSelected;
				if (null != handler)
				{
					handler(this, new TodoSelectedEventArgs { selectedTodo = todo });
				}
			}
			
		}

		public class TodoSelectedEventArgs : EventArgs
		{
			public test1.MyClass.Todo selectedTodo { get; set; }


		}
	}
}


