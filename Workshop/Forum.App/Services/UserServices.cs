using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forum.App.Contracts;
using Forum.Data;
using Forum.DataModels;

namespace Forum.App.Services
{
   public class UserServices : IUserService
   {
       private ForumData forumData;
       private ISession session;

        public UserServices(ForumData forumData, ISession session)
        {
            this.forumData = forumData;
            this.session = session;
        }

        public bool TrySignUpUser(string username, string password)
        {
            bool validUsername = !string.IsNullOrWhiteSpace(username) && password.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(username) && password.Length > 3;
            if (!validPassword || !validUsername)
            {
                throw new ArgumentException("Username and Password must be longer than 3 symbols!");
            }

            bool userAlreadyexists = forumData.Users.Any(p => p.Username == username);

            if (userAlreadyexists)
            {
                throw new InvalidOperationException("Username taken!");
            }

            int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
            User user = new User(userId, username, password);
            forumData.Users.Add(user);
            forumData.SaveChanges();
            this.TryLogInUser(username, password);
            return true;

        }

        public bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            User user = this.forumData.Users.FirstOrDefault(p => p.Username == username && p.Password == password);
            if (user == null)
            {
                return false;
            }

            session.Reset();
            session.LogIn(user);

            return true;

        }

        public string GetUserName(int userId)
        {
            var name = this.forumData.Users.Find(p => p.Id == userId).Username;
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("No such name exists in database");
            }

            return name;
        }

        public User GetUserById(int userId)
        {
            var user = this.forumData.Users.Find(p => p.Id == userId);
            if(user == null)
            {
                throw new ArgumentException("No such user exists in database");
            }
            return user;
        }

      
   }
}
