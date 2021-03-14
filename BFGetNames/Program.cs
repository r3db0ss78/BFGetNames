#nullable enable

using System;

namespace BFGetNames
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Enter some text to search for:");
			string? filter = Console.ReadLine();
			if (filter == null)
				return;

			string[] names = GetNames(filter);
			foreach (string name in names)
				Console.WriteLine(name);

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}

		public static string[] GetNames(string filter)
		{
			string jsonData = JsonData.GetJsonData();

			//todo: take this json data and return an array of names after filtering by whatever the user types in.
			//todo: if you have any questions please email me at jtackabury@binaryfortress.com
		}
	}
}
