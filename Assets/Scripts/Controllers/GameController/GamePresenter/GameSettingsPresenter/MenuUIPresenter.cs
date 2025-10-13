using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class MenuUIPresenter : MonoBehaviour
{
    [SerializeField] private Panel _panel;
    [SerializeField] private Panel _themesPanel;
    [SerializeField] private Button _bottomPanelOpenButton;
    [SerializeField] private Button _recordsButton;
    [SerializeField] private Button _bottomPanelCloseButton;
    [SerializeField] private Button _playButton;
    [SerializeField] private MyToggles _playerThemesToggles;
    [SerializeField] private MyToggles _worldThemesToggles;
    [SerializeField] private TMP_Text _pointsText;
    private PlayerThemeModel[] _playerThemesModel;
    private WorldThemeModel[] _worldThemesModel;

    internal event UnityAction onInputPlay
    {
        add => _playButton.onClick.AddListener(value);
        remove => _playButton.onClick.RemoveListener(value);
    }
    internal event UnityAction onInputRecords
    {
        add => _recordsButton.onClick.AddListener(value);
        remove => _recordsButton.onClick.RemoveListener(value);
    }
    internal Action<PlayerThemeModel> onInputPlayerThemeModel;
    internal Action<WorldThemeModel> onInputWorldThemeModel;

    internal void OutputSettingsDatabase(GameDatabase gameModel)
    {
        _playerThemesModel = gameModel.PlayerThemeModels;
        List<(int, Sprite)> playerButtonsModel = new();
        Array.ForEach(_playerThemesModel, i => playerButtonsModel.Add(new(i.ID, i.Icon)));
        _playerThemesToggles.OutputModels(playerButtonsModel);
        
        _worldThemesModel = gameModel.WorldThemeModels;
        List<(int, Sprite)> worldButtonsModel = new();
        Array.ForEach(_worldThemesModel, i => worldButtonsModel.Add(new(i.ID, i.Icon)));
        _worldThemesToggles.OutputModels(worldButtonsModel);
    }

    internal void OutputPlayerThemeModel(PlayerThemeModel playerThemeModel) =>
        _playerThemesToggles.OutputModel(playerThemeModel.ID);

    internal void OutputWorldThemeModel(WorldThemeModel worldThemeModel) => 
        _worldThemesToggles.OutputModel(worldThemeModel.ID);
    
    internal void OutputPanel(bool value)
    {
        _panel.OutputOpen(value);
        _themesPanel.OutputOpen(false);
    }

    internal void OutputNewRecordModel(int value) =>
        _pointsText.text = value.ToString();

    private void Awake()
    {
        _playerThemesToggles.onInput += InputPlayerThemeToggle;
        _worldThemesToggles.onInput += InputWorldThemeToggle;
        _themesPanel.onPanelOpen += OutputBottomPanelOpen;
        _bottomPanelOpenButton.onClick.AddListener(InputBottomPanelOpen);
        _bottomPanelCloseButton.onClick.AddListener(InputBottomPanelClose);
    }
    private void OnDestroy()
    {
        _playerThemesToggles.onInput -= InputPlayerThemeToggle;
        _worldThemesToggles.onInput -= InputWorldThemeToggle;
        _themesPanel.onPanelOpen -= OutputBottomPanelOpen;
        _bottomPanelOpenButton.onClick.RemoveListener(InputBottomPanelOpen);
        _bottomPanelCloseButton.onClick.RemoveListener(InputBottomPanelClose);
    }

    private void InputPlayerThemeToggle(int id) =>
        onInputPlayerThemeModel.Invoke(Array.Find(_playerThemesModel, i => id == i.ID));

    private void InputWorldThemeToggle(int id) =>
        onInputWorldThemeModel.Invoke(Array.Find(_worldThemesModel, i => id == i.ID));

    private void OutputBottomPanelOpen(bool isOpen)
    {
        _bottomPanelOpenButton.interactable = !isOpen;
        _bottomPanelCloseButton.gameObject.SetActive(isOpen);
    }

    private void InputBottomPanelOpen()
    {
        _themesPanel.OutputOpen(true);
        _playButton.gameObject.SetActive(false);
    }
    
    private void InputBottomPanelClose()
    {
        _themesPanel.OutputOpen(false);
        _playButton.gameObject.SetActive(true);
    }
}