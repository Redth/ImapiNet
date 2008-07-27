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
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Imapi.Net.ObjectModel;
using Imapi.Net.Properties;
using Imapi.Net.Interop.Enumerations;
using Imapi.Net.Interop.Exceptions;
using Imapi.Net.Interop.Interfaces;
using Imapi.Net;
using FILETIME=System.Runtime.InteropServices.ComTypes.FILETIME;
using STATSTG=System.Runtime.InteropServices.ComTypes.STATSTG;

#endregion Using Directives

namespace Imapi.Net.Interop
{
    /// <summary>
    /// Implementation of IStorage for the JolietDiscMaster interface.
    /// </summary>
    [Guid( "CD79B02B-DB7C-4bed-B169-C0A71804089E" )]
    [ComVisible( true )]
    internal class JolietStorage : Disposable, IStorage
    {
        #region Private Member Variables

        private readonly string _name;
        private readonly JolietDiscMasterStorage _owner;
        private JolietEnumStatStg _enumStatStg;

        #endregion Private Member Variables

        #region Public Methods and Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JolietStorage"/> class.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="name">The name.</param>
        public JolietStorage( JolietDiscMasterStorage owner, string name )
        {
            if ( owner == null )
            {
                throw new ArgumentNullException( "owner" );
            }

            _owner = owner;
            _name = name;
        }


        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="JolietStorage"/> is reclaimed by garbage collection.
        /// </summary>
        ~JolietStorage()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose( false );
        }


        /// <summary>
        /// Returns a <see cref="System.String"></see> that represents the current <see cref="System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"></see> that represents the current <see cref="System.Object"></see>.
        /// </returns>
        public override string ToString()
        {
            return _name;
        }

        #endregion Public Methods and Constructors

        #region IStorage Members

        /// <summary>
        /// The OpenStream method opens an existing stream object within this
        /// storage object in the specified access mode.
        /// IStorage::OpenStream opens an existing stream object within this
        /// storage object in the access mode specified in grfMode. There are
        /// restrictions on the permissions that can be given in grfMode. For
        /// example, the permissions on this storage object restrict the
        /// permissions on its streams. In general, access restrictions on
        /// streams need to be stricter than those on their parent storages.
        /// Compound-file streams must be opened with STGM_SHARE_EXCLUSIVE.
        /// </summary>
        /// <param name="pwcsName">const WCHAR* pwcsName
        /// [in] A pointer to a wide character null-terminated Unicode string that
        /// contains the name of the stream to open. The 000 through 01f characters,
        /// serving as the first character of the stream/storage name, are reserved
        /// for use by OLE. This is a compound file restriction, not a structured
        /// storage restriction.</param>
        /// <param name="reserved1">void* reserved1
        /// [in] Reserved for future use; must be NULL.</param>
        /// <param name="grfMode">DWORD grfMode
        /// [in] Specifies the access mode to be assigned to the open stream. For more
        /// information and descriptions of possible values, see STGM Constants. Other
        /// modes you choose must at least specify STGM_SHARE_EXCLUSIVE when calling
        /// this method in the compound file implementation.</param>
        /// <param name="reserved2">DWORD reserved2
        /// [in] Reserved for future use; must be zero.</param>
        /// <returns>
        /// IStream** ppstm
        /// [out] A pointer to IStream pointer variable that receives the interface
        /// pointer to the newly opened stream object. If an error occurs, *ppstm must
        /// be set to NULL.
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
        public IStream OpenStream( [In] [MarshalAs( UnmanagedType.BStr )] string pwcsName, IntPtr reserved1,
                                   [In] [MarshalAs( UnmanagedType.U4 )] int grfMode,
                                   [In] [MarshalAs( UnmanagedType.U4 )] int reserved2 )
        {
            IStream ppstm;
            if ( reserved1 != IntPtr.Zero )
            {
                throw new ArgumentException( Resources.Error_Msg_JolietStorage_reserved1_null,
                                             Resources.Variables_reserved1 );
            }

            if ( reserved2 != 0 )
            {
                throw new ArgumentException( Resources.Error_Msg_JolietStorage_reserved2_0,
                                             Resources.Variables_reserved2 );
            }

            IStream stream = _owner.RequestIStream( pwcsName );
            if ( stream != null )
            {
                ppstm = stream;
            }
            else
            {
                unchecked
                {
                    var error = (int) ErrorCodes.E_FAIL;
                    throw new COMException( Resources.Error_Msg_JolietStorage_CouldNotCreateStorage, error );
                }
            }
            return ppstm;
        }

