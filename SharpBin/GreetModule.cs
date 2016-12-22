using System;
using Nancy;

public class GreetModule : NancyModule
{
	class GreetModel
	{
		public string Name { get; set; }
		public int Year { get; set; }
	}
	
	public GreetModule ()
	{
		Get ["/greet/{name}"] = x => {
			return Response.AsJson (new GreetModel { Name = x.name, Year = DateTime.Now.Year }, HttpStatusCode.BadGateway);
		};
	}
}
