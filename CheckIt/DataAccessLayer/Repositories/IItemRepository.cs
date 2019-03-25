using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    interface IItemRepository
    {
        Item getItemByID(Guid itemID);
        Item getItemByName(string name);

        void addItem(Item item);
        void updateItem(Item item);
        void removeItem(Item item);
    }
}
