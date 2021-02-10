using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GalaSoft.MvvmLight.Command;
using Persons;
using Persons.Model;
using Persons.Model.Validators;
using Persons.ViewModel;

namespace PersonsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Add_Person_To_Database()
        {
            // Arrange           
            PersonDatabase dtb = PersonDatabase.Instance;
            PersonViewModel pvm = new PersonViewModel() 
            {
                Name = "Jan", 
                Surname = "Boťa", 
                Birthdate = new DateTime(2001,08,23), 
                PersonalIdentificationNumber = "123456/1234" 
            };
            
            // Act 
            pvm.ClickCommand.Execute(null);
            
            // Assert
            // Ověř, že se zpráva dostala do datového modelu
            Assert.AreEqual(dtb.Count, 1);
        }

        [TestMethod]
        public void BirthdateValidator_Return_Correct_Value()
        {
            BirthdateValidator btV = new BirthdateValidator();
            DateTime today = DateTime.Today;
            DateTime tooBack = new DateTime(1800, 1, 1);
            DateTime correct = new DateTime(2001, 11, 6);

            bool td = btV.IsValid(today);
            bool tb = btV.IsValid(tooBack);
            bool cr = btV.IsValid(correct);

            Assert.IsFalse(td);
            Assert.IsFalse(tb);
            Assert.IsTrue(cr);
        }

        [TestMethod]
        public void Name_And_Surname_Validators_Return_Correct_Value()
        {
            NameValidator nmV = new NameValidator();
            SurnameValidator snV = new SurnameValidator();
            string correct = "xx";
            string incorect = "";

            bool nmC = nmV.IsValid(correct);
            bool nmI = nmV.IsValid(incorect);
            bool snC = snV.IsValid(correct);
            bool SnI = snV.IsValid(incorect);

            Assert.IsFalse(nmI);
            Assert.IsFalse(SnI);
            Assert.IsTrue(nmC);
            Assert.IsTrue(snC);
        }

        [TestMethod]
        public void Rc_Validators_Return_Correct_Value()
        {
            RCBefore1954Validator rcBf = new RCBefore1954Validator();
            RCAfter1955Validator rcAf = new RCAfter1955Validator();
            string correctB = "531122/111";
            string incorrectB = "ffsead/123";
            string correctA = "020823/1234";
            string incorrectA = "125369/256";

            bool rcBfC = rcBf.IsValid(correctB);
            bool rcBfI = rcBf.IsValid(incorrectB);
            bool rcAfC = rcAf.IsValid(correctA);
            bool rcAfI = rcAf.IsValid(incorrectA);

            Assert.IsFalse(rcBfI);
            Assert.IsTrue(rcBfC);
            Assert.IsFalse(rcAfI);
            Assert.IsTrue(rcAfC);
        }
    }
}
