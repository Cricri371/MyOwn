namespace Cricri371.Framework.Configuration
{
    public interface IConfiguration
    {
        string Read(string key);

        bool Write(string key, string newValue);
    }
}