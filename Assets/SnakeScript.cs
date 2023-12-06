using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    private Vector3 direction = Vector3.right;
    private List<Transform> segmentList = new List<Transform>();

    public Transform prefabSegment;
    public int initialTailSize = 4;

    

    private void Start()
    {
        this.Reset();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.direction = Vector3.up;
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.direction = Vector3.down;
        } else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.direction = Vector3.left;
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.direction = Vector3.right;
        }
    }


    private void FixedUpdate()
    {
        for(int i=this.segmentList.Count -1; i>0; i--)
        {
            this.segmentList[i].position = this.segmentList[i - 1].position;
        }

        this.transform.position += this.direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Food")
        {
            this.Grow();
        } else if(other.tag == "Obstacle")
        {
            this.Reset();
        }
        Food.instace.FoodRandomLocation();
    }

    private void Reset()
    {
        for(int i=this.segmentList.Count-1; i>0; i--)
        {
            Destroy(this.segmentList[i].gameObject);
        }
        this.segmentList.Clear();
        this.segmentList.Add(this.transform);
        this.transform.position = Vector3.zero;

        for(int i=1; i<this.initialTailSize; i++)
        {
            this.segmentList.Add(Instantiate(this.prefabSegment));
        }
    }

    private void Grow()
    {
        Transform newSegment = Instantiate(this.prefabSegment);
        newSegment.position = this.segmentList[this.segmentList.Count - 1].position;
        this.segmentList.Add(newSegment);
    }
}
