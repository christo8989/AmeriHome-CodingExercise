using System;
using AmeriHome.Root.Common.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Utilities
{
	[TestClass]
	public class MathExtensionTests
	{
		private double value;
		private double interval;

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void ToCeiling_ThrowsArgumentExceptionOnNegativeValue()
		{
			Action action = () => MathExtension.ToCeiling(-1, 1);
			action();
		}  

		[TestMethod]
		public void ToCeiling_WholeNumberValue()
		{
			this.value = 2;
			this.interval = 1;
			var expected = 2;
			var actual = MathExtension.ToCeiling(this.value, this.interval);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToCeiling_WholeNumberValueWithWholeNumberInterval()
		{
			this.value = 5;
			this.interval = 7;
			var expected = 7;
			var actual = MathExtension.ToCeiling(this.value, this.interval);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToCeiling_RealNumberValue()
		{
			this.value = 0.5;
			this.interval = 1;
			var expected = 1;
			var actual = MathExtension.ToCeiling(this.value, this.interval);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToCeiling_RealNumberValueWithRealNumberInterval()
		{
			this.value = 0.51;
			this.interval = 0.25;
			var expected = 0.75;
			var actual = MathExtension.ToCeiling(this.value, this.interval);
			Assert.AreEqual(expected, actual);
		}
	}
}
