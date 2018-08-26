using System;
using System.Collections.Generic;
using FSharpLib;
using Microsoft.FSharp.Collections;

namespace LibTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

			List<int> array = new List<int>{ 1, 2, 3, 4, 5 };
			var fsArray = ListModule.OfSeq(array);

			var permuteArray = FMath.permutations(fsArray);
			foreach (var fsCaseArray in permuteArray)
			{
				var csCaseArray = ListModule.ToArray(fsCaseArray);
				Console.WriteLine(string.Join(",", csCaseArray));
			}

			Console.ReadKey();
        }
    }
}
