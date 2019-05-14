using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.DataAccessLayer;
using CheckIt.DataAccessLayer.Repositories;

namespace CheckIt.ServiceLayer
{
    public class ItemService
    {
        private IItemRepository itemRepo;

        public ItemService(DataBaseContext db)
        {
            itemRepo = new ItemRepository(db);
        }

        /// <summary>
        /// Gets Item from database using the Item's ID.
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns>Item</returns>
        public Item GetItem(Guid itemID)
        {
            return itemRepo.GetItemByID(itemID);
        }

        /// <summary>
        /// Gets Item from database using the Item's name.
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns>Item</returns>
        public Item GetItem(string name)
        {
            return itemRepo.GetItemByName(name);
        }

        /// <summary>
        /// Adds Item to database.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>True if successful, otherwise fales.</returns>
        public bool AddItem(Item item)
        {
            try
            {
                itemRepo.AddItem(item);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Updates existing Item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>True if successful, otherwise fales.</returns>
        public bool UpdateItem(Item item)
        {
            try
            {
                itemRepo.UpdateItem(item);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Removes Item from database.S
        /// </summary>
        /// <param name="item"></param>
        /// <returns>True if successful, otherwise fales.</returns>
        public bool RemoveItem(Item item)
        {
            try
            {
                itemRepo.RemoveItem(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
