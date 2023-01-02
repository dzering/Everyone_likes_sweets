using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border
{
    public Border()
    {
        GameObject border = new GameObject("Boarder");
        BoxCollider2D boxCollider2D = border.AddComponent<BoxCollider2D>();
        Camera camera = Camera.main;
        float height = 2f * camera.orthographicSize;
        float width = height * camera.aspect;

        boxCollider2D.size = new Vector2(width, 0.1f);
        border.transform.position = new Vector3(0, height/2);
        border.tag = "Border";
    }
}