        /// <summary>
        /// The OpenStorage method opens an existing storage object with the specified name
        /// in the specified access mode.
        /// Remarks
        /// If the pstgPriority parameter is NULL, it is ignored. If the pstgPriority
        /// parameter is not NULL, it is an IStorage pointer to a previous opening of an
        /// element of the storage object, usually one that was opened in priority mode.
        /// The storage object should be closed and reopened according to grfMode. When
        /// the IStorage::OpenStorage method returns, pstgPriority is no longer valid.
        /// Use the value supplied in the ppstg parameter.
        /// Storage objects can be opened with STGM_DELETEONRELEASE, in which case the
        /// object is destroyed when it receives its final release. This is useful for
        /// creating temporary storage objects.
        /// </summary>
        /// <param name="pwcsName">const WCHAR* pwcsName
        /// [in] A pointer to a wide character null-terminated Unicode string that
        /// contains the name of the storage object to open. The 000 through 01f characters,
        /// serving as the first character of the stream/storage name, are reserved for
        /// use by OLE. This is a compound file restriction, not a structured storage
        /// restriction. It is ignored if pstgPriority is non-NULL.</param>
        /// <param name="pstgPriority">IStorage* pstgPriority
        /// [in] Must be NULL. A non-NULL value will return STG_E_INVALIDPARAMETER.</param>
        /// <param name="grfMode">DWORD grfMode
        /// [in] Specifies the access mode to use when opening the storage object. For
        /// descriptions of the possible values, see STGM Constants. Other modes you
        /// choose must at least specify STGM_SHARE_EXCLUSIVE when calling this method.</param>
        /// <param name="snbExclude">SNB snbExclude
        /// [in] Must be NULL. A non-NULL value will return STG_E_INVALIDPARAMETER.</param>
        /// <param name="reserved">DWORD reserved
        /// [in] Reserved for future use; must be zero.</param>
        /// <returns>
        /// IStorage** ppstg
        /// [out] When successful, pointer to the location of an IStorage pointer to the
        /// opened storage object. This parameter is set to NULL if an error occurs.
        /// </returns>
        /// <exception cref="Exceptions.StorageAccessDeniedException">
        /// Not enough permissions to create storage object.
        /// </exception>
        /// <exception cref="Exceptions.FileExistsException">
        /// The name specified for the storage object already exists in the storage object and the grfMode parameter includes the flag STGM_FAILIFTHERE.
        /// </exception>
        /// <exception cref="InsufficientMemoryException">
        /// The storage object was not created due to a lack of memory.
        /// </exception>
        /// <exception cref="Exceptions.InvalidStorageFunctionException">
        /// The specified combination of flags in the grfMode parameter is not supported.
        /// </exception>
        /// <exception cref="Exceptions.InvalidStorageNameException">
        /// Not a valid value for pwcsName.
        /// </exception>
        /// <exception cref="Exceptions.InvalidPointerException">
        /// The pointer specified for the storage object was not valid.
        /// </exception>
        /// <exception cref="Exceptions.InvalidParameterException">
        /// One of the parameters was not valid.
        /// </exception>
        /// <exception cref="Exceptions.StorageRevertedException">
        /// The storage object has been invalidated by a revert operation above it in the transaction tree.
        /// </exception>
        /// <exception cref="Exceptions.TooManyOpenFilesException">
        /// The storage object was not created because there are too many open files.
        /// </exception>
        public IStorage OpenStorage( [In] [MarshalAs( UnmanagedType.BStr )] string pwcsName, IntPtr pstgPriority,
                                     [In] [MarshalAs( UnmanagedType.U4 )] int grfMode, IntPtr snbExclude,
                                     [In] [MarshalAs( UnmanagedType.U4 )] int reserved )
        {
            IStorage ppstg;

            if ( pstgPriority != IntPtr.Zero )
            {
                throw new ArgumentException( Resources.Error_Msg_JolietStorage_pstgPriority_null,
                                             Resources.Variables_pstgPriority );
            }

            if ( snbExclude != IntPtr.Zero )
            {
                throw new ArgumentException( Resources.Error_Msg_JolietStorage_snbExclude_null,
                                             Resources.Variables_snbExclude );
            }

            if ( reserved != 0 )
            {
                throw new ArgumentException( Resources.Error_Msg_JolietStorage_reserved_0, Resources.Variables_reserved );
            }

            IStorage storage = _owner.RequestStorage( pwcsName );
            if ( storage != null )
            {
                ppstg = storage;
            }
            else
            {
                unchecked
                {
                    var error = (int) ErrorCodes.E_FAIL;
                    throw new COMException( Resources.Error_Msg_JolietStorage_CouldNotCreateStorage, error );
                }
            }

            return ppstg;
        }

