﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using XmlGuy;

namespace XmlGuyTests
{
	public class XmlTests
	{
		[Test]
		public void NullValuesAreHandled()
		{
			var doc = new XmlDocument();

			Assert.DoesNotThrow(() => doc.Begin("x").Add("guy", null));
		}

		[Test]
		public void ProducesValidXMLForValidInput()
		{

		}

        [Test]
        public void ValidationCheckIdentifiesErrors()
        {
            var doc = new XmlGuy.XmlDocument().Begin("root").Add("ns:ben");
            //Assert.IsFalse(doc.Up());
        }

		[Test]
		public void MyTest()
		{
			var doc = new XmlDocument();

			doc.Begin("organisation")
				.Add("staff")
					.Add("member", new { name = "Joe Smith", age = "45" }).Up()
					.Add("member", new { name = "Jane Smith", age = "48" }).Up()
					.Up()
				.Add("offices")
					.Add("office", new { name = "Head Office", location = "Balmain, Sydney" }).Up()
					.Up()
				.Add("revenue", "0").Up()
				.Add("description").CData("This organisation is a world class leader in excellence").Up()
				.Add("investors");

			Console.WriteLine(doc.ToString(true)); // enable pretty formatting
		}
	}
}
