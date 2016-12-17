using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UserContext db = new UserContext())
            {
                // создаем два объекта User
                User user1 = new User();
                user1.Name = "Tom";

                user1.Age = 33;
                user1.phones.Add(new Phone{number = "123-45-67"});
                user1.phones.Add(new Phone { number = "123-45-68" });
                User user2 = new User { Name = "Sam", Age = 26 };
               
                // добавляем их в бд
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var users = db.Users;
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach(var phone in u.phones)
                        sb.Append(phone.number).Append(" ");
                    Console.WriteLine("{0} - {1} {2}", u.Name, u.Age, sb.ToString().Trim());
                }
            }
            Console.Read();
        }
    }
}
