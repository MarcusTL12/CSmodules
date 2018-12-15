using static Util.CU;
using System.Linq;


namespace Julekalender
{
	class Des6
	{
		private static bool ZeroHeavy(int n)
		{
			string s = n.ToString();
			return s.Aggregate(0, (tot, next) => tot + (next == '0' ? 1 : 0)) > (s.Length / 2);
		}
		
		public static void Run()
		{
			long sum = 0;
			for (int i = 1; i <= 18163106; i++) sum += (ZeroHeavy(i) ? i : 0);
			Log(sum);
		}
	}
}
