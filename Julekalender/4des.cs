using static Util.CU;
using Util;
using System;


namespace Julekalender
{
	class Des4
	{
		public static void Run()
		{
			SimpleImg img = new SimpleImg("input/pok.png");

			for (int i = 0; i < img.pixels.Length; i++)
			{
				if (!img.IsAlpha(i))
				{
					img.pixels[i] &= 0xF;
					img.pixels[i] *= 0x11;
				}
			}

			img.Write("input/test.png");
		}
	}
}
