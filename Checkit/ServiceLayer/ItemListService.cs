using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.DataAccessLayer;
using CheckIt.DataAccessLayer.Repositories;


namespace CheckIt.ServiceLayer
{
    public class ItemListService
    {
        private IItemListRepository itemListRepo;

        public ItemListService(DataBaseContext db)
        {
            itemListRepo = new ItemListRepository(db);
        }

        /// <summary>
        /// Gets all the Items associated with User.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<Item> GetItemsByUserID(Guid userID)
        {
            return itemListRepo.GetItemsByUserID(userID);
        }

        /// <summary>
        /// Gets all the Users associated with Item.
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public List<User> GetUsersByItemID(Guid itemID)
        {
            return itemListRepo.GetUsersByItemID(itemID);
        }

        /// <summary>
        /// Adds ItemList to database.
        /// </summary>
        /// <param name="itemlist"></param>
        /// <returns></returns>
        public bool AddItemList(ItemList itemlist)
        {
            try
            {
                itemListRepo.AddItemList(itemlist);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Removes ItemList from database.
        /// </summary>
        /// <param name="itemlist"></param>
        /// <returns></returns>
        public bool RemoveItemList(ItemList itemlist)
        {
            try
            {
                itemlist = itemListRepo.GetItemList(itemlist.userID, itemlist.itemID);
                itemListRepo.RemoveItemList(itemlist);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
