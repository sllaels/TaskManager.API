using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Contracts
{
    public class TaskRequest
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string?  Descriptoin { get; set; }
        public string? Category { get; set; }
        public string? Prioritet { get; set; }
        public DateTime Date { get; set; }
    }
}
