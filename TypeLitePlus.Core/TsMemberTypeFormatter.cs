using System;
using TypeLitePlus.TsModels;

namespace TypeLitePlus
{
    /// <summary>
    /// Defines a method used to format class member types.
    /// </summary>
    /// <param name="tsProperty">The typescript property</param>
    /// <returns>The formatted type.</returns>
    public delegate string TsMemberTypeFormatter(TsProperty tsProperty, string memberTypeName);

}