        /// <summary>
        /// The EnumElements method retrieves a pointer to an enumerator object that can
        /// be used to enumerate the storage and stream objects contained within this
        /// storage object.
        /// Remarks
        /// The enumerator object returned by this method implements the IEnumSTATSTG
        /// interface, one of the standard enumerator interfaces that contain the Next,
        /// Reset, Clone, and Skip methods. IEnumSTATSTG enumerates the data stored in
        /// an array of STATSTG structures.
        /// The storage object must be open in read mode to allow the enumeration of its elements.
        /// The order in which the elements are enumerated and whether the enumerator is
        /// a snapshot or always reflects the current state of the storage object, and
        /// depends on the IStorage implementation.
        /// </summary>
        /// <param name="reserved1">DWORD reserved1
        /// [in] Reserved for future use; must be zero.</param>
        /// <param name="reserved2">void* reserved2
        /// [in] Reserved for future use; must be NULL.</param>
        /// <param name="reserved3">DWORD reserved3
        /// [in] Reserved for future use; must be zero.</param>
        /// <param name="ppenum">IEnumSTATSTG** ppenum
        /// [out] Pointer to IEnumSTATSTG* pointer variable that receives the interface pointer
        /// to the new enumerator object.</param>
        /// TODO: Add Exceptions
        public void EnumElements( [In] [MarshalAs( UnmanagedType.U4 )] int reserved1, IntPtr reserved2,
                                  [In] [MarshalAs( UnmanagedType.U4 )] int reserved3,
                                  [MarshalAs( UnmanagedType.Interface )] out IEnumSTATSTG ppenum )
        {
            if ( reserved1 != 0 )
            {
                ppenum = null;
                throw new ArgumentException( Resources.Error_Msg_JolietStorage_Reserved1, Resources.Variables_reserved1 );
            }

            if ( reserved2 != IntPtr.Zero )
            {
                ppenum = null;
                throw new ArgumentException( Resources.Error_Msg_JolietStorage_Reserved2, Resources.Variables_reserved2 );
            }

            if ( reserved3 != 0 )
            {
                ppenum = null;
                throw new ArgumentException( Resources.Error_Msg_JolietStorage_Reserved3, Resources.Variables_reserved3 );
            }

            _enumStatStg = new JolietEnumStatStg( _owner );
            ppenum = _enumStatStg;
        }


