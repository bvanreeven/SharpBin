using System;
using System.Text;
using System.IO;
using Nancy;

namespace SharpBin
{
	public class EchoModule : NancyModule
	{
		public EchoModule ()
		{
			Get ["/echo"] = _ => {
				var result = new StringBuilder ();
				AddHeaders (result);
				return result.ToString ();
			};

			Post ["/echo"] = _ => {
				var result = new StringBuilder ();
				AddHeaders (result);

				var body = new StreamReader (Request.Body, Encoding.UTF8).ReadToEnd ();
				result.AppendLine ("<h2>Request body</h2>");
				result.AppendLine ($"<p>{body}</p>");

				return result.ToString ();
			};
		}

		void AddHeaders (StringBuilder result)
		{
			result.AppendLine ("<h2>Request headers</h2>");
			result.AppendLine ("<table>");
			result.AppendLine ("<tr><th>Header</th><th>Value</th></tr>");
			foreach (var header in this.Request.Headers) {
				result.AppendLine ($"<tr><td>{header.Key}</td><td>{string.Join (", ", header.Value)}</td></tr>");
			}
			result.AppendLine ("</table>");
		}
	}
}
