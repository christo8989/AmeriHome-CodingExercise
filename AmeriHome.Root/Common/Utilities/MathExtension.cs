namespace AmeriHome.Root.Common.Utilities
{
	// Not object oriented but neither is the Math class.
	public static class MathExtension
	{
		// Should be in another class.
		public static double ToCeiling(double value, double interval)
		{
			//throw if value is negative.
			//throw if interval is 0 or less.
			var remainder = value % interval;
			var result = remainder > 0 ? value + (interval - remainder) : value;
			return result;
		}
	}
}
