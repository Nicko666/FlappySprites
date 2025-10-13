using System;

public interface IProjectPresenter
{
    public event Action onInputLoadDatabase;
    public event Action onInputLoadData;
    public event Action onInputSaveData;
    public event Action onInputLogIn;
}
