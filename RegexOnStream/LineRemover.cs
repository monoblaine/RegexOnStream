//ş
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RegexOnStream;

internal class LineRemover : LineWorker {
    public LineRemover (StreamWriter streamWriter, Regex pattern, String replacement) : base(streamWriter, pattern, replacement) {
    }

    public override void Execute (ref String line) {
        if (!Pattern.IsMatch(line)) {
            StreamWriter.WriteLine(line);
        }
    }
}
