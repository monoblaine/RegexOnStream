A simple and stupid tool to read lines from a text file and do one of the following:

1. Copy the lines to a new file when `Regex.IsMatch(line)` is `false`,
2. Replace and copy the lines using some regex.

Usage:

```
RegexOnStream.exe <pathToInputFile> <pattern> <remove|replace> [replacement]
```

Example:

```
RegexOnStream.exe some-huge-mssql-script-log.txt '\d+ rows affected|^$' remove
```
