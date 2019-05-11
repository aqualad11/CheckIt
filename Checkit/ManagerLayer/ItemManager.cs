﻿using System;
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



            //update item on database
            bool update = itemService.UpdateItem(item);
            if(!update)
            {
                throw new UpdateFailed("Item Failed to Update");
            }

        }
    }
}
