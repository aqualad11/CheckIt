using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    class ItemRepository : IItemRepository
    {
        private DataBaseContext db;

        public ItemRepository(DataBaseContext db)
        {
            this.db = db;
        }
        
        public Item getItemByID(Guid itemID)
        {
            Item item = db.Items.Find(itemID);
            return item;
        }

        public Item getItemByName(string name)
        {
            Item item = db.Items.Where(i => i.ItemName == name).FirstOrDefault();
            return item;
        }

        public void addItem(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
        }

        public void removeItem(Item item)
        {
            db.Items.Remove(item);
            db.SaveChanges();
        }

        public void updateItem(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
