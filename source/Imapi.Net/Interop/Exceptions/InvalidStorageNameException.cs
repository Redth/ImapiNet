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

#endregion Using Directives

namespace Imapi.Net.Interop.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class InvalidStorageNameException : ImapiException
    {
        #region Public Methods and Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidStorageNameException"/> class.
        /// </summary>
        public InvalidStorageNameException()
            : base( Resources.Error_Msg_STG_E_INVALIDNAME )
        {
            unchecked
            {
                HResult = (int) ErrorCodes.STG_E_INVALIDNAME;
            } // End unchecked
        } // End InvalidStorageNameException()


        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidStorageNameException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public InvalidStorageNameException( string message )
            : base( message + Environment.NewLine + Resources.Error_Msg_STG_E_INVALIDNAME )
        {
            unchecked
            {
                HResult = (int) ErrorCodes.STG_E_INVALIDNAME;
            } // End unchecked
        } // End InvalidStorageNameException(string message)


        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidStorageNameException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public InvalidStorageNameException( string message, Exception innerException )
            : base( message + Environment.NewLine + Resources.Error_Msg_STG_E_INVALIDNAME, innerException )
        {
            unchecked
            {
                HResult = (int) ErrorCodes.STG_E_INVALIDNAME;
            } // End unchecked
        } // End InvalidStorageNameException(string message, Exception innerException)


        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidStorageNameException"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="context">The context.</param>
        protected InvalidStorageNameException( SerializationInfo info, StreamingContext context )
            : base( info, context )
        {
            unchecked
            {
                HResult = (int) ErrorCodes.STG_E_INVALIDNAME;
            } // End unchecked
        } // End InvalidStorageNameException(SerializationInfo info, StreamingContext context)

        #endregion Public Methods and Constructors
    } // End class InvalidStorageNameException
} // End namespace Imapi.Net.Interop.Exceptions