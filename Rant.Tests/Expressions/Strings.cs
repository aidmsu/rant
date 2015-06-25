﻿using NUnit.Framework;

namespace Rant.Tests.Expressions
{
	[TestFixture]
	public class Strings
	{
		private readonly RantEngine rant = new RantEngine();

		[Test]
		[TestCase("test", Result = "test")]
		[TestCase("<noun>", Result = "<noun>")]
		public string RegularStrings(string value)
		{
			return rant.Do($"[@ \"{value}\" ]").Main;
        }

		[Test]
		[TestCase("<noun>")]
		public void PatternStrings(string value)
		{
			var result = rant.Do($"[@ $\"{value}\"() ]").Main;
			Assert.NotNull(result);
			Assert.GreaterOrEqual(result.Length, 2);
			Assert.AreNotEqual(value, result);
        }

		[Test]
		public void Concatenation()
		{
			Assert.AreEqual("test string", rant.Do("[@ \"test\" ~ \" string\" ]").Main);
		}

		[Test]
		public void PatternStringConcat()
		{
			var result = rant.Do("[@ ($\"[case:upper]test \" ~ \"string\")() ]").Main;
			Assert.AreEqual("TEST STRING", result);
		}
	}
}
