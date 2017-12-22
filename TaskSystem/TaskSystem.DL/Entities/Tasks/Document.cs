namespace TaskSystem.DL.Entities.Tasks
{
    public class Document : IPkidEntity
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public User User { get; set; }

        public int WorkTaskId { get; set; }
        public WorkTask WorkTask { get; set; }
    }
}
