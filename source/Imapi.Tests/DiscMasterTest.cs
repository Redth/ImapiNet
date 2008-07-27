#region License

//
// Author: Ian Davis <ian.f.davis@gmail.com>
// Copyright (c) 2005-2008, Ian Davis.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

#endregion

#region Using Directives

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace Imapi.Net.UnitTests
{
    /// <summary>
    ///This is a test class for Imapi.Net.DiscMaster and is intended
    ///to contain all Imapi.Net.DiscMaster Unit Tests
    ///</summary>
    [TestFixture]
    public class DiscMasterTest
    {
        /// <summary>
        ///A test for CancelBurn ()
        ///</summary>
        [Test]
        public void CancelBurnTest()
        {
            var target = new DiscMaster();

            target.CancelBurn();

            Assert.Ignore( "A method that does not return a value cannot be verified." );
        }

        /// <summary>
        ///A test for ClearFormatContent ()
        ///</summary>
        [Test]
        public void ClearFormatContentTest()
        {
            var target = new DiscMaster();

            target.ClearFormatContent();

            Assert.Ignore( "A method that does not return a value cannot be verified." );
        }

        /// <summary>
        ///A test for DiscMaster ()
        ///</summary>
        [Test]
        public void ConstructorTest()
        {
            var target = new DiscMaster();

            // TODO: Implement code to verify target
            Assert.Ignore( "TODO: Implement code to verify target" );
        }

        /// <summary>
        ///A test for DiscMasterFormats
        ///</summary>
        [Test]
        public void DiscMasterFormatsTest()
        {
            var target = new DiscMaster();

            IEnumerator<Guid> val = null; // TODO: Assign to an appropriate value for the property

            Assert.AreEqual( val, target.DiscMasterFormats,
                             "Imapi.Net.DiscMaster.DiscMasterFormats was not set correctly." );
            Assert.Ignore( "Verify the correctness of this test method." );
        }

        /// <summary>
        ///A test for DiscRecorders
        ///</summary>
        [Test]
        public void DiscRecordersTest()
        {
            var target = new DiscMaster();

            DiscRecorderCollection val = null; // TODO: Assign to an appropriate value for the property

            Assert.AreEqual( val, target.DiscRecorders, "Imapi.Net.DiscMaster.DiscRecorders was not set correctly." );
            Assert.Ignore( "Verify the correctness of this test method." );
        }

        /// <summary>
        ///A test for Dispose ()
        ///</summary>
        [Test]
        public void DisposeTest()
        {
            var target = new DiscMaster();

            target.Dispose();

            Assert.Ignore( "A method that does not return a value cannot be verified." );
        }

        /// <summary>
        ///A test for IDiscMaster
        ///</summary>
        [Test]
        public void IDiscMasterTest()
        {
            //DiscMaster target = new DiscMaster();

            //Imapi.Net.UnitTests.Imapi_Net_Interfaces_IDiscMasterAccessor val = null; // TODO: Assign to an appropriate value for the property

            //Imapi.Net.UnitTests.Imapi_Net_DiscMasterAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_DiscMasterAccessor(target);

            //Assert.AreEqual(val, accessor.IDiscMaster, "Imapi.Net.DiscMaster.IDiscMaster was not set correctly.");
            //Assert.Ignore("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for JolietDiscMaster
        ///</summary>
        [Test]
        public void JolietDiscMasterTest()
        {
            var target = new DiscMaster();

            JolietDiscMaster val = null; // TODO: Assign to an appropriate value for the property

            Assert.AreEqual( val, target.JolietDiscMaster,
                             "Imapi.Net.DiscMaster.JolietDiscMaster was not set correctly." );
            Assert.Ignore( "Verify the correctness of this test method." );
        }

        /// <summary>
        ///A test for RedbookDiscMaster
        ///</summary>
        [Test]
        public void RedbookDiscMasterTest()
        {
            var target = new DiscMaster();

            RedbookDiscMaster val = null; // TODO: Assign to an appropriate value for the property

            Assert.AreEqual( val, target.RedbookDiscMaster,
                             "Imapi.Net.DiscMaster.RedbookDiscMaster was not set correctly." );
            Assert.Ignore( "Verify the correctness of this test method." );
        }
    }
}