        /// <summary>
        /// The Stat method retrieves the STATSTG structure for this open storage object.
        /// Remarks
        /// IStorage::Stat retrieves the STATSTG structure for the current storage
        /// object. The STATSTG structure contains statistical information about the
        /// storage object. IStorage::EnumElements returns a pointer to an enumerator
        /// object. The enumerator object returned by this method implements the
        /// IEnumSTATSTG interface, through which the data stored in the array of the
        /// STATSTG structures is enumerated.
        /// </summary>
        /// <param name="pstatstg">
        /// STATSTG* pstatstg
        /// [out] On return, pointer to a STATSTG structure where this method places
        /// information about the open storage object. This parameter is NULL if an
        /// error occurs. 
        /// </param>
        /// <param name="grfStatFlag">
        /// DWORD grfStatFlag
        /// [in] Specifies that some of the members in the STATSTG structure are not
        /// returned, thus saving a memory allocation operation. Values are taken from
        /// the STATFLAG enumeration. 
        /// </param>
        public void Stat( out STATSTG pstatstg, StatFlag grfStatFlag )
        {
            pstatstg = new STATSTG();

            if ( grfStatFlag != StatFlag.NoName )
            {
                pstatstg.pwcsName = _name;
            }
            pstatstg.type = (int) STGTY.Storage;
            pstatstg.cbSize = Marshal.SizeOf( typeof (STATSTG) );
        }

        #endregion

        #region IStorage Unimplemented Methods

        /// <summary>
        /// The CreateStream method creates and opens a stream object with the
        /// specified name contained in this storage object. All elements within
        /// a storage objects, both streams and other storage objects, are kept
        /// in the same name space.
        /// HRESULT CreateStream(
        /// const WCHAR* pwcsName,
        /// DWORD grfMode,
        /// DWORD reserved1,
        /// DWORD reserved2,
        /// IStream** ppstm
        /// );
        /// I am ignoring the E_PENDING error because we are not using high latency asynchronous storage.
        /// I am ignoring the STG_E_INVALIDFLAG error because we limit the use of the flag parameter to the enumeration.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/istorage_createstream.asp
        /// </summary>
        /// <param name="pwcsName">const WCHAR* pwcsName
        /// [in] A pointer to a wide character null-terminated Unicode string that
        /// contains the name of the newly created stream. The name can be used later
        /// to open or reopen the stream. The name must not exceed 31 characters in
        /// length, not including the string terminator. The 000 through 01f characters,
        /// serving as the first character of the stream/storage name, are reserved for
        /// use by OLE. This is a compound file restriction, not a structured storage
        /// restriction.</param>
        /// <param name="grfMode">DWORD grfMode
        /// [in] Specifies the access mode to use when opening the newly created
        /// stream. For more information and descriptions of the possible values,
        /// see STGM Constants.</param>
        /// <param name="reserved1">DWORD reserved1
        /// [in] Reserved for future use; must be zero.</param>
        /// <param name="reserved2">DWORD reserved2
        /// [in] Reserved for future use; must be zero.</param>
        /// <returns>
        /// IStream** ppstm
        /// [out] On return, pointer to the location of the new IStream interface
        /// pointer. This is only valid if the operation is successful. When an error
        /// occurs, this parameter is set to NULL.
        /// </returns>
        /// <exception cref="Exceptions.StorageAccessDeniedException"></exception>
        /// <exception cref="Exceptions.StorageFileAlreadyExistsException"></exception>
        /// <exception cref="InsufficientMemoryException"></exception>
        /// <exception cref="Exceptions.InvalidStorageFunctionException"></exception>
        /// <exception cref="Exceptions.InvalidStorageNameException"></exception>
        /// <exception cref="Exceptions.InvalidPointerException"></exception>
        /// <exception cref="Exceptions.InvalidParameterException"></exception>
        /// <exception cref="Exceptions.StorageRevertedException"></exception>
        /// <exception cref="Exceptions.TooManyOpenFilesException"></exception>
        public IStream CreateStream( [In] [MarshalAs( UnmanagedType.BStr )] string pwcsName,
                                     [In] [MarshalAs( UnmanagedType.U4 )] int grfMode,
                                     [In] [MarshalAs( UnmanagedType.U4 )] int reserved1,
                                     [In] [MarshalAs( UnmanagedType.U4 )] int reserved2 )
        {
            throw new MethodNotImplementedException();
        }

