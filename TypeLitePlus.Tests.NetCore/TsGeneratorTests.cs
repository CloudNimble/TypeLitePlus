using System;
using System.Linq;

using Xunit;
using TypeLitePlus.Tests.NetCore.TestModels;
using System.IO;
using System.Text.RegularExpressions;

namespace TypeLitePlus.Tests.NetCore
{
    public class TsGeneratorTests
    {

        #region Generate tests

        [Fact]
        public void WhenModelContainsReference_ReferenceIsAddedToOutput()
        {
            var model = new TsModel();
            model.References.Add("knockout.d.ts");

            var target = new TsGenerator();
            var script = target.Generate(model);

            Assert.Contains("/// <reference path=\"knockout.d.ts\" />", script);
        }

        [Fact]
        public void WhenClassHasBase_MultipleBasesArentGenerated()
        {
            var builder = new TsModelBuilder();
            builder.Add<Employee>();
            builder.Add<User>();
            var model = builder.Build();

            var target = new TsGenerator();
            var script = target.Generate(model);

            var count = Regex.Matches(script, Regex.Escape("interface Person")).Count;
            Assert.True(count == 1, script);
        }

        [Fact]
        public void WhenModeIsInterfaces_ClassesArentGenerated()
        {
            var builder = new TsModelBuilder();
            builder.Add<Employee>();
            builder.Add<User>();
            var model = builder.Build();

            var target = new TsGenerator();
            var script = target.Generate(model);

            var interfaceCount = Regex.Matches(script, Regex.Escape("interface")).Count;
            Assert.True(interfaceCount > 0, script);

            var namespaceCount = Regex.Matches(script, Regex.Escape("namespace")).Count;
            Assert.True(namespaceCount > 0, script);

            var classCount = Regex.Matches(script, Regex.Escape("class")).Count;
            Assert.True(classCount == 0, script);

            var moduleCount = Regex.Matches(script, Regex.Escape("module")).Count;
            Assert.True(moduleCount == 0, script);
        }

        [Fact]
        public void WhenModeIsClasses_InterfacesArentGenerated()
        {
            var builder = new TsModelBuilder();
            builder.Add<Employee>();
            builder.Add<User>();
            var model = builder.Build();

            var target = new TsGenerator
            {
                Mode = TsGenerationModes.Classes
            };
            var script = target.Generate(model);

            var classCount = Regex.Matches(script, Regex.Escape("class")).Count;
            Assert.True(classCount > 0, script);

            var moduleCount = Regex.Matches(script, Regex.Escape("module")).Count;
            Assert.True(moduleCount > 0, script);

            var interfaceCount = Regex.Matches(script, Regex.Escape("interface")).Count;
            Assert.True(interfaceCount == 0, script);

            var namespaceCount = Regex.Matches(script, Regex.Escape("namespace")).Count;
            Assert.True(namespaceCount == 0, script);
        }

        [Fact]
        public void WhenClassIsIgnored_InterfaceForClassIsntGenerated()
        {
            var builder = new TsModelBuilder();
            builder.Add<Address>();
            var model = builder.Build();
            model.Classes.Where(o => o.Name == "Address").Single().IsIgnored = true;

            var target = new TsGenerator();
            var script = target.Generate(model);

            Assert.DoesNotContain("Address", script);
        }

        [Fact]
        public void WhenClassIsIgnoredByAttribute_InterfaceForClassIsntGenerated()
        {
            var builder = new TsModelBuilder();
            builder.Add<IgnoreTestBase>();
            var model = builder.Build();

            var target = new TsGenerator();
            var script = target.Generate(model);

            Assert.DoesNotContain("IgnoreTestBase", script);
        }

        [Fact]
        public void WhenBaseClassIsIgnoredByAttribute_InterfaceForClassIsntGenerated()
        {
            var builder = new TsModelBuilder();
            builder.Add<IgnoreTest>();
            var model = builder.Build();

            var target = new TsGenerator();
            var script = target.Generate(model);

            Assert.DoesNotContain("interface IgnoreTestBase", script);
        }


