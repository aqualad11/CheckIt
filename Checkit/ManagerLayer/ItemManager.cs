using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.DataAccessLayer;
using CheckIt.ServiceLayer;

namespace CheckIt.ManagerLayer
{
    public class ItemManager
    {
        private ItemService itemService;
        private ItemListService itemlistService;

        public ItemManager(DataBaseContext db)
        {
            itemService = new ItemService(db);
            itemlistService = new ItemListService(db);
        }


        public void UpdateItemAndAlert(string itemName, double price)
        {
            var item = itemService.GetItem(itemName);
            if (item == null)
            {
                throw new ItemDoesNotExistException("Item does not exist in our database.");
            }

            //Get all users which have item in their list
            var users = itemlistService.GetUsersByItemID(item.itemID);

            //Setup for variables for email
            var emailService = new EmailService();
            string subject = "GOOD NEWS FROM CHECKIT!";
            string message = "An item in your wishlist has lowered in price! The item "
                + item.ItemName + " originally priced at $" + item.price + " has dropped to $" + price + ".";

            //send alert
            emailService.SendAlertMail(users, subject, message);

            //update item
            item.price = price;
            itemService.UpdateItem(item);
        }

        public void UpdateItem(string itemName, double price, string url, string picKey)
        {
            var item = itemService.GetItem(itemName);
            if (item == null)
            {
                throw new ItemDoesNotExistException("Item does not exist in our database.");
            }

            //updateItem
            item.price = price;
            item.url = url == null ? item.url : url;
            item.picKey = picKey == null ? item.picKey : picKey;

            //update item on database
            bool update = itemService.UpdateItem(item);
            if(!update)
            {
                throw new UpdateFailed("Item Failed to Update");
            }

        }

        public void AddItemToList(string itemName, double price, string url, string picKey, Guid userID)
        {
            var item = itemService.GetItem(itemName);
            if(item == null)
            {
                Item newItem = new Item(itemName, price, url, picKey);
                itemService.AddItem(newItem);
                item = itemService.GetItem(itemName);
            }

            ItemList itemlist = new ItemList(userID, item.itemID);
            if(!itemlistService.AddItemList(itemlist))
            {
                throw new AddFailedException("Failed to add item to list.");
            }
        }

        public List<Item> GetItemsFromWatchList(Guid userID)
        {
            return itemlistService.GetItemsByUserID(userID);
        }
    }
}
