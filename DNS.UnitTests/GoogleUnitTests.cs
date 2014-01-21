/*
 * MS	14-01-21	initial version
 * 
 * 
 * 
 */
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MFToolkit.Net.Dns;

namespace DNS.UnitTests
{
	[TestClass]
	public class GoogleUnitTests
	{
		[TestMethod]
		public void TestRecordA()
		{
			try
			{
				DnsRequest r = new DnsRequest();
				Question q = new Question("google.com", DnsType.A, DnsClass.IN);
				r.Questions.Add(q);

				DnsResolver dns = new DnsResolver();
				dns.LoadNetworkConfiguration();			// using local IP configuration

				DnsResponse res = dns.Resolve(r);

				Assert.IsNotNull(res, "DnsResponse is null");

				var sb = new StringBuilder();

				foreach (Answer a in res.Answers)
					sb.AppendLine(a.ToString());
			}
			catch (Exception ex)
			{
				Assert.Fail("A record could not be read: " + ex.Message);
			}
		}

		[TestMethod]
		public void TestRecordMX()
		{
			try
			{
				DnsRequest r = new DnsRequest();
				Question q = new Question("google.com", DnsType.MX, DnsClass.IN);
				r.Questions.Add(q);

				DnsResolver dns = new DnsResolver();
				dns.LoadNetworkConfiguration();			// using local IP configuration

				DnsResponse res = dns.Resolve(r);

				Assert.IsNotNull(res, "DnsResponse is null");

				var sb = new StringBuilder();

				foreach (Answer a in res.Answers)
					sb.AppendLine(a.ToString());
			}
			catch (Exception ex)
			{
				Assert.Fail("MX record could not be read: " + ex.Message);
			}
		}
	}
}
