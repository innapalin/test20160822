﻿using System;


using System;

using UIKit;
using Security;
using Foundation;

using Debug = System.Diagnostics.Debug;


namespace test1.iOS
{
	public class DataClass
	{
		public DataClass()
		{
		}

		private void SaveRecord()
		{

			var record = new SecRecord(SecKind.GenericPassword)
			{
				Label = "交易密碼",
				Description = "用於xxx服務",
				Account = "liddle.fang@gmail.com",
				Service = "Transcation",
				Comment = "Demo",
				ValueData = NSData.FromString("P@ssw0rd"),
				Generic = NSData.FromString("SecurityChainDemo")
			};

			var status = SecKeyChain.Add(record);

			if (SecStatusCode.Success == status)
			{
				Debug.WriteLine("Keychain Saved!");
			}
			else if (SecStatusCode.DuplicateItem == status || SecStatusCode.DuplicateKeyChain == status)
			{
				Debug.WriteLine("Duplicate !");
				SecKeyChain.Remove(record);
			}
			else {
				Debug.WriteLine($"{ status }");
			}

		}

		private string QueryRecord()
		{

			SecStatusCode status;

			var rec = new SecRecord(SecKind.GenericPassword)
			{
				Generic = NSData.FromString("SecurityChainDemo")
			};

			var match = SecKeyChain.QueryAsRecord(rec, out status);

			if (SecStatusCode.Success == status && null != match)
			{

				Debug.WriteLine($"{match.Account};{match.ValueData.ToString()}");

				return match.Account;
			}

			Debug.WriteLine("Nothing found.");
			return string.Empty;

		}

		private void SaveNSDefaults()
		{

			var message = "Hello, Xamarin!";

			NSUserDefaults.StandardUserDefaults.SetString(message, "demokey");
			NSUserDefaults.StandardUserDefaults.Synchronize();

			Debug.WriteLine($"{ message } Saved!");
		}

		private string ReadNSDefaults()
		{
			var stored = NSUserDefaults.StandardUserDefaults.StringForKey("demokey");

			Debug.WriteLine($"stored:{stored}!");

			return stored;
		}
	}
}

