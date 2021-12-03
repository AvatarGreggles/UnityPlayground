using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Battle, Dialog, Cutscene, Paused }
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerMovement2DTopDown playerMovement2DTopDown;

    public GameState state;

    GameState stateBeforePause;


    public static GameController Instance { get; private set; }
    public PlayerMovement2DTopDown PlayerMovement2DTopDown { get => playerMovement2DTopDown; set => playerMovement2DTopDown = value; }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        DialogManager.Instance.OnShowDialog += () =>
              {
                  state = GameState.Dialog;
              };

        DialogManager.Instance.OnCloseDialog += () =>
        {
            if (state == GameState.Dialog)
                state = GameState.FreeRoam;
        };
    }

    public void PauseGame(bool pause)
    {
        if (pause)
        {
            stateBeforePause = state;
            state = GameState.Paused;
        }
        else
        {
            state = stateBeforePause;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (state == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();
        }
    }

    private void FixedUpdate()
    {
        if (state == GameState.FreeRoam)
        {
            playerMovement2DTopDown.HandleUpdate();
        }
    }
}
