using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


public class Program
{
	private static Stopwatch watch = new Stopwatch();

	private static Random random = new Random();
	private static string[] chars
	{ get; } = Enumerable
		.Range(65, 26)                                                       //A~Z
		.Select(e => ((char)e).ToString())
		.Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))  //a~z
		.Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))           //0~9
		.ToArray();

	public static void Main()
	{

		watch.Restart();

		for (int i = 0; i < 10000; i++)
		{
			RandomString(25);
		}
		//Console.WriteLine(RandomString(25));
		//Console.WriteLine(RandomString(25));

		watch.Stop();

		Console.WriteLine("New alg: " + watch.ElapsedTicks);



		watch.Restart();

		for (int i = 0; i < 10000; i++)
		{
			RandomStringOld(25);
		}
		//		Console.WriteLine(RandomStringOld(25));

		//Console.WriteLine(RandomStringOld(25));
		watch.Stop();

		Console.WriteLine("Old alg: " + watch.ElapsedTicks);

		Console.ReadLine();
	}

	internal static string RandomString(int length)
	{
		StringBuilder builder = new StringBuilder();
		var charsList = new List<string>(chars);

		int z = Math.Min(length, charsList.Count);

		for (int i = 0; i < z; i++)
		{
			int j = random.Next(charsList.Count);
			builder.Append(charsList[j]);
			charsList.RemoveAt(j);
		}

		return builder.ToString();
	}

	internal static string RandomStringOld(int length)
	{
		StringBuilder builder = new StringBuilder();
		Enumerable
			.Range(65, 26)
			.Select(e => ((char)e).ToString())
			.Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
			.Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
			.OrderBy(e => Guid.NewGuid())
			.Take(length)
			.ToList().ForEach(e => builder.Append(e));
		return builder.ToString();
	}
}