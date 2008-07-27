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

using System.Runtime.InteropServices;
using Imapi.Net.Interop.Exceptions;

#endregion Using Directives

namespace Imapi.Net.Interop.Interfaces
{
    /// <summary>
    /// The IJolietDiscMaster interface enables the staging
    /// of a CD data disc. It represents one of the formats
    /// supported by MSDiscMasterObj, and it allows the creation
    /// of a single Track-at-Once data disc. The data is written
    /// to the disc with the Joliet and ISO-9660 file systems.
    /// A temporary folder is constructed and added to the image.
    /// This can be repeated multiple times with the directory and
    /// file structures overlapping. The overlapping file structures
    /// appear seamlessly when read back. When the overwrite option is
    /// used, overlapping paths cause the last file added to show up
    /// in the directory, while the earlier files with conflicting
    /// names are still present on the disc but now not readable by
    /// normal means.
    /// 
    /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/ijolietdiscmaster.asp
    /// </summary>
    [ComImport]
    [Guid( "E3BC42CE-4E5C-11D3-9144-00104BA11C5E" )]
    [InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
    public interface IJolietDiscMaster
    {
        //    MIDL_INTERFACE("E3BC42CE-4E5C-11D3-9144-00104BA11C5E")
        //    IJolietDiscMaster : public IUnknown
        //    {
        //    public:
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetTotalDataBlocks( 
        //            /* [retval][out] */ long *pnBlocks) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetUsedDataBlocks( 
        //            /* [retval][out] */ long *pnBlocks) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetDataBlockSize( 
        //            /* [retval][out] */ long *pnBlockBytes) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE AddData( 
        //            /* [in] */ IStorage *pStorage,
        //            long lFileOverwrite) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetJolietProperties( 
        //            /* [out] */ IPropertyStorage **ppPropStg) = 0;
        //        
        //        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetJolietProperties( 
        //            /* [in] */ IPropertyStorage *pPropStg) = 0;        
        //    };


        /// <summary>
        /// Returns the total number of blocks available for staging a Joliet
        /// data disc.
        /// The data returned from this method is valid only after a
        /// SetActiveDiscRecorder
        /// call, especially in a multi-session burn.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/ijolietdiscmaster_gettotaldatablocks.asp
        /// </summary>
        /// <param name="pnBlocks">
        /// long* pnBlocks
        /// [out] Total number of data blocks available on a disc.
        /// </param>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        void GetTotalDataBlocks( out int pnBlocks );


        /// <summary>
        /// Returns the total number of data blocks that are in use. The data returned
        /// from this method is valid only after a SetActiveDiscRecorder call, especially
        /// in a multi-session burn.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/ijolietdiscmaster_getuseddatablocks.asp
        /// </summary>
        /// <param name="pnBlocks">
        /// long* pnBlocks
        /// [out] Total number of data blocks in use in the staged image.
        /// </param>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        void GetUsedDataBlocks( out int pnBlocks );


        /// <summary>
        /// Returns the size of a data block.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/ijolietdiscmaster_getdatablocksize.asp
        /// </summary>
        /// <param name="pnBlockBytes">
        /// long* pnBlockBytes
        /// [out] Total size of a single data block, in bytes.
        /// </param>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        void GetDataBlockSize( out int pnBlockBytes );


        /// <summary>
        /// Adds the contents of a root storage to the staged image file. This storage
        /// will be enumerated to place all substorages and streams in the root file
        /// system of the stage image file. Substorages become folders and streams become
        /// files. Multiple calls to this method can be repeated to slowly stage an image
        /// file without wasting undue amounts of hard drive space building up a storage
        /// file.
        /// When you repeat an AddData operation, folders with duplicate files cause a test
        /// of lFileOverwrite. If the flag is nonzero, the file is overwritten. Earlier
        /// files with conflicting names are still written to disc from the image file.
        /// If lFileOverwrite is zero and a file with the same name exists, AddData fails
        /// with IMAPI_E_FILEEXISTS.
        /// While AddData can be called multiple times after calling
        /// IDiscMaster::SetActiveDiscRecorder, SetActiveDiscRecorder must be called any
        /// time a new image is started, and immediately before the first AddData call,
        /// regardless of whether the burner is the same one used in the previous image
        /// creation.
        /// If a call to this method would overrun the number of available data blocks,
        /// the method returns IMAPI_E_DISCFULL and ignores all data that was to be added.
        /// This ensures that the final Joliet file system is not corrupted.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/ijolietdiscmaster_adddata.asp
        /// </summary>
        /// <param name="pStorage">
        /// IStorage* pStorage
        /// [in] Path to the storage whose subitems are to be added to the root of the
        /// staged image file.
        /// </param>
        /// <param name="lFileOverwrite">
        /// long lFileOverwrite
        /// [in] If this parameter is nonzero, overwrite existing files with the same
        /// name. Otherwise, the last file added appears in the directory.
        /// </param>
        /// <exception cref="COMException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="FileExistsException"></exception>
        /// <exception cref="DiscFullException"></exception>
        /// <exception cref="BadJolietNameException"></exception>
        void AddData( IStorage pStorage, int lFileOverwrite );


        /// <summary>
        /// Returns a pointer to an IPropertyStorage interface that contains the Joliet
        /// properties.
        /// Properties are not retained after Imapi is closed. A property set is
        /// convenient for Imapi because it stores an ID/TYPE/VALUE Combination,
        /// as well as ID/NAME associations. Each Combination is a single property,
        /// and Imapi uses these properties as values that are unique to the Joliet
        /// interface. For example, the Joliet interface supports a VolumeName property.
        /// The caller can modify these properties by calling SetJolietProperties.
        /// Current properties include the following.
        /// VolumeName
        ///   The volume name of the disc after recording. Default is the current
        ///   date.
        /// PlaceBootImageOnDisc
        ///   A Boolean value that indicates whether a boot image is to be placed
        ///   on the disc.
        /// BootImageManufacturerIDString
        ///    A BString value (maximum of 24 bytes) that contains identification
        ///    information for the creator of the boot image.
        /// BootImagePlatform
        ///    A byte value that indicates the OS for the boot image. 
        ///    Format: 0 = x86, 1 = PowerPC, 2 = Mac. Other values are undefined.
        /// BootImageEmulationType
        ///    A byte value that indicates the emulation type of the boot image. 
        ///    Format: 0 = no emulation (raw CD blocks); 
        ///    1 = 1.2-MB diskette image; 
        ///    2 = 1.44-inch diskette image; 
        ///    3 = 2.88-MB diskette image; 
        ///    4 = hard disk emulation. 
        ///    For more information on each of these, the user should refer to th
        ///    "El Torito Bootable CD-ROM Format Specification" by Phoenix Technologies.
        /// BootImage
        ///    The IStream object where the Imapi client stores the boot image to
        ///    be burned on the CD.
        /// Note  By setting the four boot image properties, Imapi will create a
        /// bootable disc. No further work, beyond providing the boot image, is
        /// necessary.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/ijolietdiscmaster_getjolietproperties.asp
        /// </summary>
        /// <param name="ppPropStg">
        /// IPropertyStorage** ppPropStg
        /// [out] Address of a pointer to an IPropertyStorage interface for the
        /// Joliet property set with all current properties defined.
        /// </param>
        /// <exception cref="COMException"></exception> 
        /// <exception cref="NoDevicePropertiesException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="NoActiveFormatException"></exception>
        /// <exception cref="WrongFormatException"></exception>
        void GetJolietProperties( out IPropertyStorage ppPropStg );


        /// <summary>
        /// Sets Joliet properties.
        /// Applications should query for a property set using GetJolietProperties,
        /// modify only those settings of interest, and then call SetJolietProperties
        /// to change all values simultaneously.
        /// Some properties are read-only. Both read-only properties and unsupported
        /// properties are ignored without generating an error (see IMAPI_S_PROPERTIESIGNORED).
        /// For example, someone could submit a property set to this interface and
        /// attempt to change the ClearlyNeverHeardOfBefore property. Because
        /// ClearlyNeverHeardOfBefore is an unknown value, the property is ignored
        /// and the method succeeds.
        /// After calling SetJolietProperties, an application should verify property
        /// settings by calling GetJolietProperties.
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/devio/base/ijolietdiscmaster_setjolietproperties.asp
        /// </summary>
        /// <param name="pPropStg">
        /// IPropertyStorage* pPropStg
        /// [in] Pointer to the IPropertyStorage interface that the Joliet interface
        /// can use to retrieve new settings on various properties.
        /// </param>
        /// <exception cref="COMException"></exception> 
        /// <exception cref="NoDevicePropertiesException"></exception>
        /// <exception cref="DiscMasterNotOpenedException"></exception>
        /// <exception cref="NoActiveFormatException"></exception>
        /// <exception cref="WrongFormatException"></exception>
        void SetJolietProperties( [In] IPropertyStorage pPropStg );
    }
}