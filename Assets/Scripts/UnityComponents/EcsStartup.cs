using Leopotam.Ecs;
using UnityEngine;

public class EcsStartup : MonoBehaviour
{
    public StaticData staticData;
    public SceneData sceneData;
    public SceneEvents sceneEvents;

    private FileDataHandler<SettingsData> settingsDataHandler;
    private SettingsData settingsData;
    private FileDataHandler<LocalData> localDataHandler;
    private LocalData localData;

    private EcsWorld ecsWorld;
    private EcsSystems updateSystems;
    private EcsSystems fixedUpdateSystems;

    private void Start()
    {
        ecsWorld = new EcsWorld();
        updateSystems = new EcsSystems(ecsWorld);
        fixedUpdateSystems = new EcsSystems(ecsWorld);
        RuntimeData runtimeData = new RuntimeData();

        //load
        Load();

        updateSystems
            .Add(new PlayerInitSystem())
            .Add(new PlayerCollisionSystem())
            .Add(new PlayerAnimationSystem())
            .Add(new PlayerMoveSystem())
            //.Add(new PlayerGravityMultiplyerSystem())
            .Add(new PlayerThemeSystem())
            .Add(new CurrentPointsSystem())
            .Add(new RecordPointSystem())
            .Add(new WorldThemeSystem())
            .Inject(staticData)
            .Inject(sceneData)
            .Inject(sceneEvents)
            .Inject(settingsData)
            .Inject(localData)
            .Inject(runtimeData);

        fixedUpdateSystems
            .Add(new TimeControlSystem())
            .Add(new ObstacleInitSystem())
            .Inject(staticData)
            .Inject(sceneData)
            .Inject(sceneEvents)
            .Inject(settingsData)
            .Inject(localData)
            .Inject(runtimeData);

        updateSystems.Init();
        fixedUpdateSystems.Init();

        //start game
        sceneEvents.MenuNotify();

    }

    private void Update()
    {
        updateSystems?.Run();
    }

    private void FixedUpdate()
    {
        fixedUpdateSystems?.Run();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            //save
            Save();
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnDestroy()
    {
        updateSystems?.Destroy();
        updateSystems = null;

        fixedUpdateSystems?.Destroy();
        fixedUpdateSystems = null;
        
        ecsWorld?.Destroy();
        ecsWorld = null;
    }

    void Load()
    {
        settingsDataHandler = new(Application.persistentDataPath, "settingsData");
        settingsData = settingsDataHandler.Load();
        if (settingsData == null)
            settingsData = new();
        
        localDataHandler = new(Application.persistentDataPath, "localData ", staticData.encryptionCodeWord);
        localData = localDataHandler.Load();
        if (localData == null)
            localData = new();
    }

    void Save()
    {
        settingsDataHandler.Save(settingsData);
        localDataHandler.Save(localData);
       
        Debug.Log("Data saved");
    }

}