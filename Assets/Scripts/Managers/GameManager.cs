using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager s_instance;
    public static GameManager GetInstance { get { Init(); return s_instance; } }

    InputManager _input = new InputManager();
    public static InputManager Input { get { return GetInstance._input; } }

    UIManager uiManager;
    public static UIManager UI { get { return GetInstance.uiManager; } }

    void Start()
    {
        Init();
        uiManager = GetComponent<UIManager>();
    }

    void Update()
    {
        _input.OnUpdate();
    }

    static void Init()
    {
        if(s_instance == null)
        {
            GameObject go = GameObject.Find("@GameManager");
            if(go == null)
            {
                go = new GameObject { name = "@GameManager" };
                go.AddComponent<GameManager>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<GameManager>();
        }
    }
}
