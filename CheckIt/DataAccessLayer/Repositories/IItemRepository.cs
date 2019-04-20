using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    public interface IItemRepository
    {
        Item GetItemByID(Guid itemID);
        Item GetItemByName(string name);

        void AddItem(Item item);
        void UpdateItem(Item item);
        void RemoveItem(Item item);
    }
}
