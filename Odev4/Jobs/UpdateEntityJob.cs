using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Entities.DataModel;
using Hangfire;
using Microsoft.Data.SqlClient;

namespace Odev4.Jobs
{
    public class UpdateEntityJob
    {
        public UpdateEntityJob()
        {
            //Her gün saat 18:00'da çalışacak şekilde Cron tanımı olan Recurring Job'u tetiklemek.
            RecurringJob.AddOrUpdate(()=>DoJob(), "0 18 * * *");
        }

        public void DoJob()
        {
            //Aynı gün içinde 08:00'dan 18:00'a kadar eklenen userların Status değeri Inactive olacağı için
            //Status=Inactive olan tüm userlar seçildi.
            List<User> users = Select("Inactive");
            foreach (var item in users)
            {
                //Seçilen tüm userların Status değeri Active olarak değiştirildi ve güncellendi.
                item.Status = "Active";
                Update(item);
            }
        }

        //Dapper kullanılarak yapılan Listeleme işlemi
        public List<User> Select(string status)
        {
            var sql = "SELECT * FROM Users WHERE Status=@Status";
            IEnumerable<User> list;
            using (var connection=new SqlConnection("Server=LAPTOP-58K1GN78; Database=HW4DB;Trusted_Connection=True;"))
            {
                connection.Open();
                list=connection.Query<User>(sql, new {Status = status});
            }

            return list.ToList();
        }

        //Dapper kullanılarak yapılan Güncelleme işlemi
        public void Update(User entity)
        {
            var sql = "UPDATE Users SET FirstName=@FirstName,LastName=@LastName, Status=@Status WHERE Id=@Id";
            using (var connection = new SqlConnection("Server=LAPTOP-58K1GN78; Database=HW4DB;Trusted_Connection=True;"))
            {
                connection.Open();
                connection.Execute(sql, entity);
            }
        }
    }
}
