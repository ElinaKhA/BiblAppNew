using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiblApp
{
    public class UserRepository
    {
        SQLiteConnection database;
        public UserRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<User>();
            database.CreateTable<Book>();
        }
        public IEnumerable<User> GetItems()
        {
            return database.Table<User>().ToList();
        }
        public User GetItem(int id)
        {
            return database.Get<User>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<User>(id);
        }
        public int SaveItem(User item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }


        public IEnumerable<Book> GetBooks()
        {
            return database.Table<Book>().ToList();
        }
        public Book GetBook(int id)
        {
            return database.Get<Book>(id);
        }
        public int DeleteBook(int id)
        {
            return database.Delete<Book>(id);
        }
        public int SaveBook(Book item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
