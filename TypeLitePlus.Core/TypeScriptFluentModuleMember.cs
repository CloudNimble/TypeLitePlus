using TypeLitePlus.TsModels;

namespace TypeLitePlus
{
    /// <summary>
    /// Represents a wrapper around TsModelBuilder and TsGenerator that simplify usage a enables fluent configuration for types.
    /// </summary>
    public class TypeScriptFluentModuleMember : TypeScriptFluent
    {
        /// <summary>
        /// Gets the class being configured.
        /// </summary>
        public TsModuleMember Member { get; protected set; }

        internal TypeScriptFluentModuleMember(TypeScriptFluent fluentConfigurator, TsModuleMember member)
            : base(fluentConfigurator)
        {
            this.Member = member;
        }

        /// <summary>
        /// Changes the name of the type being configured .
        /// </summary>
        /// <param name="name">The new name of the type</param>
        /// <returns>Instance of the TypeScriptFluentModuleMember that enables fluent configuration.</returns>
        public TypeScriptFluentModuleMember Named(string name)
        {
            this.Member.Name = name;
            return this;
        }

        /// <summary>
        /// Maps the type being configured to the specific module
        /// </summary>
        /// <param name="moduleName">The name of the module</param>
        /// <returns>Instance of the TypeScriptFluentModuleMember that enables fluent configuration.</returns>
        public TypeScriptFluentModuleMember ToModule(string moduleName)
        {
            this.Member.Module = new TsModule(moduleName);
            return this;
        }

        /// <summary>
        /// Ignores this member when generating typescript
        /// </summary>
        /// <returns>Instance of the TypeScriptFluentModuleMember that enables fluent configuration.</returns>
        public TypeScriptFluentModuleMember Ignore()
        {
            if (Member is TsClass)
            {
                ((TsClass)Member).IsIgnored = true;
            }
            return this;
        }
    }
}