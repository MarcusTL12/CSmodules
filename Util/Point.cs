


namespace Util
{
	class Point<T>
	{
		private T x, y;

		public Point(T x, T y)
		{
			Set(x, y);
		}

		public T GetX()
		{
			return x;
		}

		public T GetY()
		{
			return y;
		}

		public void SetX(T x)
		{
			this.x = x;
		}

		public void SetY(T y)
		{
			this.y = y;
		}

		public void Set(T x, T y)
		{
			SetX(x);
			SetY(y);
		}

		public override string ToString()
		{
			return $"({x}, {y})";
		}
	}
}
