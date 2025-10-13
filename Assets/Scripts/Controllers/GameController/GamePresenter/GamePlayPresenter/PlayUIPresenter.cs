using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

internal class PlayUIPresenter : MonoBehaviour
{
    [SerializeField] private Panel _panel;
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private TMP_Text _speedText;
    [SerializeField] private Button _jumpButton;

    internal event UnityAction onInputJump
    {
        add => _jumpButton.onClick.AddListener(value);
        remove => _jumpButton.onClick.RemoveListener(value);
    }

    internal void OutputPanel(bool value) =>
        _panel.OutputOpen(value);

    internal void OutputCurrentPointsModel(int points) =>
        _pointsText.text = points.ToString();

    internal void OutputSpeed(float speed) =>
        _speedText.text = String.Format("{0:0.00}", speed);
}