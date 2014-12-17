using NUnit.Framework;
using System;

namespace Cint.Test.RobotCleaner.Tests
{
	[TestFixture]
	public class OfficeTest
	{
		private Office office;

		[SetUp]
		public void SetUp ()
		{
			office = new Office ();
		}

		[Test]
		public void CounterShouldBeOne()
		{
			office.RecordCleaning (new Position (1, 1));
			office.RecordCleaning (new Position (1, 1));

			Assert.That (office.TotalCleaned, Is.EqualTo (1));
		}

		[Test]
		public void CounterShouldBeFive()
		{
			office.RecordCleaning (new Position (1, 1));
			office.RecordCleaning (new Position (1, 2));
			office.RecordCleaning (new Position (1, 3));
			office.RecordCleaning (new Position (1, 4));
			office.RecordCleaning (new Position (1, 5));

			Assert.That (office.TotalCleaned, Is.EqualTo (5));
		}

	}
}

