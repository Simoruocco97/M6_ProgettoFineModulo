using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Vector2 MovementSystem { get; private set; }
    public bool IsActive {get; private set;} = true;

    private void Update()
    {
        if (!IsActive)
        {
            MovementSystem = Vector2.zero;
            return;
        }

        MovementSystem = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    public void StopInput() => IsActive = false;
}