using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerView;
    [SerializeField] private float gravity = - 9.81f;
    [SerializeField] private float jump = 10;

    private float velocity;

    private void Start()
    {
        velocity = 0;
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.Space))
            velocity = jump;

        velocity += gravity * Time.deltaTime;
        transform.Translate(new Vector3(0, velocity * Time.deltaTime, 0));
    }
}
