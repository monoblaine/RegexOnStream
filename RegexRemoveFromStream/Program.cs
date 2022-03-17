//ş
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RegexRemoveFromStream;

internal class Program {
    private static void Main (String[] args) {
        if (args.Length < 2) {
            Console.WriteLine("Usage: RegexRemoveFromStream.exe <pathToInputFile> <patternToFilterOut>");
            return;
        }

        var inputFile = new FileInfo(Path.GetFullPath(args[0]));
        var outputFile = new FileInfo(
            Path.Combine(
                inputFile.DirectoryName,
                $"{Path.GetFileNameWithoutExtension(inputFile.Name)}_output{inputFile.Extension}"
            )
        );
        var pattern = new Regex(args[1]);
        using var reader = inputFile.OpenText();
        using var writer = outputFile.CreateText();
        String str;

        while ((str = reader.ReadLine()) is not null) {
            if (!pattern.IsMatch(str)) {
                writer.WriteLine(str);
            }
        }
    }
}
