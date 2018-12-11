using System;

namespace Util
{
	public class Timing
	{
		public static long Time()
		{
			return DateTimeOffset.Now.ToUnixTimeMilliseconds();
		}
	}
}
