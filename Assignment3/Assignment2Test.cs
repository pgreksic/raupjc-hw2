using System;
using System.Collections.Generic;
using System.Linq;
using Assignment2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment3
{
    [TestClass]
    public class Assignment2Test
    {

        ///TodoRepository tests start here
        [TestMethod]
        public void Get()
        {
            TodoItem firstItem = new TodoItem("Test item number 1.");
            TodoItem secondItem = new TodoItem("Test item number 2.");
            TodoItem thirdItem=new TodoItem("Test item number 3.");

            ITodoRepository testTodoRepository=new TodoRepository();

            testTodoRepository.Add(firstItem);
            testTodoRepository.Add(secondItem);

            Assert.AreEqual(firstItem, testTodoRepository.Get(firstItem.Id));
            Assert.AreEqual(secondItem, testTodoRepository.Get(secondItem.Id));
            Assert.AreEqual(null, testTodoRepository.Get(thirdItem.Id));



        }

        [TestMethod]
        public void Add()
        {
            ITodoRepository testTodoRepository=new TodoRepository();

            TodoItem firstItem = new TodoItem("Test item number 1.");
            TodoItem secondItem = new TodoItem("Test item number 2.");
            //TodoItem thirdItem = new TodoItem("Test item number 3.");
            String testString = "duplicate TodoItem_Id: " + secondItem.Id.ToString();
            String testNullString = "Value cannot be null.";

            Assert.AreEqual(firstItem, testTodoRepository.Add(firstItem));
            Assert.AreEqual(secondItem, testTodoRepository.Add(secondItem));


            try
            {
                testTodoRepository.Add(secondItem);
            }
            catch (DuplicateTodoItemException ex)
            {
                Assert.AreEqual(ex.Message, testString);
            }


            try
            {
                testTodoRepository.Add(null);
                
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(testNullString,ex.Message);
            }
        }

        [TestMethod]
        public void Remove()
        {
            TodoItem firstItem = new TodoItem("Test item number 1.");
            TodoItem secondItem = new TodoItem("Test item number 2.");
            TodoItem thirdItem = new TodoItem("Test item number 3.");

            ITodoRepository testTodoRepository = new TodoRepository();
            testTodoRepository.Add(firstItem);
            testTodoRepository.Add(secondItem);


            Assert.AreEqual(true, testTodoRepository.Remove(firstItem.Id));
            Assert.AreEqual(true, testTodoRepository.Remove(secondItem.Id));
            Assert.AreEqual(false,testTodoRepository.Remove(firstItem.Id));
            Assert.AreEqual(false,testTodoRepository.Remove(secondItem.Id));
            Assert.AreEqual(false, testTodoRepository.Remove(thirdItem.Id));
        }

        [TestMethod]
        public void Update()
        {
            TodoItem firstItem = new TodoItem("Test item number 1.");
            TodoItem secondItem = new TodoItem("Test item number 2.");
            TodoItem thirdItem = new TodoItem("Test item number 3.");
            thirdItem.Id = firstItem.Id;
            String testNullString = "Value cannot be null.";

            ITodoRepository testTodoRepository = new TodoRepository();

            testTodoRepository.Add(firstItem);
            testTodoRepository.Update(secondItem);
            testTodoRepository.Update(firstItem);

            Assert.AreEqual(2, testTodoRepository.GetAll().Count);
            testTodoRepository.Update(thirdItem);
            Assert.AreEqual(thirdItem.Text, testTodoRepository.Get(firstItem.Id).Text);

            try
            {
                testTodoRepository.Update(null);
                Assert.Fail();
            }
            catch(ArgumentNullException ex)
            {
                Assert.AreEqual(testNullString, ex.Message);
            }


        }

        [TestMethod]
        public void MarkAsCompleted_TodoRepository()
        {

            ITodoRepository testTodoRepository = new TodoRepository();

            TodoItem firstItem = new TodoItem("Test item number 1.");
            TodoItem secondItem = new TodoItem("Test item number 2.");
            TodoItem thirdItem = new TodoItem("Test item number 3.");

            testTodoRepository.Add(firstItem);
            testTodoRepository.Add(secondItem);

            Assert.AreEqual(true, testTodoRepository.MarkAsCompleted(firstItem.Id));
            Assert.AreEqual(true, testTodoRepository.MarkAsCompleted(secondItem.Id));
            Assert.AreEqual(false, testTodoRepository.MarkAsCompleted(thirdItem.Id));
            Assert.AreEqual(false, testTodoRepository.MarkAsCompleted(firstItem.Id));
            Assert.AreEqual(false, testTodoRepository.MarkAsCompleted(secondItem.Id));

        }

        [TestMethod]
        public void GetAll()
        {
            ITodoRepository testTodoRepository = new TodoRepository();

            TodoItem firstItem = new TodoItem("Test item number 1.");
            TodoItem secondItem = new TodoItem("Test item number 2.");
            TodoItem thirdItem = new TodoItem("Test item number 3.");

            testTodoRepository.Add(firstItem);
            testTodoRepository.Add(secondItem);
            testTodoRepository.Add(thirdItem);

            Assert.AreEqual(3,testTodoRepository.GetAll().Count);

            List<TodoItem> getAllTestList = testTodoRepository.GetAll();

            Assert.AreEqual(firstItem.Text, getAllTestList[0].Text);
            Assert.AreEqual(secondItem.Text, getAllTestList[1].Text);
            Assert.AreEqual(thirdItem.Text, getAllTestList[2].Text);
        }

        [TestMethod]
        public void GetActive()
        {

            ITodoRepository testTodoRepository = new TodoRepository();

            TodoItem firstItem = new TodoItem("Test item number 1.");
            TodoItem secondItem = new TodoItem("Test item number 2.");
            TodoItem thirdItem = new TodoItem("Test item number 3.");

            testTodoRepository.Add(firstItem);
            testTodoRepository.Add(secondItem);
            thirdItem.MarkAsCompleted();
            testTodoRepository.Add(thirdItem);

            Assert.AreEqual(2, testTodoRepository.GetActive().Count);

        }

        [TestMethod]
        public void GetCompleted()
        {
            ITodoRepository testTodoRepository = new TodoRepository();

            TodoItem firstItem = new TodoItem("Test item number 1.");
            TodoItem secondItem = new TodoItem("Test item number 2.");
            TodoItem thirdItem = new TodoItem("Test item number 3.");

            firstItem.MarkAsCompleted();
            secondItem.MarkAsCompleted();

            testTodoRepository.Add(firstItem);
            testTodoRepository.Add(secondItem);
            testTodoRepository.Add(thirdItem);

            Assert.AreEqual(2, testTodoRepository.GetCompleted().Count);
            Assert.AreEqual(true, testTodoRepository.GetCompleted().All(item => item.IsCompleted));


        }

        [TestMethod]
        public void GetFiltered()
        {
            ITodoRepository testTodoRepository = new TodoRepository();

            TodoItem firstItem = new TodoItem("Test item number 1.");
            TodoItem secondItem = new TodoItem("Test item number 2.");
            TodoItem thirdItem = new TodoItem("Test item number 3.");

            firstItem.MarkAsCompleted();
            secondItem.MarkAsCompleted();

            testTodoRepository.Add(firstItem);
            testTodoRepository.Add(secondItem);
            testTodoRepository.Add(thirdItem);

            List<TodoItem> testList = testTodoRepository.GetFiltered(item => item.IsCompleted);
            Assert.AreEqual(2, testList.Count);
            Assert.AreEqual(false, testList.Contains(thirdItem));
            Assert.AreEqual(thirdItem.Text,testTodoRepository.GetFiltered(item => !item.IsCompleted).First().Text);


        }

        //TodoRepository tests end here...................................................................................
        // ...............................................................................................................
        


        //TodoItem tests start here.......................................................................................
        //................................................................................................................

        [TestMethod]
        public void EqualsTest()
        {
            TodoItem firstItem = new TodoItem("Test item with same text");
            TodoItem secondItem = new TodoItem("Test item with same text");

            Assert.AreEqual(false, firstItem.Equals(secondItem));
            Assert.AreNotEqual(firstItem, secondItem);
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            TodoItem firstItem = new TodoItem("Test item with same text");
            TodoItem secondItem = new TodoItem("Test item with same text");

            Assert.AreNotEqual(secondItem.GetHashCode(), firstItem.GetHashCode());
        }


        [TestMethod]
        public void MarkAsCompleted_TodoItem()
        {
            TodoItem firstItem = new TodoItem("Test item with same text");
            TodoItem secondItem = new TodoItem("Test item with same text");

            firstItem.MarkAsCompleted();
            Assert.AreEqual(true, firstItem.IsCompleted);
            Assert.AreEqual(false, secondItem.IsCompleted);

        }

        //TodoItem tests end here.........................................................................................
        //................................................................................................................

    }
}
