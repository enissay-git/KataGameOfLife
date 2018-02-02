using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeTest
{
    [TestClass]
    public class GameOfLifeTests
    {
        private IGameOfLifeService myInterface;

        private void InitTest ()
        {
            myInterface = null;
        }

        [TestMethod]
        public void when_cell_is_alive_then_isAlive_return_true()
        {
            InitTest();
            Cell myCell = new Cell(true);

            Assert.IsTrue(myInterface.IsAlive(myCell));
        }
    }
}
