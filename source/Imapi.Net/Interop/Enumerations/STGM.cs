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

#endregion

namespace Imapi.Net.Interop.Enumerations
{
    /// <summary>
    /// Storage instantiation modes.
    /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/wceappservices5/html/wce50lrfSTGM127.asp
    /// </summary>
    [Flags]
    public enum STGM : uint
    {
        // Access STGM_READ 0x00000000L 
        //   STGM_WRITE 0x00000001L 
        //   STGM_READWRITE 0x00000002L 
        // Sharing STGM_SHARE_DENY_NONE 0x00000040L 
        //   STGM_SHARE_DENY_READ 0x00000030L 
        //   STGM_SHARE_DENY_WRITE 0x00000020L 
        //   STGM_SHARE_EXCLUSIVE 0x00000010L 
        //   STGM_PRIORITY 0x00040000L 
        // Creation STGM_CREATE 0x00001000L 
        //   STGM_CONVERT 0x00020000L 
        //   STGM_FAILIFTHERE 0x00000000L 
        // Transactioning STGM_DIRECT 0x00000000L 
        //   STGM_TRANSACTED 0x00010000L 
        // Transactioning Performance STGM_NOSCRATCH 0x00100000L 
        //   STGM_NOSNAPSHOT 0x00200000L 
        // Direct SWMR and Simple STGM_SIMPLE 0x08000000L 
        //   STGM_DIRECT_SWMR 0x00400000L 
        // Delete On Release STGM_DELETEONRELEASE 0x04000000L 


        /// <summary>
        /// In direct mode, each change to a storage element is written as it occurs. This is the default. 
        /// </summary>
        STGM_DIRECT = 0x00000000,


        /// <summary>
        /// In transacted mode, changes are buffered and are written only if an explicit commit operationis called. 
        /// To ignore the changes, call the Revert method in the IStream, IStorage, or IPropertyStorage
        /// interfaces. 
        /// The COM compound file and NSS implementations of IStorage do not support transacted streams,
        /// which means that streams can be opened only in direct mode, and you cannot revert changes to them. 
        /// Transacted storages are, however, supported. 
        /// The compound file, NSS standalone, and NTFS implementations of IPropertySetStorage similarly
        /// do not support transacted, simple mode property sets as these property sets are stored in streams. 
        /// However, non-simple property sets, which can be created by specifying the
        /// PROPSETFLAG_NONSIMPLE flag in the grfFlags parameter of IPropertySetStorage::Create, are supported. 
        /// </summary>
        STGM_TRANSACTED = 0x00010000,


        /// <summary>
        /// STGM_SIMPLE is a mode that provides a much faster implementation of a compound file in a limited,
        /// but frequently used case. It is described in detail in the following Remarks section. 
        /// </summary>
        STGM_SIMPLE = 0x08000000,


        /// <summary>
        /// The STGM_DIRECT_SWMR supports direct mode for single-writer, multi-reader file operations. 
        /// </summary>
        STGM_DIRECT_SWMR = 0x00400000,


        /// <summary>
        /// For stream objects, STGM_READ allows you to call the ISequentialStream::Read method. For storage
        /// objects, you can enumerate the storage elements and open them for reading. 
        /// </summary>
        STGM_READ = 0x00000000,


        /// <summary>
        /// STGM_WRITE lets you save changes to the object. 
        /// </summary>
        STGM_WRITE = 0x00000001,


        /// <summary>
        /// STGM_READWRITE is the combination of STGM_READ and STGM_WRITE. 
        /// </summary>
        STGM_READWRITE = 0x00000002,


        /// <summary>
        /// Specifies that subsequent openings of the object are not denied read or write access. 
        /// </summary>
        STGM_SHARE_DENY_NONE = 0x00000040,


        /// <summary>
        /// Prevents others from subsequently opening the object in STGM_READ mode. It is typically used on
        /// a root storage object. 
        /// </summary>
        STGM_SHARE_DENY_READ = 0x00000030,


        /// <summary>
        /// Prevents others from subsequently opening the object in STGM_WRITE mode. This value is typically
        /// used to prevent unnecessary copies made of an object opened by multiple users. 
        /// If this value is not specified, a snapshot is made, independent of whether there are subsequent
        /// opens or not. Thus, you can improve performance by specifying this value. 
        /// </summary>
        STGM_SHARE_DENY_WRITE = 0x00000020,


        /// <summary>
        /// The combination of STGM_SHARE_DENY_READ and STGM_SHARE_DENY_WRITE. 
        /// </summary>
        STGM_SHARE_EXCLUSIVE = 0x00000010,


        /// <summary>
        /// Opens the storage object with exclusive access to the most recently committed version. Thus,
        /// other users cannot commit changes to the object while you have it open in priority mode. 
        /// You gain performance benefits for copy operations, but you prevent others from committing
        /// changes. So, you should limit the time you keep objects open in priority mode. You must specify
        /// STGM_DIRECT and STGM_READ with priority mode. 
        /// </summary>
        STGM_PRIORITY = 0x00040000,


        /// <summary>
        /// Indicates that the underlying file is to be automatically destroyed when the root storage
        /// object is released. This capability is most useful for creating temporary files. 
        /// </summary>
        STGM_DELETEONRELEASE = 0x04000000,


        /// <summary>
        /// Indicates that an existing storage object or stream should be removed before the new one replaces
        /// it. A new object is created when this flag is specified, only if the existing object has been
        /// successfully removed. 
        /// This flag is used in the following situations: 
        ///   When you are trying to create a storage object on disk but a file of that name already exists. 
        ///   When you are trying to create a stream inside a storage object but a stream with the specified
        ///   name already exists. 
        ///   When you are creating a byte array object but one with the specified name already exists. 
        /// </summary>
        STGM_CREATE = 0x00001000,


        /// <summary>
        /// Creates the new object while preserving existing data in a stream named CONTENTS. In the case of
        /// a storage object or a byte array, the old data is flattened to a stream regardless of whether the
        /// existing file or byte array currently contains a layered storage object. 
        /// </summary>
        STGM_CONVERT = 0x00020000,


        /// <summary>
        /// Causes the create operation to fail if an existing object with the specified name exists. In this
        /// case, STG_E_FILEALREADYEXISTS is returned. STGM_FAILIFTHERE applies to both storage objects and
        /// streams. 
        /// </summary>
        STGM_FAILIFTHERE = 0x00000000,


        /// <summary>
        /// In transacted mode, a scratch file is usually used to save until the commit operation. Specifying
        /// STGM_NOSCRATCH permits the unused portion of the original file to be used as scratch space. This
        /// does not affect the data in the original file, and is a much more efficient use of memory. 
        /// </summary>
        STGM_NOSCRATCH = 0x00100000,


        /// <summary>
        /// This flag is used when opening a storage with STGM_TRANSACTED and without STGM_SHARE_EXCLUSIVE
        /// or STGM_SHARE_DENY_WRITE. 
        /// In this case, specifying STGM_NOSNAPSHOT prevents the system-provided implementation from
        /// creating a snapshot copy of the file. 
        /// Instead, changes to the file are written to the end of the file. Unused space is not reclaimed
        /// unless consolidation is done during the commit, and there is only one current writer on the file. 
        /// When the file is opened in no snapshot mode, another open cannot be done without specifying
        /// STGM_NOSNAPSHOT — in other words, you cannot combine no-snapshot with other modes. 
        /// </summary>
        STGM_NOSNAPSHOT = 0x00200000
    } // End enum STGM
} // End namespace Imapi.Net.Interop.Enumerations