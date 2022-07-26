using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIModule : GameModule
{
    public static GameObject MainCanvas;
    private static Transform _content;

    private static Dictionary<string, GameObject> _displayedUI;

    public override void OnRegister()
    {
        CreateMainCanvas();
        _displayedUI = new Dictionary<string, GameObject>();
    }

    private static void CreateMainCanvas()
    {
        MainCanvas = Instantiate(Resources.Load<GameObject>("Defaults/MainCanvas"));
        MainCanvas.name = "MainCanvas";
        _content = MainCanvas.transform.GetChild(0);
        DontDestroyOnLoad(MainCanvas);
    }

    public static GameObject ShowUI(GameObject go)
    {
        string id = go.name;
        if (_displayedUI.ContainsKey(go.name))
        {
            _displayedUI[go.name].transform.SetAsLastSibling();
            return _displayedUI[go.name];
        }
        go = Instantiate(go, _content, false);
        go.transform.SetAsLastSibling();
        go.name = id;
        _displayedUI.Add(id, go);
        return go;
    }

    public static void DestroyUI(string id)
    {
        if (!_displayedUI.ContainsKey(id))
        {
            Debug.Log($"no {id} exists.");
            return;
        }

        Destroy(_displayedUI[id]);
        _displayedUI.Remove(id);
    }

    public static void DestroyUI(GameObject go)
    {
        DestroyUI(go.name);
    }

    public override void OnUnregister()
    {
        //
    }
}
