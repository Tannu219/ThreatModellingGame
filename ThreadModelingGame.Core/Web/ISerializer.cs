namespace ThreadModelingGame.Core.Web
{
    public interface ISerializer
    {
        string Serialize<T>(T obj);
        T Deserialize<T>(string value);
    }
}