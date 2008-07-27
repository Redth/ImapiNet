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

#endregion Using Directives

namespace Imapi.Net.Interop.Enumerations
{
    /// <summary>
    /// An int value that indicates the emulation type of the boot image.
    /// For more information on each of these, refer to the
    /// "El Torito Bootable CD-ROM Format Specification" by Phoenix Technologies.
    /// The latest known link to the specification is http://www.phoenix.com/NR/rdonlyres/98D3219C-9CC9-4DF5-B496-A286D893E36A/0/specscdrom.pdf
    /// and more information can be found at http://en.wikipedia.org/wiki/El_Torito_(CD-ROM_standard)
    /// </summary>
    public enum BootImageEmulationType
    {
        /// <summary>
        /// Use raw CD blocks.
        /// </summary>
        NoEmulation = 0,


        /// <summary>
        /// Emulate a 1.2 MB diskette image.
        /// </summary>
        DisketteImage12MB = 1,


        /// <summary>
        /// Emulate a 1.44 inch diskette image.
        /// </summary>
        DisketteImage144Inch = 2,


        /// <summary>
        /// Emulate a 2.88 MB diskette image.
        /// </summary>
        DisketteImage288MB = 3,


        /// <summary>
        /// Emulate a hard disk.
        /// </summary>
        HardDiskEmulation = 4
    } // End enum BootImageEmulationType
} // End namespace Imapi.Net.Interop.Enumerations