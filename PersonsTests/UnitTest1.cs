using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GalaSoft.MvvmLight.Command;
using Persons;
using Persons.Model;
using Persons.ViewModel;

namespace PersonsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           // // Arrange
           // string testMessage = "Unit test zprava"; Persons.
           // ZpravaModel z = ZpravaModel.ZpravaDatabase;
           // ZpravaViewModel zvm = new ZpravaViewModel { Zprava = testMessage };
           // 
           // // Act 
           // // Tohle za nás v aplikaci udělá binding
           // // na TextBox a Button. V testu to dokážeme simulovat voláním.
           // zvm.SendCommand.Execute(null);
           //
           // // Assert
           // // Ověř, že se zpráva dostala do datového modelu
           // Assert.AreEqual(z.VsechnyZpravy[0], testMessage);
        }
    }
}
