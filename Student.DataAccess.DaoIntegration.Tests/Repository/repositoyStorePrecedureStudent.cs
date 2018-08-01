using Microsoft.VisualStudio.TestTools.UnitTesting;
using Student.Business.Logic.Modules;
using Student.DataAccess.Dao.Interfaces;
using Student.DataAccess.Dao;

namespace Student.DataAccess.Dao.Repository.Integration.Tests
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