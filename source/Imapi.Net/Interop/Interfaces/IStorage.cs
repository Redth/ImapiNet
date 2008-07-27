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
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Imapi.Net.Interop.Enumerations;
using FILETIME=System.Runtime.InteropServices.ComTypes.FILETIME;
using STATSTG=System.Runtime.InteropServices.ComTypes.STATSTG;

#endregion Using Directives

namespace Imapi.Net.Interop.Interfaces
{
    /// <summary>
    /// The IStorage interface supports the creation and management of
    /// structured storage objects. Structured storage allows hierarchical
    /// storage of information within a single file, and is often referred
    /// to as "a file system within a file". Elements of a structured
    /// storage object are storages and streams. Storages are analogous to
    /// directories, and streams are analogous to files. Within a structured
    /// storage there will be a primary storage object that may contain
    /// substorages, possibly nested, and streams. Storages provide the
    /// structure of the object, and streams contain the data, which is
    /// manipulated through the <see cref="IStream"/> interface.
    /// The IStorage interface provides methods for creating and managing
    /// the root storage object, child storage objects, and stream objects.
    /// These methods can create, open, enumerate, move, copy, rename, or
    /// delete the elements in the storage object.
    /// An application must release its IStorage pointers when it is done
    /// with the storage object to deallocate memory used. There are also
    /// methods for changing the date and time of an element.
    /// There are a number of different modes in which a storage object and
    /// its elements can be opened, determined by setting values from STGM
    /// constants. One aspect of this is how changes are committed. You can
    /// set direct mode, in which changes to an object are immediately written
    /// to it, or transacted mode, in which changes are written to a buffer
    /// until explicitly committed. The IStorage interface provides methods
    /// for committing changes and reverting to the last-committed version.
    /// For example, a stream can be opened in read-only mode or read/write
    /// mode. For more information, see STGM Constants.
    /// Other methods provide access to information about a storage object
    /// and its elements through the STATSTG structure.
    /// When To Implement
    /// Generally, you would not implement this interface unless you were
    /// defining a new storage scheme for your system. COM provides a compound
    /// file implementation of the IStorage interface that supports transacted
    /// access. COM provides a set of helper APIs to facilitate using the
    /// compound file implementation of storage objects. For more information,
    /// see IStorage - Compound File Implementation.
    /// When To Use
    /// Call the methods of IStorage to manage substorages or streams within the
    /// current storage. This management includes creating, opening, or
    /// destroying substorages or streams, as well as managing aspects such as
    /// time stamps, names, and so forth. You also can commit changes or revert
    /// to previous version for storages opened in transacted mode. The methods
    /// of IStorage do not include means to read and write data—this is reserved
    /// for <see cref="IStream"/>, which manages the actual data. While the IStorage and
    /// <see cref="IStream"/> interfaces are used to manipulate the storage object and its
    /// elements, the IPersistStorage interface contains methods that are called
    /// to serialize the storage object and its elements to a disk file.
    /// The IStorage interface inherits the methods of the standard COM interface <see cref="IUnknown"/>.
    /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/istorage.asp
    /// </summary>
    [ComImport]
    [Guid( "0000000B-0000-0000-C000-000000000046" )]
    [InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
    public interface IStorage
    {
        /// <summary>
        /// The CreateStream method creates and opens a stream object with the
        /// specified name contained in this storage object. All elements within
        /// a storage objects, both streams and other storage objects, are kept
        /// in the same name space.
        /// 
        /// HRESULT CreateStream(
        ///  const WCHAR* pwcsName,
        ///  DWORD grfMode,
        ///  DWORD reserved1,
        ///  DWORD reserved2,
        ///  IStream** ppstm
        /// );
        /// 
        /// I am ignoring the E_PENDING error because we are not using high latency asynchronous storage.
        /// I am ignoring the STG_E_INVALIDFLAG error because we limit the use of the flag parameter to the enumeration.
        /// 
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/istorage_createstream.asp
        /// </summary>
        /// <param name="pwcsName">
        /// const WCHAR* pwcsName
        /// [in] A pointer to a wide character null-terminated Unicode string that
        /// contains the name of the newly created stream. The name can be used later
        /// to open or reopen the stream. The name must not exceed 31 characters in
        /// length, not including the string terminator. The 000 through 01f characters,
        /// serving as the first character of the stream/storage name, are reserved for
        /// use by OLE. This is a compound file restriction, not a structured storage
        /// restriction. 
        /// </param>
        /// <param name="grfMode">
        /// DWORD grfMode
        /// [in] Specifies the access mode to use when opening the newly created
        /// stream. For more information and descriptions of the possible values,
        /// see STGM Constants.  
        /// </param>
        /// <param name="reserved1">
        /// DWORD reserved1
        /// [in] Reserved for future use; must be zero. 
        /// </param>
        /// <param name="reserved2">
        /// DWORD reserved2
        /// [in] Reserved for future use; must be zero. 
        /// </param>
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
        [return : MarshalAs( UnmanagedType.Interface )]
        IStream CreateStream( [In] [MarshalAs( UnmanagedType.BStr )] string pwcsName,
                              [In] [MarshalAs( UnmanagedType.U4 )] int grfMode,
                              [In] [MarshalAs( UnmanagedType.U4 )] int reserved1,
                              [In] [MarshalAs( UnmanagedType.U4 )] int reserved2 );


        /// <summary>
        /// The OpenStream method opens an existing stream object within this
        /// storage object in the specified access mode.
        /// 
        /// HRESULT OpenStream(
        ///   const WCHAR* pwcsName,
        ///   void* reserved1,
        ///   DWORD grfMode,
        ///   DWORD reserved2,
        ///   IStream** ppstm
        /// );
        /// 
        /// IStorage::OpenStream opens an existing stream object within this
        /// storage object in the access mode specified in grfMode. There are
        /// restrictions on the permissions that can be given in grfMode. For
        /// example, the permissions on this storage object restrict the
        /// permissions on its streams. In general, access restrictions on
        /// streams need to be stricter than those on their parent storages.
        /// Compound-file streams must be opened with STGM_SHARE_EXCLUSIVE.
        /// 
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/istorage_openstream.asp
        /// </summary>
        /// <param name="pwcsName">
        /// const WCHAR* pwcsName
        /// [in] A pointer to a wide character null-terminated Unicode string that
        /// contains the name of the stream to open. The 000 through 01f characters,
        /// serving as the first character of the stream/storage name, are reserved
        /// for use by OLE. This is a compound file restriction, not a structured
        /// storage restriction. 
        /// </param>
        /// <param name="reserved1">
        /// void* reserved1
        /// [in] Reserved for future use; must be NULL.
        /// </param>
        /// <param name="grfMode">
        /// DWORD grfMode
        /// [in] Specifies the access mode to be assigned to the open stream. For more
        /// information and descriptions of possible values, see STGM Constants. Other
        /// modes you choose must at least specify STGM_SHARE_EXCLUSIVE when calling
        /// this method in the compound file implementation. 
        /// </param>
        /// <param name="reserved2">
        /// DWORD reserved2
        /// [in] Reserved for future use; must be zero. 
        /// </param>
        /// <returns>
        /// IStream** ppstm
        /// [out] A pointer to IStream pointer variable that receives the interface
        /// pointer to the newly opened stream object. If an error occurs, *ppstm must
        /// be set to NULL. 
        /// </returns>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="Exceptions.StorageAccessDeniedException"></exception>
        /// <exception cref="InsufficientMemoryException"></exception>
        /// <exception cref="Exceptions.InvalidStorageFunctionException"></exception>
        /// <exception cref="Exceptions.InvalidStorageNameException"></exception>
        /// <exception cref="Exceptions.InvalidPointerException"></exception>
        /// <exception cref="Exceptions.InvalidParameterException"></exception>
        /// <exception cref="Exceptions.StorageRevertedException"></exception>
        /// <exception cref="Exceptions.TooManyOpenFilesException"></exception>
        [return : MarshalAs( UnmanagedType.Interface )]
        IStream OpenStream( [In] [MarshalAs( UnmanagedType.BStr )] string pwcsName, IntPtr reserved1,
                            [In] [MarshalAs( UnmanagedType.U4 )] int grfMode,
                            [In] [MarshalAs( UnmanagedType.U4 )] int reserved2 );


        /// <summary>
        /// The CreateStorage method creates and opens a new storage object nested within
        /// this storage object with the specified name in the specified access mode.
        /// 
        /// HRESULT CreateStorage(
        ///   const WCHAR* pwcsName,
        ///   DWORD grfMode,
        ///   DWORD reserved1,
        ///   DWORD reserved2,
        ///   IStorage** ppstg
        /// );
        /// 
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
        ///   The STGM_SHARE_EXCLUSIVE flag must be specified. 
        /// * The STGM_DELETEONRELEASE flag. If this flag is specified, the function returns
        ///   STG_E_INVALIDFLAG. 
        /// If a storage object with the same name already exists and grfMode is set to
        /// STGM_FAILIFTHERE, this method fails with the return value STG_E_FILEALREADYEXISTS.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/istorage_createstorage.asp
        /// 
        /// I am ignoring the STG_S_CONVERTED result:
        /// The existing stream with the specified name was replaced with a new storage object containing a 
        /// single stream called CONTENTS. The new storage object will be added.
        /// </summary>
        /// <param name="pwcsName">
        /// const WCHAR* pwcsName
        /// [in] A pointer to a wide character null-terminated Unicode string that contains
        /// the name of the newly created storage object. The name can be used later to
        /// reopen the storage object. The name must not exceed 31 characters in length, not
        /// including the string terminator. The 000 through 01f characters, serving as the
        /// first character of the stream/storage name, are reserved for use by OLE. This is a
        /// compound file restriction, not a structured storage restriction. 
        /// </param>
        /// <param name="grfMode">
        /// DWORD grfMode
        /// [in] A value that specifies the access mode to use when opening the newly created
        /// storage object. For more information and a description of possible values, see
        /// STGM Constants. 
        /// </param>
        /// <param name="reserved1">
        /// DWORD reserved1
        /// [in] Reserved for future use; must be zero. 
        /// </param>
        /// <param name="reserved2">
        /// DWORD reserved2
        /// [in] Reserved for future use; must be zero. 
        /// </param>
        /// <returns>
        /// IStorage** ppstg
        /// [out] A pointer, when successful, to the location of the IStorage pointer to the
        /// newly created storage object. This parameter is set to NULL if an error occurs. 
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
        [return : MarshalAs( UnmanagedType.Interface )]
        IStorage CreateStorage( [In] [MarshalAs( UnmanagedType.BStr )] string pwcsName,
                                [In] [MarshalAs( UnmanagedType.U4 )] int grfMode,
                                [In] [MarshalAs( UnmanagedType.U4 )] int reserved1,
                                [In] [MarshalAs( UnmanagedType.U4 )] int reserved2 );


        /// <summary>
        /// The OpenStorage method opens an existing storage object with the specified name
        /// in the specified access mode.
        /// 
        /// HRESULT OpenStorage(
        ///   const WCHAR* pwcsName,
        ///   IStorage* pstgPriority,
        ///   DWORD grfMode,
        ///   SNB snbExclude,
        ///   DWORD reserved,
        ///   IStorage** ppstg
        /// );
        /// 
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
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/istorage_openstorage.asp
        /// </summary>
        /// <param name="pwcsName">
        /// const WCHAR* pwcsName
        /// [in] A pointer to a wide character null-terminated Unicode string that
        /// contains the name of the storage object to open. The 000 through 01f characters,
        /// serving as the first character of the stream/storage name, are reserved for
        /// use by OLE. This is a compound file restriction, not a structured storage
        /// restriction. It is ignored if pstgPriority is non-NULL. 
        /// </param>
        /// <param name="pstgPriority">
        /// IStorage* pstgPriority
        /// [in] Must be NULL. A non-NULL value will return STG_E_INVALIDPARAMETER. 
        /// </param>
        /// <param name="grfMode">
        /// DWORD grfMode
        /// [in] Specifies the access mode to use when opening the storage object. For
        /// descriptions of the possible values, see STGM Constants. Other modes you
        /// choose must at least specify STGM_SHARE_EXCLUSIVE when calling this method. 
        /// </param>
        /// <param name="snbExclude">
        /// SNB snbExclude
        /// [in] Must be NULL. A non-NULL value will return STG_E_INVALIDPARAMETER.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/snb.asp
        /// </param>
        /// <param name="reserved">
        /// DWORD reserved
        /// [in] Reserved for future use; must be zero. 
        /// </param>
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
        [return : MarshalAs( UnmanagedType.Interface )]
        IStorage OpenStorage( [In] [MarshalAs( UnmanagedType.BStr )] string pwcsName, IntPtr pstgPriority,
                              [In] [MarshalAs( UnmanagedType.U4 )] int grfMode, IntPtr snbExclude,
                              [In] [MarshalAs( UnmanagedType.U4 )] int reserved );


        /// <summary>
        /// The CopyTo method copies the entire contents of an open storage object to another storage object.
        /// HRESULT CopyTo(
        /// DWORD ciidExclude,
        /// IID const* rgiidExclude,
        /// SNB snbExclude,
        /// IStorage* pstgDest
        /// );
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
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/istorage_copyto.asp
        /// </summary>
        /// <param name="ciidExclude">DWORD ciidExclude
        /// [in] The number of elements in the array pointed to by rgiidExclude. If rgiidExclude
        /// is NULL, then ciidExclude is ignored.</param>
        /// <param name="pIIDExclude">The p IID exclude.</param>
        /// <param name="snbExclude">SNB snbExclude
        /// [in] A string name block (refer to SNB) that specifies a block of storage or stream
        /// objects that are not to be copied to the destination. These elements are not created
        /// at the destination. If IID_IStorage is in the rgiidExclude array, this parameter is
        /// ignored. This parameter may be NULL.</param>
        /// <param name="stgDest">The STG dest.</param>
        /// <exception cref="Exceptions.StorageAccessDeniedException">
        /// Not enough permissions to create storage object.
        /// </exception>
        /// <exception cref="InsufficientMemoryException">
        /// The storage object was not created due to a lack of memory.
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
        /// <exception cref="Exceptions.TooManyOpenFilesException">
        /// The copy was not completed because there are too many open files.
        /// </exception>
        /// <exception cref="Exceptions.MediumFullException">
        /// The copy was not completed because the storage medium is full.
        /// </exception>
        void CopyTo( int ciidExclude, [In] [MarshalAs( UnmanagedType.LPArray )] Guid[] pIIDExclude, IntPtr snbExclude,
                     [In] [MarshalAs( UnmanagedType.Interface )] IStorage stgDest );


        /// <summary>
        /// The MoveElementTo method copies or moves a substorage or stream from this storage
        /// object to another storage object.
        /// 
        /// HRESULT MoveElementTo(
        ///   const WCHAR* pwcsName,
        ///   IStorage* pstgDest,
        ///   LPWSTR pwcsNewName,
        ///   DWORD grfFlags
        /// );
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
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/istorage_moveelementto.asp
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
        /// TODO: Add Exceptions
        void MoveElementTo( [In] [MarshalAs( UnmanagedType.BStr )] string pwcsName,
                            [In] [MarshalAs( UnmanagedType.Interface )] IStorage pstgDest,
                            [In] [MarshalAs( UnmanagedType.BStr )] string pwcsNewName,
                            [In] [MarshalAs( UnmanagedType.U4 )] int grfFlags );


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
        /// 
        /// HRESULT Commit(
        ///   DWORD grfCommitFlags
        /// );
        /// 
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/istorage_commit.asp
        /// </summary>
        /// <param name="grfCommitFlags">
        /// DWORD grfCommitFlags
        /// [in] Controls how the changes are committed to the storage object. See the
        /// STGC enumeration for a definition of these values. 
        /// </param>
        /// TODO: Add Exceptions
        void Commit( STGC grfCommitFlags );


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
        /// http://msdn.microsoft.com/library/en-us/stg/stg/istorage_revert.asp
        /// </summary>
        /// TODO: Add Exceptions
        void Revert();


        /// <summary>
        /// The EnumElements method retrieves a pointer to an enumerator object that can
        /// be used to enumerate the storage and stream objects contained within this
        /// storage object.
        /// HRESULT EnumElements(
        /// DWORD reserved1,
        /// void* reserved2,
        /// DWORD reserved3,
        /// IEnumSTATSTG** ppenum
        /// );
        /// Remarks
        /// The enumerator object returned by this method implements the IEnumSTATSTG
        /// interface, one of the standard enumerator interfaces that contain the Next,
        /// Reset, Clone, and Skip methods. IEnumSTATSTG enumerates the data stored in
        /// an array of STATSTG structures.
        /// The storage object must be open in read mode to allow the enumeration of its elements.
        /// The order in which the elements are enumerated and whether the enumerator is
        /// a snapshot or always reflects the current state of the storage object, and
        /// depends on the IStorage implementation.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/istorage_enumelements.asp
        /// </summary>
        /// <param name="reserved1">DWORD reserved1
        /// [in] Reserved for future use; must be zero.</param>
        /// <param name="reserved2">void* reserved2
        /// [in] Reserved for future use; must be NULL.</param>
        /// <param name="reserved3">DWORD reserved3
        /// [in] Reserved for future use; must be zero.</param>
        /// <param name="ppenum">Pointer to IEnumSTATSTG* pointer variable that receives the interface pointer to the new enumerator object.</param>
        /// TODO: Add Exceptions
        void EnumElements( [In] [MarshalAs( UnmanagedType.U4 )] int reserved1, IntPtr reserved2,
                           [In] [MarshalAs( UnmanagedType.U4 )] int reserved3,
                           [MarshalAs( UnmanagedType.Interface )] out IEnumSTATSTG ppenum );


        /// <summary>
        /// The DestroyElement method removes the specified storage or stream from this storage object.
        /// 
        /// HRESULT DestroyElement(
        ///   wchar* pwcsName
        /// );
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
        /// 
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/istorage_destroyelement.asp
        /// </summary>
        /// <param name="pwcsName">
        /// wchar* pwcsName
        /// [in] A pointer to a wide character null-terminated Unicode string that contains
        /// the name of the storage or stream to be removed. 
        /// </param>
        /// TODO: Add Exceptions
        void DestroyElement( [In] [MarshalAs( UnmanagedType.BStr )] string pwcsName );


        /// <summary>
        /// The RenameElement method renames the specified substorage or stream in this storage object.
        /// HRESULT RenameElement(
        /// const WCHAR* pwcsOldName,
        /// const WCHAR* pwcsNewName
        /// );
        /// IStorage::RenameElement renames the specified substorage or stream in this storage
        /// object. An element in a storage object cannot be renamed while it is open. The rename
        /// operation is subject to committing the changes if the storage is open in transacted mode.
        /// The IStorage::RenameElement method is not guaranteed to work in low memory with storage
        /// objects open in transacted mode. It may work in direct mode.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/istorage_renameelement.asp
        /// </summary>
        /// <param name="pwcsOldName">Old name of the PWCS.</param>
        /// <param name="pwcsNewName">const WCHAR* pwcsNewName
        /// [in] Pointer to a wide character null-terminated unicode string that contains the new
        /// name for the specified substorage or stream.
        /// Note  The pwcsName, created in CreateStorage or CreateStream must not exceed 31 characters
        /// in length, not including the string terminator.</param>
        /// TODO: Add Exceptions
        void RenameElement( [In] [MarshalAs( UnmanagedType.BStr )] string pwcsOldName,
                            [In] [MarshalAs( UnmanagedType.BStr )] string pwcsNewName );


        /// <summary>
        /// The SetElementTimes method sets the modification, access, and creation times of the
        /// specified storage element, if the underlying file system supports this method.
        /// 
        /// HRESULT SetElementTimes(
        ///   const WCHAR* pwcsName,
        ///   FILETIME const* pctime,
        ///   FILETIME const* patime,
        ///   FILETIME const* pmtime
        /// );
        /// 
        /// Remarks
        /// SetElementTimes sets time statistics for the specified storage element within this
        /// storage object.
        /// Not all file systems support all the time values. This method sets those times that
        /// are supported and ignores the rest. Each time-value parameter can be NULL; indicating
        /// that no modification should occur.
        /// Call the IStorage::Stat method to retrieve these time values.
        /// 
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/istorage_setelementtimes.asp
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
        /// TODO: Add Exceptions
        void SetElementTimes( [In] [MarshalAs( UnmanagedType.BStr )] string pwcsName, [In] FILETIME pctime,
                              [In] FILETIME patime, [In] FILETIME pmtime );


        /// <summary>
        /// The SetClass method assigns the specified class identifier (CLSID) to this storage object.
        /// 
        /// HRESULT SetClass(
        ///   REFCLSID clsid
        /// );
        /// 
        /// Remarks
        /// When first created, a storage object has an associated CLSID of CLSID_NULL.
        /// Call SetClass to assign a CLSID to the storage object.
        /// Call the IStorage::Stat method to retrieve the current CLSID of a storage object.
        /// 
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/istorage_setclass.asp
        /// </summary>
        /// <param name="clsid">
        /// REFCLSID clsid
        /// [in] The CLSID that is to be associated with the storage object. 
        /// </param>
        /// TODO: Add Exceptions
        void SetClass( [In] ref Guid clsid );


        /// <summary>
        /// The SetStateBits method stores up to 32 bits of state information in
        /// this storage object. This method is reserved for future use.
        /// 
        /// HRESULT SetStateBits(
        ///   DWORD grfStateBits,
        ///   DWORD grfMask
        /// );
        /// 
        /// Remarks
        /// The values for the state bits are not currently defined
        /// 
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/istorage_setstatebits.asp
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
        /// TODO: Add Exceptions
        void SetStateBits( int grfStateBits, int grfMask );


        /// <summary>
        /// The Stat method retrieves the STATSTG structure for this open storage object.
        /// 
        /// HRESULT Stat(
        ///   STATSTG* pstatstg,
        ///   DWORD grfStatFlag
        /// );
        /// 
        /// Remarks
        /// IStorage::Stat retrieves the STATSTG structure for the current storage
        /// object. The STATSTG structure contains statistical information about the
        /// storage object. IStorage::EnumElements returns a pointer to an enumerator
        /// object. The enumerator object returned by this method implements the
        /// IEnumSTATSTG interface, through which the data stored in the array of the
        /// STATSTG structures is enumerated.
        /// 
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/istorage_stat.asp
        /// </summary>
        /// <param name="pStatStg">
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
        /// TODO: Add Exceptions
        void Stat( out STATSTG pStatStg, StatFlag grfStatFlag );
    }
}