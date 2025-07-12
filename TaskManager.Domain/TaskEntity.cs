namespace TaskManager.Domain
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string? Descriptoin { get; set; }
        public string? Category { get; set; }
        public string? Prioritet { get; set; }
        public DateTime Date { get; set; }
    }
}
