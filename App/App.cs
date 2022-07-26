using UnityEngine;

public static class App
{
    public static Modules Modules;
    
    /// <summary>
    /// Game Entry Point
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    public static void Start()
    {
        Modules = new Modules();
        
        Modules.Register<InputModule>();
        Modules.Register<EventModule>();
        Modules.Register<SaveModule>();
        Modules.Register<BlackboardModule>();
        Modules.Register<UIModule>();
        
        Debug.Log("Property Tycoon");
    }
}
