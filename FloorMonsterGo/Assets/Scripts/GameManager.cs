using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Rigidbody pokeballPrefab;
    private Vector2 startSwipePosition;
    private float startSwipeTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount != 1)
            return;

        var touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began)
        {
            startSwipePosition = touch.position;
            startSwipeTime = Time.time;
        }
        else if(touch.phase == TouchPhase.Ended)
        {
            var distance = (touch.position - startSwipePosition).magnitude;
            var deltaTime = Time.time - startSwipeTime;
            var velocity = distance / deltaTime;

            ThrowBall(velocity);
        }
    }

    public void ThrowBall(float velocity)
    {
        var position = Camera.main.transform.position + (Camera.main.transform.forward * 0.5f);
        var ball = Instantiate(pokeballPrefab, position, Camera.main.transform.rotation);

        ball.angularVelocity = Random.insideUnitSphere * Random.Range(0.5f, 2);

        var direction = Vector3.RotateTowards(Camera.main.transform.forward, Vector3.up, Mathf.Deg2Rad * 30, 0);
        ball.velocity = direction * velocity * 0.001f;
    }
}
