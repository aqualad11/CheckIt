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
        
        public ItemList getItemList(Guid userID, Guid itemID)
        {
            ItemList itemList = db.ItemLists.Where(i => i.userID == userID && i.itemID == itemID).FirstOrDefault();
            return itemList;
        }

        public List<Item> getItemsByUserID(Guid userID)
        {
            var items = db.ItemLists.Where(i => i.userID == userID).Select(i => i.item).ToList();
            return items;
        }

        /// <summary>
        /// Adds an Itemlist object to DB
        /// doesn't check for duplicates, must be handled in service layer
        /// </summary>
        /// <param name="itemlist"></param>
        public void addItemList(ItemList itemlist)
        {
            db.ItemLists.Add(itemlist);
            db.SaveChanges();
        }

        /// <summary>
        /// removes the ItemList object passed in from DB
        /// throws InvalidOperationException
        /// </summary>
        /// <param name="itemlist"></param>
        public void removeItemList(ItemList itemlist)
        {
            db.ItemLists.Remove(itemlist);
            db.SaveChanges();
        }

        public void removeItemList(Guid userID, Guid itemID)
        {
            ItemList itemList = db.ItemLists.Where(i => i.userID == userID && i.itemID == itemID).FirstOrDefault();
            db.ItemLists.Remove(itemList);
            db.SaveChanges();
        }
    }
}
