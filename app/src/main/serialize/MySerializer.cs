namespace app.main.serialize;

public abstract class MySerializer<T>
{
    public abstract T Read(string filename);

    public abstract bool Write(T t, string filename);
}