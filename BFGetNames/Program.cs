#nullable enable

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace BFGetNames
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			string? filter;
			while (true)
			{
				Console.WriteLine("Enter some text to search for:");
				filter = Console.ReadLine();
				if (!String.IsNullOrEmpty(filter))
				{
					break;
				}
			}

			string[] names = GetNames(filter);
			Console.WriteLine($"{names.Length} results were found for [ {filter} ]");

			if (names.Length > 0)
			{
				foreach (string name in names)
				{
					Console.WriteLine(name);
				}
			}

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();

		}


		public static string[] GetNames(string filter)
		{

			string json = JsonData.GetJsonData();
			List<string> names = new List<string>();
			JArray jArray = JArray.Parse(json);

			//todo: take this json data and return an array of names after filtering by whatever the user types in.
			//todo: if you have any questions please email me at jtackabury@binaryfortress.com
			try
			{
				foreach (JObject item in jArray)
				{
					string countryName = item.GetValue("name").ToString();
					string countryCode = item.GetValue("code").ToString();

					if (!String.IsNullOrEmpty(countryName) && !String.IsNullOrEmpty(countryCode))
					{
						if (countryName.Contains(filter, StringComparison.OrdinalIgnoreCase) || countryCode.Contains(filter, StringComparison.OrdinalIgnoreCase))
						{
							names.Add(countryName);
						}
					}
				}
			}
			catch
			{
				throw;
			}

			return names.ToArray();
		}
	}
}
