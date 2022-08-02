using InspiredSoftware.IO;

namespace IO.Test
{
    [TestClass]
    public class IOTest
    {
        public string TempPath => System.IO.Path.GetTempPath();
        public string TempFile => System.IO.Path.GetTempFileName();

        [TestMethod]
        public void CloneTest()
        {
            var origin = new FilePath(TempPath);
            var clone = origin.Clone();
            Assert.IsTrue(origin.ToString().Equals(clone.ToString()));
            Assert.IsFalse(object.ReferenceEquals(origin, clone));
        }

        [TestMethod]
        public void CombineTest()
        {
            string? temp = TempPath;
            string[] paths = new[] { "sub", "folder" };
            var origin = new FilePath(temp);
            FilePath? result = origin.Combine(paths);
            var compare = new FilePath(Path.Combine(temp, paths[0], paths[1]));
            Assert.IsTrue(compare.ToString().Equals(result.ToString()));
        }

        [TestMethod]
        public void CompareToTest()
        {
            var temp = TempFile;
            var compare1 = new FilePath(temp.ToLower());
            var compare2 = new FilePath(temp.ToUpper());
            Assert.IsTrue(0 == compare1.CompareTo(compare2));
        }

        [TestMethod]
        public void EqualsTest()
        {
            var temp = TempFile;
            var compare1 = new FilePath(temp.ToLower());
            var compare2 = new FilePath(temp.ToUpper());
            Assert.IsTrue(compare1.Equals(compare2));
        }

        [TestInitialize]
        public void InitializeTest() { }

        [TestCleanup]
        public void CleanupTest() { }
    }
}