using System;
using System.IO;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

    public class Credentials
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public static bool UserLog(string username, string password)
        {
            using (var db = new LiteDatabase(@".\Creds.db"))
            {
                // Username Check

                    var users = db.GetCollection<Credentials>("users");
                    users.EnsureIndex(x => x.Username);
                    var uResults = users.FindOne(x => x.Username == username);

                    if (uResults != null)
                    {
                        // Password Check

                        bool authentic = PasswordHash.ValidatePassword(password, uResults.Password);

                        if (authentic == true)
                        {
                        return true;

                        }
                        else
                        {
                        // Password Check Fail

                        return false;
                    }

                    }
                    else
                    {
                        // New User

                        NewUser(username, password);
                        return true;

                    }
                }
            }
        

        public static void NewUser(string username, string password)
        {
            using (var db = new LiteDatabase(@".\Creds.db"))
            {
            // Generating new account and applicable directories
                string newUser = username;
                string newPass = password;
                string passwordHash = PasswordHash.HashPassword(newPass);
                var users = db.GetCollection<Credentials>("users");
                string newServer = $@".\{newUser}";
                Directory.CreateDirectory(newServer);
            var User = new Credentials
            {
                    Id = Guid.NewGuid().ToString(),
                    Username = newUser,
                    Password = passwordHash,
                };
                users.Insert(User);
            }
        }
    }