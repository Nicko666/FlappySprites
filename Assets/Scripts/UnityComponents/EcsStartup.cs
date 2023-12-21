using Leopotam.Ecs;
using UnityEngine;

public class EcsStartup : MonoBehaviour
{
    public StaticData staticData;
    public SceneData sceneData;
    public SceneEvents sceneEvents;
    public GooglePlayData googlePlayData;

    private FileDataHandler<SettingsData> settingsDataHandler;
    private SettingsData settingsData;
    private FileDataHandler<LocalData> localDataHandler;
    private LocalData localData;

    private EcsWorld ecsWorld;
    private EcsSystems initSystems;
    private EcsSystems updateSystems;

    private void Start()
    {
        ecsWorld = new EcsWorld();
        updateSystems = new EcsSystems(ecsWorld);
        initSystems = new EcsSystems(ecsWorld);
        RuntimeData runtimeData = new RuntimeData();

        //load
        Load();

        initSystems
            .Add(new PlayerInitSystem())
            .Add(new PlayerCollisionSystem())
            .Add(new PlayerMoveSystem())
            .Add(new PlayerThemeSystem())
            .Add(new CurrentPointsSystem())
            .Add(new RecordPointSystem())
            .Add(new WorldThemeSystem())
            .Add(new ObstacleInitSystem())
            .Add(new TimeControlSystem())
            .Inject(staticData)
            .Inject(sceneData)
            .Inject(sceneEvents)
            .Inject(googlePlayData)
            .Inject(settingsData)
            .Inject(localData)
            .Inject(runtimeData);

        updateSystems
            .Add(new PlayerAnimationSystem())
            //.Add(new PlayerGravityMultiplyerSystem())
            .Inject(sceneEvents);

        initSystems.Init();
        updateSystems.Init();

        //start game
        sceneEvents.MenuNotify();

    }

    private void Update()
    {
        updateSystems?.Run();
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
        initSystems?.Destroy();
        initSystems = null;

        updateSystems?.Destroy();
        updateSystems = null;
        
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