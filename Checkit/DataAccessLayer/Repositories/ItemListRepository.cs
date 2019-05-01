using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    public class ItemListRepository : IItemListRepository
    {
        private DataBaseContext db;

        public ItemListRepository(DataBaseContext db)
        {
            this.db = db;
        }
        
        /// <summary>
        /// Gets specific ItemList
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public ItemList GetItemList(Guid userID, Guid itemID)
        {
            ItemList itemList = db.ItemLists.Where(i => i.userID == userID && i.itemID == itemID).FirstOrDefault();
            return itemList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<Item> GetItemsByUserID(Guid userID)
        {
            var items = db.ItemLists.Where(i => i.userID == userID).Select(i => i.item).ToList();
            return items;
        }

        public List<User> GetUsersByItemID(Guid itemID)
        {
            var users = db.ItemLists.Where(i => i.itemID == itemID).Select(i => i.user).ToList();
            return users;
        }

        /// <summary>
        /// Adds an Itemlist object to DB
        /// doesn't check for duplicates, must be handled in service layer
        /// </summary>
        /// <param name="itemlist"></param>
        /// <exception cref="System.Data.Entity.Infrastructure.DbUpdateException">Thrown when userID is invalid</exception>
        public void AddItemList(ItemList itemlist)
        {
            db.ItemLists.Add(itemlist);
            db.SaveChanges();
        }

        /// <summary>
        /// removes the ItemList object passed in from DB
        /// throws InvalidOperationException
        /// </summary>
        /// <param name="itemlist"></param>
        /// <exception cref="System.InvalidOperationException">Thrown when userID or itemID are invalid</exception>
        public void RemoveItemList(ItemList itemlist)
        {
            db.ItemLists.Remove(itemlist);
            db.SaveChanges();
        }

    }
}
