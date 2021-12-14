using UnityEngine;

public class Control : MonoBehaviour
{
    private Vector3 _worldPosition;
    private Platform _platform;
    private bool _isEnable;

    private GameObject _one;
    private GameObject _two;
    
    
    private Vector2 _initialPos = new Vector2(-2.8f, -4.4f);
    private Vector2[] possibleDirection = new Vector2[] { Vector2.right, Vector2.up, 
                                                       Vector2.left, Vector2.down };

    public GameObject GetOne => _one;
    public GameObject GetTwo => _two;


    private void Awake()
    {
#if UNITY_ANDROID
        _platform = Platform.Android;
#endif
# if UNITY_EDITOR
        _platform = Platform.UnityEditor;
#endif
    }

    private void Update()
    {
        SelectSquareToChange();

        if (_platform == Platform.UnityEditor)
        {
            if (Input.GetMouseButton(0))
            {
                _worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Moved(_worldPosition);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Ended();
            }
        }

        if (_platform.Equals(Platform.Android) && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            _worldPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Began();
            }
            else if (touch.phase == TouchPhase.Moved && _isEnable)
            {
                Moved(_worldPosition);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Ended();
            }
        }
    }

    private void Began()
    {
        _isEnable = true;
    }

    private void Moved(Vector3 worldPosition)
    {
        Vector2 vector = new Vector2(worldPosition.x, worldPosition.y);
        transform.position = vector;
    }

    private void Ended()
    {
        // PathFinder to start position
        transform.position = _initialPos;

        // Deselect One and Two Objects
        _one = null;
        _two = null;

        _isEnable = false;
    }
   
    private void SelectSquareToChange()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 0f, 
                                                     LayerMask.GetMask("Raycast"));
        
        if (hit)
        {
            if (_one == false)
            {
                _one = hit.collider.gameObject;
            }
            else if (_two == false && hit.collider.gameObject.Equals(_one) == false)
            {
                if (FindPossibleBlocks(hit.collider.gameObject))
                    _two = hit.collider.gameObject;
            }
        }
    }

    private bool FindPossibleBlocks(GameObject twoObj)
    {
        _one.layer = 0;
        for (int i = 0; i < possibleDirection.Length; i++)
        {
            RaycastHit2D hitNearObj = Physics2D.Raycast(_one.transform.position, possibleDirection[i],
                                                        0.8f, LayerMask.GetMask("Raycast"));

            if (hitNearObj && hitNearObj.collider.gameObject.Equals(twoObj))
            {
                _one.layer = 3;
                return true;
            }
        }
        _one.layer = 3;
        return false;
    }
}

public enum Platform
{
    UnityEditor,
    Android,
    Windows,
    Other
}