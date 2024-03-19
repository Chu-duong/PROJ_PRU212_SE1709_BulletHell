using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    PAUSE,
    INGAME,
    MENU
}

public class GameState : MonoBehaviour
{
    private static State currentState = State.MENU;

    public static void Set(State state)
    {
        currentState = state;
    }

    public static State Current()
    {
        return currentState;
    }
}
