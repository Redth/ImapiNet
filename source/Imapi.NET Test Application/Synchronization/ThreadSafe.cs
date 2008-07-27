#region License

//
// Author: Ian Davis <ian.f.davis@gmail.com>
// Copyright (c) 2005-2008, Ian Davis.
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
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

#endregion

namespace Imapi.Net.Test.Synchronization
{
    public static class ThreadSafe
    {
        /// <summary>
        /// Wraps an event handler to make it threadsafe for the current control.
        /// The control using this code should pass a (this) pointer into the first
        /// parameter. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control">The target control on whose thread we will call on.</param>
        /// <param name="eventHandler">The event handler to call on the control's thread.</param>
        /// <returns></returns>
        public static EventHandler<T> EventHandler<T>( Control control, EventHandler<T> eventHandler )
            where T : EventArgs
        {
            return delegate( object sender, T eventArgs )
                   {
                       if ( control.InvokeRequired )
                       {
                           try
                           {
                               control.Invoke( eventHandler, sender, eventArgs );
                           }
                           catch ( Exception ex )
                           {
                               Console.WriteLine( ex.Message + Environment.NewLine + ex.StackTrace );
                           }
                       }
                       else
                       {
                           eventHandler( sender, eventArgs );
                       }
                   };
        }

        /// <summary>
        /// Events the handler.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="eventHandler">The event handler.</param>
        /// <returns></returns>
        public static EventHandler EventHandler( Control control, EventHandler eventHandler )
        {
            return delegate( object sender, EventArgs eventArgs )
                   {
                       if ( control.InvokeRequired )
                       {
                           control.Invoke( eventHandler, sender, eventArgs );
                       }
                       else
                       {
                           eventHandler( sender, eventArgs );
                       }
                   };
        }

        /// <summary>
        /// Invokes the specified context.
        /// All System.Windows.Forms.Control derived classes implement this interface.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="methodInvoker">The method.</param>
        public static void Invoke( ISynchronizeInvoke context, MethodInvoker methodInvoker )
        {
            if ( context.InvokeRequired )
            {
                context.Invoke( methodInvoker, null );
            }
            else
            {
                methodInvoker();
            }
        }

        /// <summary>
        /// Invokes the specified synchronization context.
        /// </summary>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="methodInvoker">The method invoker.</param>
        public static void Invoke( SynchronizationContext synchronizationContext, MethodInvoker methodInvoker )
        {
            synchronizationContext.Post( delegate
                                         {
                                             methodInvoker();
                                         }, null );
        }
    }
}