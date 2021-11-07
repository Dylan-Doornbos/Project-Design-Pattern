using UnityEngine;

public class PlayerAirborne : IState
{
    private Rigidbody2D _rb;
    private float _diveForce;

    public PlayerAirborne(Rigidbody2D rb, float diveForce)
    {
        _rb = rb;
        _diveForce = diveForce;
    }
    
    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 diveVelocity = new Vector2(0, -_diveForce);

            _rb.velocity = diveVelocity;
        }
    }

    public void OnEnter() { }

    public void OnExit() { }
}
