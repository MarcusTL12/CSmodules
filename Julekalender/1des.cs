using System.IO;
using System.Collections.Generic;
using System.Linq;
using static Util.CU;


namespace Julekalender
{
	class Dec1
	{
		public static void Run()
		{
			int a;

			using (StreamReader io = new StreamReader("input/input-vekksort.txt"))
			{
				List<int> buffer = new List<int>();
				buffer.Add(int.Parse(io.ReadLine()));
				int i = buffer[0];
				while (!io.EndOfStream) {
					int l = int.Parse(io.ReadLine());
					if (l >= i)
					{
						i = l;
						buffer.Add(l);
					}
				}
				a = buffer.Sum();
			}
			Log(a);
		}
	}
}
