using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private DataBaseContext db;

        public ItemRepository(DataBaseContext db)
        {
            this.db = db;
        }
        
        /// <summary>
        /// Gets Item using the item's ID.
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns>Item, or null if it doesn't exist.</returns>
        public Item GetItemByID(Guid itemID)
        {
            Item item = db.Items.Find(itemID);
            return item;
        }

        /// <summary>
        /// Gets Item using the item's name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Item, or null if it doesn't exist.</returns>
        public Item GetItemByName(string name)
        {
            Item item = db.Items.Where(i => i.ItemName == name).FirstOrDefault();
            return item;
        }

        /// <summary>
        /// Adds an Item to the repository
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
        }

        /// <summary>
        /// Updates existing Item in database
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="System.Data.Entity.Infrastructure.DbUpdateConcurrencyException">Thrown when item does not exist in database.</exception>
        public void RemoveItem(Item item)
        {
            db.Items.Remove(item);
            db.SaveChanges();
        }

        /// <summary>
        /// Removes Item
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="System.InvalidOperationException">Thrown when trying to delete non existing Item from database.</exception>
        public void UpdateItem(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
