#region License

//
// Author: Ian Davis <ian.f.davis@gmail.com>
// Copyright (c) 2007-2008, Ian Davis.
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
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using Imapi.Net.Interop;
using Imapi.Net.Interop.Interfaces;
using Imapi.Net;
using Imapi.Net.ObjectModel;

#endregion Using Directives

//////////////////////////////////////////////////////////////////////////////// 
//   TODO:          Currently all folder/file creation is based on the local
//                  storage. When a file is added it is stored on this storage
//                  even if it has a dest path which says it should reside in a
//                  subdir. Ex - Current folder is "" - root. Call is made:
//                  RootStorage.AddFile("C:\I386\_DEFAULT.PI_", "I386\_DEFAULT.PI_");
//                  This file will be stored on the root storage rather than
//                  creating a substorage I386 and then adding _DEFAULT.PI_ to that
//                  storage. This is a next goal to implement. All unit tests are
//                  currently run for the current scheme and will have to be
//                  rewritten.
//                  I also want AddFile and CreateSubfolder to take nested paths
//                  to create multiple substorages. Ex 
//                  CreateSubfolder("I386\ASMS\5100\MSFT\WINDOWS\SYSTEM\DEFAULT");
//                  will create 7 subfolders if needed and return the final storage
//                  representing DEFAULT.
//                  FetchSubFolder should also be able to use nested paths. It will
//                  currently return the first match it encounters.
////////////////////////////////////////////////////////////////////////////////

namespace Imapi.Net
{
    /// <summary>
    /// A <c>JolietDiscMasterStorage</c> manages a single directory to be added
    /// to the disc.  A directory can contain files and sub-directories;
    /// the top level or root directory of the CD has a blank folder name.
    /// </summary>
    public class JolietDiscMasterStorage : Disposable
    {
        #region Private Member Variables

        private readonly string _folderName;
        private readonly DiscMaster _owner;
        private bool _disposed;
        private Dictionary<string, string> _files;
        private JolietStorage _storage;
        // Hashtable of folders; key is name, value is folder
        private Dictionary<string, JolietDiscMasterStorage> _subfolders;
        // Hashtable of files; key is name, value is source file

        #endregion Private Member Variables

        #region Public Methods and Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JolietDiscMasterStorage"/> class.
        /// </summary>
        /// <param name="owner">The owner.</param>
        internal JolietDiscMasterStorage( DiscMaster owner )
        {
            if ( owner == null )
            {
                throw new ArgumentNullException( "owner" );
            } // End if (owner == null)

            _owner = owner;
            _folderName = "";
            _subfolders = new Dictionary<string, JolietDiscMasterStorage>();
            _files = new Dictionary<string, string>();
            _storage = new JolietStorage( this, "" );
        } // End JolietDiscMasterStorage(DiscMaster owner)


        /// <summary>
        /// Initializes a new instance of the <see cref="JolietDiscMasterStorage"/> class.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="folder">The folder.</param>
        internal JolietDiscMasterStorage( DiscMaster owner, string folder )
        {
            if ( owner == null )
            {
                throw new ArgumentNullException( "owner" );
            } // End if (owner == null)

            _owner = owner;
            _folderName = folder;
            _subfolders = new Dictionary<string, JolietDiscMasterStorage>();
            _files = new Dictionary<string, string>();
            _storage = new JolietStorage( this, _folderName );
        } // End JolietDiscMasterStorage(DiscMaster owner, string folder) 


        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="Imapi.Net.JolietDiscMasterStorage"/> is reclaimed by garbage collection.
        /// </summary>
        ~JolietDiscMasterStorage()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose( false );
        } // End ~JolietDiscMasterStorage


        /// <summary>
        /// Clears any files associated with the storage
        /// </summary>
        public void Clear()
        {
            if ( _storage != null )
            {
                foreach ( JolietDiscMasterStorage subStorage in _subfolders.Values )
                {
                    // Be aware of the recursion when debugging.
                    subStorage.Clear();
                    //subStorage.Dispose();
                } // End foreach (JolietDiscMasterStorage subStorage in _subfolders.Values)
            } // End if (_storage != null)
            _subfolders = new Dictionary<string, JolietDiscMasterStorage>();
            _files = new Dictionary<string, string>();
        } // End Clear()


        /// <summary>
        /// Create a sub folder
        /// </summary>
        /// <param name="folderName">Name of the folder.</param>
        /// <returns>Sub folder</returns>
        public JolietDiscMasterStorage CreateSubfolder( string folderName )
        {
            if ( !_subfolders.ContainsKey( folderName ) )
            {
                var subfolder = new JolietDiscMasterStorage( _owner, folderName );
                _subfolders.Add( folderName, subfolder );
                //return subfolder;
            } // End if (!_subfolders.ContainsKey(folderName))
            //JolietDiscMasterStorage subfoldera = new JolietDiscMasterStorage(_owner, folderName);
            //return subfoldera;
            return _subfolders[folderName];
        } // End JolietDiscMasterStorage CreateSubfolder(string folderName)


