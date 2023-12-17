using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nonp : MonoBehaviour
{
    public Transform[] positions;
    int nextPosIndex;
    Transform nextPosition;
    public float movSpeed;
    // Start is called before the first frame update
    void Start()
    {
        nextPosition = positions[0];
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    public void Move()
    {
        if (transform.position == nextPosition.position)
        {
            nextPosIndex++;

            if (nextPosIndex >= positions.Length)
            {
                nextPosIndex = 0;
            }

            nextPosition = positions[nextPosIndex];
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPosition.position, movSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hello There");
    }
}
