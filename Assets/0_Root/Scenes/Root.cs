using SweetGame.Enemy;
using UnityEngine;

public class Root : MonoBehaviour
{
    private BirdController _birdController;
    void Start()
    {
        _birdController = new BirdController(1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        _birdController.Execute();
    }
}
