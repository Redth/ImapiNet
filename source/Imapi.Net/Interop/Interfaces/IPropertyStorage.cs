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
using Imapi.Net.Interop.Enumerations;
using Imapi.Net.Interop.Structs;
using FILETIME=System.Runtime.InteropServices.ComTypes.FILETIME;

#endregion Using Directives

namespace Imapi.Net.Interop.Interfaces
{
    /// <summary>
    /// IPropertyStorage
    /// The IPropertyStorage interface manages the persistent properties
    /// of a single property set. Persistent properties consist of
    /// information that can be stored persistently in a property set,
    /// such as the summary information associated with a file. This
    /// contrasts with run-time properties associated with Controls and
    /// Automation, which can be used to affect system behavior. Use the
    /// methods of the IPropertySetStorage interface to create or open a
    /// persistent property set. An instance of the IPropertySetStorage
    /// interface can manage zero or more IPropertyStorage instances.
    /// Each property within a property set is identified by a property
    /// identifier (ID), a four-byte ULONG value unique to that set. You
    /// can also assign a string name to a property through the IPropertyStorage
    /// interface.
    /// Property IDs differ from the dispatch IDs used in Automation dispid
    /// property name tags. One difference is that the general-purpose use
    /// of property ID values zero and one is prohibited in IPropertyStorage,
    /// while no such restriction exists in IDispatch. In addition,
    /// while there is significant overlap among the data types for property
    /// values that may be used in IPropertyStorage and IDispatch, the
    /// property sets are not identical. Persistent property data types used
    /// in IPropertyStorage methods are defined in the PROPVARIANT structure.
    /// The IPropertyStorage interface can be used to access both simple and
    /// nonsimple property sets. Nonsimple property sets can hold several
    /// Complex property types that cannot be held in a simple property set.
    /// For more information see Storage vs. Stream for a Property Set.
    /// When To Implement
    /// Implement IPropertyStorage when you want to store properties in an
    /// object. If you are using the Com Compound files implementation, the
    /// Compound file object created through a call to StgCreateDocfile includes
    /// an implementation of IPropertySetStorage, which allows access to the
    /// implementation of IPropertyStorage. Once you have a pointer to any of
    /// the interface implementations (such as IStorage) on this object, you
    /// can call QueryInterface to get a pointer to the IPropertySetStorage
    /// interface implementation, and then call either the Open or Create
    /// method, as appropriate to obtain a pointer to the IPropertyStorage
    /// interface managing the specified property set.
    /// When To Use
    /// Use IPropertyStorage to create and manage properties that are stored
    /// in a given property set.
    /// 
    /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ipropertystorage.asp
    /// </summary>
    [ComImport]
    [Guid( "00000138-0000-0000-C000-000000000046" )]
    [InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
    public interface IPropertyStorage
    {
        /// <summary>
        /// The ReadMultiple method reads specified properties from the
        /// current property set.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ipropertystorage_readmultiple.asp
        /// </summary>
        /// <param name="cpspec">
        /// ULONG cpspec
        /// [in] The numeric count of properties to be specified in the
        /// rgpspec array. The value of this parameter can be set to zero;
        /// however, that defeats the purpose of the method as no properties
        /// are thereby read, regardless of the values set in rgpspec. 
        /// </param>
        /// <param name="rgpspec">
        /// const PROPSPEC rgpspec[]
        /// [in] An array of PROPSPEC structures specifies which properties
        /// are read. Properties can be specified either by a property ID or
        /// by an optional string name. It is not necessary to specify
        /// properties in any particular order in the array. The array can
        /// contain duplicate properties, resulting in duplicate property
        /// values on return for simple properties. Nonsimple properties
        /// should return access denied on an attempt to open them a second
        /// time. The array can contain a mixture of property IDs and string IDs. 
        /// </param>
        /// <param name="rgpropvar">
        /// PROPVARIANT rgpropvar[1]
        /// [out] Caller-allocated array of a PROPVARIANT structure that, on
        /// return, contains the values of the properties specified by the
        /// corresponding elements in the rgpspec array. The array must be
        /// at least large enough to hold values of the cpspec parameter of
        /// the PROPVARIANT structure. The cpspec parameter specifies the
        /// number of properties set in the array. The caller is not required
        /// to initialize these PROPVARIANT structure values in any specific
        /// order. However, the implementation must fill all members correctly
        /// on return. If there is no other appropriate value, the implementation
        /// must set the vt member of each PROPVARIANT structure to VT_EMPTY. 
        /// </param>
        /// <exception cref="COMException">
        /// S_FALSE: All the property names or IDs had valid syntax, but none of
        /// them exist in this property set. Accordingly, no properties were
        /// retrieved, and each PROPVARIANT structure is set to VT_EMPTY. 
        /// 
        /// HRESULT_FROM_WIN32(ERROR_NOT_SUPPORTED): One of the properties cannot
        /// be read because the property type was not supported by this
        /// IPropertyStorage implementation. 
        /// 
        /// HRESULT_FROM_WIN32(ERROR_NO_UNICODE_TRANSLATION): There was a failed
        /// attempt to translate a Unicode string to or from ANSI
        /// </exception>
        /// <exception cref="Exceptions.StorageAccessDeniedException">
        /// The requested access to the property set has been denied, or, when one
        /// or more of the properties is a stream or storage object, access to that
        /// substorage or substream has been denied. The storage or stream may
        /// already be open. No properties were retrieved. 
        /// </exception>
        /// <exception cref="InsufficientMemoryException">
        /// Insufficient memory exists to perform this operation. No properties were
        /// retrieved. For computers running on Windows NT 4.0 and earlier, the size
        /// limit is 256 KB. For computers running on Windows 2000, Windows XP, and
        /// Windows Server 2003, the limit is 1 MB for OLE property sets. 
        /// </exception>
        /// <exception cref="Exceptions.InvalidParameterException">
        /// At least one of the parameters is invalid; for example, when one of the PROPSPEC structures contains an illegal value of the ulKind member. If the ulKind member is set to a string name instead of a property set value, some properties may not be retrieved. 
        /// </exception>
        /// <exception cref="Exceptions.InvalidPointerException">
        /// At least one of the pointers passed is invalid. No properties were retrieved. 
        /// </exception>
        void ReadMultiple( int cpspec, ref PropSpec rgpspec, [MarshalAs( UnmanagedType.Struct )] out object rgpropvar );

        /// <summary>
        /// The WriteMultiple method writes a specified group of properties to
        /// the current property set. If a property with a specified name or
        /// property identifier already exists, it is replaced, even when the
        /// old and new types for the property value are different. If a
        /// property of a given name or property ID does not exist, it is created.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ipropertystorage_writemultiple.asp
        /// </summary>
        /// <param name="cpspec">
        /// ULONG cpspec
        /// [in] The number of properties set. The value of this parameter can be
        /// set to zero; however, this defeats the purpose of the method as no
        /// properties are then written. 
        /// </param>
        /// <param name="rgpspec">
        /// const PROPSPEC rgpspec[]
        /// [in] An array of the property IDs (PROPSPEC) to which properties are
        /// set. These need not be in any particular order, and may contain
        /// duplicates, however the last specified property ID is the one that
        /// takes effect. A mixture of property IDs and string names is permitted. 
        /// </param>
        /// <param name="rgpropvar">
        /// const PROPVARIANT rgpropvar[]
        /// [in] An array (of size cpspec) of PROPVARIANT structures that contain the property values to be written.
        /// The array must be the size specified by cpspec.
        /// </param>
        /// <param name="propidNameFirst">
        /// PROPID propidNameFirst
        /// [in] The minimum value for the property IDs that the method must assign if the rgpspec parameter
        /// specifies string-named properties for which no property IDs currently exist. If all string-named
        /// properties specified already exist in this set, and thus already have property IDs, this value is
        /// ignored. When not ignored, this value must be greater than, or equal to, two and less than 0x80000000.
        /// Property IDs 0 and 1 and greater than 0x80000000 are reserved for special use.
        /// </param>
        /// <exception cref="COMException">
        /// HRESULT_FROM_WIN32(ERROR_NOT_SUPPORTED): One of the properties cannot
        /// be read because the property type was not supported by this
        /// IPropertyStorage implementation. 
        /// 
        /// HRESULT_FROM_WIN32(ERROR_NO_UNICODE_TRANSLATION): There was a failed
        /// attempt to translate a Unicode string to or from ANSI
        /// </exception>
        /// <exception cref="Exceptions.StorageAccessDeniedException">
        /// The requested access to the property set has been denied, or, when one
        /// or more of the properties is a stream or storage object, access to that
        /// substorage or substream has been denied. The storage or stream may
        /// already be open. No properties were retrieved. 
        /// </exception>
        /// <exception cref="InsufficientMemoryException">
        /// Insufficient memory exists to perform this operation. No properties were
        /// retrieved. For computers running on Windows NT 4.0 and earlier, the size
        /// limit is 256 KB. For computers running on Windows 2000, Windows XP, and
        /// Windows Server 2003, the limit is 1 MB for OLE property sets. 
        /// </exception>
        /// <exception cref="Exceptions.InvalidParameterException">
        /// At least one of the parameters is invalid; for example, when one of the
        /// PROPSPEC structures contains an illegal value of the ulKind member. If the
        /// ulKind member is set to a string name instead of a property set value, some
        /// properties may not be retrieved. 
        /// </exception>
        /// <exception cref="Exceptions.InvalidPointerException">
        /// At least one of the pointers passed is invalid. No properties were retrieved. 
        /// </exception>
        /// <exception cref="Exceptions.WriteFaultException">
        /// An error occurred when writing the storage.
        /// </exception>
        /// <exception cref="Exceptions.StorageRevertedException">
        /// The property set was reverted. For example, if the property set is deleted
        /// while open, by using IPropertySetStorage::Delete, this status would be returned. 
        /// </exception>
        /// <exception cref="Exceptions.MediumFullException">
        /// The disk is full or the property-set size limit of 256 KB has been exceeded.
        /// Some properties may or may not have been written. For more information, see
        /// the Remarks section. 
        /// </exception>
        /// <exception cref="Exceptions.PropertySetMismatchException">
        /// An attempt was made to write a nonsimple (stream- or storage-valued) property
        /// to a simple property set. 
        /// </exception>
        void WriteMultiple( uint cpspec, ref PropSpec rgpspec, [MarshalAs( UnmanagedType.Struct )] ref object rgpropvar,
                            uint propidNameFirst );

        /// <summary>
        /// The DeleteMultiple method deletes as many of the indicated properties as exist in this property set.
        /// 
        /// HRESULT DeleteMultiple(
        ///   ULONG cpspec,
        ///   const PROPSPEC rgpspec[]
        /// );
        /// 
        /// Remarks
        /// IPropertyStorage::DeleteMultiple must delete as many of the indicated properties as are in
        /// the current property set. If a deletion of a stream- or storage-valued property occurs
        /// while that property is open, the deletion will succeed and place the previously returned
        /// IStream or IStorage pointer in the reverted state.
        /// 
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ipropertystorage_deletemultiple.asp
        /// </summary>
        /// <param name="cpspec">
        /// ULONG cpspec 
        /// [in] The numerical count of properties to be deleted. The value of this parameter can
        /// legally be set to zero, however that defeats the purpose of the method as no properties
        /// are thereby deleted, regardless of the value set in rgpspec. 
        /// </param>
        /// <param name="rgpspec">
        /// const PROPSPEC rgpspec[]
        /// [in] Properties to be deleted. A mixture of property identifiers and string-named
        /// properties is permitted. There may be duplicates, and there is no requirement that
        /// properties be specified in any order. 
        /// </param>
        /// <exception cref="Exceptions.StorageAccessDeniedException">
        /// The requested access to the property set has been denied, or, when one
        /// or more of the properties is a stream or storage object, access to that
        /// substorage or substream has been denied. The storage or stream may
        /// already be open. No properties were retrieved. 
        /// </exception>
        /// <exception cref="InsufficientMemoryException">
        /// Insufficient memory exists to perform this operation. No properties were
        /// retrieved. For computers running on Windows NT 4.0 and earlier, the size
        /// limit is 256 KB. For computers running on Windows 2000, Windows XP, and
        /// Windows Server 2003, the limit is 1 MB for OLE property sets. 
        /// </exception>
        /// <exception cref="Exceptions.InvalidParameterException">
        /// At least one of the parameters is invalid; for example, when one of the
        /// PROPSPEC structures contains an illegal value of the ulKind member. If the
        /// ulKind member is set to a string name instead of a property set value, some
        /// properties may not be retrieved. 
        /// </exception>
        /// <exception cref="Exceptions.InvalidPointerException">
        /// At least one of the pointers passed is invalid. No properties were retrieved. 
        /// </exception>
        void DeleteMultiple( uint cpspec, ref PropSpec rgpspec );


        /// <summary>
        /// The ReadPropertyNames method retrieves any existing string names for the specified property IDs.
        /// 
        /// HRESULT ReadPropertyNames(
        ///   ULONG cpropid,
        ///   const PROPID rgpropid[],
        ///   LPWSTR rglpwstrName[]
        /// );
        /// 
        /// Remarks
        /// For each property ID in the list of property IDs supplied in the rgpropid array, ReadPropertyNames retrieves the corresponding string name, if there is one. String names are created either by specifying the names in calls to IPropertyStorage::WriteMultiple when creating the property, or through a call to IPropertyStorage::WritePropertyNames. In either case, the string name is optional, however all properties must have a property ID.
        /// String names mapped to property IDs must be unique within the set.
        /// 
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ipropertystorage_readpropertynames.asp
        /// </summary>
        /// <param name="cpropid">
        /// ULONG cpropid
        /// [in] The number of elements on input of the array rgpropid. The value of this
        /// parameter can be set to zero, however that defeats the purpose of this method
        /// as no property names are thereby read. 
        /// </param>
        /// <param name="rgpropid">
        /// const PROPID rgpropid[]
        /// [in] An array of property IDs for which names are to be retrieved. 
        /// </param>
        /// <param name="rglpwstrName">
        /// LPWSTR rglpwstrName[] 
        /// [in, out] A caller-allocated array of size cpropid of LPWSTR members. On return,
        /// the implementation fills in this array. A given entry contains either the
        /// corresponding string name of a property ID or it can be empty if the property
        /// ID has no string names.
        /// Each LPWSTR member of the array should be freed using the CoTaskMemFree function. 
        /// </param>
        /// <exception cref="COMException">
        /// S_FALSE: No string names were retrieved because none of the requested property
        /// identifiers have string names presently associated with them in this property
        /// storage object; this result does not address whether the given property
        /// identifiers presently exist in the set. 
        /// 
        /// HRESULT_FROM_WIN32(ERROR_NO_UNICODE_TRANSLATION): There was a failed
        /// attempt to translate a Unicode string to or from ANSI
        /// </exception>
        /// <exception cref="Exceptions.StorageAccessDeniedException">
        /// The requested access to the property set has been denied, or, when one
        /// or more of the properties is a stream or storage object, access to that
        /// substorage or substream has been denied. The storage or stream may
        /// already be open. No properties were retrieved. 
        /// </exception>
        /// <exception cref="InsufficientMemoryException">
        /// Insufficient memory exists to perform this operation. No properties were
        /// retrieved. For computers running on Windows NT 4.0 and earlier, the size
        /// limit is 256 KB. For computers running on Windows 2000, Windows XP, and
        /// Windows Server 2003, the limit is 1 MB for OLE property sets. 
        /// </exception>
        /// <exception cref="Exceptions.InvalidParameterException">
        /// At least one of the parameters is invalid; for example, when one of the PROPSPEC structures contains an illegal value of the ulKind member. If the ulKind member is set to a string name instead of a property set value, some properties may not be retrieved. 
        /// </exception>
        /// <exception cref="Exceptions.InvalidHeaderException"></exception>
        /// <exception cref="Exceptions.ReadFaultException"></exception>
        void ReadPropertyNames( uint cpropid, [In] ref uint rgpropid,
                                [Out] [MarshalAs( UnmanagedType.LPWStr )] out string rglpwstrName );


        /// <summary>
        /// The WritePropertyNames method assigns string names to a specified array of property IDs in the current property set.
        /// 
        /// HRESULT WritePropertyNames(
        ///   ULONG cpropid,
        ///   const PROPID rgpropid[],
        ///   LPWSTR const rglpwstrName[]
        /// );
        /// 
        /// Remarks
        /// For more information about property sets and memory management, see
        /// Managing Property Sets.
        /// IPropertyStorage::WritePropertyNames assigns string names to property IDs
        /// passed to the method in the rgpropid array. It associates each string name
        /// in the rglpwstrName array with the respective property ID in rgpropid. It
        /// is explicitly valid to define a name for a property ID that is not currently
        /// present in the property storage object.
        /// It is also valid to change the mapping for an existing string name (determined
        /// by a case-insensitive match). That is, you can use the WritePropertyNames method
        /// to map an existing name to a new property ID, or to map a new name to a property
        /// ID that already has a name in the dictionary. In either case, the original
        /// mapping is deleted. Property names must be unique (as are property IDs) within
        /// the property set.
        /// The storage of string property names preserves the case. Unless
        /// PROPSETFLAG_CASE_SENSITIVE is passed to IPropertySetStorage::Create, property set
        /// names are case insensitive by default. With case-insensitive property sets, the
        /// name strings passed by the caller are interpreted according to the locale of the
        /// property set, as specified by the PID_LOCALE property. If the property set has
        /// no locale property, the current user is assumed by default. String property names
        /// are limited in length to 128 characters. Property names that begin with the
        /// binary Unicode characters 0x0001 through 0x001F are reserved for future use.
        /// If the value of an element in the rgpropid array parameter is set to 0xffffffff 
        /// PID_ILLEGAL), the corresponding name is ignored by
        /// IPropertyStorage::WritePropertyNames. For example, if this method is called with
        /// a cpropid parameter of 3, but the first element of the array, rgpropid[1], is set
        /// to PID_ILLEGAL, then only two property names are written. The rgpropid[1] element
        /// is ignored.
        /// 
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ipropertystorage_writepropertynames.asp
        /// </summary>
        /// <param name="cpropid">
        /// ULONG cpropid 
        /// [in] The size on input of the array rgpropid. Can be zero. However, making it zero
        /// causes this method to become non-operational. 
        /// </param>
        /// <param name="rgpropid">
        /// const PROPID rgpropid[]
        /// [in] An array of the property IDs for which names are to be set. 
        /// </param>
        /// <param name="rglpwstrName">
        /// LPWSTR const rglpwstrName[]
        /// [in] Array of new names to be assigned to the corresponding property IDs in the
        /// rgpropid array. These names may not exceed 255 characters (not including the NULL
        /// terminator). 
        /// </param>
        /// <exception cref="COMException">
        /// HRESULT_FROM_WIN32(ERROR_NO_UNICODE_TRANSLATION): There was a failed
        /// attempt to translate a Unicode string to or from ANSI
        /// </exception>
        /// <exception cref="Exceptions.StorageAccessDeniedException">
        /// The requested access to the property set has been denied, or, when one
        /// or more of the properties is a stream or storage object, access to that
        /// substorage or substream has been denied. The storage or stream may
        /// already be open. No properties were retrieved. 
        /// </exception>
        /// <exception cref="InsufficientMemoryException">
        /// Insufficient memory exists to perform this operation. No properties were
        /// retrieved. For computers running on Windows NT 4.0 and earlier, the size
        /// limit is 256 KB. For computers running on Windows 2000, Windows XP, and
        /// Windows Server 2003, the limit is 1 MB for OLE property sets. 
        /// </exception>
        /// <exception cref="Exceptions.InvalidParameterException">
        /// At least one of the parameters is invalid; for example, when one of the PROPSPEC structures contains an illegal value of the ulKind member. If the ulKind member is set to a string name instead of a property set value, some properties may not be retrieved. 
        /// </exception>
        /// <exception cref="Exceptions.InvalidStorageNameException"></exception>
        void WritePropertyNames( uint cpropid, ref uint rgpropid,
                                 [In] [MarshalAs( UnmanagedType.LPWStr )] ref string rglpwstrName );


        /// <summary>
        /// The DeletePropertyNames method deletes specified string names from the
        /// current property set.
        /// 
        /// HRESULT DeletePropertyNames(
        ///   ULONG cpropid,
        ///   const PROPID rgpropid[]
        /// );
        /// 
        /// Remarks
        /// For each property identifier in rgpropid, IPropertyStorage::DeletePropertyNames
        /// removes any corresponding name-to-property ID mapping. An attempt is silently
        /// ignored to delete the name of a property that either does not exist or does not
        /// currently have a string name associated with it. This method has no effect on the
        /// properties themselves.
        /// Note  All the stored string property names can be deleted by deleting property
        /// identifier zero, but cpropid must be equal to 1 for this to be a valid parameter
        /// error.
        /// 
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ipropertystorage_deletepropertynames.asp
        /// </summary>
        /// <param name="cpropid">
        /// ULONG cpropid 
        /// [in] The size on input of the array rgpropid. If 0, no property names are deleted. 
        /// </param>
        /// <param name="rgpropid">
        /// const PROPID rgpropid[]
        /// [in] Property identifiers for which string names are to be deleted. 
        /// </param>
        /// <exception cref="Exceptions.StorageAccessDeniedException">
        /// The requested access to the property set has been denied, or, when one
        /// or more of the properties is a stream or storage object, access to that
        /// substorage or substream has been denied. The storage or stream may
        /// already be open. No properties were retrieved. 
        /// </exception>
        /// <exception cref="InsufficientMemoryException">
        /// Insufficient memory exists to perform this operation. No properties were
        /// retrieved. For computers running on Windows NT 4.0 and earlier, the size
        /// limit is 256 KB. For computers running on Windows 2000, Windows XP, and
        /// Windows Server 2003, the limit is 1 MB for OLE property sets. 
        /// </exception>
        /// <exception cref="Exceptions.InvalidParameterException">
        /// At least one of the parameters is invalid; for example, when one of the PROPSPEC structures contains an illegal value of the ulKind member. If the ulKind member is set to a string name instead of a property set value, some properties may not be retrieved. 
        /// </exception>
        void DeletePropertyNames( uint cpropid, [In] ref uint rgpropid );


        /// <summary>
        /// The SetClass method assigns a new CLSID to the current property storage
        /// object, and persistently stores the CLSID with the object.
        /// 
        /// HRESULT SetClass(
        ///   REFCLSID clsid
        /// );
        /// 
        /// Remarks
        /// Assigns a CLSID to the current property storage object. The CLSID has no relationship
        /// to the stored property IDs. Assigning a CLSID allows a piece of code to be associated
        /// with a given instance of a property set; such code, for example, might manage the user 
        /// interface (UI). Different CLSIDs can be associated with different property set instances
        /// that have the same FMTID.
        /// If the property set is created with the pclsid parameter of the IPropertySetStorage::Create
        /// method specified as NULL, the CLSID is set to all zeroes.
        /// The current CLSID on a property storage object can be retrieved with a call to
        /// IPropertyStorage::Stat. The initial value for the CLSID can be specified at the time that
        /// the storage is created with a call to IPropertySetStorage::Create.
        /// Setting the CLSID on a nonsimple property set (one that can legally contain storage- or
        /// stream-valued properties, as described in IPropertySetStorage::Create) also sets the CLSID
        /// on the underlying sub-storage.
        /// 
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ipropertystorage_setclass.asp
        /// </summary>
        /// <param name="clsid">
        /// REFCLSID clsid 
        /// [in] New CLSID to be associated with the property set. 
        /// </param>
        /// <exception cref="Exceptions.StorageAccessDeniedException">
        /// The requested access to the property set has been denied, or, when one
        /// or more of the properties is a stream or storage object, access to that
        /// substorage or substream has been denied. The storage or stream may
        /// already be open. 
        /// </exception>
        /// <exception cref="InsufficientMemoryException">
        /// Insufficient memory exists to perform this operation. No properties were
        /// retrieved. For computers running on Windows NT 4.0 and earlier, the size
        /// limit is 256 KB. For computers running on Windows 2000, Windows XP, and
        /// Windows Server 2003, the limit is 1 MB for OLE property sets. 
        /// </exception>
        /// <exception cref="Exceptions.InvalidParameterException">
        /// At least one of the parameters is invalid; for example, when one of the PROPSPEC structures contains an illegal value of the ulKind member. If the ulKind member is set to a string name instead of a property set value, some properties may not be retrieved. 
        /// </exception>
        void SetClass( ref Guid clsid );


        /// <summary>
        /// /// The IPropertyStorage::Commit method saves changes made to a property
        /// storage object to the parent storage object.
        /// 
        /// HRESULT Commit(
        ///   DWORD grfCommitFlags
        /// );
        /// 
        /// Remarks
        /// Like IStorage::Commit, the IPropertyStorage::Commit method ensures that any
        /// changes made to a property storage object are reflected in the parent storage.
        /// In direct mode in the compound file implementation, a call to this method
        /// causes any changes currently in the memory buffers to be flushed to the
        /// underlying property stream. In the compound-file implementation for nonsimple
        /// property sets, IStorage::Commit is also called on the underlying substorage
        /// object with the passed grfCommitFlags parameter.
        /// In transacted mode, this method causes the changes to be permanently reflected
        /// in the persistent image of the storage object. The changes that are committed
        /// must have been made to this property set since it was opened or since the last
        /// commit on this opening of the property set. The commit method publishes the
        /// changes made on one object level to the next level. Of course, this remains
        /// subject to any outer-level transaction that may be present on the object in
        /// which this property set is contained. Write permission must be specified when
        /// the property set is opened (through IPropertySetStorage) on the property set
        /// opening for the commit operation to succeed.
        /// If the commit operation fails for any reason, the state of the property storage
        /// object remains as it was before the commit.
        /// This call has no effect on existing storage- or stream-valued properties opened
        /// from this property storage, but it does commit them.
        /// 
        /// Valid values for the grfCommitFlags parameter are listed below.
        /// STGC_DEFAULT
        /// * Commits per the usual transaction semantics. Last writer wins. This flag may
        /// not be specified with other flag values. 
        /// STGC_ONLYIFCURRENT
        /// * Commits the changes only if the current persistent contents of the property
        /// set are the ones on which the changes about to be committed are based. That is,
        /// does not commit changes if the contents of the property set have been changed
        /// by a commit from another opening of the property set. The error STG_E_NOTCURRENT
        /// is returned if the commit does not succeed for this reason. 
        /// STGC_OVERWRITE
        /// * Useful only when committing a transaction that has no further outer nesting
        /// level of transactions, though acceptable in all cases. 
        /// 
        /// Note  Indicates that the caller is willing to risk some data corruption at the
        /// expense of decreased disk usage on the destination volume. This flag is
        /// potentially useful in low disk-space scenarios, though it should be used with
        /// caution.
        ///   
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ipropertystorage_commit.asp
        /// </summary>
        /// <param name="grfCommitFlags">
        /// DWORD grfCommitFlags 
        /// [in] The flags that specify the conditions under which the commit is to be
        /// performed. For more information about specific flags and their meanings, see
        /// the Remarks section.
        /// </param>
        /// <exception cref="Exceptions.StorageAccessDeniedException">
        /// The requested access to the property set has been denied, or, when one
        /// or more of the properties is a stream or storage object, access to that
        /// substorage or substream has been denied. The storage or stream may
        /// already be open.
        /// </exception>
        /// <exception cref="InsufficientMemoryException">
        /// Insufficient memory exists to perform this operation. No properties were
        /// retrieved. For computers running on Windows NT 4.0 and earlier, the size
        /// limit is 256 KB. For computers running on Windows 2000, Windows XP, and
        /// Windows Server 2003, the limit is 1 MB for OLE property sets. 
        /// </exception>
        /// <exception cref="Exceptions.InvalidParameterException">
        /// At least one of the parameters is invalid; for example, when one of the PROPSPEC structures contains an illegal value of the ulKind member. If the ulKind member is set to a string name instead of a property set value, some properties may not be retrieved. 
        /// </exception>
        /// <exception cref="Exceptions.StorageNotCurrentException"></exception>
        void Commit( STGC grfCommitFlags );


        /// <summary>
        /// The Revert method discards all changes to the named property set since it was
        /// last opened or discards changes that were last committed to the property set.
        /// This method has no effect on a direct-mode property set.
        /// 
        /// HRESULT Revert();
        /// 
        /// Remarks
        /// For transacted-mode property sets, this method discards all changes that have
        /// been made in this property set since the set was opened or since the time it
        /// was last committed, (whichever is later). After this operation, any existing
        /// storage- or stream-valued properties that have been opened from the property
        /// set being reverted are no longer valid and cannot be used. The error
        /// STG_E_REVERTED will be returned on all calls, except those to Release, using
        /// these streams or storages.
        /// For direct-mode property sets, this request is ignored and returns S_OK.
        /// 
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ipropertystorage_revert.asp
        /// </summary>
        /// <exception cref="Exceptions.UnexpectedErrorException"></exception>
        void Revert();


        /// <summary>
        /// The Enum method creates an enumerator object designed to enumerate data of type
        /// STATPROPSTG, which contains information on the current property set. On return,
        /// this method supplies a pointer to the IEnumSTATPROPSTG pointer on this object.
        /// 
        /// HRESULT Enum(
        ///   IEnumSTATPROPSTG** ppenum
        /// );
        /// 
        /// Remarks
        /// IPropertyStorage::Enum creates an enumeration object that can be used to iterate
        /// STATPROPSTG structures. On return, this method supplies a pointer to an instance
        /// of the IEnumSTATPROPSTG interface on this object, whose methods you can call to
        /// obtain information about the current property set.
        /// 
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ipropertystorage_enum.asp
        /// </summary>
        /// <param name="ppenum">
        /// IEnumSTATPROPSTG** ppenum 
        /// [out] Pointer to IEnumSTATPROPSTG pointer variable that receives the interface
        /// pointer to the new enumerator object. 
        /// </param>
        /// <exception cref="Exceptions.StorageAccessDeniedException">
        /// The requested access to the property set has been denied, or, when one
        /// or more of the properties is a stream or storage object, access to that
        /// substorage or substream has been denied. The storage or stream may
        /// already be open. 
        /// </exception>
        /// <exception cref="InsufficientMemoryException">
        /// There is not enough memory to perform this operation.  
        /// </exception>
        /// <exception cref="Exceptions.InvalidParameterException">
        /// At least one of the parameters is invalid; for example, when one of the PROPSPEC structures contains an illegal value of the ulKind member. If the ulKind member is set to a string name instead of a property set value, some properties may not be retrieved. 
        /// </exception>
        /// <exception cref="Exceptions.ReadFaultException"></exception>
        void Enum( ref IEnumSTATPROPSTG ppenum );


        /// <summary>
        /// The Stat method retrieves information about the current open property set.
        /// 
        /// HRESULT Stat(
        ///   STATPROPSETSTG* pstatpsstg
        /// );
        /// 
        /// Remarks
        /// IPropertyStorage::Stat fills in and returns a pointer to a STATPROPSETSTG
        /// structure, containing statistics about the current property set.
        /// 
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ipropertystorage_stat.asp
        /// </summary>
        /// <param name="pstatpsstg">
        /// STATPROPSETSTG* pstatpsstg 
        /// [out] Pointer to a STATPROPSETSTG structure, which contains statistics about
        /// the current open property set. 
        /// </param>
        /// <exception cref="Exceptions.StorageAccessDeniedException">
        /// The requested access to the property set has been denied, or, when one
        /// or more of the properties is a stream or storage object, access to that
        /// substorage or substream has been denied. The storage or stream may
        /// already be open. 
        /// </exception>
        /// <exception cref="InsufficientMemoryException">
        /// There is not enough memory to perform this operation.  
        /// </exception>
        /// <exception cref="Exceptions.InvalidParameterException">
        /// At least one of the parameters is invalid; for example, when one of the PROPSPEC structures contains an illegal value of the ulKind member. If the ulKind member is set to a string name instead of a property set value, some properties may not be retrieved. 
        /// </exception>
        void Stat( out StatPropSetSTG pstatpsstg );


        /// <summary>
        /// The SetTimes method sets the modification, access, and creation times of this
        /// property set, if supported by the implementation. Not all implementations
        /// support all these time values.
        /// 
        /// HRESULT SetTimes(
        ///   const FILETIME* pctime,
        ///   const FILETIME* patime,
        ///   const FILETIME* pmtime
        /// );
        /// 
        /// Remarks
        /// Sets the modification, access, and creation times of the current open property
        /// set, if supported by the implementation (not all implementations support all
        /// these time values). Unsupported time stamps are always reported as zero, enabling
        /// the caller to test for support. A call to IPropertyStorage::Stat supplies (among
        /// other data) time-stamp information.
        /// Notice that this functionality is provided as an IPropertyStorage method on a
        /// property-storage object that is already open, in contrast to being provided as a
        /// method in IPropertySetStorage. Normally, when the SetTimes method is not explicitly
        /// called, the access and modification times are updated as a side effect of reading
        /// and writing the property set. When SetTimesis used, the latest specified times
        /// supersede either default times or time values specified in previous calls to SetTimes.
        /// 
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/ipropertystorage_settimes.asp
        /// </summary>
        /// <param name="pctime">
        /// const FILETIME* pctime
        /// [in] Pointer to the new creation time for the property set. May be NULL, indicating
        /// that this time is not to be modified by this call. 
        /// </param>
        /// <param name="patime">
        /// const FILETIME* patime
        /// [in] Pointer to the new access time for the property set. May be NULL, indicating
        /// that this time is not to be modified by this call. 
        /// </param>
        /// <param name="pmtime">
        /// const FILETIME* pmtime
        /// [in] Pointer to the new modification time for the property set. May be NULL, indicating
        /// that this time is not to be modified by this call. 
        /// </param>
        /// <exception cref="Exceptions.StorageAccessDeniedException">
        /// The requested access to the property set has been denied, or, when one
        /// or more of the properties is a stream or storage object, access to that
        /// substorage or substream has been denied. The storage or stream may
        /// already be open. 
        /// </exception>
        /// <exception cref="InsufficientMemoryException">
        /// There is not enough memory to perform this operation.  
        /// </exception>
        /// <exception cref="Exceptions.InvalidParameterException">
        /// At least one of the parameters is invalid; for example, when one of the PROPSPEC structures contains an illegal value of the ulKind member. If the ulKind member is set to a string name instead of a property set value, some properties may not be retrieved. 
        /// </exception>
        void SetTimes( ref FILETIME pctime, ref FILETIME patime, ref FILETIME pmtime );
    }
}