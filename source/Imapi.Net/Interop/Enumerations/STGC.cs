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
    /// The STGC enumeration constants specify the conditions for
    /// performing the Commit operation in the IStorage::Commit
    /// and IStream::Commit methods.
    /// Remarks
    /// You can specify STGC_DEFAULT or some Combination of
    /// STGC_OVERWRITE, STGC_ONLYIFCURRENT, and
    /// STGC_DANGEROUSLYComMITMERELYTODISKCACHE for normal Commit
    /// operations. You can specify STGC_CONSOLIDATE with any other
    /// STGC flags.
    /// Typically, use STGC_ONLYIFCURRENT to protect the storage
    /// object in cases where more than one user can edit the object
    /// simultaneously.
    /// 
    /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/stg/stg/stgc.asp
    /// </summary>
    [Flags]
    public enum STGC : uint
    {
        /// <summary>
        /// You can specify this condition with STGC_CONSOLIDATE, or some Combination of the other three flags in this list of elements. Use this value to increase the readability of code.
        /// </summary>
        STGC_DEFAULT = 0,


        /// <summary>
        /// The Commit operation can overwrite existing data to reduce
        /// overall space requirements. This value is not reCommended for
        /// typical usage because it is not as robust as the default value.
        /// In this case, it is possible for the Commit operation to fail
        /// after the old data is overwritten, but before the new data is
        /// Completely Committed. Then, neither the old version nor the
        /// new version of the storage object will be intact.
        /// You can use this value in the following cases:
        /// * The user is willing to risk losing the data.
        /// * The low-memory save sequence will be used to safely save the
        ///   storage object to a smaller file.
        /// * A previous Commit returned STG_E_MEDIUMFULL, but overwriting
        ///   the existing data would provide enough space to Commit changes
        ///   to the storage object.
        /// Be aware that the Commit operation verifies that adequate space
        /// exists before any overwriting occurs. Thus, even with this value
        /// specified, if the Commit operation fails due to space requirements,
        /// the old data is safe. It is possible, however, for data loss to
        /// occur with the STGC_OVERWRITE value specified if the Commit
        /// operation fails for any reason other than lack of disk space.
        /// </summary>
        STGC_OVERWRITE = 1,


        /// <summary>
        /// Prevents multiple users of a storage object from overwriting each
        /// other's changes. The Commit operation occurs only if there have
        /// been no changes to the saved storage object because the user most
        /// recently opened it. Thus, the saved version of the storage object
        /// is the same version that the user has been editing. If other users
        /// have changed the storage object, the Commit operation fails and
        /// returns the STG_E_NOTCURRENT value. To override this behavior, call
        /// the IStorage::Commit or IStream::Commit method again using the
        /// STGC_DEFAULT value.
        /// </summary>
        STGC_ONLYIFCURRENT = 2,


        /// <summary>
        /// Commits the changes to a write-behind disk cache, but does not save
        /// the cache to the disk. In a write-behind disk cache, the operation
        /// that writes to disk actually writes to a disk cache, thus increasing
        /// performance. The cache is eventually written to the disk, but usually
        /// not until after the write operation has already returned. The 
        /// performance increase Comes at the expense of an increased risk of
        /// losing data if a problem occurs before the cache is saved and the
        /// data in the cache is lost.
        /// If you do not specify this value, then Committing changes to root-level
        /// storage objects is robust even if a disk cache is used. The two-phase
        /// Commit process ensures that data is stored on the disk and not just to
        /// the disk cache.
        /// </summary>
        STGC_DANGEROUSLYCOMMITMERELYTODISKCACHE = 4,


        /// <summary>
        /// Windows 2000 and Windows XP: Indicates that a storage should be
        /// consolidated after it is Committed, resulting in a smaller file on disk.
        /// This flag is valid only on the outermost storage object that has been
        /// opened in transacted mode. It is not valid for streams. The
        /// STGC_CONSOLIDATE flag can be Combined with any other STGC flags.
        /// </summary>
        STGC_CONSOLIDATE = 8
    } // End enum STGC
} // End namespace Imapi.Net.Interop.Enumerations