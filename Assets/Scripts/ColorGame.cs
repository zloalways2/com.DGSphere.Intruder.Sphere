using UnityEngine;
using UnityEngine.UI;

public class ColorGame : MonoBehaviour 
{
	public Color[] colorPalette;		
	public Color curColor;				
	public Color curOddColor;
	public GameObject[] colorSquares;	
	public int oddColorSquare;
	public float difficultyModifier;	
	public int round;					
	public int scoreIntruder;				
	public float eliminationTime;
	[SerializeField] private GameControllerIntruder gameControllerIntruder;

	void Awake()
	{
		Restart();
	}

	public void Restart()
    {
		round = 0;
		scoreIntruder = 0;
		NewRound();
	}

	private void NewRound()
	{
		difficultyModifier /= 1.08f;													
		round++;
		curColor = colorPalette[Random.Range(0, colorPalette.Length - 1)];
		float diff = 1.0f / 255.0f * difficultyModifier;
		curOddColor = new Color(curColor.r - diff, curColor.g - diff, curColor.b - diff);
		oddColorSquare = Random.Range(0, colorSquares.Length - 1);
		for (int xIntruder = 0; xIntruder < colorSquares.Length; xIntruder++)
		{
			if (xIntruder == oddColorSquare)
			{
				colorSquares[xIntruder].GetComponent<Image>().color = curOddColor;
			}
			else
			{
				colorSquares[xIntruder].GetComponent<Image>().color = curColor;
			}
		}
	}

	private void FailGame()
	{
		gameControllerIntruder.ShowWinMenuIntruder();																
	}

	public void CheckSquare(GameObject square)												
	{
		if (colorSquares[oddColorSquare] == square)
		{
			NewRound();
			scoreIntruder += 75;
			gameControllerIntruder.UpdatePointsIntruder(75);
		}
		else
		{
			FailGame();
		}
	}
}										
