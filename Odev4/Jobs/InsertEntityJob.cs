using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Entities.DataModel;
using Hangfire;

namespace Odev4.Jobs
{
    public class InsertEntityJob
    {
        //Her gün saat 8-18 arası 15 dakika aralıklarla çalışacak job tanımı
        public InsertEntityJob()
        {
            RecurringJob.AddOrUpdate(()=>DoJob(), "*/15 8-18 * * *");       
        }

        public void DoJob()
        {
            //Database'e eklenecek yeni user oluşturuluyor.
            User item = new User
            {
                FirstName = RandomString(5),
                LastName = RandomString(6),
                Status="Inactive"
            };
            Add(item);
        }

        //Rastgele isim ve soyisim oluşturmak için kullanılan metot
        private static string RandomString(int length)
        {
            Random rnd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

        //Dapper kullanılarak yapılan ekleme işlemi.
        public void Add(User entity)
        {
            var sql = "Insert into Users(FirstName,Lastname,Status) VALUES(@FirstName,@LastName,@Status)";
            using (var connection=new SqlConnection("Server=LAPTOP-58K1GN78; Database=HW4DB;Trusted_Connection=True;"))
            {
                connection.Open();
                connection.Execute(sql, entity);
            }
        }
    }
}
