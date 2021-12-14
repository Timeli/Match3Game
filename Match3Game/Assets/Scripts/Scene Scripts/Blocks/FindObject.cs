using UnityEngine;

public class FindObject : MonoBehaviour
{
    private Vector3 _worldPosition;
    private bool _isEnable;

    private GameObject _One;
    private GameObject _Two;

    Vector2[] vectors = new Vector2[] { Vector2.right, Vector2.up, 
                                        Vector2.left, Vector2.down };

    private void Update()
    {
        ChooseSquareToChange();
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            _worldPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Began();
            }

            else if (touch.phase == TouchPhase.Moved && _isEnable)
            {
                Moved();
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                Ended();
            }
        }
    }

    public GameObject GetOne()
    {
        return _One;
    }

    public GameObject GetTwo()
    {
        return _Two;
    }

    private void ChooseSquareToChange()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 0f, LayerMask.GetMask("Raycast"));
        
        if (hit)
        {
            if (!_One)
            {
                _One = hit.collider.gameObject;
            }
            else if (!_Two && !hit.collider.gameObject.Equals(_One))
            {
                if (FindPossibleBlocks(hit.collider.gameObject))
                    _Two = hit.collider.gameObject;
            }
        }
    }

    private bool FindPossibleBlocks(GameObject twoObj)
    {
        _One.layer = 0;
        for (int i = 0; i < vectors.Length; i++)
        {
            RaycastHit2D hitNearObj = Physics2D.Raycast(_One.transform.position, vectors[i], 0.8f, LayerMask.GetMask("Raycast"));

            if (hitNearObj && hitNearObj.collider.gameObject.Equals(twoObj))
            {
                _One.layer = 3;
                return true;
            }
        }
        _One.layer = 3;
        return false;
    }

    private void Began()
    {
        _isEnable = true;
    }

    private void Moved()
    {
        Vector2 vector = new Vector2(_worldPosition.x, _worldPosition.y);
        transform.position = vector;
    }

    private void Ended()
    {
        // PathFinder to start position
        transform.position = new Vector2(-2.8f, -4.4f);

        // Deselect One and Two Objects
        _One = null;
        _Two = null;

        _isEnable = false;
    }
}
