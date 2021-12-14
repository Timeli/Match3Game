using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class Animates : MonoBehaviour
{
    private Animator _animator;
    private PlayableDirector _director;

    protected void StarActivate(GameObject obj)
    {
        _director = obj.GetComponent<PlayableDirector>();
        _director.Play();
    }

    protected void ActivateWinPannel(GameObject obj)
    {
        _animator = obj.GetComponent<Animator>();
        _animator.SetTrigger("Down");
    }

    protected void MoveUpPanel(GameObject obj)
    {
        _animator = obj.GetComponent<Animator>();
        _animator.SetTrigger("Pause");
    }

    protected void MoveDownPanel(GameObject obj)
    {
        _animator = obj.GetComponent<Animator>();
        _animator.SetTrigger("Play");
    }

    protected void Add(GameObject obj)
    {
        _animator = obj.GetComponent<Animator>();
        _animator.SetTrigger("Adds");
    }

    protected void Set(GameObject obj)
    {
        _animator = obj.GetComponent<Animator>();
        _animator.SetTrigger("Sets");
    }

    protected void Out(GameObject obj)
    {
        if (obj)
        {
            obj.GetComponent<SpriteRenderer>().sortingOrder = 2;
            _animator = obj.GetComponent<Animator>();
            _animator.SetTrigger("Blows");
            StartCoroutine(Destroyer(0.5f, obj));
        }
    }

    private IEnumerator Destroyer(float delay, GameObject obj)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
}
