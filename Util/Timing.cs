

namespace Util
{
	public class Time
	{
		public static long Time()
		{
			return DateTimeOffset.Now.ToUnixTimeMilliseconds();
		}
	}
}
