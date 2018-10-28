using System;
using System.Collections.Generic;
using System.Text;

namespace TypeLitePlus
{

    /// <summary>
    /// 
    /// </summary>
    public enum TsGenerationModes
    {
        /// <summary>
        /// Renders the file with declared namespaces and interfaces.
        /// </summary>
        Definitions,

        /// <summary>
        /// Renders the file with exported modules and classes.
        /// </summary>
        Classes
    }
}
