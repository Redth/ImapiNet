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

using System.Runtime.InteropServices;
using NUnit.Framework;

#endregion

namespace Imapi.Net.UnitTests
{
    /// <summary>
    ///This is a test class for Imapi.Net.JolietStorage and is intended
    ///to contain all Imapi.Net.JolietStorage Unit Tests
    ///</summary>
    [TestFixture]
    public class JolietStorageTest
    {
        /// <summary>
        ///A test for Commit (STGC)
        ///</summary>
        [ExpectedException( typeof (COMException) )]
        [Test]
        public void CommitTest()
        {
            //DiscMaster discMaster = new DiscMaster();
            //JolietDiscMaster jolietDiscMaster = discMaster.JolietDiscMaster;
            //JolietDiscMasterStorage owner = jolietDiscMaster.RootStorage;
            //string name = "Root";
            //object target = Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor.CreatePrivate(owner, name);
            //Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor(target);
            //Imapi_Net_Enumerations_STGCAccessor a = null;
            //accessor.Commit(a);
            //discMaster.Dispose();
        }

        /// <summary>
        ///A test for JolietStorage (JolietDiscMasterStorage, string)
        ///</summary>
        [Test]
        public void ConstructorTest()
        {
            //DiscMaster discMaster = new DiscMaster();
            //JolietDiscMaster jolietDiscMaster = discMaster.JolietDiscMaster;
            //JolietDiscMasterStorage owner = jolietDiscMaster.RootStorage;
            //string name = "Root";
            //object target = Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor.CreatePrivate(owner, name);
            //Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor(target);
            //discMaster.Dispose();
        }

        /// <summary>
        ///A test for CopyTo (uint, ref Guid, IntPtr, ref IStorage)
        ///</summary>
        [ExpectedException( typeof (COMException) )]
        [Test]
        public void CopyToTest()
        {
            //DiscMaster discMaster = new DiscMaster();
            //JolietDiscMaster jolietDiscMaster = discMaster.JolietDiscMaster;
            //JolietDiscMasterStorage owner = jolietDiscMaster.RootStorage;
            //string name = "Root";
            //object target = Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor.CreatePrivate(owner, name);
            //Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor(target);
            //Guid tempGuid = Guid.Empty;
            //Imapi_Net_Interfaces_IStorageAccessor a = null;
            //accessor.CopyTo(0, ref tempGuid, IntPtr.Zero, ref a);
            //discMaster.Dispose();
        }

        /// <summary>
        ///A test for CreateStorage (string, STGM, uint, uint, out IStorage)
        ///</summary>
        [ExpectedException( typeof (COMException) )]
        [Test]
        public void CreateStorageTest()
        {
            //DiscMaster discMaster = new DiscMaster();
            //JolietDiscMaster jolietDiscMaster = discMaster.JolietDiscMaster;
            //JolietDiscMasterStorage owner = jolietDiscMaster.RootStorage;
            //string name = "Root";
            //object target = Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor.CreatePrivate(owner, name);
            //Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor(target);
            //Imapi_Net_Interfaces_IStorageAccessor a = null;
            //accessor.CreateStorage("", null, 0, 0, out a);
            //discMaster.Dispose();
        }

        /// <summary>
        ///A test for CreateStream (string, STGM, uint, uint, out IStream)
        ///</summary>
        [ExpectedException( typeof (COMException) )]
        [Test]
        public void CreateStreamTest()
        {
            //DiscMaster discMaster = new DiscMaster();
            //JolietDiscMaster jolietDiscMaster = discMaster.JolietDiscMaster;
            //JolietDiscMasterStorage owner = jolietDiscMaster.RootStorage;
            //string name = "Root";
            //object target = Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor.CreatePrivate(owner, name);
            //Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor(target);
            //IStream istream = null;
            //accessor.CreateStream("", null, 0, 0, out istream);
            //discMaster.Dispose();
        }

        /// <summary>
        ///A test for DestroyElement (string)
        ///</summary>
        [Test]
        public void DestroyElementTest()
        {
            //DiscMaster discMaster = new DiscMaster();
            //JolietDiscMaster jolietDiscMaster = discMaster.JolietDiscMaster;
            //JolietDiscMasterStorage owner = jolietDiscMaster.RootStorage;
            //string name = "Root";
            //object target = Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor.CreatePrivate(owner, name);
            //Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor(target);
            //accessor.DestroyElement("");
            //discMaster.Dispose();
        }

