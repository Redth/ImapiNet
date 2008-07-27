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
    /// Recorderstate is used to represent the current status
    /// of a recorder on the current system.
    /// </summary>
    public enum RecorderState
    {
        // #define	RECORDER_DOING_NOTHING	( 0 )
        // #define	RECORDER_OPENED	( 0x1 )
        // #define	RECORDER_BURNING	( 0x2 )

        /// <summary>
        /// The recorder is idle.
        /// </summary>
        DoingNothing = 0x0,


        /// <summary>
        /// CD tray is open.
        /// </summary>
        Opened = 0x1,


        /// <summary>
        /// Recorder is in use and burning.
        /// </summary>
        Burning = 0x2,


        /// <summary>
        /// Error state.
        /// </summary>
        InvalidState = 0x3
    } // End enum RecorderState
} // End namespace Imapi.Net.Interop.Enumerations