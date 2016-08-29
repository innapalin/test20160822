
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Debug = System.Diagnostics.Debug;

namespace test1.Droid
{
	[Activity(Label = "MyListActivity")]
	public class MyListActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here

			SetContentView(Resource.Layout.tabel_mylistview_itemview);

			ShowTable();
		}

		private void ShowTable()
		{
			var list = new List<test1.MyClass.Todo>();
			list.Add(new test1.MyClass.Todo { Name = "name1", Desc = "Desc1" });
			list.Add(new test1.MyClass.Todo { Name = "name2", Desc = "Desc2" });
			list.Add(new test1.MyClass.Todo { Name = "name3", Desc = "Desc3" });
			list.Add(new test1.MyClass.Todo { Name = "name4", Desc = "Desc4" });
			list.Add(new test1.MyClass.Todo { Name = "name5", Desc = "Desc5" });


			var listView = FindViewById<ListView>(Resource.Id.table_mylistview_todolistview);
			//myTable.Source = todoSource;
			listView.Adapter = new TodoAdapter(list, this);

			//todoSource.TodoSelected += (object sender, TodoSelectedEventArgs e) =>
			listView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
			{

				var selectedTodo = list[e.Position];
				Debug.WriteLine($"Name:{selectedTodo.Name}; Description:{selectedTodo.Desc}");
			};
		}

		class TodoAdapter : BaseAdapter<test1.MyClass.Todo>
		{
			private List<test1.MyClass.Todo> Todos { get; set; }
			private Activity Context { get; set; }

			public TodoAdapter(IEnumerable<test1.MyClass.Todo> source, Activity context) 
			{
				Todos = new List<test1.MyClass.Todo>();
				Todos.AddRange(source);

				Context = context;
			}

			public override long GetItemId(int position)
			{
				//throw new NotImplementedException();
				return position;
			}

			//public override test1.MyClass.Todo this[int position]
			//{
			//	get
			//	{
			//		throw new NotImplementedException();
			//	}
			//}

			public override test1.MyClass.Todo this[int position] => Todos[position];

			public override int Count 
			{
				get
				{
					throw new NotImplementedException();
				}

				return Todos.Count;
			}

			//public override int Count => Todos.Count;

			public override View GetView(int position, View convertView, ViewGroup parent)
			{
				//throw new NotImplementedException();
				var view = convertView;
				if (null == view) {
					view = this.Context.LayoutInflater.Inflate(Resource.Layout.Table_MyListView_Layout, parent, false);
				}



				var todo = Todos[position];

				view.FindViewById<TextView>(Resource.Id.table_mylistview_itemview_lbname).Text = todo.Name;
				view.FindViewById<TextView>(Resource.Id.table_mylistview_itemview_lbdesc).Text = todo.Desc;
				return view;
			}
		}
	}
}

