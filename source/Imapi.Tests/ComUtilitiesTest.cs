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

using NUnit.Framework;

#endregion

namespace Imapi.Net.UnitTests
{
    /// <summary>
    ///This is a test class for Imapi.Net.ComUtilities and is intended
    ///to contain all Imapi.Net.ComUtilities Unit Tests
    ///</summary>
    [TestFixture]
    public class ComUtilitiesTest
    {
        /// <summary>
        ///A test for DateTimeToFiletime (DateTime)
        ///</summary>
        [Test]
        public void DateTimeToFiletimeTest()
        {
            //DateTime dateTime = new DateTime(1912, 2, 23, 5, 34, 32, 23);
            //FILETIME fileTime;

            //fileTime = Imapi.Net.UnitTests.Imapi_Net_ComUtilitiesAccessor.DateTimeToFiletime(dateTime);

            //DateTime expected = Imapi.Net.UnitTests.Imapi_Net_ComUtilitiesAccessor.FiletimeToDateTime(fileTime);

            //Assert.AreEqual(expected, dateTime, "Imapi.Net.ComUtilities.DateTimeToFiletime did not return the expected value.");
        }

        /// <summary>
        ///A test for FiletimeToDateTime (FILETIME)
        ///</summary>
        [Test]
        public void FiletimeToDateTimeTest()
        {
            ////DateTime dateTime = DateTime.Now;
            //FILETIME fileTime = new FILETIME();
            //fileTime.dwHighDateTime = 0xABCD;
            //fileTime.dwLowDateTime = 0x1234;

            //DateTime dateTime = Imapi.Net.UnitTests.Imapi_Net_ComUtilitiesAccessor.FiletimeToDateTime(fileTime);

            //FILETIME expected = Imapi.Net.UnitTests.Imapi_Net_ComUtilitiesAccessor.DateTimeToFiletime(dateTime);

            //Assert.AreEqual(expected, fileTime, "Imapi.Net.ComUtilities.DateTimeToFiletime did not return the expected value.");
        }
    }
}