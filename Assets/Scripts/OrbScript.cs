using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour, ICollectable
{
    public void OnCollected()
    {
        GameManager.gameManager.OrbCollected();
        Destroy(gameObject);
    }

public float scaleTime = 2f;
private float scale = 1f;
public float rotateAmount = 2f;
public float scaleAmount = 0.005f;

    void Start()
    {
        StartCoroutine(ScaleObject());
    }

    void FixedUpdate()
    {
        transform.Rotate(0, rotateAmount, 0);
        transform.localScale += new Vector3(1f, 1f, 1f) * scale * scaleAmount;
    }
    private IEnumerator ScaleObject()
    {
        yield return new WaitForSeconds(scaleTime);
        scale = -scale;
        yield return ScaleObject();
    }
}