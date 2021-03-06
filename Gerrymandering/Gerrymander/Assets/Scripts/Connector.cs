﻿using UnityEngine;
using System.Collections;

public class Connector : MonoBehaviour {

    public Node A, B;
    public bool isVisited = false;

    private int numCollisions = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Delete() { }

    public override bool Equals(System.Object obj) {
        // If parameter is null return false.
        if (obj == null) {
            return false;
        }

        // If parameter cannot be cast to Point return false.
        Connector ctr = obj as Connector;
        if ((System.Object)ctr == null) {
            return false;
        }

        // Return true if the fields match:
        return (this.A == ctr.A && this.B == ctr.B) || (this.A == ctr.B && this.B == ctr.A);
    }

    public bool Equals(Connector ctr) {
        // If parameter is null return false:
        if ((object)ctr == null) {
            return false;
        }

        // Return true if the fields match:
        return (this.A == ctr.A && this.B == ctr.B) || (this.A == ctr.B && this.B == ctr.A);
    }

    public override int GetHashCode() {
        return this.A.GetHashCode() * this.B.GetHashCode();
    }

    public bool IsColliding()
    {
        return numCollisions > 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Node>() != null || collision.gameObject.GetComponent<Connector>() != null)
        {
            ++numCollisions;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Node>() != null || collision.gameObject.GetComponent<Connector>() != null)
        {
            --numCollisions;
        }
    }
}
