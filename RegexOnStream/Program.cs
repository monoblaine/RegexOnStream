//ş
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RegexOnStream;

internal class Program {
    private static void Main (String[] args) {
        if (args.Length < 3) {
            Console.WriteLine("Usage: RegexOnStream.exe <pathToInputFile> <pattern> <remove|replace> [replacement]");
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
        using var reader = new StreamReader(inputFile.OpenRead(), detectEncodingFromByteOrderMarks: true);
        reader.Peek();
        var encoding = reader.CurrentEncoding;
        using var writer = new StreamWriter(outputFile.OpenWrite(), encoding);
        String str;
        LineWorker lineWorker = args[2] switch {
            "remove" => new LineRemover(writer, pattern, null),
            "replace" => new LineReplacer(writer, pattern, args.Length > 3 ? args[3] : String.Empty),
            _ => throw new NotImplementedException(args[2])
        };

        while ((str = reader.ReadLine()) is not null) {
            lineWorker.Execute(ref str);
        }
    }
}
