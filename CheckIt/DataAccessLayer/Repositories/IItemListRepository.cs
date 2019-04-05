using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    public interface IItemListRepository
    {
        ItemList getItemList(Guid userID, Guid itemID);
        List<Item> getItemsByUserID(Guid userID);

        void addItemList(ItemList itemlist);
        void removeItemList(ItemList itemlist);
        void removeItemList(Guid userID, Guid itemID);
    }
}
