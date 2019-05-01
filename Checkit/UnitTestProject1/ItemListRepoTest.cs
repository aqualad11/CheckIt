using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using CheckIt.DataAccessLayer;
using CheckIt.DataAccessLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIt.UnitTests
{
    [TestClass]
    public class ItemListRepoTest
    {
        /// <summary>
        /// Tests GetItemList using valid ItemList in db
        /// </summary>
        [TestMethod]
        public void GetItemListValid()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemListRepository itemListRepo = new ItemListRepository(db);
            Guid userID = new Guid("44361F37-036B-E911-AA03-021598E9EC9E");
            Guid itemID = new Guid("4A361F37-036B-E911-AA03-021598E9EC9E");

            //Act
            ItemList il = itemListRepo.GetItemList(userID, itemID);

            //Assert 
            Assert.IsNotNull(il);
        }

        /// <summary>
        /// Tests GetItemList using invalid userID & itemID
        /// </summary>
        [TestMethod]
        public void GetItemListInvalid()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemListRepository itemListRepo = new ItemListRepository(db);
            Guid userID = new Guid("7CF91B37-DC4A-E911-8259-0A64F53465D0");
            Guid itemID = new Guid("83F91B37-DC4A-E911-8259-0A64F53465D0");

            //Act
            ItemList il = itemListRepo.GetItemList(userID, itemID);

            //Assert 
            Assert.IsNull(il);
        }

        /// <summary>
        /// Tests GetItemsByUserID using valid UserID in itemlist
        /// </summary>
        [TestMethod]
        public void GetItemsByValidUserID()
        {
            //Arrange 
            DataBaseContext db = new DataBaseContext();
            IItemListRepository itemListRepo = new ItemListRepository(db);
            Guid userID = new Guid("46361F37-036B-E911-AA03-021598E9EC9E");

            //Act
            List<Item> items = itemListRepo.GetItemsByUserID(userID);

            //Assert
            Assert.AreEqual(items.Count, 2);
        }

        /// <summary>
        /// Tests GetItemsByUserID using invalid UserID which is not in itemList
        /// </summary>
        [TestMethod]
        public void GetItemsByInvalidUserID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemListRepository itemListRepo = new ItemListRepository(db);
            Guid userID = new Guid("7CF91B37-DC4A-E911-8259-0A64F53465D0");

            //Act
            List<Item> items = itemListRepo.GetItemsByUserID(userID);

            //Assert
            Assert.AreEqual(items.Count, 0);
        }

        /// <summary>
        /// Tests GetUserByItemID using a valid itemID
        /// </summary>
        [TestMethod]
        public void GetUsersByValidItemID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemListRepository itemListRepo = new ItemListRepository(db);
            Guid itemID = new Guid("4A361F37-036B-E911-AA03-021598E9EC9E");

            //Act
            List<User> users = itemListRepo.GetUsersByItemID(itemID);

            //Assert
            Assert.AreEqual(users.Count, 2);
        }

        /// <summary>
        /// Tests GetUserByItemID using an invalid itemID
        /// </summary>
        [TestMethod]
        public void GetUserByInvalidItemID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemListRepository itemListRepo = new ItemListRepository(db);
            Guid itemID = new Guid();

            //Act
            List<User> users = itemListRepo.GetUsersByItemID(itemID);

            //Assert
            Assert.AreEqual(users.Count, 0);
        }

        /// <summary>
        /// Tests AddItemList with new ItemList with existing user and item
        /// </summary>
        /// <param name="itemlist"></param>
        [TestMethod]
        public void AddItemListValidUserItem()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemListRepository itemListRepo = new ItemListRepository(db);
            Guid userID = new Guid("FB8A70A1-056B-E911-AA03-021598E9EC9E");
            Guid itemID = new Guid("4B361F37-036B-E911-AA03-021598E9EC9E");
            ItemList il = new ItemList(userID, itemID);

            //Act
            itemListRepo.AddItemList(il);
            ItemList newIl = itemListRepo.GetItemList(userID, itemID);

            //Assert
            Assert.IsNotNull(newIl);
        }

        /// <summary>
        /// Tests AddItemList with new ItemList with an Nonexisting user and valid item
        /// </summary>
        [TestMethod]
        public void AddItemListInvalidUser()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemListRepository itemListRepo = new ItemListRepository(db);
            Guid userID = new Guid();
            Guid itemID = new Guid("4B361F37-036B-E911-AA03-021598E9EC9E");
            ItemList il = new ItemList(userID, itemID);

            //Act => Assert
            Assert.ThrowsException<DbUpdateException>(() => itemListRepo.AddItemList(il));
        }

        /// <summary>
        /// Tests AddItemList with new ItemList with an valid user and Nonexisting item
        /// </summary>
        [TestMethod]
        public void AddItemListInvalidItem()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemListRepository itemListRepo = new ItemListRepository(db);
            Guid userID = new Guid("FB8A70A1-056B-E911-AA03-021598E9EC9E");
            Guid itemID = new Guid();
            ItemList il = new ItemList(userID, itemID);

            //Act => Assert
            Assert.ThrowsException<DbUpdateException>(() => itemListRepo.AddItemList(il));
        }

        /// <summary>
        /// Tests RemoveItemList(ItemList) with valid Itemlist
        /// </summary>
        [TestMethod]
        public void RemoveItemListValid()
        {
            //Assert
            DataBaseContext db = new DataBaseContext();
            IItemListRepository itemListRepo = new ItemListRepository(db);
            Guid userID = new Guid("FB8A70A1-056B-E911-AA03-021598E9EC9E");
            Guid itemID = new Guid("4B361F37-036B-E911-AA03-021598E9EC9E");
            ItemList itemList = itemListRepo.GetItemList(userID, itemID);

            //Act
            itemListRepo.RemoveItemList(itemList);
            ItemList newIl = itemListRepo.GetItemList(userID, itemID);

            //Assert
            Assert.IsNull(newIl);

        }

        /// <summary>
        /// Tests RemoveItemList(ItemList) with invalid Itemlist
        /// </summary>
        [TestMethod]
        public void RemoveItemListInvalid()
        {
            //Assert
            DataBaseContext db = new DataBaseContext();
            IItemListRepository itemListRepo = new ItemListRepository(db);
            Guid userID = new Guid("7DF91B37-DC4A-E911-8259-0A64F53465D0");
            Guid itemID = new Guid("85F91B37-DC4A-E911-8259-0A64F53465D0");
            ItemList itemList = new ItemList(userID, itemID);

            //Act
            Assert.ThrowsException<InvalidOperationException>(() => itemListRepo.RemoveItemList(itemList));
            
        }

    }
}
