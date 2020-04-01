namespace StringLibraryTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using UtilityLibraries;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestStartsWithUpper()
        {
            // Tests that we expect to return true.
            string[] words = { "Alphabet", "Zebra", "ABC", "Αθήνα", "Москва" };
            foreach (string word in words)
            {
                bool result = word.StartsWithUpper();
                Assert.IsTrue(
                    result,
                    string.Format(
                        "Expected for '{0}': true; Actual: {1}",
                        word,
                        result));
            }
        }

        [TestMethod]
        public void TestDoesNotStartWithUpper()
        {
            // Tests that we expect to return false.
            string[] words = { "alphabet", "zebra", "abc", "αυτοκινητοβιομηχανία", "государство", "1234", ".", ";", " " };
            foreach (string word in words)
            {
                bool result = word.StartsWithUpper();
                Assert.IsFalse(
                    result,
                    string.Format(
                        "Expected for '{0}': false; Actual: {1}",
                        word,
                        result));
            }
        }

        [TestMethod]
        public void DirectCallWithNullOrEmpty()
        {
            // Tests that we expect to return false.
            string[] words = { string.Empty, null };
            foreach (string word in words)
            {
                bool result = word.StartsWithUpper();
                Assert.IsFalse(
                    result,
                    string.Format(
                        "Expected for '{0}': false; Actual: {1}",
                        word ?? "<null>",
                        result));
            }
        }
    }
}