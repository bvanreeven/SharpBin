using System;
using System.Diagnostics;
using System.Threading;
using Nancy.Hosting.Self;

namespace SharpBin
{
	class MainClass
	{
		public static void Main (string [] args)
		{
			using (var nancyHost = new NancyHost (new Uri ("http://localhost:8888/"))) {
				nancyHost.Start ();

				Console.WriteLine ("NancyHost started");

				new ManualResetEvent (false).WaitOne ();
			}
		}
	}
}
