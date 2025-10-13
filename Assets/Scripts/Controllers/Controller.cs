using System;
using UnityEngine;

public class Controller : IDisposable
{
    protected IProjectPresenter _loadingPresenter;
    protected GooglePlayController _googlePlayController = new GooglePlayController();

    public Controller(
        IProjectPresenter loadingPresenter
        )
    {
        Application.targetFrameRate = 60;

        _loadingPresenter = loadingPresenter;

        _loadingPresenter.onInputLoadData += _googlePlayController.SetGooglePlayLogIn;
    }
    public virtual void Dispose()
    {
        _loadingPresenter.onInputLoadData -= _googlePlayController.SetGooglePlayLogIn;
    }
}
