using ImageMagick;


namespace Util
{
	class SimpleImg
	{
		public readonly byte[] pixels;
		public readonly int w, h;
		public readonly bool alpha;

		public SimpleImg(string filePath)
		{
			using (var img = new MagickImage(filePath))
			{
				w = img.Width;
				h = img.Height;
				var pix = img.GetPixels();
				alpha = pix.Channels == 4;
				pixels = pix.GetValues();
			}
		}

		public SimpleImg(byte[] pixels, int w, int h)
		{
			this.pixels = pixels;
			this.w = w;
			this.h = h;
		}

		public void Write(string filePath)
		{
			var mr = new MagickReadSettings();
			mr.Format = alpha ? MagickFormat.Rgba : MagickFormat.Rgb;
			mr.Width = w;
			mr.Height = h;
			new MagickImage(pixels, mr).Write("input/test.png");
		}
		
		public bool IsAlpha(int index)
		{
			return alpha && (index % 4 == 3);
		}
	}
}

