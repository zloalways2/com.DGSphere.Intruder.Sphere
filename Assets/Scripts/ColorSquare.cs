using UnityEngine;

public class ColorSquare : MonoBehaviour 
{
	public ColorGame game;
	void OnMouseDown()
	{
		game.CheckSquare(gameObject);
	}
}