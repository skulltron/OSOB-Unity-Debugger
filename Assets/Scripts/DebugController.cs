using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugController : MonoBehaviour
{
    bool ShowConsole;

    string Input;

    public static DebugCommand IAMALONE, AKUSUGIH;

    public List<object> CommandList;

    public void OnReturn(InputValue Value)
    {
        if (ShowConsole)
        {
            HandleInput();
            Input = "";
        }
    }

    private void Awake()
    {
        IAMALONE = new DebugCommand("iamalone", "Removes all heroes from the scene.", "iamalone", () => {
            Enemy.DieAll();
            Debug.Log("All Killed");
        });

        AKUSUGIH = new DebugCommand("akusugih", "Mendadak jadi sugih", "akusugih", () => {
            //Controller.instance.MONEY += 99999;
            Debug.Log("Added Gold");
        });

        CommandList = new List<object>
        {
            IAMALONE,
            AKUSUGIH
        };
    }

    private void OnDebug(InputValue Value)
    {
        ShowConsole = !ShowConsole;
    }

    private void OnGUI()
    {
        if(!ShowConsole) { return; }

        float y = 0f;

        GUI.Box(new Rect(0, y, Screen.width, 30), "");

        GUI.backgroundColor = new Color(0, 0, 0, 0);
        Input               = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), Input);
    }

    private void HandleInput()
    {
        for(byte i = 0; i < CommandList.Count; i++)
        {
            DebugCommandBase CommandBase = CommandList[i] as DebugCommandBase;

            if (Input.Contains(CommandBase.CommandID))
            {
                if(CommandList[i] as DebugCommand != null)
                {
                    (CommandList[i] as DebugCommand).Invoke();
                }
            }
        }
    }
}
