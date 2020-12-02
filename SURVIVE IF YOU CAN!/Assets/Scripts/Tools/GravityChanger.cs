using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class GravityChanger : MonoBehaviour
{
    private void Awake()
    {
        float x = FindObjectOfType<Transform>().position.x;
        if(x < 0) Physics.gravity = new Vector3(8f, 0, 0);

        if(x > 0) Physics.gravity = new Vector3(-8f, 0, 0);
    }
}