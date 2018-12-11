using static Util.CU;
using static Util.Timing;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Julekalender
{
	class Dec2
	{
		public static void Run()
		{
			using (StreamReader io = new StreamReader("input/input-rain.txt"))
			{
				Regex rx = new Regex(@"\((\d+)\,(\d+)\);\((\d+)\,(\d+)\)", RegexOptions.Compiled);
				Dictionary<float, int> nums = new Dictionary<float, int>();
				while (!io.EndOfStream)
				{
					float[] buff = (from i in rx.Match(io.ReadLine()).Groups.Skip(1) select float.Parse(i.Value)).ToArray();
					float s = (buff[3] - buff[1]) / (buff[2] - buff[0]);
					if (nums.ContainsKey(s))
						nums[s] += 1;
					else
						nums.Add(s, 1);
				}
				int curmax = 0;
				foreach (var i in nums)
					if (curmax < i.Value)
						curmax = i.Value;
				Log(curmax);
			}
		}
	}
}
