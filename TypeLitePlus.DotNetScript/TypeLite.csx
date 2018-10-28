#! "netcoreapp2.1"
//INFO: The commented line below is an example of using a NuGet package right in the script.
//#r "nuget: NodaTime, 2.4.0"

//INFO: The commented line below is an example of referencing an assembly from your project. Must be a relative reference.
//#r "bin/Debug/netcoreapp2.1/YourNamespace.YourApp.YourComponent.dll"

using System.IO;
using TypeLitePlus;
//INFO: Don't forget to add your "usings" here.

//INFO: Make the properties nullable if you want to be able to use anonymous signatures.
var ts = TypeScript.Definitions()
    .WithMemberFormatter((identifier) =>
        identifier.Name + "?");

//INFO: It's usually a good idea to explicitly specify your types.
ts.For<SomeObjectHere>();

var output = ts.Generate();
//INFO: Remove the semicolon and uncomment the lines below if you want ES6 compatible concrete classes.
    //.Replace("interface", "export class")
    //.Replace("module", "export namespace");

File.WriteAllText("YOURFILENAME.ts", output);