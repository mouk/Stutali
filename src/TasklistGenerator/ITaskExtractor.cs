namespace TasklistGenerator
{
    public interface ITaskExtractor
    {
        TaskToken Extract(string line);
        int Priority { get; set; }
    }
}