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

using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace Imapi.Net.UnitTests
{
    /// <summary>
    ///This is a test class for Imapi.Net.JolietDiscMasterStorage and is intended
    ///to contain all Imapi.Net.JolietDiscMasterStorage Unit Tests
    ///</summary>
    [TestFixture]
    public class JolietDiscMasterStorageTest
    {
        /// <summary>
        ///A test for AddFile (string, string)
        ///</summary>
        [Test]
        public void AddFileTest()
        {
            var owner = new DiscMaster();
            JolietDiscMaster jolietDiscMaster = owner.JolietDiscMaster;
            JolietDiscMasterStorage target = jolietDiscMaster.RootStorage;

            string sourceFileName = @"C:\I386\EARL.AC_";

            string outputFileName = @"I386\EARL.AC_";

            target.AddFile( sourceFileName, outputFileName );

            IEnumerator<string> files = target.Files;
            files.MoveNext();
            Assert.AreEqual( files.Current, outputFileName );
            files.Dispose();
        }

        /// <summary>
        ///A test for Clear ()
        ///</summary>
        [Test]
        public void ClearTest()
        {
            var owner = new DiscMaster();
            JolietDiscMaster jolietDiscMaster = owner.JolietDiscMaster;
            JolietDiscMasterStorage target = jolietDiscMaster.RootStorage;

            string sourceFileName = @"C:\I386\EARL.AC_";

            string outputFileName = @"I386\EARL.AC_";

            target.AddFile( sourceFileName, outputFileName );

            IEnumerator<string> files = target.Files;
            files.MoveNext();
            Assert.AreEqual( files.Current, outputFileName );
            files.Dispose();
            target.Clear();
            files = target.Files;
            Assert.AreEqual( files.MoveNext(), false );
            owner.Dispose();
        }

        /// <summary>
        ///A test for CreateSubfolder (string)
        ///</summary>
        [Test]
        public void CreateSubfolderTest()
        {
            var owner = new DiscMaster();
            JolietDiscMaster jolietDiscMaster = owner.JolietDiscMaster;
            JolietDiscMasterStorage target = jolietDiscMaster.RootStorage;

            string folderName = "I386";

            JolietDiscMasterStorage actual = target.CreateSubfolder( folderName );

            Assert.AreEqual( folderName, actual.FolderName,
                             "Imapi.Net.JolietDiscMasterStorage.CreateSubfolder did not return the expected value." );
            IEnumerator<string> folders = target.Folders;
            folders.MoveNext();
            Assert.AreEqual( folderName, folders.Current,
                             "Imapi.Net.JolietDiscMasterStorage.CreateSubfolder did not return the expected value." );
            folders.Dispose();
            owner.Dispose();
        }


        /// <summary>
        ///A test for FetchSubfolder (string)
        ///</summary>
        [Test]
        public void FetchSubfolderTest()
        {
            var owner = new DiscMaster();
            JolietDiscMaster jolietDiscMaster = owner.JolietDiscMaster;
            JolietDiscMasterStorage storage = jolietDiscMaster.RootStorage;

            var destinationFolders = new[]
                                     {
                                         "I386", "ASMS", "COMPDATA", "DRW", "LANG", "SYSTEM32", "WIN9XMIG", "WIN9XUPG",
                                         "WINNTUPG", "_DEFAULT.PI_", "12520437.CP_", "12520850.CP_", "1394.IN_",
                                         "1394BUS.SY_", "1394VDBG.IN_", "1394VDBG.SY_", "3DFXVS2K.IN_", "3DGARRO.CU_",
                                         "3DGMOVE.CU_", "3DGNESW.CU_", "3DGNO.CU_", "3DGNS.CU_", "3DGNWSE.CU_", "3DGWE.CU_"
                                         , "3DSMOVE.CU_", "3DSNS.CU_", "3DSNWSE.CU_", "3DWARRO.CU_", "3DWMOVE.CU_",
                                         "3DWNESW.CU_", "3DWNO.CU_"
                                     };

            for ( int i = 0; i < destinationFolders.Length; i++ )
            {
                JolietDiscMasterStorage target = storage.CreateSubfolder( destinationFolders[i] );
                JolietDiscMasterStorage actual = storage.FetchSubfolder( destinationFolders[i] );
                Assert.AreEqual( destinationFolders[i], actual.FolderName,
                                 "Imapi.Net.JolietDiscMasterStorage.FetchSubfolder did not return the expected value." );
                Assert.AreEqual( target, actual,
                                 "Imapi.Net.JolietDiscMasterStorage.FetchSubfolder  did not return the expected value." );
                target.Dispose();
                actual.Dispose();
            }

            JolietDiscMasterStorage nullStorage = storage.FetchSubfolder( "None" );
            Assert.AreEqual( null, nullStorage,
                             "Imapi.Net.JolietDiscMasterStorage.FetchSubfolder did not return the expected value." );

            owner.Dispose();
        }

        /// <summary>
        ///A test for Files
        ///</summary>
        [Test]
        public void FilesTest()
        {
            var owner = new DiscMaster();
            JolietDiscMaster jolietDiscMaster = owner.JolietDiscMaster;
            JolietDiscMasterStorage storage = jolietDiscMaster.RootStorage;

            var sourceFiles = new[]
                              {
                                  @"C:\I386\ASMS", @"C:\I386\COMPDATA", @"C:\I386\DRW", @"C:\I386\LANG",
                                  @"C:\I386\SYSTEM32", @"C:\I386\WIN9XMIG", @"C:\I386\WIN9XUPG", @"C:\I386\WINNTUPG",
                                  @"C:\I386\_DEFAULT.PI_", @"C:\I386\12520437.CP_", @"C:\I386\12520850.CP_",
                                  @"C:\I386\1394.IN_", @"C:\I386\1394BUS.SY_", @"C:\I386\1394VDBG.IN_",
                                  @"C:\I386\1394VDBG.SY_", @"C:\I386\3DFXVS2K.IN_", @"C:\I386\3DGARRO.CU_",
                                  @"C:\I386\3DGMOVE.CU_", @"C:\I386\3DGNESW.CU_", @"C:\I386\3DGNO.CU_",
                                  @"C:\I386\3DGNS.CU_", @"C:\I386\3DGNWSE.CU_", @"C:\I386\3DGWE.CU_",
                                  @"C:\I386\3DSMOVE.CU_", @"C:\I386\3DSNS.CU_", @"C:\I386\3DSNWSE.CU_",
                                  @"C:\I386\3DWARRO.CU_", @"C:\I386\3DWMOVE.CU_", @"C:\I386\3DWNESW.CU_",
                                  @"C:\I386\3DWNO.CU_"
                              };

            var destinationFiles = new[]
                                   {
                                       @"I386\ASMS", @"I386\COMPDATA", @"I386\DRW", @"I386\LANG", @"I386\SYSTEM32",
                                       @"I386\WIN9XMIG", @"I386\WIN9XUPG", @"I386\WINNTUPG", @"I386\_DEFAULT.PI_",
                                       @"I386\12520437.CP_", @"I386\12520850.CP_", @"I386\1394.IN_", @"I386\1394BUS.SY_",
                                       @"I386\1394VDBG.IN_", @"I386\1394VDBG.SY_", @"I386\3DFXVS2K.IN_",
                                       @"I386\3DGARRO.CU_", @"I386\3DGMOVE.CU_", @"I386\3DGNESW.CU_", @"I386\3DGNO.CU_",
                                       @"I386\3DGNS.CU_", @"I386\3DGNWSE.CU_", @"I386\3DGWE.CU_", @"I386\3DSMOVE.CU_",
                                       @"I386\3DSNS.CU_", @"I386\3DSNWSE.CU_", @"I386\3DWARRO.CU_", @"I386\3DWMOVE.CU_",
                                       @"I386\3DWNESW.CU_", @"I386\3DWNO.CU_"
                                   };

            for ( int i = 0; i < sourceFiles.Length; i++ )
            {
                storage.AddFile( sourceFiles[i], destinationFiles[i] );
            }

            IEnumerator<string> files = storage.Files;
            int count = 0, j;
            while ( files.MoveNext() )
            {
                count++;
                for ( j = 0; j < destinationFiles.Length; j++ )
                {
                    if ( destinationFiles[j] == files.Current )
                    {
                        break;
                    }
                }

                if ( j == destinationFiles.Length )
                {
                    Assert.Fail();
                }
            }
            Assert.AreEqual( count, destinationFiles.Length );
            owner.Dispose();
        }

        /// <summary>
        ///A test for FolderName
        ///</summary>
        [Test]
        public void FolderNameTest()
        {
            var owner = new DiscMaster();
            JolietDiscMaster jolietDiscMaster = owner.JolietDiscMaster;
            JolietDiscMasterStorage storage = jolietDiscMaster.RootStorage;

            var destinationFolders = new[]
                                     {
                                         "I386", "ASMS", "COMPDATA", "DRW", "LANG", "SYSTEM32", "WIN9XMIG", "WIN9XUPG",
                                         "WINNTUPG", "_DEFAULT.PI_", "12520437.CP_", "12520850.CP_", "1394.IN_",
                                         "1394BUS.SY_", "1394VDBG.IN_", "1394VDBG.SY_", "3DFXVS2K.IN_", "3DGARRO.CU_",
                                         "3DGMOVE.CU_", "3DGNESW.CU_", "3DGNO.CU_", "3DGNS.CU_", "3DGNWSE.CU_", "3DGWE.CU_"
                                         , "3DSMOVE.CU_", "3DSNS.CU_", "3DSNWSE.CU_", "3DWARRO.CU_", "3DWMOVE.CU_",
                                         "3DWNESW.CU_", "3DWNO.CU_"
                                     };

            for ( int i = 0; i < destinationFolders.Length; i++ )
            {
                storage.CreateSubfolder( destinationFolders[i] );
            }

            IEnumerator<string> folders = storage.Folders;
            int count = 0, j;
            while ( folders.MoveNext() )
            {
                count++;
                for ( j = 0; j < destinationFolders.Length; j++ )
                {
                    if ( destinationFolders[j] == folders.Current )
                    {
                        break;
                    }
                }

                if ( j == destinationFolders.Length )
                {
                    Assert.Fail();
                }
            }
            Assert.AreEqual( count, destinationFolders.Length );
            owner.Dispose();
        }

        /// <summary>
        ///A test for Folders
        ///</summary>
        [Test]
        public void FoldersTest()
        {
            var owner = new DiscMaster();
            JolietDiscMaster jolietDiscMaster = owner.JolietDiscMaster;
            JolietDiscMasterStorage storage = jolietDiscMaster.RootStorage;

            var destinationFolders = new[]
                                     {
                                         "I386", "ASMS", "COMPDATA", "DRW", "LANG", "SYSTEM32", "WIN9XMIG", "WIN9XUPG",
                                         "WINNTUPG", "_DEFAULT.PI_", "12520437.CP_", "12520850.CP_", "1394.IN_",
                                         "1394BUS.SY_", "1394VDBG.IN_", "1394VDBG.SY_", "3DFXVS2K.IN_", "3DGARRO.CU_",
                                         "3DGMOVE.CU_", "3DGNESW.CU_", "3DGNO.CU_", "3DGNS.CU_", "3DGNWSE.CU_", "3DGWE.CU_"
                                         , "3DSMOVE.CU_", "3DSNS.CU_", "3DSNWSE.CU_", "3DWARRO.CU_", "3DWMOVE.CU_",
                                         "3DWNESW.CU_", "3DWNO.CU_"
                                     };

            for ( int i = 0; i < destinationFolders.Length; i++ )
            {
                storage.CreateSubfolder( destinationFolders[i] );
            }

            IEnumerator<string> folders = storage.Folders;
            int count = 0, j;
            while ( folders.MoveNext() )
            {
                count++;
                for ( j = 0; j < destinationFolders.Length; j++ )
                {
                    if ( destinationFolders[j] == folders.Current )
                    {
                        break;
                    }
                }

                if ( j == destinationFolders.Length )
                {
                    Assert.Fail();
                }
            }
            Assert.AreEqual( count, destinationFolders.Length );
            Assert.AreEqual( "", storage.FolderName );
            owner.Dispose();
        }

        /// <summary>
        ///A test for RequestIStream (string)
        ///</summary>
        [Test]
        public void RequestIStreamTest()
        {
            //DiscMaster owner = new DiscMaster();
            //JolietDiscMaster jolietDiscMaster = owner.JolietDiscMaster;
            //JolietDiscMasterStorage storage = jolietDiscMaster.RootStorage;

            //string[] sourceFiles = new string[] { @"C:\I386\_DEFAULT.PI_", @"C:\I386\12520437.CP_", @"C:\I386\12520850.CP_", @"C:\I386\1394.IN_", @"C:\I386\1394BUS.SY_", @"C:\I386\1394VDBG.IN_", @"C:\I386\1394VDBG.SY_", @"C:\I386\3DFXVS2K.IN_", @"C:\I386\3DGARRO.CU_", @"C:\I386\3DGMOVE.CU_", @"C:\I386\3DGNESW.CU_", @"C:\I386\3DGNO.CU_", @"C:\I386\3DGNS.CU_", @"C:\I386\3DGNWSE.CU_", @"C:\I386\3DGWE.CU_", @"C:\I386\3DSMOVE.CU_", @"C:\I386\3DSNS.CU_", @"C:\I386\3DSNWSE.CU_", @"C:\I386\3DWARRO.CU_", @"C:\I386\3DWMOVE.CU_", @"C:\I386\3DWNESW.CU_", @"C:\I386\3DWNO.CU_" };

            //string[] destinationFiles = new string[] { @"I386\_DEFAULT.PI_", @"I386\12520437.CP_", @"I386\12520850.CP_", @"I386\1394.IN_", @"I386\1394BUS.SY_", @"I386\1394VDBG.IN_", @"I386\1394VDBG.SY_", @"I386\3DFXVS2K.IN_", @"I386\3DGARRO.CU_", @"I386\3DGMOVE.CU_", @"I386\3DGNESW.CU_", @"I386\3DGNO.CU_", @"I386\3DGNS.CU_", @"I386\3DGNWSE.CU_", @"I386\3DGWE.CU_", @"I386\3DSMOVE.CU_", @"I386\3DSNS.CU_", @"I386\3DSNWSE.CU_", @"I386\3DWARRO.CU_", @"I386\3DWMOVE.CU_", @"I386\3DWNESW.CU_", @"I386\3DWNO.CU_" };

            //for (int i = 0; i < sourceFiles.Length; i++)
            //{
            //    storage.AddFile(sourceFiles[i], destinationFiles[i]);
            //}

            //Imapi.Net.UnitTests.Imapi_Net_JolietDiscMasterStorageAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_JolietDiscMasterStorageAccessor(storage);

            //IStream actual;

            //actual = accessor.RequestIStream(destinationFiles[destinationFiles.Length - 1]);
            //int cb = 312;
            //byte[] pv = new byte[cb];
            //IntPtr pcbRead = IntPtr.Zero;
            //actual.Read(pv, cb, pcbRead);
            //System.IO.FileStream fs = new System.IO.FileStream(sourceFiles[sourceFiles.Length -1], System.IO.FileMode.Open);
            //byte[] data = new byte[cb];
            //fs.Read(data, 0, cb);

            //for (int i = 0; i < 312; i++)
            //{
            //    Assert.AreEqual(pv[i], data[i]);
            //}

            //fs.Dispose();
            //owner.Dispose();
        }

        /// <summary>
        ///A test for RequestStorage (string)
        ///</summary>
        [Test]
        public void RequestStorageTest()
        {
            //DiscMaster owner = new DiscMaster();
            //JolietDiscMaster jolietDiscMaster = owner.JolietDiscMaster;
            //JolietDiscMasterStorage storage = jolietDiscMaster.RootStorage;

            //string[] destinationFolders = new string[] { "I386", "ASMS", "COMPDATA", "DRW", "LANG", "SYSTEM32", "WIN9XMIG", "WIN9XUPG", "WINNTUPG"};

            //for (int i = 0; i < destinationFolders.Length; i++)
            //{
            //    storage.CreateSubfolder(destinationFolders[i]);
            //}

            //Imapi.Net.UnitTests.Imapi_Net_JolietDiscMasterStorageAccessor accessor = new Imapi.Net.UnitTests.Imapi_Net_JolietDiscMasterStorageAccessor(storage);

            //string name = destinationFolders[0];

            //Imapi.Net.UnitTests.Imapi_Net_Interfaces_IStorageAccessor actual;

            //actual = accessor.RequestStorage(name);

            //Assert.AreEqual(actual.ToString(), name, "Imapi.Net.JolietDiscMasterStorage.RequestStorage did not return the expected value.");

            //owner.Dispose();
        }
    }
}