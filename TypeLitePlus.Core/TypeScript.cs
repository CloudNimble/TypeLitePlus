using System;
using System.Reflection;
using TypeLitePlus.TsModels;

namespace TypeLitePlus
{
    /// <summary>
    /// Provides helper methods for generating TypeScript definition files.
    /// </summary>
    public static class TypeScript
    {
        /// <summary>
        /// Creates an instance of the FluentTsModelBuider for use in T4 templates.
        /// </summary>
        /// <returns>An instance of the FluentTsModelBuider</returns>
        public static TypeScriptFluent Definitions()
        {
            return new TypeScriptFluent();
        }

        /// <summary>
        /// Creates an instance of the FluentTsModelBuider for use in T4 templates.
        /// </summary>
        /// <param name="scriptGenerator">The script generator you want it constructed with</param>
        /// <returns>An instance of the FluentTsModelBuider</returns>
        public static TypeScriptFluent Definitions(TsGenerator scriptGenerator)
        {
            return new TypeScriptFluent(scriptGenerator);
        }
    }
}