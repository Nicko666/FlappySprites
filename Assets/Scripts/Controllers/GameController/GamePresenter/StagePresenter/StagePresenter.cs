using System;

internal class StagePresenter
{
    internal Action onInputMenu;
    internal Action onInputPlay;
    internal Action onInputRecord;

    internal void OutputStageModel(StageModel stageModel)
    {
        Action action = stageModel switch
        {
            StageModel.Menu => onInputMenu,
            StageModel.Play => onInputPlay,
            StageModel.Record => onInputRecord,
            _ => onInputMenu
        };
        action.Invoke();
    }
}
