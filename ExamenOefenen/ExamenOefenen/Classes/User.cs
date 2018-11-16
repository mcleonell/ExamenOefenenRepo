﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenOefenen
{
    class User
    {
        public int UserID { get; private set; }
        public string Username { get; private set; }

        public User()
        {

        }

        public string GetUser()
        {
            Database db = new Database();
            return db.GetColumn("users", "username", "userID = " + UserID).ToString();
        }

        public static List<User> GetUserList()
        {
            List<User> users = new List<User>();

            Database db = new Database();

            List<int> userIDList()
            {
                List<int> userIDs = new List<int>();
                foreach (var userId in db.GetColumn("users", "userID", " 1 = 1 "))
                {
                    userIDs.Add((int)userId);
                }
                return userIDs;
            }

            List<string> usernameList()
            {
                List<string> usernames = new List<string>();
                foreach (var username in db.GetColumn("users", "userName", " 1 = 1 "))
                {
                    usernames.Add(username.ToString());
                }
                return usernames;
            }

            for (int i = 0; i < db.GetColumn("users", "userID", " 1 = 1 ").Count; i++)
            {
                User u = new User();
                u.UserID = userIDList()[i];
                u.Username = usernameList()[i];
                users.Add(u);
            }

            return users;
        }

        public List<Vak> VakkenVoorCurrentUser(int userID)
        {
            List<Vak> v = new List<Vak>();

            //TODO - Laat Vak.CurrentUserVakkenLijst(userID);

            return v;
        }

        public void CreateUser(string _input)
        {
            Database db = new Database();
            db.AddToColumn("users", "username", _input);
        }
    }
}
