using NUnit.Framework;
using PayCalc;

namespace PayCalcNUnitTest //test repo, test calc 
{
    [TestFixture]
    public class PermEmployeeRepositoryTest
    {
        [Test]
        public void ReadAllReturnsAll()
        {
           var tst = new MockEmployeeRepository();

            var x = tst.GetAll();

            Assert.That(string.Concat(x).Split("Id").Length, Is.EqualTo(1));
        }
    }
}