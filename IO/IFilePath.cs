namespace InspiredSoftware.IO
{
    public interface IFilePath
    {
        object Clone();
        FilePath Combine(params string[] paths);
        int CompareTo(FilePath other);
        bool Equals(FilePath? other);
        string ToString();
    }
}