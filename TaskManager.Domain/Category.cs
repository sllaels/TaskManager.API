using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain
{
   public class Category
    {
        public int Id { get; set; }
        public string Tittle { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId {  get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(TaskEntity))]
        public int TaskId { get; set; }
        public  TaskEntity TaskEntity { get; set; }
    }
}