        /// <summary>
        ///A test for EnumElements (uint, IntPtr, uint, out IEnumSTATSTG)
        ///</summary>
        [Test]
        public void EnumElementsTest()
        {
            //DiscMaster discMaster = new DiscMaster();
            //JolietDiscMaster jolietDiscMaster = discMaster.JolietDiscMaster;
            //JolietDiscMasterStorage owner = jolietDiscMaster.RootStorage;

            //string[] destinationFolders = new string[] { "I386", "ASMS", "COMPDATA", "DRW", "LANG", "SYSTEM32", "WIN9XMIG", "WIN9XUPG", "WINNTUPG" };
            //Dictionary<string, string> folders = new Dictionary<string, string>(destinationFolders.Length);
            //for (int i = 0; i < destinationFolders.Length; i++)
            //{
            //    owner.CreateSubfolder(destinationFolders[i]);
            //    folders.Add(destinationFolders[i], destinationFolders[i]);
            //}

            //string name = "";

            //object target = Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor.CreatePrivate(owner, name);

            //Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor(target);

            //uint reserved1 = 0; 

            //IntPtr reserved2 = IntPtr.Zero; 

            //uint reserved3 = 0; 

            //Imapi.Net.UnitTests.Imapi_Net_Interfaces_IEnumSTATSTGAccessor ppenum;

            //accessor.EnumElements(reserved1, reserved2, reserved3, out ppenum);

            //STATSTG statstg = new STATSTG();

            //uint received = 0;

            //ppenum.Next(1, ref statstg, out received);

            //Assert.IsTrue(received > 0);

            //while (received > 0)
            //{
            //    Assert.IsTrue(folders.ContainsKey(statstg.pwcsName), "ppenum_EnumElements_expected was not set correctly.");
            //    Assert.AreEqual(statstg.type, 1, "ppenum_EnumElements_expected was not set correctly.");
            //    ppenum.Next(1, ref statstg, out received);
            //}

            //owner.Dispose();
        }

        /// <summary>
        ///A test for MoveElementTo (string, ref IStorage, string, STGMove)
        ///</summary>
        [ExpectedException( typeof (COMException) )]
        [Test]
        public void MoveElementToTest()
        {
            //DiscMaster discMaster = new DiscMaster();
            //JolietDiscMaster jolietDiscMaster = discMaster.JolietDiscMaster;
            //JolietDiscMasterStorage owner = jolietDiscMaster.RootStorage;
            //string name = "Root";
            //object target = Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor.CreatePrivate(owner, name);
            //Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor(target);
            //Imapi_Net_Interfaces_IStorageAccessor a = null;
            //Imapi_Net_Enumerations_STGMoveAccessor b = null;
            //accessor.MoveElementTo("", ref a, "", b);
            //discMaster.Dispose();
        }

        /// <summary>
        ///A test for OpenStorage (string, IStorage, STGM, IntPtr, uint, out IStorage)
        ///</summary>
        [Test]
        public void OpenStorageTest1()
        {
            //DiscMaster discMaster = new DiscMaster();
            //JolietDiscMaster jolietDiscMaster = discMaster.JolietDiscMaster;
            //JolietDiscMasterStorage owner = jolietDiscMaster.RootStorage;

            //string[] destinationFolders = new string[] { "I386", "ASMS", "COMPDATA", "DRW", "LANG", "SYSTEM32", "WIN9XMIG", "WIN9XUPG", "WINNTUPG" };

            //for (int i = 0; i < destinationFolders.Length; i++)
            //{
            //    owner.CreateSubfolder(destinationFolders[i]);
            //}

            //string name = "Root";
            //object target = Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor.CreatePrivate(owner, name);

            //Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor(target);

            //string pwcsName = destinationFolders[0];

            //Imapi.Net.UnitTests.Imapi_Net_Interfaces_IStorageAccessor pstgPriority  = null;

            //Imapi.Net.UnitTests.Imapi_Net_Enumerations_STGMAccessor grfMode = Imapi_Net_Enumerations_STGMAccessor.STGM_SHARE_EXCLUSIVE;

            //IntPtr snbExclude = IntPtr.Zero;

            //uint reserved = 0; 

            //Imapi.Net.UnitTests.Imapi_Net_Interfaces_IStorageAccessor ppstg;

            //accessor.OpenStorage(pwcsName, pstgPriority, grfMode, snbExclude, reserved, out ppstg);

            //Assert.AreEqual(ppstg.ToString(), destinationFolders[0]);

            //discMaster.Dispose();
        }

