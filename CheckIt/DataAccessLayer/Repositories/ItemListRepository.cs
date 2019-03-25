using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    class ItemListRepository : IItemListRepository
    {
        private DataBaseContext db;

        public ItemListRepository(DataBaseContext db)
        {
            this.db = db;
        }
        
        public ItemList getItemListByID(Guid itemlistID)
        {
            ItemList itemlist = db.ItemLists.Find(itemlistID);
            return itemlist;
        }

        public List<ItemList> getItemListsByUserID(Guid userID)
        {
            var itemlists = db.ItemLists.Where(i => i.userID == userID).ToList();
            return itemlists;
        }

        public List<Item> getListOfItemsByUserID(Guid userID)
        {
            var items = db.ItemLists.Where(i => i.userID == userID).Select(i => i.item).ToList();
            return items;
        }

        public void addItemList(ItemList itemlist)
        {
            db.ItemLists.Add(itemlist);
            db.SaveChanges();
        }

        public void removeItemList(ItemList itemlist)
        {
            db.ItemLists.Remove(itemlist);
            db.SaveChanges();
        }

        public void updateItemList(ItemList itemlist)
        {
            db.Entry(itemlist).State = EntityState.Modified;
            db.SaveChanges();
        }


    }
}
