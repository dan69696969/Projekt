using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusObject : MonoBehaviour
{
    public Text thisText;

    public GameObject canvas;
    public int x, y;

    public float timer;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;

        //canvas = GameObject.Find("Canvas");
        canvas = GameObject.Find("Canvas1");

        transform.SetParent(canvas.transform);

        x = Random.Range(-150, 200);
        y = Random.Range(-400, 150);

        transform.localPosition = new Vector3(x, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.5f)
        {
            Destroy(this.gameObject);
        }

        transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * speed, 0);

        thisText.text = "+" + Game.hitPower;
    }
}
