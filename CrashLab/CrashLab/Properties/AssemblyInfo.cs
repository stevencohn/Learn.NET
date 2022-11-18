//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Diagnostics;

[assembly: AssemblyTitle("TestDummy")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("TestDummy")]
[assembly: AssemblyCopyright("Copyright ©  2013")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyDelaySign(false)]

// Relax the C# compiler to prevent string-literal interning
[assembly: CompilationRelaxations(8)]

// Wrap exceptions that do not derive from Exception with a RuntimeWrappedException object
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]

[assembly: Debuggable(
	// Disable optimizations performed by the compiler to make your output file smaller, faster,
	// and more efficient. Optimizations result in code rearrangement in the output file, which
	// can make debugging difficult. Typically optimization should be disabled while debugging
	DebuggableAttribute.DebuggingModes.DisableOptimizations |
	// Enable edit and continue. Edit and continue enables you to make changes to your source code
	// while your program is in break mode. The ability to edit and continue is compiler dependent
	DebuggableAttribute.DebuggingModes.EnableEditAndContinue |
	// Use the implicit MSIL sequence points, not the program database (PDB) sequence points. The
	// symbolic information normally includes at least one Microsoft intermediate language (MSIL)
	// offset for each source line. When the just-in-time (JIT) compiler is about to compile a
	// method, it asks the profiling services for a list of MSIL offsets that should be preserved.
	// These MSIL offsets are called sequence points.
	DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints |
	// Instructs the just-in-time (JIT) compiler to use its default behavior, which includes
	// enabling optimizations, disabling Edit and Continue support, and using symbol store
	// sequence points if present. In the .NET Framework version 2.0, JIT tracking information,
	// the Microsoft intermediate language (MSIL) offset to the native-code offset within a method,
	// is always generated
	DebuggableAttribute.DebuggingModes.Default)]
