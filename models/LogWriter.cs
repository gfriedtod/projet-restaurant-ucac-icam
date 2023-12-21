namespace models;

public class LogWriter
{
    private StreamWriter _streamWriter;
    public LogWriter(StreamWriter streamWriter)
    {
        _streamWriter = streamWriter;
    }

    public void write(string data)
    {
        Console.WriteLine(data);
        
        
        _streamWriter.Write(data);
        _streamWriter.WriteLine(data);
    }
    
}
