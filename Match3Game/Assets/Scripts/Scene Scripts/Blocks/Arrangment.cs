using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrangment : Animates
{
    [SerializeField] private GameObject _blue;
    [SerializeField] private GameObject _green;
    [SerializeField] private GameObject _orange;
    [SerializeField] private GameObject _purple;
    [SerializeField] private GameObject _red;

    private int _count = 36;
    private int[] _blocks;

    private Vector3 startPos = new Vector3(-2.8f, -3.6f);
    private float stepX = 0.8f;
    private float _delay = 0.02f;
    int counter;


    private void Start()
    {
        _blocks = new int[_count];
        FillMassive(_blocks);
        StartCoroutine(Arrange(_blocks));
        StartCoroutine(DelayArrange(1.5f));
    }

    private IEnumerator DelayArrange(float delay)
    {
        Global.ArrangmentBlocks = "Arragment";
        yield return new WaitForSeconds(delay);
        Global.ArrangmentBlocks = "Wait";
    }

    private IEnumerator Arrange(int[] order)
    {
        for (int i = 0; i < order.Length; i++)
        {
            GameObject currentObj;
            if (order[i] == 1)
                currentObj = _blue;
            else if (order[i] == 2)
                currentObj = _orange;
            else if (order[i] == 3)
                currentObj = _red;
            else if (order[i] == 4)
                currentObj = _purple;
            else
                currentObj = _green;

            Vector3 position = Getposition();
            Set(Instantiate(currentObj, position, Quaternion.identity));

            yield return new WaitForSeconds(_delay);
        }
    }

    private Vector3 Getposition()
    {
        if (counter == 6)
        {
            startPos.x -= 4.8f;
            startPos.y += 0.8f;
            counter = 0;
        }
        counter++;    
        startPos = new Vector3(startPos.x + stepX, startPos.y);
        return startPos;
    }

    private void FillMassive(int[] mass)
    {
        int row = 0;
        for (int i = 0; i < mass.Length; i++)
        {
            if (i % 7 == 0)
                row++;

            mass[i] = row;
        }
        ShuffleMassive(mass);
    }

    private void ShuffleMassive(int[] mass)
    {
        for (int i = 0; i < mass.Length; i++)
        {
            int randomIndex = Random.Range(i, mass.Length);
            int current = mass[i];

            mass[i] = mass[randomIndex];
            mass[randomIndex] = current;
        }
    }
}
