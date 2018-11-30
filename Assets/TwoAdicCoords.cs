using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoAdicCoords : MonoBehaviour
{
	public int[] from = new int[2];
	public int[] to = new int[2];

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

	void Update()
	{

		Vector2 MoveTo = new Vector2((float)to[0] /100f, to[1]);
		transform.position = Vector2.MoveTowards(transform.position, MoveTo, 0.01f);

		if (new Vector2(transform.position.x, transform.position.y) == MoveTo)
		{
			from = to;
			to = new int[2] { Collatz(from[0]), Count(Collatz(from[0])) };
		}

	}
}
