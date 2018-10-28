using System;
using TypeLitePlus.TsModels;

namespace TypeLitePlus
{
    /// <summary>
    /// Defines a method used to determine if a type should be marked with the keyword "export".
    /// </summary>
    /// <param name="tsClass">The class model to format</param>
    /// <param name="typeName">The type name to format</param>
    /// <returns>A bool indicating if a member should be exported.</returns>
    public delegate bool TsTypeVisibilityFormatter(TsClass tsClass, string typeName);

}
