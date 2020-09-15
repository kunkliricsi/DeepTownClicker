namespace DeepTownClicker.Layer2.Interfaces
{
    public interface ILogger
    {
        void Write(char message);
        void Write(string message);
        void WriteLine();
        void WriteLine(char message);
        void WriteLine(string message);
    }
}