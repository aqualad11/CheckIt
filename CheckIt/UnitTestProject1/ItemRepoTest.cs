using System;
using System.Data.Entity.Infrastructure;
using CheckIt.DataAccessLayer;
using CheckIt.DataAccessLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIt.UnitTests
{
    [TestClass]
    public class ItemRepoTest
    {
        /// <summary>
        /// Tests GetItemByID with valid itemID
        /// </summary>
        [TestMethod]
        public void getItemByValidID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemRepository itemRepo = new ItemRepository(db);
            Guid itemID = new Guid("83F91B37-DC4A-E911-8259-0A64F53465D0");

            //Act
            Item item = itemRepo.GetItemByID(itemID);

            //Assert
            Assert.IsNotNull(item);
        }

        /// <summary>
        /// Tests GetItemByID with invalid itemID
        /// </summary>
        [TestMethod]
        public void getItemByInvalidID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemRepository itemRepo = new ItemRepository(db);
            Guid itemID = new Guid();

            //Act
            Item item = itemRepo.GetItemByID(itemID);

            //Assert
            Assert.IsNull(item);
        }

        /// <summary>
        /// Tests GetItemByName using valid name
        /// </summary>
        [TestMethod]
        public void getItemByValidName()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemRepository itemRepo = new ItemRepository(db);
            string name = "Oakley";

            //Act
            Item item = itemRepo.GetItemByName(name);

            //Assert
            Assert.IsNotNull(item);
        }

        /// <summary>
        /// Tests GetItemByName using invalid name(empty string)
        /// </summary>
        [TestMethod]
        public void getItemByInvalidName()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemRepository itemRepo = new ItemRepository(db);
            string name = "";

            //Act
            Item item = itemRepo.GetItemByName(name);

            //Assert
            Assert.IsNull(item);
        }

        /// <summary>
        /// Tests AddItem
        /// </summary>
        [TestMethod]
        public void addItem()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemRepository itemRepo = new ItemRepository(db);
            Item item = new Item()
            {
                ItemName = "Polaroid Camera",
                price = 69.99,
                url = "www.polaroid.com/camera",
                picKey = "polaroidCamera"
            };

            //Act 
            itemRepo.AddItem(item);
            Item newItem = itemRepo.GetItemByName("Polaroid Camera");

            //Assert 
            Assert.IsNotNull(newItem);

        }

        /// <summary>
        /// Tests UpdateItem with Existing Item
        /// </summary>
        [TestMethod]
        public void updateValidItem()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemRepository itemRepo = new ItemRepository(db);
            Item item = itemRepo.GetItemByName("Polaroid Camera");
            string newUrl = "www.newUrl.com/PolaroidCamera";

            //Act
            item.url = newUrl;
            itemRepo.UpdateItem(item);
            Item updatedItem = itemRepo.GetItemByName("Polaroid Camera");

            //Assert
            Assert.IsNotNull(updatedItem);
        }

        /// <summary>
        /// Tests UpdateItem using an invalid Item(not existant in db)
        /// </summary>
        [TestMethod]
        public void updateInvalidItem()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemRepository itemRepo = new ItemRepository(db);
            Item item = new Item()
            {
                ItemName = "Polaroid Camera",
                price = 69.99,
                url = "www.polaroid.com/camera",
                picKey = "polaroidCamera"
            };

            //Act => Assert
            Assert.ThrowsException<DbUpdateConcurrencyException>(() => itemRepo.UpdateItem(item));
            
        }

        /// <summary>
        /// Tests RemoveItem using a valid Item
        /// </summary>
        [TestMethod]
        public void removeValidItem()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemRepository itemRepo = new ItemRepository(db);
            Item item = itemRepo.GetItemByName("Polaroid Camera");

            //Act
            itemRepo.RemoveItem(item);
            Item removedItem = itemRepo.GetItemByName("Polaroid Camera");

            //Assert
            Assert.IsNull(removedItem);
        }

        /// <summary>
        /// Tests RemoveItem using an invalid Item
        /// </summary>
        [TestMethod]
        public void removeInvalidItem()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemRepository itemRepo = new ItemRepository(db);
            Item item = new Item()
            {
                ItemName = "NonExisitingItem"
            };

            //Act => Assert
            Assert.ThrowsException<InvalidOperationException>(() => itemRepo.RemoveItem(item));
        }

    }
}