        /// <summary>
        ///A test for OpenStream (string, IntPtr, STGM, uint, out IStream)
        ///</summary>
        [Test]
        public void OpenStreamTest()
        {
            //DiscMaster discMaster = new DiscMaster();
            //JolietDiscMaster jolietDiscMaster = discMaster.JolietDiscMaster;
            //JolietDiscMasterStorage owner = jolietDiscMaster.RootStorage;

            //string[] destinationFolders = new string[] { "I386", "ASMS", "COMPDATA", "DRW", "LANG", "SYSTEM32", "WIN9XMIG", "WIN9XUPG", "WINNTUPG" };

            //for (int i = 0; i < destinationFolders.Length; i++)
            //{
            //    owner.CreateSubfolder(destinationFolders[i]);
            //}

            //string[] sourceFiles = new string[] { @"C:\I386\_DEFAULT.PI_", @"C:\I386\12520437.CP_", @"C:\I386\12520850.CP_", @"C:\I386\1394.IN_", @"C:\I386\1394BUS.SY_", @"C:\I386\1394VDBG.IN_", @"C:\I386\1394VDBG.SY_", @"C:\I386\3DFXVS2K.IN_", @"C:\I386\3DGARRO.CU_", @"C:\I386\3DGMOVE.CU_", @"C:\I386\3DGNESW.CU_", @"C:\I386\3DGNO.CU_", @"C:\I386\3DGNS.CU_", @"C:\I386\3DGNWSE.CU_", @"C:\I386\3DGWE.CU_", @"C:\I386\3DSMOVE.CU_", @"C:\I386\3DSNS.CU_", @"C:\I386\3DSNWSE.CU_", @"C:\I386\3DWARRO.CU_", @"C:\I386\3DWMOVE.CU_", @"C:\I386\3DWNESW.CU_", @"C:\I386\3DWNO.CU_" };

            //string[] destinationFiles = new string[] { @"I386\_DEFAULT.PI_", @"I386\12520437.CP_", @"I386\12520850.CP_", @"I386\1394.IN_", @"I386\1394BUS.SY_", @"I386\1394VDBG.IN_", @"I386\1394VDBG.SY_", @"I386\3DFXVS2K.IN_", @"I386\3DGARRO.CU_", @"I386\3DGMOVE.CU_", @"I386\3DGNESW.CU_", @"I386\3DGNO.CU_", @"I386\3DGNS.CU_", @"I386\3DGNWSE.CU_", @"I386\3DGWE.CU_", @"I386\3DSMOVE.CU_", @"I386\3DSNS.CU_", @"I386\3DSNWSE.CU_", @"I386\3DWARRO.CU_", @"I386\3DWMOVE.CU_", @"I386\3DWNESW.CU_", @"I386\3DWNO.CU_" };

            //for (int i = 0; i < sourceFiles.Length; i++)
            //{
            //    owner.AddFile(sourceFiles[i], destinationFiles[i]);
            //}

            //string name = null; 

            //object target = Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor.CreatePrivate(owner, name);

            //Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor(target);

            //IntPtr reserved1 = IntPtr.Zero;

            //Imapi.Net.UnitTests.Imapi_Net_Enumerations_STGMAccessor grfMode = Imapi_Net_Enumerations_STGMAccessor.STGM_SHARE_EXCLUSIVE;

            //uint reserved2 = 0;

            //IStream ppstm = null;

            //string pwcsName = String.Empty;

            //for (int i = 0; i < destinationFiles.Length; i++)
            //{
            //    ppstm = null;
            //    pwcsName = destinationFiles[i];
            //    accessor.OpenStream(pwcsName, reserved1, grfMode, reserved2, out ppstm);

            //    Assert.AreEqual(ppstm.ToString(), destinationFiles[i], "ppstm_OpenStream_expected was not set correctly.");
            //}
            //discMaster.Dispose();
        }

        /// <summary>
        ///A test for RenameElement (string, string)
        ///</summary>
        [ExpectedException( typeof (COMException) )]
        [Test]
        public void RenameElementTest()
        {
            //DiscMaster discMaster = new DiscMaster();
            //JolietDiscMaster jolietDiscMaster = discMaster.JolietDiscMaster;
            //JolietDiscMasterStorage owner = jolietDiscMaster.RootStorage;
            //string name = "Root";
            //object target = Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor.CreatePrivate(owner, name);
            //Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor(target);
            //accessor.RenameElement("", "");
            //discMaster.Dispose();
        }

        /// <summary>
        ///A test for Revert ()
        ///</summary>
        [ExpectedException( typeof (COMException) )]
        [Test]
        public void RevertTest()
        {
            //DiscMaster discMaster = new DiscMaster();
            //JolietDiscMaster jolietDiscMaster = discMaster.JolietDiscMaster;
            //JolietDiscMasterStorage owner = jolietDiscMaster.RootStorage;
            //string name = "Root";
            //object target = Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor.CreatePrivate(owner, name);
            //Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor(target);
            //accessor.Revert();
            //discMaster.Dispose();
        }

