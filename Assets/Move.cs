using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	public GameObject Circle;
	public float speed = 2;
	public int n = 10000;

	int Collatz(int n)
	{
		/*
		while ((n - 1) % 4 != 0)
		{
			n = (3 * n + 1) / 2;

		}
		*/
		n = 3 * n + 1;
		while (n % 2 == 0)
		{
			n /= 2;
		}
		return n;
	}

	int Count(int n)
	{
		int m = 0;
		while(((3*n+1)/2) % 2 == 1)
		{
			m++;
		}
		return m;
	}

	// Use this for initialization
	void Start()
	{
		for (int i = 1; i < n; i += 2)
		{
			Instantiate(Circle);
			Circle.tag = "Point";

			Circle.GetComponent<Coords>().input = i;
			Circle.GetComponent<Coords>().output = Collatz(i);

			Circle.transform.position = new Vector2(i, Collatz(i)) / 75;

			Circle.GetComponent<Coords>().newinput = Circle.GetComponent<Coords>().output;
			Circle.GetComponent<Coords>().newoutput = Collatz(Circle.GetComponent<Coords>().newinput);
		}
	}
}
