using System.Diagnostics;
using System;
using global::System.ComponentModel;

namespace Invaders.My
{
    internal static partial class MyProject
    {
        internal partial class MyForms
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Invaders m_Invaders;

            public Invaders Invaders
            {
                [DebuggerHidden]
                get
                {
                    m_Invaders = MyForms.Create__Instance__(m_Invaders);
                    return m_Invaders;
                }
                [DebuggerHidden]
                set
                {
                    if (value == m_Invaders)
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_Invaders);
                }
            }
        }
    }
}
