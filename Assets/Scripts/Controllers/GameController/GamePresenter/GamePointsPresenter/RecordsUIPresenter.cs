using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RecordsUIPresenter : MonoBehaviour
{
    [SerializeField] private Panel _panel;
    [SerializeField] private Button _menuButton;
    [SerializeField] private GameObject _newRecordPointsObject;
    [SerializeField] private TMP_Text _currentPointsText;
    
    internal event UnityAction onInputMenu
    {
        add => _menuButton.onClick.AddListener(value);
        remove => _menuButton.onClick.RemoveListener(value);
    }

    internal void OutputPanel(bool value)
    {
        _panel.OutputOpen(value);

        if (!value)
            _newRecordPointsObject.SetActive(false);
    }

    internal void OutputCurrentPointsModel(int points) =>
        _currentPointsText.text = points.ToString();

    internal void OutputNewRecordModel() =>
        _newRecordPointsObject.SetActive(true);
}
