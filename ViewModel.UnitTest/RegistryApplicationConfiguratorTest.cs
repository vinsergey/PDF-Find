using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using System.Configuration;

namespace ViewModel.UnitTest
{
    [TestClass]
    public class RegistryApplicationConfiguratorTest
    {

        string key = new AppSettingsReader().GetValue("RegKey", typeof(string)).ToString();

        [TestMethod]
        public void RegistryApplicationConfiguratorConstructorTest()
        {
            var regAppConfig = new RegistryApplicationConfigurator();

            Assert.IsNotNull(regAppConfig);
        }

        [TestMethod]
        public void RegistryApplicationConfiguratorSaveMethodTest() 
        {
            var regAppConfig = new RegistryApplicationConfigurator()
            {
                Language = "ukrainian",
                ReaderPath = @"C:\Users\Maxxxwell\AppData\Roaming\Microsoft\Internet Explorer\Quick Launch\User Pinned\StartMenu\Visual Studio 2017.lnk",
                //@"C:\Program Files\WinRAR\WinRAR.exe"
                DataBaseConnectionString = "conectionSTR"
            };

            regAppConfig.SaveCommand.Execute(null);

            regAppConfig = new RegistryApplicationConfigurator();

            Assert.AreEqual(regAppConfig.Language, "ukrainian");
            Assert.AreEqual(regAppConfig.ReaderPath, @"C:\Users\Maxxxwell\AppData\Roaming\Microsoft\Internet Explorer\Quick Launch\User Pinned\StartMenu\Visual Studio 2017.lnk"); //@"C:\Program Files\WinRAR\WinRAR.exe");
            Assert.AreEqual(regAppConfig.DataBaseConnectionString, "conectionSTR");
        }

        [TestMethod]
        public void RegistryApplicationConfiguratorReaderPathValidation()
        {
            try
            {
                string[] mass = { "", @"C:\Program Files\WinRAR\WinRAR.txt", @"‪C:\Program Files\WinRAR\ReadMe.txt" };
                var regAppConfig = new RegistryApplicationConfigurator();

                //regAppConfig.ReaderPath = @"C:\Program Files\WinRAR\WinRAR.exe";

                foreach (var item in mass)
                {
                    regAppConfig.ReaderPath = item;
                }

                Assert.Fail("Wrong ReaderPath");
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch
            {
                //ignore
            }
        }

        [TestCleanup]
        public void CleanUpRegistry()
        {
            RegistryKey currentUser = Registry.CurrentUser;
            RegistryKey pdfFindKey = currentUser.OpenSubKey(key, true);

            if (pdfFindKey != null)
            Registry.CurrentUser.DeleteSubKey(key);
        }
    }
}
