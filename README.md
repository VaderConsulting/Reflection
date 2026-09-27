# Reflection

VB.NET plugin-host sample. Test App lists `*.dll` next to the exe, loads the selected assembly, and invokes `Importer.Name` and `Importer.Data` through reflection. PlugIn defines `IPlugIn` plus a `Base` class; DLL-1 and DLL-2 each return a different Data string. IPlugIn is an empty extra class-library stub. Built as a VS 2008/2010 learning solution.

**Source last updated:** 2010-03-09  
**Language:** VB.NET  
**Target:** .NET 3.5  
**Output:** WinForms exe + plugin class libraries

## Solution structure

| Project | Language | Type | Purpose |
|---------|----------|------|---------|
| `Test App` | VB.NET | WinForms exe (.NET 3.5) | Lists DLLs and invokes Importer methods via reflection |
| `PlugIn` | VB.NET | class library (.NET 3.5) | `IPlugIn` interface and `Base` plugin class |
| `DLL-1` | VB.NET | class library (.NET 3.5) | Sample plugin returning "DLL 1" |
| `DLL-2` | VB.NET | class library (.NET 3.5) | Sample plugin returning "DLL 2" |
| `IPlugIn` | VB.NET | class library (.NET 3.5) | Empty stub (`Class1`) |

## How to open

Open `Reflection.sln` in Visual Studio 2008 or later. Run Test App with the plugin DLLs in the same folder as the exe.

## Requirements

- Visual Studio 2008, .NET Framework 3.5

## Attribution and provenance

Working copy from my Historical Dev folder.

From Dave Robinson's Historical Dev archive (OneDrive folder `Reflection`). Assembly company/copyright fields are the Visual Studio Microsoft 2010 defaults.

## License

MIT License. Copyright (c) 2026 VaderConsulting.
