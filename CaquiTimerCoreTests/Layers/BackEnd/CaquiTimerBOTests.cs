using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaquiTimer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaquiTimer.Tests
{
    [TestClass()]
    public class CaquiTimerBOTests
    {
        [TestMethod()]
        public void CaquiTimerBOTest()
        {
            try
            {

                CaquiTimerBO objTest;
                objTest = CaquiTimerBO.Instance;

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}