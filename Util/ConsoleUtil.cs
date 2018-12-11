using System;


namespace Util
{
	class CU
	{
		public static void Log(string msg, params object[] arg)
		{
			Console.WriteLine(string.Format(msg, arg));
		}

		public static void Log(object msg)
		{
			Console.WriteLine(msg);
		}
	}
}

