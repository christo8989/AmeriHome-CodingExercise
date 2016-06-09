using System;
namespace AmeriHome.Root.Common.Utilities
{
	// Not object oriented but neither is the Math class.
	public static class MathExtension
	{
		public static double ToCeiling(double value, double interval)
		{
			if (value < 0)
				throw new ArgumentException("'value' cannot be negative.", "value"); //nameof(value)
			interval = Math.Abs(interval);
			var remainder = value % interval;
			var result = remainder > 0 ? value + (interval - remainder) : value;
			return result;
		}
	}
}
