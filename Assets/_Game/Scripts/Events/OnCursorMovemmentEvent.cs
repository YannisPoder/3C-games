using UnityEngine;

public class OnCursorMovemmentEvent
{
    public Vector2 Direction {  get; private set; }
    public float Speed { get; private set; }

    public OnCursorMovemmentEvent(Vector2 direction, float speed)
    {
        Direction = direction; Speed = speed;
    }

}
