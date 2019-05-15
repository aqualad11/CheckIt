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
        public void ItemRepository_GetItemByID_ValidID()
        {
            //Arrange
            DataBaseContext db = new DataBaseContext();
            IItemRepository itemRepo = new ItemRepository(db);
            Guid itemID = new Guid("4A361F37-036B-E911-AA03-021598E9EC9E");

            //Act
            Item item = itemRepo.GetItemByID(itemID);

            //Assert
            Assert.IsNotNull(item);
        }

        /// <summary>
        /// Tests GetItemByID with invalid itemID
        /// </summary>
        [TestMethod]
        public void ItemRepository_GetItemByID_InvalidID()
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
        public void ItemRepository_GetItemByName_ValidName()
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
        public void ItemRepository_GetItemByName_InvalidName()
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
        public void ItemRepository_AddItem_Successful()
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
        public void ItemRepository_UpdateItem_ValidItem()
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
        public void ItemRepository_UpdateItem_InvalidItem()
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
        public void ItemRepository_RemoveItem_ValidItem()
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
        public void ItemRepository_RemoveItem_InvalidItem()
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
