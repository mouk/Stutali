namespace TasklistGenerator
{
    public interface ITaskExtractor
    {
        TaskToken Extract(string line);
    }
}