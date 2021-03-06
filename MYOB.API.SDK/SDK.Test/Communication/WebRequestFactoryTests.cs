﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK.Communication;
using NUnit.Framework;


namespace SDK.Test.Communication
{
    [TestFixture]
    public class WebRequestFactoryTests
    {
        [Test]
        public void WhenICreateAWebRequestObjectItIsPopulatedWithSuppliedUri()
        {
            const string uri = "http://localhost";

            var request1 = new WebRequestFactory().Create(new Uri(uri));

            Assert.AreEqual(new Uri(uri), request1.RequestUri);
        }

        [Test]
        public void WhenICreateSeveralWebRequestObjectTheyAreNotTheSameObject()
        {
            const string uri = "http://localhost";

            var request1 = new WebRequestFactory().Create(new Uri(uri));
            var request2 = new WebRequestFactory().Create(new Uri(uri));

            Assert.AreNotSame(request1, request2);
        }

        [Test]
        public void WhenISupplyAnAcceptHeader_ItIsAppliedTo_TheCreatedWebRequestObject()
        {
			// arrange
            const string uri = "http://localhost";
            const string mime = "application/pdf";

			// act
            var request = new WebRequestFactory().Create(new Uri(uri), mime);

			// assert
            Assert.IsInstanceOf<HttpWebRequest>(request);
            Assert.AreEqual(mime, (request as HttpWebRequest).Accept);  
        }
    }
}
