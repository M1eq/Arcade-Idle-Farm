using UnityEngine;

public class BootstrapState : IState
{
    private readonly IGameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;

    public BootstrapState(IGameStateMachine gameStateMachine, SceneLoader sceneLoader)
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
    }

    public void Enter() =>
        _sceneLoader.LoadScene(SceneNames.INITIAL_SCENE, OnInitialSceneLoaded);
    
    public void Exit() { }

    private void OnInitialSceneLoaded() =>
        Debug.Log("Initial Scene Loaded");
}
