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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.ComTypes;

#endregion Using Directives

namespace Imapi.Net.Interop.Util
{
    /// <summary>
    /// 
    /// </summary>
    internal static class ComUtilities
    {
        /// <summary>
        /// Returns an equivalent <see cref="System.DateTime"/> of the <see cref="System.Runtime.InteropServices.ComTypes.FILETIME"/> object.
        /// </summary>
        /// <param name="fileTime">The file time.</param>
        /// <returns></returns>
        [SuppressMessage( "Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode" )]
        public static DateTime FiletimeToDateTime( FILETIME fileTime )
        {
            long hFT2 = ( ( (long) fileTime.dwHighDateTime ) << 32 ) + fileTime.dwLowDateTime;
            return DateTime.FromFileTime( hFT2 );
        } // End DateTime FiletimeToDateTime(FILETIME fileTime)


        /// <summary>
        /// Returns an equivalent <see cref="System.Runtime.InteropServices.ComTypes.FILETIME"/> of the <see cref="System.DateTime"/> object.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static FILETIME DateTimeToFiletime( DateTime dateTime )
        {
            FILETIME ft;
            long hFT1 = dateTime.ToFileTime();
            ft.dwLowDateTime = (int) ( ( hFT1 << 32 ) >> 32 );
            ft.dwHighDateTime = (int) ( hFT1 >> 32 );
            return ft;
        } // End FILETIME DateTimeToFiletime(DateTime dateTime)
    } // End class ComUtilities
} // End namespace Imapi.Net.Interop