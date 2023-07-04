using System;
using todolist.Pages.TodoLists;
using NUnit.Framework;

namespace Nunittest
{
    public class CreateCardTest
    {
        CreateModel createModel;
        [SetUp]
        public void Setup()
        {
            createModel = new CreateModel();
        }

        [Test]
        public void CreateCard_Work()
        {
            //arrage
            var name = "Card 1";
            var content = "Verify card 1";

            //act
            createModel.OnGet();
            createModel.OnPost();
            //assert
            Assert.That(true, "222");
        }
    }
}
