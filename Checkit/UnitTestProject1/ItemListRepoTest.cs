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
        public void getItemListValid()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemListRepository itemListRepo = new ItemListRepository(db);
            Guid userID = new Guid("7AF91B37-DC4A-E911-8259-0A64F53465D0");
            Guid itemID = new Guid("83F91B37-DC4A-E911-8259-0A64F53465D0");

            //Act
            ItemList il = itemListRepo.GetItemList(userID, itemID);

            //Assert 
            Assert.IsNotNull(il);
        }

        /// <summary>
        /// Tests GetItemList using invalid userID & itemID
        /// </summary>
        [TestMethod]
        public void getItemListInvalid()
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
        public void getItemsByValidUserID()
        {
            //Arrange 
            DataBaseContext db = new DataBaseContext();
            IItemListRepository itemListRepo = new ItemListRepository(db);
            Guid userID = new Guid("7BF91B37-DC4A-E911-8259-0A64F53465D0");

            //Act
            List<Item> items = itemListRepo.GetItemsByUserID(userID);

            //Assert
            Assert.AreEqual(items.Count, 2);
        }

        /// <summary>
        /// Tests GetItemsByUserID using invalid UserID which is not in itemList
        /// </summary>
        [TestMethod]
        public void getItemsByInvalidUserID()
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
        /// Tests AddItemList with new ItemList with existing user and item
        /// </summary>
        /// <param name="itemlist"></param>
        [TestMethod]
        public void addItemListValidUserItem()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemListRepository itemListRepo = new ItemListRepository(db);
            Guid userID = new Guid("7DF91B37-DC4A-E911-8259-0A64F53465D0");
            Guid itemID = new Guid("85F91B37-DC4A-E911-8259-0A64F53465D0");
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
        public void addItemListInvalidUser()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemListRepository itemListRepo = new ItemListRepository(db);
            Guid userID = new Guid();
            Guid itemID = new Guid("85F91B37-DC4A-E911-8259-0A64F53465D0");
            ItemList il = new ItemList(userID, itemID);

            //Act => Assert
            Assert.ThrowsException<DbUpdateException>(() => itemListRepo.AddItemList(il));
        }

        /// <summary>
        /// Tests AddItemList with new ItemList with an valid user and Nonexisting item
        /// </summary>
        [TestMethod]
        public void addItemListInvalidItem()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemListRepository itemListRepo = new ItemListRepository(db);
            Guid userID = new Guid("7DF91B37-DC4A-E911-8259-0A64F53465D0");
            Guid itemID = new Guid();
            ItemList il = new ItemList(userID, itemID);

            //Act => Assert
            Assert.ThrowsException<DbUpdateException>(() => itemListRepo.AddItemList(il));
        }

        /// <summary>
        /// Tests RemoveItemList(ItemList) with valid Itemlist
        /// </summary>
        [TestMethod]
        public void removeItemListValid()
        {
            //Assert
            DataBaseContext db = new DataBaseContext();
            IItemListRepository itemListRepo = new ItemListRepository(db);
            Guid userID = new Guid("7DF91B37-DC4A-E911-8259-0A64F53465D0");
            Guid itemID = new Guid("85F91B37-DC4A-E911-8259-0A64F53465D0");
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
        public void removeItemListInvalid()
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

        /// <summary>
        /// Tests RemoveItemList(userID, itemID) with valid Itemlist
        /// </summary>
        [TestMethod]
        public void removeItemListValidUserItem()
        {
            //Assert 
            //Assert
            DataBaseContext db = new DataBaseContext();
            IItemListRepository itemListRepo = new ItemListRepository(db);
            Guid userID = new Guid("7DF91B37-DC4A-E911-8259-0A64F53465D0");
            Guid itemID = new Guid("85F91B37-DC4A-E911-8259-0A64F53465D0");

            //Act
            itemListRepo.RemoveItemList(userID, itemID);
            ItemList newIl = itemListRepo.GetItemList(userID, itemID);

            //Assert
            Assert.IsNull(newIl);
        }

        /// <summary>
        /// Tests RemoveItemList(userID, itemID) with invalid userID
        /// same outcome should happen with invaliditemID
        /// </summary>
        [TestMethod]
        public void removeItemInvalidUserItem()
        {
            //Assert
            DataBaseContext db = new DataBaseContext();
            IItemListRepository itemListRepo = new ItemListRepository(db);
            Guid userID = new Guid("7DF91B37-DC4A-E911-8259-0A64F53465D0");
            Guid itemID = new Guid("85F91B37-DC4A-E911-8259-0A64F53465D0");
            ItemList itemList = new ItemList(userID, itemID);

            //Act => Assert
            Assert.ThrowsException<InvalidOperationException>(() => itemListRepo.RemoveItemList(itemList));
        }
    }
}
