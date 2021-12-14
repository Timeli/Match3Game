using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocks : MonoBehaviour
{
    private int _distance = 0;
    private float _speed = 0.1f;

    private bool _isGrounded;


    private void Update()
    {
        if (Global.MoveTwo.Equals("Wait") && Global.Destroyer.Equals("Wait")
            && Global.ArrangmentBlocks.Equals("Wait"))
        {
            MoveDown();
        }

        if (!CheckDown())
        {
            Global.Grounded = "NoAllGround";
        }
    }

    public bool GetGround()
    {
        return _isGrounded;
    }


    private void MoveDown()
    {
        if (!CheckDown() && _distance == 0)
        {
            _distance = 8;
            _isGrounded = false;
        }
        else if (!_isGrounded && _distance > 0)
        {
            
            transform.position = new Vector2(transform.position.x, transform.position.y - _speed);
            _distance -= 1;
        }
        else
        {
            _isGrounded = true;
        }
    }

    private bool CheckDown()
    {
        Vector2 position = new Vector2(transform.position.x + 0.25f, transform.position.y - 0.43f);
        RaycastHit2D hit = Physics2D.Raycast(position, -Vector2.up, 0f);

        if (hit)
            return true;
        return false;
    }
}
