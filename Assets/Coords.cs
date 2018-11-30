using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coords : MonoBehaviour
{
	public int input, output;
	public int newinput, newoutput;

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

	void Update()
	{
		{
			Vector2 MoveTo = new Vector2(newinput, newoutput) / 75;
			transform.position = Vector2.MoveTowards(transform.position, MoveTo, 0.01f);

			if (new Vector2(transform.position.x, transform.position.y) == MoveTo)
			{
				newinput = newoutput;
				newoutput = Collatz(newinput);
			}
		}
	}
}