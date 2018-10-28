#! "netcoreapp2.1"

//INFO: Make sure you're getting the latest version here, Roslyn doesn't let you specify version ranges.
#r "nuget: TypeLitePlus.Core, 2.0.1-CI-20181028-053456"

//INFO: The commented line below is an example of using a NuGet package right in the script.
//#r "nuget: NodaTime, 2.4.0"

//INFO: The commented line below is an example of referencing an assembly from your project. Must be a relative reference.
//#r "bin/Debug/netcoreapp2.1/YourNamespace.YourApp.YourComponent.dll"

using System.IO;
using TypeLitePlus;
//INFO: Don't forget to add your "usings" here.

//INFO: Make the properties nullable if you want to be able to use anonymous signatures.
var ts = TypeScript.Definitions()
//INFO: Uncomment the line below if you'd like to generate exported classes instead of declared interfaces.
    //.WithMode(TsGenerationModes.Classes)
    .WithMemberFormatter((identifier) =>
        identifier.Name + "?");

//INFO: It's usually a good idea to explicitly specify your types.
ts.For<SomeObjectHere>();

File.WriteAllText("YOURFILENAME.ts", ts.Generate());