        /// <summary>
        /// The CreateStorage method creates and opens a new storage object nested within
        /// this storage object with the specified name in the specified access mode.
        /// Remarks
        /// If a storage with the name specified in the pwcsName parameter already exists
        /// within the parent storage object, and the grfMode parameter includes the
        /// STGM_CREATE flag, the existing storage is replaced by the new one. If the
        /// grfMode parameter includes the STGM_CONVERT flag, the existing element is
        /// converted to a stream object named CONTENTS and the new storage object is
        /// created containing the CONTENTS stream object. The destruction of the old
        /// element and the creation of the new storage object are both subject to the
        /// transaction mode on the parent storage object. Be aware that you cannot use
        /// STGM_CONVERT if you are also using STGM_CREATE.
        /// The COM-provided compound file implementation of the IStorage::CreateStorage
        /// method does not support the following behavior:
        /// * The STGM_PRIORITY flag for nonroot storages.
        /// * Opening the same storage object more than once from the same parent storage.
        /// The STGM_SHARE_EXCLUSIVE flag must be specified.
        /// * The STGM_DELETEONRELEASE flag. If this flag is specified, the function returns
        /// STG_E_INVALIDFLAG.
        /// If a storage object with the same name already exists and grfMode is set to
        /// STGM_FAILIFTHERE, this method fails with the return value STG_E_FILEALREADYEXISTS.
        /// </summary>
        /// <param name="pwcsName">const WCHAR* pwcsName
        /// [in] A pointer to a wide character null-terminated Unicode string that contains
        /// the name of the newly created storage object. The name can be used later to
        /// reopen the storage object. The name must not exceed 31 characters in length, not
        /// including the string terminator. The 000 through 01f characters, serving as the
        /// first character of the stream/storage name, are reserved for use by OLE. This is a
        /// compound file restriction, not a structured storage restriction.</param>
        /// <param name="grfMode">DWORD grfMode
        /// [in] A value that specifies the access mode to use when opening the newly created
        /// storage object. For more information and a description of possible values, see
        /// STGM Constants.</param>
        /// <param name="reserved1">DWORD reserved1
        /// [in] Reserved for future use; must be zero.</param>
        /// <param name="reserved2">DWORD reserved2
        /// [in] Reserved for future use; must be zero.</param>
        /// <returns>
        /// IStorage** ppstg
        /// [out] A pointer, when successful, to the location of the IStorage pointer to the
        /// newly created storage object. This parameter is set to NULL if an error occurs.
        /// </returns>
        /// <exception cref="Exceptions.MethodNotImplementedException"></exception>
        public IStorage CreateStorage( [In] [MarshalAs( UnmanagedType.BStr )] string pwcsName,
                                       [In] [MarshalAs( UnmanagedType.U4 )] int grfMode,
                                       [In] [MarshalAs( UnmanagedType.U4 )] int reserved1,
                                       [In] [MarshalAs( UnmanagedType.U4 )] int reserved2 )
        {
            throw new MethodNotImplementedException();
        }

