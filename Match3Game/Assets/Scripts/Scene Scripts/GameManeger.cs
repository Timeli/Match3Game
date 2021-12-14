using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManeger : MonoBehaviour
{
    private GameObject[] _objects;

    private int _countObjects;
    private bool _startChecks;

    private void Start()
    {
        Invoke("FindBlocks", 2f);
    }

    private void Update()
    {
        if (_startChecks)
        {
            CheckAllGround();
            _objects = GameObject.FindGameObjectsWithTag("Blocks");
        }
    }

   

    private void FindBlocks()
    {
        _objects = GameObject.FindGameObjectsWithTag("Blocks");
        _startChecks = true;
    }

    private void CheckAllGround()
    {
        _countObjects = 0;
        foreach (GameObject obj in _objects)
        {
            if (obj != null)
                _countObjects++;
        }

        foreach (GameObject obj in _objects)
        {
            if (obj != null)
                if (obj.GetComponent<MoveBlocks>().GetGround())
                    _countObjects -= 1;
        }

        if (_countObjects == 0)
            Global.Grounded = "AllGround";
        else
            Global.Grounded = "NoAllGround";
    }
}
