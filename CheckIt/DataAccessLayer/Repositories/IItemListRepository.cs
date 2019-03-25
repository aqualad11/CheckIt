using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    interface IItemListRepository
    {
        ItemList getItemListByID(Guid itemlistID);
        List<ItemList> getItemListsByUserID(Guid userID);
        List<Item> getListOfItemsByUserID(Guid userID);

        void addItemList(ItemList itemlist);
        void updateItemList(ItemList itemList);
        void removeItemList(ItemList itemlist);
    }
}
