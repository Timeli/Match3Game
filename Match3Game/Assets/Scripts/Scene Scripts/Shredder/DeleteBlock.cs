using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBlock : Animates
{
    private RaycastHit2D[] _raycasts;
    private List<GameObject> toDestroy;

    private void Start()
    {
        Global.Destroyer = "Wait";
        toDestroy = new List<GameObject>();
    }

    private void Update()
    {
        CastRayToBlocks();
    }

    public int GetLenthBlocks()
    {
        return toDestroy.Count;
    }

    private void CastRayToBlocks()
    {
        Vector2 direction;

        if (transform.position.y == -4.4f)
            direction = Vector2.up;
        else
            direction = Vector2.right;

        if (transform.position.x == 2.8f && transform.position.y == -4.4f)
        {
            if (toDestroy.Count > 0)
                StartCoroutine(Destroyer());
        }

        _raycasts = Physics2D.RaycastAll(transform.position, direction, 5.0f, LayerMask.GetMask("Raycast"));
        Debug.DrawRay(transform.position, direction, Color.red);
        FindBlocksToDestroy(_raycasts);
    }

    private IEnumerator Destroyer()
    {
        for (int i = 0; i < toDestroy.Count; i++)
        {

            Global.Destroyer = "Destroying";
            Out(toDestroy[i]);
            yield return new WaitForSeconds(0.03f);
        }
        toDestroy.Clear();
        Global.Destroyer = "Wait";

    }

    private void FindBlocksToDestroy(RaycastHit2D[] rcasts)
    {
        int matches = 0;
        for (int i = 0; i < rcasts.Length - 1; i++)
        {
            if (rcasts[i].collider.name == rcasts[i + 1].collider.name)
            {
                matches++;
            }

            if (rcasts[i].collider.name != rcasts[i + 1].collider.name && matches >= 2)
            {
                for (int j = i; matches >= 0; matches--, j--)
                {
                    toDestroy.Add(rcasts[j].collider.gameObject);
                }
            }
            else if (i == rcasts.Length - 2 && matches >= 2)
            {
                for (int j = i + 1; matches >= 0; matches--, j--)
                {
                    toDestroy.Add(rcasts[j].collider.gameObject);
                }
            }

            if (rcasts[i].collider.name != rcasts[i + 1].collider.name)
            {
                matches = 0;
            }
        }
    }

}
