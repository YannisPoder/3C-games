using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    GameContext gameContext;
    private void Awake()
    {
        gameContext = CreateContext();

        InitializeScene();
    }

    private GameContext CreateContext()
    {
        EventBus events = new();

        return new GameContext(events);
    }

    private void InitializeScene()
    {
        MonoBehaviour[] behaviours = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);

        foreach(MonoBehaviour behaviour in behaviours)
        {
            if(behaviour is IContextInitialise initializable)
            {
                initializable.Initialise(gameContext.EventBus);
            }
        }
    }
}
