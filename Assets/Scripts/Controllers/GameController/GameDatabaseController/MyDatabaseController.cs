using System;

public class MyDatabaseController<T>
{
    private T _database;

    public Action<T> onLoadDatabase;

    public MyDatabaseController(T database) =>
        _database = database;

    public void LoadDatabase() =>
        onLoadDatabase.Invoke(_database);
}
