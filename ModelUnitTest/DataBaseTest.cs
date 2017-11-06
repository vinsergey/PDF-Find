using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Model.Tests
{
    [TestClass]
    public class DataBaseTest
    {
        private const string DataBaseName = "PdfFindTestBase";

        [TestMethod]
        public void DataBaseConstructor()
        {
            new DataBase(DataBaseName).Dispose();

            try
            {
                var wrongName = "PdfFindNotExistedBase";
                using (var db = new DataBase(wrongName))
                    db.ReportConfigurations.FirstOrDefault();
                Assert.Fail("Wrong connection string not failed");
            }
            catch
            {
                //ignore
            }
        }

        [TestMethod]
        public void DataBaseRead()
        {
            using (var db = new DataBase(DataBaseName))
                db.ReportConfigurations.FirstOrDefault();
        }

        [TestMethod]
        public void DataBaseWrite()
        {
            var group = new GroupConfiguration() { GroupName = "Report" };

            // create
            using (var db = new DataBase(DataBaseName))
            {
                db.GroupConfigurations.Add(group);
                db.SaveChanges();
            }

            // read
            using (var db = new DataBase(DataBaseName))
                db.GroupConfigurations.First(g => g.Id == group.Id);

            // delete
            using (var db = new DataBase(DataBaseName))
            {
                var removeGroup = db.GroupConfigurations.First(g => g.Id == group.Id);
                db.GroupConfigurations.Remove(removeGroup);
                db.SaveChanges();
                Assert.IsNull(db.GroupConfigurations.FirstOrDefault(g => g.Id == group.Id));
            }
        }
    }
}
