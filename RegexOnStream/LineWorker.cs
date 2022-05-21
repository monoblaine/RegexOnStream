//ş
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RegexOnStream;

internal abstract class LineWorker {
    protected LineWorker (StreamWriter streamWriter, Regex pattern, String replacement) {
        StreamWriter = streamWriter;
        Pattern = pattern;
        Replacement = replacement;
    }

    public StreamWriter StreamWriter { get; }

    public Regex Pattern { get; }

    public String Replacement { get; }

    public abstract void Execute (ref String line);
}