        /// <summary>
        /// The CopyTo method copies the entire contents of an open storage object to another storage object.
        /// Remarks
        /// This method merges elements contained in the source storage object with those
        /// already present in the destination. The layout of the destination storage object
        /// may differ from the source storage object.
        /// The copy process is recursive, invoking IStorage::CopyTo and IStream::CopyTo
        /// on the elements nested inside the source.
        /// When copying a stream on top of an existing stream with the same name, the
        /// existing stream is first removed and then replaced with the source stream.
        /// When copying a storage on top of an existing storage with the same name, the
        /// existing storage is not removed. As a result, after the copy operation, the
        /// destination IStorage contains older elements, unless they were replaced by newer
        /// ones with the same names.
        /// A storage object may expose interfaces other than IStorage, including IRootStorage,
        /// IPropertyStorage, or IPropertySetStorage. The rgiidExclude parameter permits the
        /// exclusion of any or all of these additional interfaces from the copy operation.
        /// A caller with a newer or more efficient copy of an existing substorage or stream
        /// object may want to exclude the current versions of these objects from the copy
        /// operation. The snbExclude and rgiidExclude parameters provide two ways of excluding
        /// a storage objects existing storages or streams.
        /// Note to Callers
        /// The most common way to use the IStorage::CopyTo method is to copy everything from
        /// the source to the destination, as in most full-save and save-as operations.
        /// The following example code shows how to copy everything from the source storage
        /// object to the destination storage object.
        /// pstg-&gt;CopyTo(0, Null, Null, pstgDest)
        /// Note  To compact a document file, call CopyTo on the root storage object and copy
        /// to a new storage object.
        /// </summary>
        /// <param name="ciidExclude">DWORD ciidExclude
        /// [in] The number of elements in the array pointed to by rgiidExclude. If rgiidExclude
        /// is NULL, then ciidExclude is ignored.</param>
        /// <param name="rgiidExclude">IID const* rgiidExclude
        /// [in] An array of interface identifiers (IIDs) that either the caller knows about and
        /// does not want copied or that the storage object does not support, but whose state the
        /// caller will later explicitly copy. The array can include IStorage, indicating that
        /// only stream objects are to be copied, and IStream, indicating that only storage
        /// objects are to be copied. An array length of zero indicates that only the state
        /// exposed by the IStorage object is to be copied; all other interfaces on the object
        /// are to be ignored. Passing NULL indicates that all interfaces on the object are to
        /// be copied.</param>
        /// <param name="snbExclude">SNB snbExclude
        /// [in] A string name block (refer to SNB) that specifies a block of storage or stream
        /// objects that are not to be copied to the destination. These elements are not created
        /// at the destination. If IID_IStorage is in the rgiidExclude array, this parameter is
        /// ignored. This parameter may be NULL.</param>
        /// <param name="pstgDest">IStorage* pstgDest
        /// [in] A pointer to the open storage object into which this storage object is to be
        /// copied. The destination storage object can be a different implementation of the
        /// IStorage interface from the source storage object. Thus, IStorage::CopyTo can use
        /// only publicly available methods of the destination storage object. If pstgDest is
        /// open in transacted mode, it can be reverted by calling its IStorage::Revert method.</param>
        /// <exception cref="Exceptions.MethodNotImplementedException"></exception>
        public void CopyTo( int ciidExclude, Guid[] rgiidExclude, IntPtr snbExclude, IStorage pstgDest )
        {
            throw new MethodNotImplementedException();
        }

        /// <summary>
        /// The MoveElementTo method copies or moves a substorage or stream from this storage
        /// object to another storage object.
        /// 
        /// Remarks
        /// The IStorage::MoveElementTo method is typically the same as invoking the
        /// IStorage::CopyTo method on the indicated element and then removing the source element.
        /// In this case, the MoveElementTo method uses only the publicly available functions of
        /// the destination storage object to carry out the move.
        /// If the source and destination storage objects have special knowledge about each
        /// other's implementation (they could, for example, be different instances of the same
        /// implementation), this method can be implemented more efficiently.
        /// Before calling this method, the element to be moved must be closed, and the
        /// destination storage must be open. Also, the destination object and element cannot
        /// be the same storage object/element name as the source of the move. That is, you
        /// cannot move an element to itself.
        /// </summary>
        /// <param name="pwcsName">
        /// const WCHAR* pwcsName 
        /// [in] Pointer to a wide character null-terminated Unicode string that contains the name
        /// of the element in this storage object to be moved or copied. 
        /// </param>
        /// <param name="pstgDest">
        /// IStorage* pstgDest 
        /// [in] IStorage pointer to the destination storage object. 
        /// </param>
        /// <param name="pwcsNewName">
        /// LPWSTR pwcsNewName
        /// [in] Pointer to a wide character null-terminated unicode string that contains the new
        /// name for the element in its new storage object.
        /// </param>
        /// <param name="grfFlags">
        /// DWORD grfFlags
        /// [in] Specifies whether the operation should be a move (STGMOVE_MOVE) or a copy
        /// (STGMOVE_COPY). See the STGMOVE enumeration. 
        /// </param>
        /// <exception cref="Exceptions.MethodNotImplementedException"></exception>
        public void MoveElementTo( [In] [MarshalAs( UnmanagedType.BStr )] string pwcsName,
                                   [In] [MarshalAs( UnmanagedType.Interface )] IStorage pstgDest,
                                   [In] [MarshalAs( UnmanagedType.BStr )] string pwcsNewName,
                                   [In] [MarshalAs( UnmanagedType.U4 )] int grfFlags )
        {
            throw new MethodNotImplementedException();
        }

