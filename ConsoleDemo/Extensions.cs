using ConsoleTableExt;
using System;
using System.Collections.Generic;

namespace ConsoleDemo
{
    public static class Extensions
    {
        /// <summary>
        /// Does print a list as a table in the console. Requires ConsoleTabExt NuGet. 
        /// Source: https://github.com/minhhungit/ConsoleTableExt
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="title"></param>
        public static void PrintTable<T>(this List<T> sequence, string title)
            where T : class =>
            ConsoleTableBuilder
                .From(sequence)
                .WithTitle(title, ConsoleColor.Yellow, ConsoleColor.Blue)
                .WithCharMapDefinition(CharMapDefinition.FramePipDefinition)
                .ExportAndWriteLine();
    }
}
