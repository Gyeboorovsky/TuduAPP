using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestTuduAPP
{
    [TestClass]
    public class ValicationsTest
    {
        [TestMethod]
        public void ValidateUsernameTest()
        {
            //arrange
            string[] sampleUsernames = { 
                "Tomasz",
                "Karol", 
                "kon rad23", 
                "1231", 
                "dd", 
                " ", 
                "123445", 
                "bardzod³ugiusername" };

            //act
            List<bool> results = new List<bool>();

            //foreach (string s in sampleUsernames)
            //{
            //    results.Add(ValidateUsername(s));
            //}


            //assert

        }
    }
}
