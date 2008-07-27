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
    /// The call failed because when the active recorder was selected, a previous
    /// IMAPI disc was detected and a multi-session session was established.
    /// RecordDisc has detected that this disc is no longer in the active recorder.
    /// </summary>
    [Serializable]
    public class WrongDiscException : ImapiException
    {
        #region Public Methods and Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WrongDiscException"/> class.
        /// </summary>
        public WrongDiscException()
            : base( Resources.Error_Msg_IMAPI_E_WRONGDISC )
        {
            unchecked
            {
                HResult = (int) ErrorCodes.IMAPI_E_WRONGDISC;
            } // End unchecked
        } // End WrongDiscException()


        /// <summary>
        /// Initializes a new instance of the <see cref="WrongDiscException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public WrongDiscException( string message )
            : base( message + Environment.NewLine + Resources.Error_Msg_IMAPI_E_WRONGDISC )
        {
            unchecked
            {
                HResult = (int) ErrorCodes.IMAPI_E_WRONGDISC;
            } // End unchecked
        } // End WrongDiscException(string message)


        /// <summary>
        /// Initializes a new instance of the <see cref="WrongDiscException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public WrongDiscException( string message, Exception innerException )
            : base( message + Environment.NewLine + Resources.Error_Msg_IMAPI_E_WRONGDISC, innerException )
        {
            unchecked
            {
                HResult = (int) ErrorCodes.IMAPI_E_WRONGDISC;
            } // End unchecked
        } // End WrongDiscException(string message, Exception innerException)


        /// <summary>
        /// Initializes a new instance of the <see cref="WrongDiscException"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="context">The context.</param>
        protected WrongDiscException( SerializationInfo info, StreamingContext context )
            : base( info, context )
        {
            unchecked
            {
                HResult = (int) ErrorCodes.IMAPI_E_WRONGDISC;
            } // End unchecked
        } // End WrongDiscException(SerializationInfo info, StreamingContext context)

        #endregion Public Methods and Constructors
    } // End class WrongDiscException
} // End namespace Imapi.Net.Interop.Exceptions