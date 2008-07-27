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
    ///This is a test class for Imapi.Net.DiscRecorderCollection and is intended
    ///to contain all Imapi.Net.DiscRecorderCollection Unit Tests
    ///</summary>
    [TestFixture]
    public class DiscRecorderCollectionTest
    {
        private static DiscMaster _discMaster;
        private static DiscRecorderCollection _target;

        /// <summary>
        ///A test for ActiveDiscRecorder
        ///</summary>
        [Test]
        public void ActiveDiscRecorderTest()
        {
            DiscRecorder val = _target.ActiveDiscRecorder;

            _target.ActiveDiscRecorder = val;

            Assert.AreEqual( val, _target.ActiveDiscRecorder,
                             "Imapi.Net.DiscRecorderCollection.ActiveDiscRecorder was not set correctly." );
        }

        /// <summary>
        ///A test for Add (DiscRecorder)
        ///</summary>
        [Test]
        [ExpectedException( typeof (NotSupportedException) )]
        public void AddTest()
        {
            _target.Add( null );
        }

        /// <summary>
        ///A test for Clear ()
        ///</summary>
        [Test]
        [ExpectedException( typeof (NotSupportedException) )]
        public void ClearTest()
        {
            _target.Clear();
            Assert.AreEqual( _target.Count, 0 );
        }

        /// <summary>
        ///A test for DiscRecorderCollection (IDiscMaster)
        ///</summary>
        [Test]
        public void ConstructorTest()
        {
            var discMaster = new DiscMaster();
            Assert.IsNotNull( discMaster.DiscRecorders );
            Assert.IsNotNull( discMaster.DiscRecorders.ActiveDiscRecorder );
            discMaster.Dispose();
        }

        /// <summary>
        ///A test for Contains (DiscRecorder)
        ///</summary>
        [Test]
        public void ContainsTest()
        {
            var discMaster = new DiscMaster();
            bool expected = true;
            bool actual;

            actual = discMaster.DiscRecorders.Contains( discMaster.DiscRecorders.ActiveDiscRecorder );

            Assert.AreEqual( expected, actual,
                             "Imapi.Net.DiscRecorderCollection.Contains did not return the expected value." );
            discMaster.Dispose();
        }

        /// <summary>
        ///A test for CopyTo (DiscRecorder[], int)
        ///</summary>
        [Test]
        public void CopyToTest()
        {
            var array = new DiscRecorder[_target.Count];

            int arrayIndex = 0;

            _target.CopyTo( array, arrayIndex );

            for ( int i = 0; i < array.Length; i++ )
            {
                Assert.IsTrue( _target.Contains( array[i] ),
                               "Imapi.Net.DiscRecorderCollection.CopyTo did not return the expected value." );
            }
        }

        /// <summary>
        ///A test for GetEnumerator ()
        ///</summary>
        [Test]
        public void GetEnumeratorTest()
        {
            IEnumerator<DiscRecorder> actual;

            actual = _target.GetEnumerator();

            int count = 0;

            DiscRecorder discRecorder = null;
            for ( ; actual.MoveNext(); )
            {
                discRecorder = actual.Current;
                count++;
                Assert.IsTrue( _target.Contains( discRecorder ),
                               "Imapi.Net.DiscRecorderCollection.GetEnumerator did not return the expected value." );
            }
            Assert.AreEqual( count, _target.Count,
                             "Imapi.Net.DiscRecorderCollection.GetEnumerator did not return the expected value." );
        }

        /// <summary>
        ///A test for IsReadOnly
        ///</summary>
        [Test]
        public void IsReadOnlyTest()
        {
            bool val = true;
            Assert.AreEqual( val, _target.IsReadOnly,
                             "Imapi.Net.DiscRecorderCollection.IsReadOnly was not set correctly." );
        }

        /// <summary>
        ///A test for this[int index]
        ///</summary>
        [Test]
        public void ItemTest()
        {
            int index = _target.Count - 1;
            DiscRecorder val = _target[index];

            Assert.AreEqual( val, _target[index], "Imapi.Net.DiscRecorderCollection.this was not set correctly." );
        }

        /// <summary>
        ///A test for Remove (DiscRecorder)
        ///</summary>
        [Test]
        [ExpectedException( typeof (NotSupportedException) )]
        public void RemoveTest()
        {
            bool actual = _target.Remove( null );
        }
    }
}