        [Fact]
        public void WhenPropertyIsIgnored_PropertyIsExcludedFromInterface()
        {
            var builder = new TsModelBuilder();
            builder.Add<Address>();
            var model = builder.Build();
            model.Classes.Where(o => o.Name == "Address").Single().Properties.Where(p => p.Name == "Street").Single().IsIgnored = true;

            var target = new TsGenerator();
            var script = target.Generate(model);

            Assert.DoesNotContain("Street", script);
        }

        [Fact]
        public void WhenFieldIsIgnored_FieldIsExcludedFromInterface()
        {
            var builder = new TsModelBuilder();
            builder.Add<Address>();
            var model = builder.Build();
            model.Classes.Where(o => o.Name == "Address").Single().Fields.Where(f => f.Name == "PostalCode").Single().IsIgnored = true;

            var target = new TsGenerator();
            var script = target.Generate(model);

            Assert.DoesNotContain("PostalCode", script);
        }

        [Fact]
        public void WhenClassIsReferenced_FullyQualifiedNameIsUsed()
        {
            var builder = new TsModelBuilder();
            builder.Add<Person>();
            var model = builder.Build();
            var target = new TsGenerator();
            var script = target.Generate(model);

            Assert.Contains("PrimaryAddress: TypeLitePlus.Tests.NetCore.TestModels.Address", script);
            Assert.Contains("Addresses: TypeLitePlus.Tests.NetCore.TestModels.Address[]", script);
        }

        [Fact]
        public void WhenClassIsReferencedAndOutputIsSetToEnums_ClassIsntInOutput()
        {
            var builder = new TsModelBuilder();
            builder.Add<Item>();
            var model = builder.Build();
            var target = new TsGenerator();
            var script = target.Generate(model, TsGeneratorOutput.Enums);

            Assert.DoesNotContain("interface Item", script);
        }

        [Fact]
        public void WhenClassIsReferencedAndOutputIsSetToEnums_ConstantIsntInOutput()
        {
            var builder = new TsModelBuilder();
            builder.Add<Item>();
            var model = builder.Build();
            var target = new TsGenerator();
            var script = target.Generate(model, TsGeneratorOutput.Enums);

            Assert.DoesNotContain("MaxItems", script);
        }

        [Fact]
        public void WhenEnumIsReferencedAndOutputIsSetToProperties_EnumIsntInOutput()
        {
            var builder = new TsModelBuilder();
            builder.Add<Item>();
            var model = builder.Build();
            var target = new TsGenerator();
            var script = target.Generate(model, TsGeneratorOutput.Properties);

            Assert.DoesNotContain("enum ItemType", script);
        }

        [Fact]
        public void WhenEnumIsReferencedAndOutputIsSetToProperties_ConstantIsntInOutput()
        {
            var builder = new TsModelBuilder();
            builder.Add<Item>();
            var model = builder.Build();
            var target = new TsGenerator();
            var script = target.Generate(model, TsGeneratorOutput.Properties);

            Assert.DoesNotContain("MaxItems", script);
        }

        [Fact]
        public void WhenEnumIsReferencedAndOutputIsSetToFields_EnumIsntInOutput()
        {
            var builder = new TsModelBuilder();
            builder.Add<Item>();
            var model = builder.Build();
            var target = new TsGenerator();
            var script = target.Generate(model, TsGeneratorOutput.Fields);

            Assert.DoesNotContain("enum ItemType", script);
        }

        [Fact]
        public void WhenEnumIsReferencedAndOutputIsSetToFields_ConstantIsntInOutput()
        {
            var builder = new TsModelBuilder();
            builder.Add<Item>();
            var model = builder.Build();
            var target = new TsGenerator();
            var script = target.Generate(model, TsGeneratorOutput.Fields);

            Assert.DoesNotContain("MaxItems", script);
        }

        [Fact]
        public void WhenClassIsReferencedAndOutputIsSetToConstants_ClassIsntInOutput()
        {
            var builder = new TsModelBuilder();
            builder.Add<Item>();
            var model = builder.Build();
            var target = new TsGenerator();
            var script = target.Generate(model, TsGeneratorOutput.Constants);

            Assert.DoesNotContain("interface Item", script);
        }

