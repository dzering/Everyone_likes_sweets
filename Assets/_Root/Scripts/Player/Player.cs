using SweetGame.Abstractions;
using SweetGame.Abstractions.Base;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityAction OnDead;

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

    private void OnTriggerEnter2D(Collider2D collision)
     {
        if (collision.TryGetComponent(out InteractiveObject interactible))
        {
            interactible.Interaction();
        }

       if(interactible is EnemyBase)
        {
            OnDead?.Invoke();
        }

    }
}
