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
using System.Threading;
using System.Windows.Forms;

#endregion

namespace Imapi.Net.Test
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.ThreadException += Application_ThreadException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new MainForm() );
        }


        /// <summary>
        /// Handles the ThreadException event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.Threading.ThreadExceptionEventArgs"/> instance containing the event data.</param>
        private static void Application_ThreadException( object sender, ThreadExceptionEventArgs e )
        {
            MessageBox.Show( e.Exception.Message + Environment.NewLine + e.Exception.StackTrace );
        }
    }
}