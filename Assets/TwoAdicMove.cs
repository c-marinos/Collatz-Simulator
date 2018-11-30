using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoAdicMove : MonoBehaviour
{
	public GameObject Circle, OtherCircle;
	public float speed = 2;
	public int n = 1000;

	int Collatz(int n)
	{
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

		n = (3 * n + 1) / 2;

		while (n % 2 == 1)
		{
			n = (3 * n + 1) / 2;
			m++;
		}

		return m;
	}

	// Use this for initialization
	void Start()
	{
		for (int i = 1; i < n; i += 2)
		{

			if ((i - 1) % 4 == 0)
			{
				Instantiate(OtherCircle);
				OtherCircle.GetComponent<SpriteRenderer>().color = Color.blue;

				OtherCircle.GetComponent<TwoAdicCoords>().from = new int[2] { i, Count(i) };

				OtherCircle.transform.position = new Vector2((float)i / 100f, Count(i));

				OtherCircle.GetComponent<TwoAdicCoords>().to = new int[2] { Collatz(i), Count(Collatz(i)) };
			}
			else
			{
				Instantiate(Circle);


				Circle.GetComponent<TwoAdicCoords>().from = new int[2] { i, Count(i) };

				Circle.transform.position = new Vector2((float)i /100f, Count(i));

				Circle.GetComponent<TwoAdicCoords>().to = new int[2] { Collatz(i), Count(Collatz(i)) };
			}
		}
	}
}