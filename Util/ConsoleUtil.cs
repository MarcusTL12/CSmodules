using System;
using System.Numerics;

namespace Util
{
	class CU
	{
		public static void Log(string msg, params object[] arg)
		{
			Console.WriteLine(string.Format(msg, arg));
		}

		public static void Log<T>(T[] msg)
		{
			Console.Write("[");
			Console.Write(string.Join(", ", msg));
			Console.WriteLine("]");
		}

		public static void Log<T>(T msg)
		{
			Console.WriteLine(msg);
		}
		
		public static void Log(Complex msg)
		{
			Log("{0} + {1}i", msg.Real, msg.Imaginary);
		}
	}
}

