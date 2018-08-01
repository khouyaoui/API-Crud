using Microsoft.VisualStudio.TestTools.UnitTesting;
using Student.Business.Logic.Modules;
using Student.DataAccess.Dao.Integration.Tests.Utils;
using Student.DataAccess.Dao.Interfaces;

namespace Student.DataAccess.Dao.Repository.StoreProcedure.Tests
{
    [TestClass()]
    public class RepositoryStoreProcedureStudentTests : IoCSupportedTest<BusinessModule>
    {
        private IRepository repositoryStoreProcedureStudent;

        [TestInitialize]
        public void SetUp()
        {

            this.repositoryStoreProcedureStudent = Resolve<IRepository>();

        }

        [TestMethod()]
        public void GetAllTest()
        {
            Assert.IsTrue(4 == 4);
            Assert.IsNotNull(repositoryStoreProcedureStudent);

        }

        [TestCleanup]
        public void TearDown()
        {
            repositoryStoreProcedureStudent = null;
            ShutdownIoC();

        }

    }
}