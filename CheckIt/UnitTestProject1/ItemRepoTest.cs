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
        /// Tests getItemByID with valid itemID
        /// </summary>
        [TestMethod]
        public void getItemByValidID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemRepository itemRepo = new ItemRepository(db);
            Guid itemID = new Guid("83F91B37-DC4A-E911-8259-0A64F53465D0");

            //Act
            Item item = itemRepo.getItemByID(itemID);

            //Assert
            Assert.IsNotNull(item);
        }

        /// <summary>
        /// Tests getItemByID with invalid itemID
        /// </summary>
        [TestMethod]
        public void getItemByInvalidID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemRepository itemRepo = new ItemRepository(db);
            Guid itemID = new Guid();

            //Act
            Item item = itemRepo.getItemByID(itemID);

            //Assert
            Assert.IsNull(item);
        }

        /// <summary>
        /// Tests getItemByName using valid name
        /// </summary>
        [TestMethod]
        public void getItemByValidName()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemRepository itemRepo = new ItemRepository(db);
            string name = "Oakley";

            //Act
            Item item = itemRepo.getItemByName(name);

            //Assert
            Assert.IsNotNull(item);
        }

        /// <summary>
        /// Tests getItemByName using invalid name(empty string)
        /// </summary>
        [TestMethod]
        public void getItemByInvalidName()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemRepository itemRepo = new ItemRepository(db);
            string name = "";

            //Act
            Item item = itemRepo.getItemByName(name);

            //Assert
            Assert.IsNull(item);
        }

        /// <summary>
        /// Tests addItem
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
            itemRepo.addItem(item);
            Item newItem = itemRepo.getItemByName("Polaroid Camera");

            //Assert 
            Assert.IsNotNull(newItem);

        }

        /// <summary>
        /// Tests updateItem with Existing Item
        /// </summary>
        [TestMethod]
        public void updateValidItem()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemRepository itemRepo = new ItemRepository(db);
            Item item = itemRepo.getItemByName("Polaroid Camera");
            string newUrl = "www.newUrl.com/PolaroidCamera";

            //Act
            item.url = newUrl;
            itemRepo.updateItem(item);
            Item updatedItem = itemRepo.getItemByName("Polaroid Camera");

            //Assert
            Assert.IsNotNull(updatedItem);
        }

        /// <summary>
        /// Tests updateItem using an invalid Item(not existant in db)
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
            Assert.ThrowsException<DbUpdateConcurrencyException>(() => itemRepo.updateItem(item));
            
        }

        /// <summary>
        /// Tests removeItem using a valid Item
        /// </summary>
        [TestMethod]
        public void removeValidItem()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemRepository itemRepo = new ItemRepository(db);
            Item item = itemRepo.getItemByName("Polaroid Camera");

            //Act
            itemRepo.removeItem(item);
            Item removedItem = itemRepo.getItemByName("Polaroid Camera");

            //Assert
            Assert.IsNull(removedItem);
        }

        /// <summary>
        /// Tests removeItem using an invalid Item
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
            Assert.ThrowsException<InvalidOperationException>(() => itemRepo.removeItem(item));
        }

    }
}
