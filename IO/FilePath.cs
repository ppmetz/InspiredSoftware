using System;
using System.Linq;

namespace InspiredSoftware.IO;
// inspired by "What I've learned from 20 years of programming in C#" with Joe Albahari
public class FilePath : ICloneable, IComparable<FilePath>, IEquatable<FilePath>, IFilePath
{
    readonly string _FilePath;

    public FilePath(string filePath) =>
        _FilePath = GetValidated(filePath);

    public static string GetValidated(string? filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentNullException(nameof(filePath));

        if (filePath.Length < 3) throw new ArgumentException(nameof(filePath));

        if (System.IO.Path.GetInvalidPathChars().Intersect(filePath).Any()) throw new ArgumentException(nameof(filePath));

        return System.IO.Path.GetFullPath(filePath.Trim());
    }

    public override string ToString() => _FilePath;

    public static implicit operator FilePath(string filePath) => new(filePath);

    public FilePath Combine(params string[] paths) =>
        System.IO.Path.Combine(paths.Prepend(_FilePath).ToArray());

    public virtual bool Equals(FilePath? other) =>
            _FilePath.Equals(other?.ToString(), StringComparison.InvariantCultureIgnoreCase);

    public object Clone() => new FilePath(_FilePath);

    public int CompareTo(FilePath other) => (this.Equals(other))
        ? 0
        : _FilePath.CompareTo(other.ToString());
}
