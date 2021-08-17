using System;

using ImprovedCommandInterface;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            IProgrammCommandShell blockEditor = new BlockEditor();
            blockEditor.Run();
        }
    }
}