        /// <summary>
        /// The Commit method ensures that any changes made to a storage object open in
        /// transacted mode are reflected in the parent storage. For nonroot storage
        /// objects in direct mode, this method has no effect. For a root storage, it
        /// reflects the changes in the actual device; for example, a file on disk. For
        /// a root storage object opened in direct mode, always call the IStorage::Commit
        /// method prior to Release. IStorage::Commit flushes all memory buffers to the
        /// disk for a root storage in direct mode and will return an error code upon
        /// failure. Although Release also flushes memory buffers to disk, it has no
        /// capacity to return any error codes upon failure. Therefore, calling Release
        /// without first calling Commit causes indeterminate results.
        /// </summary>
        /// <param name="grfCommitFlags">
        /// DWORD grfCommitFlags
        /// [in] Controls how the changes are committed to the storage object. See the
        /// STGC enumeration for a definition of these values. 
        /// </param>
        /// <exception cref="Exceptions.MethodNotImplementedException"></exception>
        public void Commit( STGC grfCommitFlags )
        {
            throw new MethodNotImplementedException();
        }

        /// <summary>
        /// The Revert method discards all changes that have been made to the
        /// storage object since the last commit operation.
        /// Remarks
        /// For storage objects opened in transacted mode, the IStorage::Revert
        /// method discards any uncommitted changes to this storage object or
        /// changes that have been committed to this storage object from nested
        /// elements.
        /// After this method returns, any existing elements (substorages or streams)
        /// that were opened from the reverted storage object are invalid and can
        /// no longer be used. Specifying these reverted elements in any call
        /// except IUnknown::Release returns the error STG_E_REVERTED
        /// This method has no effect on storage objects opened in direct mode.
        /// </summary>
        /// <exception cref="Exceptions.MethodNotImplementedException"></exception>
        public void Revert()
        {
            throw new MethodNotImplementedException();
        }

        /// <summary>
        /// The DestroyElement method removes the specified storage or stream from this storage object.
        /// 
        /// Remarks
        /// The DestroyElement method deletes a substorage or stream from the current storage
        /// object. After a successful call to DestroyElement, any open instance of the
        /// destroyed element from the parent storage becomes invalid.
        /// If a storage object is opened in the transacted mode, destruction of an element
        /// requires that the call to DestroyElement be followed by a call to IStorage::Commit.
        /// Note  The DestroyElement method does not shrink the directory stream. It only marks
        /// the deleted directory entry as invalid. Invalid entries are reused when creating a
        /// new storage or stream. 
        /// For content streams, the deleted stream sectors are marked as free. If the free
        /// sectors are at the end of the file, the document file should shrink. To compact a
        /// document file, call IStorage::CopyTo on the root storage object and copy to a new
        /// storage object.
        /// </summary>
        /// <param name="pwcsName">
        /// wchar* pwcsName
        /// [in] A pointer to a wide character null-terminated Unicode string that contains
        /// the name of the storage or stream to be removed. 
        /// </param>
        /// <exception cref="Exceptions.MethodNotImplementedException"></exception>
        public void DestroyElement( string pwcsName )
        {
            throw new MethodNotImplementedException();
        }

        /// <summary>
        /// The RenameElement method renames the specified substorage or stream in this storage object.
        /// 
        /// IStorage::RenameElement renames the specified substorage or stream in this storage
        /// object. An element in a storage object cannot be renamed while it is open. The rename
        /// operation is subject to committing the changes if the storage is open in transacted mode.
        /// The IStorage::RenameElement method is not guaranteed to work in low memory with storage
        /// objects open in transacted mode. It may work in direct mode.
        /// </summary>
        /// <param name="pwcsOldName ">
        /// const WCHAR* pwcsOldName 
        /// [in] Pointer to a wide character null-terminated Unicode string that contains the name
        /// of the substorage or stream to be changed.
        /// Note  The pwcsName, created in CreateStorage or CreateStream must not exceed 31 characters
        /// in length, not including the string terminator.
        /// </param>
        /// <param name="pwcsNewName">
        /// const WCHAR* pwcsNewName
        /// [in] Pointer to a wide character null-terminated unicode string that contains the new
        /// name for the specified substorage or stream.
        /// Note  The pwcsName, created in CreateStorage or CreateStream must not exceed 31 characters
        /// in length, not including the string terminator.
        /// </param>
        /// <exception cref="Exceptions.MethodNotImplementedException"></exception>
        public void RenameElement( string pwcsOldName, string pwcsNewName )
        {
            throw new MethodNotImplementedException();
        }

