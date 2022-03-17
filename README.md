A simple and stupid tool to read lines from a text file and copy the lines to a new file when `Regex.IsMatch(line)` is `false`.

Example:

```
RegexRemoveFromStream.exe some-huge-mssql-script-log.txt '\d+ rows affected|^$'
```
