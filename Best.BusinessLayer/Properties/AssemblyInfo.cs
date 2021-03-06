﻿using Best.Core.Aspects.Postsharp.ExceptionAspects;
using Best.Core.Aspects.Postsharp.LogAspects;
using Best.Core.Aspects.Postsharp.PerformanceAspects;
using Best.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Best.BusinessLayer")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Best.BusinessLayer")]
[assembly: AssemblyCopyright("Copyright ©  2019")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: LogAspect(typeof(FileLogger),AttributeTargetTypes = "Best.BusinessLayer.Concrete.Managers.*")]//Tüm metotlarda loglama işlemini yapabiliriz.
[assembly: ExceptionLogAspect(typeof(FileLogger), AttributeTargetTypes = "Best.BusinessLayer.Concrete.Managers.*")]//Tüm metotlarda hata loglama işlemini yapabiliriz.
//[assembly: PerformanceCounterAspect(AttributeTargetTypes = "Best.BusinessLayer.Concrete.Managers.*")]//Tüm metotlarda performans ölçümünü yapabiliriz.

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("1591b672-f907-4c37-8284-97f829acae56")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
