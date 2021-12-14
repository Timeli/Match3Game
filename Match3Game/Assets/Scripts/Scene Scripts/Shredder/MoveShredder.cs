using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShredder : MonoBehaviour
{
    private List<Vector3> path = new List<Vector3>()
    {
        // Start position
        new Vector3(2.8f, -4.4f),

        // Horizontal points
        new Vector2(2f, -4.4f),
        new Vector2(1.2f, -4.4f),
        new Vector2(0.4f, -4.4f),
        new Vector2(-0.6f, -4.4f),
        new Vector2(-1.2f, -4.4f),
        new Vector2(-2f, -4.4f),

        // Vertical points
        new Vector2(-2.8f, -3.6f),
        new Vector2(-2.8f, -2.8f),
        new Vector2(-2.8f, -2f),
        new Vector2(-2.8f, -1.2f),
        new Vector2(-2.8f, -0.4f),
        new Vector2(-2.8f, 0.4f)
    };

    private Vector3 startPos = new Vector3(2.8f, -4.4f);

    private int _point = 0;
    private bool _isActive;

    private void Start()
    {
        Invoke("Switch", 1f);
    }

    private void Update()
    {
        if (Global.Grounded.Equals("AllGround") &&
           Global.Destroyer.Equals("Wait") && Global.MoveTwo.Equals("Wait") ||
           Global.MoveTwo.Equals("Shredder Time"))
        {
            _isActive = true;
        }
        else
        {
            _isActive = false;
        }
        Move();
    }

    private void Switch()
    {
        if (_isActive)
            _isActive = false;
        else
            _isActive = true;
    }

    private void Move()
    {
        if (_isActive)
        {
            transform.position = path[_point];
            if (transform.position == path[_point])
                _point++;
            if (_point == path.Count)
                _point = 0;
        }
        else
        {
            transform.position = startPos;
            _point = 0;
        }
    }
}
