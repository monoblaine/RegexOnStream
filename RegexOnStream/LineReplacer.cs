//ş
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RegexOnStream;

internal class LineReplacer : LineWorker {
    public LineReplacer (StreamWriter streamWriter, Regex pattern, String replacement) : base(streamWriter, pattern, replacement) {
    }

    public override void Execute (ref String line) {
        StreamWriter.WriteLine(Pattern.Replace(line, Replacement));
    }
}
