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
    /// CD Types
    /// </summary>
    public enum MediaType
    {
        // enum MEDIA_TYPES
        // {
        //     MEDIA_CDDA_CDROM	= 1,
        //     MEDIA_CD_ROM_XA	= MEDIA_CDDA_CDROM + 1,
        //     MEDIA_CD_I	= MEDIA_CD_ROM_XA + 1,
        //     MEDIA_CD_EXTRA	= MEDIA_CD_I + 1,
        //     MEDIA_CD_OTHER	= MEDIA_CD_EXTRA + 1,
        //     MEDIA_SPECIAL	= MEDIA_CD_OTHER + 1
        // } ;


        /// <summary>
        /// No Media is inserted.
        /// </summary>
        None = 0,


        /// <summary>
        /// CDDA CDROM media
        /// </summary>
        CddaCDRom = 1,


        /// <summary>
        /// CD ROM XA media
        /// </summary>
        CDRomXA = 2,


        /// <summary>
        /// CD_I media
        /// </summary>
        Cdi = 3,


        /// <summary>
        /// CD Extra media
        /// </summary>
        CDExtra = 4,


        /// <summary>
        /// CD Other media
        /// </summary>
        CDOther = 5,


        /// <summary>
        /// Special media
        /// </summary>
        Special = 6
    } // End enum MediaType
} // End namespace Imapi.Net.Interop.Enumerations