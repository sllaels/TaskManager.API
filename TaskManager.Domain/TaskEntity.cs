using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Domain
{
    public class TaskEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите название задачи")]
        public string Tittle { get; set; }
        public string? Descriptoin { get; set; }
        public string? Category { get; set; }
        public string? Prioritet { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int UserId {  get; set; }
    }
}
