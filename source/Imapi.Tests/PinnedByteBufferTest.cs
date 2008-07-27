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
using NUnit.Framework;

#endregion

namespace Imapi.Net.UnitTests
{
    /// <summary>
    ///This is a test class for Imapi.Net.PinnedByteBuffer and is intended
    ///to contain all Imapi.Net.PinnedByteBuffer Unit Tests
    ///</summary>
    [TestFixture]
    public class PinnedByteBufferTest
    {
        /// <summary>
        ///A test for BufferAddress
        ///</summary>
        [Test]
        public void BufferAddressTest()
        {
            //int initialSize = 10;

            //object target = Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor.CreatePrivate(initialSize);

            //Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor(target);
            //IntPtr val = IntPtr.Zero;

            //Assert.AreNotEqual(val, accessor.BufferAddress, "Imapi.Net.PinnedByteBuffer.BufferAddress was not set correctly.");
        }

        /// <summary>
        ///A test for Bytes
        ///</summary>
        [Test]
        public void BytesTest()
        {
            //int initialSize = 10; 

            //object target = Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor.CreatePrivate(initialSize);

            //byte[] val = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor(target);

            //Array.Copy(val, accessor.Bytes, val.Length);

            //CollectionAssert.AreEqual(val, accessor.Bytes, "Imapi.Net.PinnedByteBuffer.Bytes was not set correctly.");
        }


        /// <summary>
        ///A test for PinnedByteBuffer (int)
        ///</summary>
        [Test]
        public void ConstructorTest()
        {
            //int initialSize = 10;

            //object target = Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor.CreatePrivate(initialSize);
            //Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor(target);
            //Assert.AreEqual(initialSize, accessor._currentSize);
            //Assert.AreNotEqual(IntPtr.Zero, accessor.BufferAddress);
        }

        /// <summary>
        ///A test for PinnedByteBuffer (int)
        ///</summary>
        [ExpectedException( typeof (ArgumentOutOfRangeException) )]
        [Test]
        public void ConstructorTest2()
        {
            //int initialSize = 0;

            //object target = Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor.CreatePrivate(initialSize);
            //Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor(target);
            //Assert.AreEqual(initialSize, accessor._currentSize);
            //Assert.AreNotEqual(IntPtr.Zero, accessor.BufferAddress);
        }

        /// <summary>
        ///A test for Dispose ()
        ///</summary>
        [Test]
        public void DisposeTest1()
        {
            //int initialSize = 100; 

            //object target = Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor.CreatePrivate(initialSize);

            //Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor(target);

            //accessor.Dispose();

            //Assert.AreEqual(accessor.Bytes, null);
            //Assert.AreEqual(accessor.Size, 0);
        }

        /// <summary>
        ///A test for Dispose ()
        ///</summary>
        [ExpectedException( typeof (InvalidOperationException) )]
        [Test]
        public void DisposeTest2()
        {
            //int initialSize = 100; 

            //object target = Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor.CreatePrivate(initialSize);

            //Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor(target);

            //accessor.Dispose();

            //Assert.AreEqual(accessor.Size, 0);
            //Assert.AreEqual(accessor.Bytes, null);
            //// This should throw an exception, the handle has been freed already.
            //Assert.AreEqual(accessor.BufferAddress, IntPtr.Zero);
        }

        /// <summary>
        ///A test for Size
        ///</summary>
        [Test]
        public void SizeTest()
        {
            //int initialSize = 10;

            //object target = Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor.CreatePrivate(initialSize);

            //int val = 10;

            //Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor(target);

            //accessor.Size = val;

            //Assert.AreEqual(val, accessor.Size, "Imapi.Net.PinnedByteBuffer.Size was not set correctly.");

            //accessor.Size = val = 15;

            //Assert.AreEqual(val, accessor.Size, "Imapi.Net.PinnedByteBuffer.Size was not set correctly.");
        }

        /// <summary>
        ///A test for Size
        ///</summary>
        [Test]
        public void SizeTest2()
        {
            //int initialSize = 10;

            //object target = Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor.CreatePrivate(initialSize);

            //int val = 0;

            //Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_PinnedByteBufferAccessor(target);

            //accessor.Size = val;

            //Assert.AreEqual(initialSize, accessor.Size, "Imapi.Net.PinnedByteBuffer.Size was not set correctly.");
        }
    }
}