        [Fact]
        public void WhenClassIsReferencedAndOutputIsSetToConstants_EnumIsntInOutput()
        {
            var builder = new TsModelBuilder();
            builder.Add<Item>();
            var model = builder.Build();
            var target = new TsGenerator();
            var script = target.Generate(model, TsGeneratorOutput.Constants);

            Assert.DoesNotContain("enum ItemType", script);
        }

        [Fact]
        public void WhenClassWithEnumReferenced_FullyQualifiedNameIsUsed()
        {
            var builder = new TsModelBuilder();
            builder.Add<Item>();
            var model = builder.Build();
            var target = new TsGenerator();
            var script = target.Generate(model);

            Assert.Contains("Type: TypeLitePlus.Tests.NetCore.TestModels.ItemType", script);
        }

        [Fact]
        public void WhenConvertorIsRegistered_ConvertedTypeNameIsUsed()
        {
            var builder = new TsModelBuilder();
            builder.Add<Address>();
            var model = builder.Build();

            var target = new TsGenerator();
            target.RegisterTypeConvertor<string>(type => "KnockoutObservable<string>");
            var script = target.Generate(model);

            Assert.Contains("Street: KnockoutObservable<string>", script);
        }

        [Fact]
        public void WhenConvertorIsRegistered_ConvertedTypeNameIsUsedForFields()
        {
            var builder = new TsModelBuilder();
            builder.Add<Address>();
            var model = builder.Build();

            var target = new TsGenerator();
            target.RegisterTypeConvertor<string>(type => "KnockoutObservable<string>");
            var script = target.Generate(model, TsGeneratorOutput.Fields);

            Assert.Contains("PostalCode: KnockoutObservable<string>", script);
        }

        [Fact]
        public void WhenConvertorIsRegisteredForGuid_ConvertedTypeNameIsUsed()
        {
            var builder = new TsModelBuilder();
            builder.Add<Address>();
            var model = builder.Build();

            var target = new TsGenerator();
            target.RegisterTypeConvertor<Guid>(type => "string");
            var script = target.Generate(model);

            Assert.Contains("Id: string", script);
        }

        [Fact]
        public void WhenConvertorIsRegisteredForGuidCollection_ConvertedTypeNameIsUsed()
        {
            var builder = new TsModelBuilder();
            builder.Add<Address>();
            var model = builder.Build();

            var target = new TsGenerator();
            target.RegisterTypeConvertor<Guid>(type => "string");
            var script = target.Generate(model);

            Assert.Contains("Ids: string[]", script);
        }

        [Fact]
        public void WhenConvertorIsRegisteredForGuid_NoStringInterfaceIsDefined()
        {
            var builder = new TsModelBuilder();
            builder.Add<Address>();
            var model = builder.Build();

            var target = new TsGenerator();
            target.RegisterTypeConvertor<Guid>(type => "string");
            var script = target.Generate(model);

            Assert.DoesNotContain("interface string {", script);
        }

        [Fact]
        public void PropertyIsMarkedOptional_OptionalPropertyIsGenerated()
        {
            var builder = new TsModelBuilder();
            builder.Add<Address>();
            var model = builder.Build();

            var target = new TsGenerator();
            var script = target.Generate(model);

            Assert.Contains("CountryID?: number", script);
        }

        [Fact]
        public void WhenInterfaceIsAdded_InterfaceIsInOutput()
        {
            var builder = new TsModelBuilder();
            builder.Add<IShippingService>();
            var model = builder.Build();
            var target = new TsGenerator();
            var script = target.Generate(model, TsGeneratorOutput.Properties);

            Assert.Contains("IShippingService", script);
            Assert.Contains("Price", script);
        }

        [Fact]
        public void WhenGenerate_OutputIsFormated()
        {
            var builder = new TsModelBuilder();
            builder.Add<Address>();
            var model = builder.Build();

            var target = new TsGenerator();
            var script = target.Generate(model);

            using (var reader = new StringReader(script))
            {
                var line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("interface Address {"))
                    {
                        Assert.StartsWith("\t", line);
                    }
                    if (line.Contains("ID: Guid"))
                    {
                        Assert.StartsWith("\t\t", line);
                    }
                }
            }
        }
        #endregion
    }
}
