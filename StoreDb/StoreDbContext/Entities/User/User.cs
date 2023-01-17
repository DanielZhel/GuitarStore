using System;

namespace StoreDb.StoreDbContext.Entities.User
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
         public string Surname { get; set; }

    }
}
