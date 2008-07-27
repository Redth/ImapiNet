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
using System.Runtime.Serialization;
using Imapi.Net.Properties;

#endregion

namespace Imapi.Net.Interop.Exceptions
{
    /// <summary>
    /// An error occurred while attempting to access the media inserted into the active disc recorder.
    /// </summary>
    [Serializable]
    public class DiscInfoException : ImapiException
    {
        #region Public Methods and Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscInfoException"/> class.
        /// </summary>
        public DiscInfoException()
            : base( Resources.Error_Msg_IMAPI_E_DISCINFO )
        {
            unchecked
            {
                HResult = (int) ErrorCodes.IMAPI_E_DISCINFO;
            } // End unchecked
        } // End DiscInfoException()


        /// <summary>
        /// Initializes a new instance of the <see cref="DiscInfoException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public DiscInfoException( string message )
            : base( message + Environment.NewLine + Resources.Error_Msg_IMAPI_E_DISCINFO )
        {
            unchecked
            {
                HResult = (int) ErrorCodes.IMAPI_E_DISCINFO;
            } // End unchecked
        } // End DiscInfoException(string message)


        /// <summary>
        /// Initializes a new instance of the <see cref="DiscInfoException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public DiscInfoException( string message, Exception innerException )
            : base( message + Environment.NewLine + Resources.Error_Msg_IMAPI_E_DISCINFO, innerException )
        {
            unchecked
            {
                HResult = (int) ErrorCodes.IMAPI_E_DISCINFO;
            } // End unchecked
        } // End DiscInfoException(string message, Exception innerException)


        /// <summary>
        /// Initializes a new instance of the <see cref="DiscInfoException"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="context">The context.</param>
        protected DiscInfoException( SerializationInfo info, StreamingContext context )
            : base( info, context )
        {
            unchecked
            {
                HResult = (int) ErrorCodes.IMAPI_E_DISCINFO;
            } // End unchecked
        } // End DiscInfoException(SerializationInfo info, StreamingContext context)

        #endregion Public Methods and Constructors
    } // End class DiscInfoException
} // End namespace Imapi.Net.Interop.Exceptions