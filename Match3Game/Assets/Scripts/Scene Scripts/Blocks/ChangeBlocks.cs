using UnityEngine;

public class ChangeBlocks : MonoBehaviour
{
    [SerializeField] private FindObject findObj;
    [SerializeField] private DeleteBlock delete;

    private GameObject _One;
    private GameObject _Two;

    private Vector3 tmpVectorOne;
    private Vector3 tmpVectorTwo;

    private int _distance = 0;
    private float _speed = 0.04f;
    private string _direction = "wait";

    private void Start()
    {
        tmpVectorOne = Vector3.zero;
        tmpVectorTwo = Vector3.zero;
        Global.MoveTwo = "Wait";
    }

    private void Update()
    {
        if (Global.Grounded.Equals("AllGround") && Global.AddBlocks.Equals("Wait")
            && Global.PausePlay.Equals("Play"))
        {
            GetTwoBlocks();
            MoveForward();
            MoveBack();
            SetGlobalCondition();
        }
        //print(_distance);
    }

    private void SetGlobalCondition()
    {
        if (_direction.Equals("forward"))
        {
            if (_distance >= 23 && _distance <= 35)
                Global.MoveTwo = "Shredder Time";
            else
                Global.MoveTwo = "Movement 2";
        }
        else if (_direction.Equals("backward"))
        {
            Global.MoveTwo = "Movement 2";
        }
        else
        {
            Global.MoveTwo = "Wait"; 
        }
    }


    private void MoveForward()
    {
        if (_direction.Equals("forward"))
        {
            if (_One && _Two)
            {
                _One.transform.position = Vector2.MoveTowards(_One.transform.position, tmpVectorTwo, _speed);
                _Two.transform.position = Vector2.MoveTowards(_Two.transform.position, tmpVectorOne, _speed);
            }

            _distance++;
            if (_distance == 38 || _distance == 70)
            {
                _distance = 22;
                _direction = "backward";
            }

            if (Global.Destroyer.Equals("Destroying") && _distance >= 36)
            {
                _distance = 40;
            }
        }
    }

    private void MoveBack()
    {
        if (_direction.Equals("backward"))
        {
            if (_One && _Two)
            {
                _One.transform.position = Vector2.MoveTowards(_One.transform.position, tmpVectorOne, _speed);
                _Two.transform.position = Vector2.MoveTowards(_Two.transform.position, tmpVectorTwo, _speed);
                _distance--;
            }
            else
            {
                _distance = 0; 
            }

            
            if (_distance == 0)
            {
                tmpVectorOne = Vector3.zero;
                tmpVectorTwo = Vector3.zero;
                _direction = "wait";
            }
        }
    }

    private void GetTwoBlocks()
    {
        if (findObj.GetOne() && findObj.GetTwo() && _direction.Equals("wait"))
        {
            _One = findObj.GetOne();
            _Two = findObj.GetTwo();
            
            if (tmpVectorOne == Vector3.zero && tmpVectorTwo == Vector3.zero )
            {
                tmpVectorOne = new Vector2(_One.transform.position.x, _One.transform.position.y);
                tmpVectorTwo = new Vector2(_Two.transform.position.x, _Two.transform.position.y);
                _direction = "forward";

            }
        }
    }
}
