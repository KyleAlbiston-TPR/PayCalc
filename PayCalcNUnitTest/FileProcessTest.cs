using NUnit.Framework;
using PayCalc;

namespace PayCalcNUnitTest
{
    [TestFixture]
    public class FileProcessTest
    {
        [Test]
        public void FileNameDoesExist()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            bool fromCall;

            //Act
            fromCall = fp.FileExists(@"C:\Users\albistok\source\repos\PayCalc");

            //Assert
            Assert.IsTrue(fromCall);
        }

        [Test]
        public void FileNameDoesNotExist()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void FileNameNullOrEmpty_UsingAttribute()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void FileNameNullOrEmpty_UsingTryCatch()
        {
            Assert.Inconclusive();
        }
    }
}