using System;
using System.Linq;
using static Util.CU;

namespace Julekalender
{
	class Des3
	{

		private static readonly long[] primes = {
			2, 3, 5, 7, 11, 13, 17, 19, 23, 29,
			31, 37, 41, 43, 47, 53, 59, 61, 67, 71,
			73, 79, 83, 89, 97, 101, 103, 107, 109, 113,
			127, 131, 137, 139, 149, 151, 157, 163, 167, 173,
			179, 181, 191, 193, 197, 199, 211, 223, 227, 229,
			233, 239, 241, 251, 257, 263, 269, 271, 277, 281,
			283, 293, 307, 311, 313, 317, 331, 337, 347, 349,
			353, 359, 367, 373, 379, 383, 389, 397, 401, 409,
			419, 421, 431, 433, 439, 443, 449, 457, 461, 463,
			467, 479, 487, 491, 499, 503, 509, 521};

		private static long primprod(int[] a)
		{
			return a.Aggregate(1L, (tot, next) => (tot * primes[next]));
		}

		public static void Run()
		{
			int[] factors = (from i in Enumerable.Range(0, 24) select 0).ToArray();
			long thresh = 4294967296;
			int nFacs = 24;
			int top = 1;
			long amtNums = 0;

			while (top < nFacs)
			{
				top = 1;
				while (primprod(factors) < thresh)
				{
					amtNums++;
					factors[0]++;
				}
				while (top < nFacs && primprod(factors) > thresh)
				{
					factors[top]++;
					for (int i = 0; i < top; i++) factors[i] = factors[top];
					top++;
				}
				if (primprod(factors) < thresh) top--;
			}
			Log(amtNums);
		}
	}
}

