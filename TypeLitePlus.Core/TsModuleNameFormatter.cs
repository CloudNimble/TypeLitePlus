using System;
using TypeLitePlus.TsModels;

namespace TypeLitePlus
{
    /// <summary>
    /// Formats a module name
    /// </summary>
    /// <param name="module">The module to be formatted</param>
    /// <returns>The module name after formatting.</returns>
    public delegate string TsModuleNameFormatter(TsModule module);

    /// <summary>
    /// Formats a module name
    /// </summary>
    /// <param name="moduleName">The module name to be formatted</param>
    /// <returns>The module name after formatting.</returns>
    [Obsolete]
    public delegate string TsSimplifiedModuleNameFormatter(string moduleName);
}