        /// <summary>
        ///A test for SetClass (ref Guid)
        ///</summary>
        [ExpectedException( typeof (COMException) )]
        [Test]
        public void SetClassTest()
        {
            //DiscMaster discMaster = new DiscMaster();
            //JolietDiscMaster jolietDiscMaster = discMaster.JolietDiscMaster;
            //JolietDiscMasterStorage owner = jolietDiscMaster.RootStorage;
            //string name = "Root";
            //object target = Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor.CreatePrivate(owner, name);
            //Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor(target);
            //Guid temp = Guid.Empty;
            //accessor.SetClass(ref temp);
            //discMaster.Dispose();
        }

        /// <summary>
        ///A test for SetElementTimes (string, ref System.Runtime.InteropServices.ComTypes.FILETIME, ref System.Runtime.InteropServices.ComTypes.FILETIME, ref System.Runtime.InteropServices.ComTypes.FILETIME)
        ///</summary>
        [ExpectedException( typeof (COMException) )]
        [Test]
        public void SetElementTimesTest()
        {
            //DiscMaster discMaster = new DiscMaster();
            //JolietDiscMaster jolietDiscMaster = discMaster.JolietDiscMaster;
            //JolietDiscMasterStorage owner = jolietDiscMaster.RootStorage;
            //string name = "Root";
            //object target = Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor.CreatePrivate(owner, name);
            //Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor(target);
            //FILETIME a, b, c;
            //a = b = c = new FILETIME();
            //accessor.SetElementTimes("", ref a, ref b, ref c);
            //discMaster.Dispose();
        }

        /// <summary>
        ///A test for SetStateBits (uint, uint)
        ///</summary>
        [ExpectedException( typeof (COMException) )]
        [Test]
        public void SetStateBitsTest()
        {
            //DiscMaster discMaster = new DiscMaster();
            //JolietDiscMaster jolietDiscMaster = discMaster.JolietDiscMaster;
            //JolietDiscMasterStorage owner = jolietDiscMaster.RootStorage;
            //string name = "Root";
            //object target = Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor.CreatePrivate(owner, name);
            //Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor(target);
            //accessor.SetStateBits(0, 0);
            //discMaster.Dispose();
        }

        /// <summary>
        ///A test for Stat (out STATSTG, StatFlag)
        ///</summary>
        [Test]
        public void StatTest()
        {
            //DiscMaster discMaster = new DiscMaster();
            //JolietDiscMaster jolietDiscMaster = discMaster.JolietDiscMaster;
            //JolietDiscMasterStorage owner = jolietDiscMaster.RootStorage;

            //string[] destinationFolders = new string[] { "I386", "ASMS", "COMPDATA", "DRW", "LANG", "SYSTEM32", "WIN9XMIG", "WIN9XUPG", "WINNTUPG" };
            //Dictionary<string, string> folders = new Dictionary<string, string>(destinationFolders.Length);
            //for (int i = 0; i < destinationFolders.Length; i++)
            //{
            //    owner.CreateSubfolder(destinationFolders[i]);
            //    folders.Add(destinationFolders[i], destinationFolders[i]);
            //}
            //string name = ""; 

            //object target = Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor.CreatePrivate(owner, name);

            //Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor(target);

            //STATSTG pstatstg;

            //Imapi.Net.UnitTests.Imapi_Net_Enumerations_StatFlagAccessor grfStatFlag = Imapi_Net_Enumerations_StatFlagAccessor.Default;

            //accessor.Stat(out pstatstg, grfStatFlag);

            //Assert.AreEqual(pstatstg.type, 1, "pstatstg_Stat_expected was not set correctly.");
            //Assert.AreEqual(pstatstg.pwcsName, "", "pstatstg_Stat_expected was not set correctly.");

            //for (int i = 0; i < destinationFolders.Length; i++)
            //{
            //    target = Imapi_Net_JolietStorageAccessor.CreatePrivate(owner, destinationFolders[i]);

            //    accessor = new Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor(target);

            //    accessor.Stat(out pstatstg, grfStatFlag);
            //    Assert.AreEqual(pstatstg.type, 1, "pstatstg_Stat_expected was not set correctly.");
            //    Assert.AreEqual(pstatstg.pwcsName, destinationFolders[i], "pstatstg_Stat_expected was not set correctly.");
            //}

            //grfStatFlag = Imapi_Net_Enumerations_StatFlagAccessor.NoName;

            //for (int i = 0; i < destinationFolders.Length; i++)
            //{
            //    target = Imapi_Net_JolietStorageAccessor.CreatePrivate(owner, destinationFolders[i]);

            //    accessor = new Imapi.Net.UnitTests.Imapi_Net_JolietStorageAccessor(target);

            //    accessor.Stat(out pstatstg, grfStatFlag);
            //    Assert.AreEqual(pstatstg.type, 1, "pstatstg_Stat_expected was not set correctly.");
            //    Assert.AreEqual(pstatstg.pwcsName, null, "pstatstg_Stat_expected was not set correctly.");
            //}

            //owner.Dispose();
        }
    }
}