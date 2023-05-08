using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAI : MonoBehaviour
{
    public string behaviour;
    public float timer;
    public Vector2 direction;
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (behaviour == "idle")
        {

        }
        if (behaviour == "move")
        {
            transform.Translate(direction*speed* Time.deltaTime);
        }
        if (timer < 0) {
            changeBehaviour();
        }
        timer -= Time.deltaTime;
        //Debug.Log(timer);
    }

    private void changeBehaviour() {
        timer = Random.Range(2, 5);
        if (behaviour != "idle") behaviour = "idle";
        else { 
            int rand = Random.Range(0, 2);

            if (rand == 0) {
                behaviour = "move";
                setDirection();

                Debug.Log("Frog is moving");
            }
            else behaviour = "idle";
        }
    }

    private void setDirection() {
        int angle = Random.Range(1, 360);

        float x = Mathf.Cos(angle);
        float y = Mathf.Sin(angle);

        direction = new Vector2(x,y);
    }

}
