using System.Collections;
using UnityEngine;

public class AddBlocks : Animates
{
    [SerializeField] private GameObject blue;
    [SerializeField] private GameObject green;
    [SerializeField] private GameObject orange;
    [SerializeField] private GameObject purple;
    [SerializeField] private GameObject red;

    private bool _isActiveAdd;
    private float _delay;    // 0.3

    private void Start()
    {
        Global.AddBlocks = "Wait";
        Invoke("Launcher", 2f);
    }

    private void Update()
    {
        if (_isActiveAdd && Global.MoveTwo.Equals("Wait")
            && Global.Destroyer.Equals("Wait"))
        {
            CheckToAddBlocks();
        }
    }

    private void Launcher()
    {
        if (!_isActiveAdd)
            _isActiveAdd = true;
        else
            _isActiveAdd = false;
    }

    private void CheckToAddBlocks()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, -Vector2.up, 6.5f, LayerMask.GetMask("Raycast"));

        if (hits.Length < 6)
        {
            Global.AddBlocks = "Add";
            _delay = 0.1f;
            _isActiveAdd = false;
            StartCoroutine(DelayAdd(hits.Length));
        }
    }

    private IEnumerator DelayAdd(int len)
    {
        GameObject block = green;

        for (int i = 0; i < (6 - len); i++)
        {
            yield return new WaitForSeconds(_delay);

            int kind = Random.Range(0, 5);
            if (kind == 0)
                block = green;
            if (kind == 1)
                block = red;
            if (kind == 2)
                block = orange;
            if (kind == 3)
                block = blue;
            if (kind == 4)
                block = purple;

            Add(Instantiate(block, transform.position, Quaternion.identity));
            _delay = 0.3f;
        }
        _isActiveAdd = true;
        Global.AddBlocks = "Wait";
    }
}
