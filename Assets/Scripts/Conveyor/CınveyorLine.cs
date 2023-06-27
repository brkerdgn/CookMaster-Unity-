using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CınveyorLine : MonoBehaviour
{
    Rigidbody rgb;

    public float speed, materialSpeed;

    MeshRenderer meshRenderer;

    float yOffset = 0;
    private void Start()
    {
        rgb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        Vector3 pos = rgb.position;
        rgb.position += Vector3.forward * Time.fixedDeltaTime * speed;
        rgb.MovePosition(pos);

        yOffset += Time.fixedDeltaTime * materialSpeed ;
        meshRenderer.material.mainTextureOffset = new Vector2(0, yOffset);
    }

}
