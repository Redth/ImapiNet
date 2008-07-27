#region Using Directives

using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;

#endregion

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

[assembly : AssemblyTitle( "Imapi.NET Test Application" )]
[assembly : AssemblyDescription( "" )]
[assembly : AssemblyConfiguration( "" )]
[assembly : AssemblyCompany( "" )]
[assembly : AssemblyProduct( "Imapi.NET Test Application" )]
[assembly : AssemblyCopyright( "Copyright © 2006" )]
[assembly : AssemblyTrademark( "" )]
[assembly : AssemblyCulture( "" )]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.

[assembly : ComVisible( false )]

// The following GUID is for the ID of the typelib if this project is exposed to COM

[assembly : Guid( "7db97bd7-797d-419d-a433-fbb36e201c46" )]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//

[assembly : AssemblyVersion( "1.0.0.0" )]
[assembly : AssemblyFileVersion( "1.0.0.0" )]

// Request the proper security permissions
//[assembly: PermissionSet(SecurityAction.RequestMinimum, Unrestricted=true)]

[assembly : PermissionSet( SecurityAction.RequestMinimum, Unrestricted = true )]