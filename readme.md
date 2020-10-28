# TypeLite Plus

**Build Status:** [![Build status](https://dev.azure.com/cloudnimble/TypeLitePlus/_apis/build/status/TypeLitePlus-CI)](https://dev.azure.com/cloudnimble/TypeLitePlus/_build/latest?definitionId=-1)

TypeLite Plus is the utility that generates [TypeScript](http://www.typescriptlang.org/) definitions from .NET classes. 

It's especially useful to keep your [TypeScript](http://www.typescriptlang.org/) classes on the client in sync with your POCO classes on the server.

This project is a fork of the [original TypeLITE project](https://bitbucket.org/LukasKabrt/typelite), which is no longer being maintained.

## .NET Standard 2.0 Support

TypeLite Plus has been recompiled for .NET Standard 2.0, so it can be used in all modern .NET app development.

## Installation

TypeLite Plus has 4 NuGet packages. In most cases, you'll just add the `TypeLitePlus` metapackage to your project. That package references the following packages:
- `TypeLitePlus.Core`: the core library that contains all of the generator logic and attributes.
- `TypeLitePlus.T4`: contains the Example T4 template and the Manager.ttinclude file.

If you're building a .NET Core project, you're likely to run into issues where the Visual Studio reflection mechanism is loading .NET 
Framework versions of certain DLLs instead of .NET Core versions. .NET Core does not have a concept of Assembly Binding Redirects, so
there is no solution to the problem under the current Visual Studio architecture. **This renders the T4 system unusable for .NET Core
projects.**

There will be a fix coming in the .NET Core 3.0 timeframe. In the meantime, there's a different solution. DotNet-Script uses the Roslyn scripting APIs to execute
CSX scripts on .NET Core. CSX files even let you pull in NuGet packages as references.

First, you'll need to open a console and type `dotnet tool install -g dotnet-script`. That will install DotNet-Script into the .NET Core toolchain. Then
you can use the following NuGet package:

- `TypeLitePlus.DotNetScript`: contains the Example CSX script.

More instructions TBD.

## Upgrading from TypeLITE



## Usage

Please check [the project webpage](http://type.litesolutions.net/)

## License

The library is distributed under MIT license.

## Showcase - projects using TypeLite Plus
* [MvcControllerToProxyGenerator](https://github.com/squadwuschel/MvcControllerToProxyGenerator)
* [BurnRate](https://burnrate.io)
* [Florida Agency for Health Care Administration](https://ahca.myflorida.com)

## Changelog

### Version 2.1.0       (27 October 2020)
Added:       Support for specifying the module output order using the `.WithModuleSortOrder(namespace, int)` option.
Added:       Support for outputting Enum values as strings using the `.WithEnumMode(TsEnumModes.String)` option.

### Version 2.0.0       (7 October 2018)
Added:       Rewritten for .NET Standard 2.0 support. Now works in any .NET project now.
Added:       DotNet-Script support for executing in .NET Core application (due to differences in reflection contexts between VS and .NET Core).
Added:       Support for outputting types as concrete Classes using the `.WithMode(TsGenerationModes.Classes)` option.
Fixed:       Manager.tt is now powered by a scaled-back version of the TemplateFileManager that ships with EF6. It's lighter and easier to maintain than the previous one.

### Version 1.8.4       (2 March 2017)
Fixed:       #128 nested inner classes has incorrect module name

### Version 1.8.3       (2 March 2017)
Fixed:       Nested IEnumerables caused infinite loop
Fixed:       Use namespace instead of deprecated module keyword

### Version 1.8.2       (13 February 2017)
Fixed:       Do not generate empty modules
Fixed:       Export constants with const keyword

### Version 1.8.1       (7 April 2016)
Added:       Added ForReferencedAssembly extension method

### Version 1.8.0       (3 April 2016)
Fixed:       #118, #113 Issues with Visual Studio 2015 Update 2

Fixed:       Error generating documentation with type params

### Version 1.7.0       (27 March 2016)
Added:       Added alternative generator for KnockoutModels (see https://bitbucket.org/svakinn/typelite/overview)

Fixed:       #82 more deterministic ordering of generated code

Fixed:       #103 types overridden in converter still appear in generated code

Added:       New extension method that register all derived typesTypesDervivedFrom<T>

### Version 1.6.0       (22 January 2016)
Fixed:       #110 interface for classes with a base class

Added:       #109 support for System.Sbyte

### Version 1.5.2       (29 November 2015)
Fixed:       Error generating JsDoc in case of the name of the assembly contains a space

### Version 1.5.1       (17 October 2015)
Fixed:       Problem with the binaries version in 1.5.0

### Version 1.5.0       (17 October 2015)
Added:       Implemented support for interface inheritance. 

Added:       Added support for [TsIgnore] attribute on classes

### Version 1.4.0       (7 August 2015)
Added:       #95, #96 Adds option to generate enums without 'const' modifier. Use TypeScript.AsConstEnums(false) in your TypeLite.tt file.

Fixed:       #94 TsGeneratorOutput isn't treated as flag in AppendEnumDefinition

### Version 1.3.1       (22 July 2015)
Fixed:       #90 export const enum for compatibility with TypeScript 1.5

### Version 1.3.0       (6 July 2015)
Added:       #89 Added support for Windows Phone 8.1 as target platform

Added:       #73 Added support for generating JSDoc comments from XML documentation. Works only in .NET 4, needs XML Doc files. Use .WithJSDoc()

### Version 1.2.0       (1 July 2015)
Added:       #86 Support for classes outside modules. A TS class is generated outside module if the source .NET class isn't in a namespace or if  [TsClass(Module = "")] attribute is used.

Fixed:       #79 ModuleNameForrmater not called in certain cases


### Version 1.1.2.0		(3 August 2015)
Fixed		#85 Unable to reuse enums

Fixed:       #84 Module name formatter doesn't work for nested namespaces

### Version 1.1.1.0		(1 March 2015)
Fixed		#76 Error when renaming modules

### Version 1.1.0.0		(12 February 2015)
Added		Better extensibility of TsGenerator, better extensibility of formatters

### Version 1.0.2.0		(17 November 2014)
Fixed		#47 Fixed problem with derived generics

### Version 1.0.1.0		(17 November 2014)
Fixed		#64 Incorrect definition for KeyValuePair<int, List<string>>

Fixed		#65 Generic property referencing containing type causes StackOverflowException

Added		#49 Better output formating

### Version 1.0.0.0		(29 October 2014)
Fixed		#57 Support for generics

### Version 0.9.6.0		(20 October 2014)
Fixed		#51 Support for multidimensional arrays

### Version 0.9.5.0		(5 September 2014)
Fixed		#52 Support for using [TsEnum] without class

Added		#60 DateTimeOffset generated as Date

Added		#50 Support for generating TypeScript interfaces from .NET interfaces

### Version 0.9.4.1		(3 September 2014)
Fixed		#59 Bug in tt files

### Version 0.9.4.0		(20 August 2014)
Added		#57 Support public fields

### Version 0.9.3.0		(18 June 2014)
Fixed		#48 For<Enum>().ToModule()
Added		#46 Support for inner classes

### Version 0.9.2.0		(1 June 2014)
Fixed		#43 Declare keyword on modules with enums

Fixed		#44 Export keyword on enums

Fixed		#45 Empty modules

Added		#27 Support for standalone enums

### Version 0.9.1.9		(10 June 2014)
Fixed		#33: Enums not created when using list

Fixed		#41: Combination of generics <T> and Enum throws an exception

Fixed		#42: Duplicate TS interfaces for generic parameters

### Version 0.9.1.8		(8 June 2014)
Added		Strong assembly names

### Version 0.9.1.7		(29 May 2014)
Added		#17: Enums should go to .ts files

### Version 0.9.1.6		(17 January 2014)
Added		MemberTypeFormatter

Fixed		#28: Fluent method for adding references

### Version 0.9.1.5		(10 November 2013)
Added		Optional fields

Fixed		#24: Nullable enums

### Version 0.9.1.4		(14 October 2013)
Added		Nuget package TypeLITE.Lib without T4 templates

Fixed		Empty modules when type convertor is used

### Version 0.9.1.3		(10 October  2013)
Fixed		Incorrect output of type convertor if the module is specified

### Version 0.9.1.2		(9 October 2013)
Fixed		#15: Problems with enum underlaying types

Fixed		#18: ModelVisitor visits enums

Added		#7:  Type convertors

Added		#9:  Fluent configuration for classes

### Version 0.9.1.1		(9 August 2013)
Added		#12: Generation of enums

### Version 0.9.1beta      	(9 August 2013)
Fixed		#13: TypeScript 0.9.1 uses boolean keyword instead of bool

### Version 0.9.0beta	(27 June 2013)
Fixed		#11: Typescript 0.9 requires declare keyword in the module definition

Enhancement	#10: Converted project to Portable class library

### Version 0.8.3		(22 April 2013)
Fixed		#4: DateTime type conversion results in invalid type definition

Fixed		#5: Generic classes result in invalid interface definitions

Fixed		#6: Properties with System.Guid type result in invalid typescript code	 

### Version 0.8.2		(8 April 2013)
Fixed		#2: TsIgnore-attribute doesn't work with properties

Added		Support for nullable value types

Added		Support for .NET 4