        /// <summary>
        /// The SetElementTimes method sets the modification, access, and creation times of the
        /// specified storage element, if the underlying file system supports this method.
        /// Remarks
        /// SetElementTimes sets time statistics for the specified storage element within this
        /// storage object.
        /// Not all file systems support all the time values. This method sets those times that
        /// are supported and ignores the rest. Each time-value parameter can be NULL; indicating
        /// that no modification should occur.
        /// Call the IStorage::Stat method to retrieve these time values.
        /// </summary>
        /// <param name="pwcsName">
        /// const WCHAR* pwcsName 
        /// [in] The name of the storage object element whose times are to be modified. If NULL,
        /// the time is set on the root storage rather than one of its elements. 
        /// </param>
        /// <param name="pctime">
        /// FILETIME const* pctime
        /// [in] Either the new creation time for the element or NULL if the creation time is not
        /// to be modified. 
        /// </param>
        /// <param name="patime">
        /// FILETIME const* patime
        /// [in] Either the new access time for the element or NULL if the access time is not to
        /// be modified.
        /// </param>
        /// <param name="pmtime">
        /// FILETIME const* pmtime
        /// [in] Either the new modification time for the element or NULL if the modification time
        /// is not to be modified. 
        /// </param>
        /// <exception cref="Exceptions.MethodNotImplementedException"></exception>
        public void SetElementTimes( [In] [MarshalAs( UnmanagedType.BStr )] string pwcsName, [In] FILETIME pctime,
                                     [In] FILETIME patime, [In] FILETIME pmtime )
        {
            throw new MethodNotImplementedException();
        }


        /// <summary>
        /// The SetClass method assigns the specified class identifier (CLSID) to this storage object.
        /// 
        /// Remarks
        /// When first created, a storage object has an associated CLSID of CLSID_NULL.
        /// Call SetClass to assign a CLSID to the storage object.
        /// Call the IStorage::Stat method to retrieve the current CLSID of a storage object.
        /// </summary>
        /// <param name="clsid">
        /// REFCLSID clsid
        /// [in] The CLSID that is to be associated with the storage object. 
        /// </param>
        /// <exception cref="Exceptions.MethodNotImplementedException"></exception>
        public void SetClass( ref Guid clsid )
        {
            throw new MethodNotImplementedException();
        }

        /// <summary>
        /// The SetStateBits method stores up to 32 bits of state information in
        /// this storage object. This method is reserved for future use.
        /// Remarks
        /// The values for the state bits are not currently defined
        /// </summary>
        /// <param name="grfStateBits">
        /// DWORD grfStateBits
        /// [in] Specifies the new values of the bits to set. No legal values are
        /// defined for these bits; they are all reserved for future use and must
        /// not be used by applications.
        /// </param>
        /// <param name="grfMask">
        /// DWORD grfMask
        /// [in] A binary mask indicating which bits in grfStateBits are
        /// significant in this call.
        /// </param>
        /// <exception cref="Exceptions.MethodNotImplementedException"></exception>
        public void SetStateBits( int grfStateBits, int grfMask )
        {
            throw new MethodNotImplementedException();
        }

        #endregion IStorage Unimplemented Methods

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
        protected override void Dispose( bool disposing )
        {
            // Check to see if Dispose has already been called.
            if ( disposing && !IsDisposed )
            {
                // Dispose managed resources.
                if ( _enumStatStg != null )
                {
                    //_enumStatStg.Dispose();
                    _enumStatStg = null;
                }
            }

            base.Dispose( disposing );
        }
    }
}