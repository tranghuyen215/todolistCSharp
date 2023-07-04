using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using todolist.Pages.TodoLists;

namespace Nunittest
{
    class ListCardTest
    {
        IndexModel indexModel;

        [SetUp]
        public void Setup()
        {
            indexModel = new IndexModel();
        }
        
        [Test]
        public void listCard_Work()
        {
            //arrage

            //act
            indexModel.OnGet();
            //assert
            Assert.That(true, "22");
        }
    }
}
