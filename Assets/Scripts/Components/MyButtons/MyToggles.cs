using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MyToggles : MonoBehaviour
{
    [SerializeField] private MyToggle _buttonPrefab;
    [SerializeField] private ScrollRect _scrollRect;

    [SerializeField] private List<ToggleModel> _list = new();

    public Action<int> onInput;

    public void OutputModels(List<(int id, Sprite icon)> buttonsModel)
    {
        for (int i = 0; i < _list.Count; i++)
        {
            ToggleModel buttonModel = _list[i];
            _list[i].button.onClick -= Input;
        }

        while (_list.Count > buttonsModel.Count)
        {
            ToggleModel buttonModel = _list[_list.Count - 1];
            _list.Remove(buttonModel);
            Destroy(buttonModel.button.gameObject);
        }
        while (_list.Count < buttonsModel.Count)
        {
            var button = Instantiate(_buttonPrefab, _scrollRect.content);
            _list.Add(new(button, 0));
        }

        for (int i = 0; i < buttonsModel.Count; i++)
        {
            _list[i].button.onClick += Input;
            _list[i].button.OutputIcon(buttonsModel[i].icon);
            _list[i] = new(_list[i].button, buttonsModel[i].id);
        }
    }

    public void OutputModel(int id) =>
        _list.ForEach(i => i.button.OutputToggled(id == i.id));

    private void Input(MyToggle button)
    {
        int hashCode = _list.Find(x => x.button == button).id;
        onInput.Invoke(hashCode);
    }

    [Serializable]
    class ToggleModel
    {
        [field: SerializeField] internal MyToggle button { get; private set; }
        [field: SerializeField] internal int id { get; private set; }

        internal ToggleModel(MyToggle button, int id)
        {
            this.button = button;
            this.id = id;
        }
    }
}
