using System.Collections.Generic;
using ToDoList;
using MySql.Data.MySqlClient;

namespace ToDoList.Models
{
    public class Item
    {
        private string _description;
        private int _id;

        public Item(string description)
        {
            _description = description;
            // _id = _instances.Count;
        }

        public string GetDescription()
        {
            return _description;
        }

        public void SetDescription(string newDescription)
        {
            _description = newDescription;
        }

        public int GetId()
        {
          return _id;
        }

        public static List<Item> GetAll()
        {
          List<Item> allItems = new List<Item> { };
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM items;";
          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
            int itemId = rdr.GetInt32(0);
            string itemDescription = rdr.GetString(1);
            // Line below now only provides one argument!
            Item newItem = new Item(itemDescription);
            allItems.Add(newItem);
          }
          conn.Close();
          if (conn != null)
          {
            conn.Dispose();
          }
          return allItems;
        }

        public static void ClearAll()
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"DELETE FROM items;";
          conn.Close();
          if(conn != null)
          {
            conn.Dispose();
          }

        }

        public static Item Find(int searchId)
        {
          // return _instances[searchId-1];
          Item dummItem = new Item("dummy item");
            return dummItem;
        }

    }
}
