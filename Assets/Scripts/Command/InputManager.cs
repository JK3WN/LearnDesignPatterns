using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] Button forwardBtn;
    [SerializeField] Button backBtn;
    [SerializeField] Button leftBtn;
    [SerializeField] Button rightBtn;
    [SerializeField] Button undoBtn;
    [SerializeField] Button redoBtn;
    [SerializeField] private PlayerMover player;

    private void Start()
    {
        forwardBtn.onClick.AddListener(OnForwardInput);
        backBtn.onClick.AddListener(OnBackInput);
        leftBtn.onClick.AddListener(OnLeftInput);
        rightBtn.onClick.AddListener(OnRightInput);
        undoBtn.onClick.AddListener(OnUndoInput);
        redoBtn.onClick.AddListener(OnRedoInput);
    }

    private void OnForwardInput()
    {
        RunPlayerCommand(player, Vector3.forward);
    }
    
    private void OnBackInput()
    {
        RunPlayerCommand(player, Vector3.back);
    }

    private void OnLeftInput()
    {
        RunPlayerCommand(player, Vector3.left);
    }

    private void OnRightInput()
    {
        RunPlayerCommand(player, Vector3.right);
    }

    private void OnUndoInput()
    {
        CommandInvoker.UndoCommand();
    }

    private void OnRedoInput()
    {
        CommandInvoker.RedoCommand();
    }

    private void RunPlayerCommand(PlayerMover playerMover, Vector3 movement)
    {
        if (playerMover == null) return;
        if (playerMover.IsValidMove(movement))
        {
            ICommand command = new MoveCommand(playerMover, movement);
            CommandInvoker.ExecuteCommand(command);
        }
    }
}
