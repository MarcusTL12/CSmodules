using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace Julekalender
{
	class Dec1
	{
		private static void Log(string msg, params object[] arg)
		{
			Console.WriteLine(string.Format(msg, arg));
		}

		private static void Log(object msg)
		{
			Console.WriteLine(msg);
		}
		
		public static void run()
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
