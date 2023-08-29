using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternScript : MonoBehaviour
{
    Rigidbody2D rb;

    public GameObject endPosition;

    public float koefficient;

    //bool editor;

    public float speed = 10;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("DestroyObject", 9);

#if UNITY_EDITOR
{
            koefficient = 1;
}
#elif UNITY_STANDALONE_OSX
{
koefficient = 0.5f;
}
#elif UNITY_ANDROID
{
koefficient = 1;
}
#elif UNITY_IOS
{
koefficient = 0.5f;
}
#endif
    }

    // Update is called once per frame
    void Update()
    {
        //rb.MovePosition(transform.position + endPosition.transform.position * Time.deltaTime * koefficient);

        transform.Translate(Vector2.down * speed * Time.deltaTime * koefficient);
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
