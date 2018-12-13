using static Util.CU;
using System;
using System.Linq;

namespace Julekalender
{
	class Des5
	{
		private static int Digits(long n)
		{
			return (int)Math.Ceiling(Math.Log10(n));
		}

		private static void Fill<T>(T[] a, T v)
		{
			for (int i = 0; i < a.Length; i++)
			{
				a[i] = v;
			}
		}

		private static int DoConc(long[] nums, long[] concnum, bool[] conc)
		{
			concnum[0] = nums[0];
			int top = 0;
			for (int i = 0, curnum = 1; i < conc.Length; i++, curnum++)
			{
				if (conc[i])
				{
					concnum[top] *= 10;
					concnum[top] += nums[curnum];
				}
				else
				{
					concnum[++top] = nums[curnum];
				}
			}
			return top;
		}

		private static int Count(bool[] a)
		{
			int max = 0;
			int cur = 0;
			for (int i = 0; i < a.Length; i++)
			{
				if (a[i]) cur++;
				else cur = 0;

				if (max < cur) max = cur;
			}
			return max;
		}

		private static void NextConc(bool[] conc)
		{
			for (int i = 0; i < conc.Length; i++)
			{
				conc[i] ^= true;
				if (conc[i]) break;
			}
		}

		private static bool HasConc(bool[] conc)
		{
			return conc.Aggregate(false, (tot, next) => tot | next);
		}

		private static long Rec(long[] concnum, int top, long target, long maxsum, int i, long partsum, long skipsum)
		{
			if (i > top) return partsum == target ? 1 : 0;
			long a = partsum + concnum[i];
			long b = maxsum - skipsum - concnum[i];
			long ret = 0;
			if (a <= target) ret += Rec(concnum, top, target, maxsum, i + 1, a, skipsum);
			if (b >= target) ret += Rec(concnum, top, target, maxsum, i + 1, partsum, skipsum - concnum[i]);
			return ret;
		}

		public static void Run()
		{
			long[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 7, 6, 5, 4, 3, 2, 1 };
			long[] concnum = new long[nums.Length];
			bool[] conc = new bool[nums.Length - 1];
			bool[] incsum = new bool[nums.Length];
			Fill(concnum, 0);
			Fill(conc, false);
			Fill(incsum, false);
			int top = 0;
			long target = 42;
			long totcomb = 0;
			NextConc(conc);
			while (HasConc(conc))
			{
				top = DoConc(nums, concnum, conc);
				long maxsum = 0;
				for (int i = 0; i <= top; i++) maxsum += concnum[i];
				if ((maxsum + target) % 2 == 0)
				{
					long sumtar = (target + maxsum) / 2;
					totcomb += Rec(concnum, top, sumtar, maxsum, 1, concnum[0], 0);
				}
				NextConc(conc);
			}
			Log(totcomb);
		}
	}
}