        /// <summary>
        /// Fetches the <c>JolietDiscMasterStorage</c> for a particular folder.
        /// TODO: IMPLEMENT
        /// </summary>
        /// <param name="folderName">Name of the folder.</param>
        /// <returns>Sub folder</returns>
        public JolietDiscMasterStorage FetchSubfolder( string folderName )
        {
            if ( FolderName == folderName )
            {
                return this;
            } // End if (FolderName == folderName)

            foreach ( JolietDiscMasterStorage dir in _subfolders.Values )
            {
                if ( dir.FolderName == folderName )
                {
                    return dir;
                } // End if (dir.FolderName == folderName)
                else
                {
                    JolietDiscMasterStorage target = dir.FetchSubfolder( folderName );
                    if ( target != null )
                    {
                        return target;
                    } // End if (target != null)
                } // End if (dir.FolderName == folderName)...else
            } // End foreach (JolietDiscMasterStorage dir in _subfolders.Values)

            return null;
        } // End JolietDiscMasterStorage FetchSubfolder(string folderName)


        /// <summary>
        /// Add a file
        /// </summary>
        /// <param name="sourceFileName">Source file name</param>
        /// <param name="outputFileName">output file name</param>
        public void AddFile( string sourceFileName, string outputFileName )
        {
            _files.Add( outputFileName, sourceFileName );
        } // End void AddFile(string sourceFileName, string outputFileName)

        #endregion Public Methods and Constructors

        /// <summary>
        /// Dispose(bool disposing) executes in two distinct scenarios.
        /// If disposing equals true, the method has been called directly
        /// or indirectly by a user's code. Managed and unmanaged resources
        /// can be disposed.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals false, the method has been called by the 
        /// runtime from inside the finalizer and you should not reference 
        /// other objects. Only unmanaged resources can be disposed.
        /// </param>
        protected virtual void Dispose( bool disposing )
        {
            // Check to see if Dispose has already been called.
            if ( disposing && !IsDisposed )
            {
                // Dispose managed resources.
                if ( _storage != null )
                {
                    foreach ( JolietDiscMasterStorage subStorage in _subfolders.Values )
                    {
                        subStorage.Dispose();
                    } // End foreach
                    _storage.Dispose();
                    _storage = null;
                }
            }
            base.Dispose( disposing );
        }

        #region Internal Methods

        /// <summary>
        /// Requests the IStream.
        /// This will only search the current dir.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        internal IStream RequestIStream( string name )
        {
            IStream returnValue = null;
            int cancel = 0;
            _owner.QueryCancelRequest( out cancel );
            if ( cancel == 0 )
            {
                if ( _files.ContainsKey( name ) )
                {
                    string fileName = _files[name];
                    try
                    {
                        var fileStream = new FileStream( fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite );
                        var istream = new ManagedFileIStream( fileStream, name );
                        returnValue = istream;
                    } // End try
                    catch ( Exception ex )
                    {
                        Trace.WriteLine( "Exception trying to read file " + fileName + " // End : " + ex + " // End " );
                        throw;
                    } // End try...catch
                } // End if (_files.ContainsKey(name))
            } // End if (cancel == 0)
            return returnValue;
        } // End IStream RequestIStream(string name)


        /// <summary>
        /// Requests the storage.
        /// This will will only search the top level directories.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        internal IStorage RequestStorage( string name )
        {
            IStorage returnValue = null;
            int cancel = 0;
            _owner.QueryCancelRequest( out cancel );
            if ( cancel == 0 )
            {
                if ( _subfolders.ContainsKey( name ) )
                {
                    JolietDiscMasterStorage folder = _subfolders[name];
                    returnValue = folder.IStorage;
                } // End if (_subfolders.ContainsKey(name))
                else if ( name.Equals( _folderName ) )
                {
                    returnValue = _storage;
                } // End else if (name.Equals(_folderName))
            } // End if (cancel == 0)
            return returnValue;
        } // End IStorage RequestStorage(string name)

        #endregion Internal Methods

        #region Public Properties

        /// <summary>
        /// Gets the name of this folder.
        /// </summary>
        /// <value>The name of the folder.</value>
        public String FolderName
        {
            get { return _folderName; } // End get
        } // End Property FolderName


        /// <summary>
        /// Gets an <c>IEnumerator</c> instance for the files contained
        /// within this storage instance.  The name returned is
        /// the name of the file on the disc.
        /// </summary>
        public IEnumerator<string> Files
        {
            get
            {
                //return _files.Keys.GetEnumerator();
                IEnumerator e = _files.Keys.GetEnumerator();
                while ( e.MoveNext() )
                {
                    yield return (string) e.Current;
                }
            } // End get
        } // End Property Files


        /// <summary>
        /// Gets an <c>IEnumerator</c> instance for the sub-folders contained
        /// within this storage instance.  The name returned is
        /// the name of the subfolder on the disc.
        /// </summary>
        public IEnumerator<string> Folders
        {
            get
            {
                //return _subfolders.Keys.GetEnumerator();
                IEnumerator e = _subfolders.Keys.GetEnumerator();
                while ( e.MoveNext() )
                {
                    yield return (string) e.Current;
                }
            } // End get
        } // End Property Folders

        #endregion Public Properties

        #region Internal Properties

        /// <summary>
        /// Gets the IStorage.
        /// </summary>
        /// <value>The IStorage.</value>
        internal IStorage IStorage
        {
            get { return _storage; } // End get
        } // End Property IStorage

        #endregion Internal Properties
    }
}