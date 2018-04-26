using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveThroughTutorial : MonoBehaviour {

	public string[] currentTextLines;
	public string[][] allTextLines;

	private int linesPerSingleDialogue;
	private int dialogueLineSets;

	private Text myText;
	public int currentTextProgress;

	public bool atEndOfCurrentDialogue;
	private int currentCharacter;

	private float timer;

	// Use this for initialization
	void Start() 
	{
		timer = 0.0f;
		atEndOfCurrentDialogue = false;
		currentCharacter = 0;

		myText = GameObject.FindGameObjectWithTag("TutorialText").GetComponent<Text>();

		linesPerSingleDialogue = 2;
		dialogueLineSets = 26;

		currentTextLines = new string[linesPerSingleDialogue];
		currentTextProgress = 0;

		allTextLines = new string[dialogueLineSets][];

		for (int i = 0; i < dialogueLineSets; i++)
		{
			allTextLines[i] = new string[linesPerSingleDialogue];
		}

		allTextLines[0][0] = "Hello! Welcome to Rochester Institute of Technology.";
		allTextLines[0][1] = "It's an honor to see you again, former president Desler.";

		allTextLines[1][0] = "Munroe doesn't know how to use the weather machine!";
		allTextLines[1][1] = "Guess we need to teach him. But we'll need the help of some students.";

		allTextLines[2][0] = "Luckily for you, your Desler Doubloons are always counting up!";
		allTextLines[2][1] = "Take a look at the top right and see for yourself.";

		allTextLines[3][0] = "You can take a good look around your old campus with the keys W, A, S, and D.";
		allTextLines[3][1] = "Give it a try!";

		allTextLines[4][0] = "You can take a closer look at the campus with Q, and a more";
		allTextLines[4][1] = "grand view with E. Scrolling your mouse wheel also works!";

		allTextLines[5][0] = "I'll bet Humans versus Zombies students are willing to help out.";
		allTextLines[5][1] = "Try pressing 1 to recruit one.";

		allTextLines[6][0] = "Or you could recruit one of my personal favorites, freshman.";
		allTextLines[6][1] = "Press 2 to recruit freshmen.";

		allTextLines[7][0] = "If you'd like to recruit students from a different department,";
		allTextLines[7][1] = "just click on the other building.";

		allTextLines[8][0] = "Of course, clicking is how you're moving this text forward,";
		allTextLines[8][1] = "so we can take a moment to laugh at this silly little trope.";

		allTextLines[9][0] = "Haha.";
		allTextLines[9][1] = "";

		allTextLines[10][0] = "....                                                     ";
		allTextLines[10][1] = "Okay, that's enough. Back to business.";

		allTextLines[11][0] = "Graduate students can be helpful too.";
		allTextLines[11][1] = "They can be recruited by pressing 3.";

		allTextLines[12][0] = "You can try... emphasis on \"try\"... to direct your students";
		allTextLines[12][1] = "by right clicking on a location.";

		allTextLines[13][0] = "But most students don't like to listen!";
		allTextLines[13][1] = "";

		allTextLines[14][0] = "There are a couple who listen a little better. Like labbies.";
		allTextLines[14][1] = "They help out other students. You can recruit them by pressing 4.";

		allTextLines[15][0] = "Of course, we're in no fear of losing students here.";
		allTextLines[15][1] = "After all, we haven't confronted Munroe with this issue yet.";

		allTextLines[16][0] = "But I'm sure Munroe will have students defending him as well.";
		allTextLines[16][1] = "We need to be ready for anything.";

		allTextLines[17][0] = "Finally, there's our mascot, Richie. He can be recruited by pressing 5.";
		allTextLines[17][1] = "";

		allTextLines[18][0] = "If you click on Richie, you can recruit students directly from his location!";
		allTextLines[18][1] = "";

		allTextLines[19][0] = "If you click on Richie, you can recruit students directly from his location!";
		allTextLines[19][1] = "I figured I'd say it again, since you probably clicked on him to test it.";

		allTextLines[20][0] = "Whenever you're ready to get started, just hit the \"Back\" button off to the right.";
		allTextLines[20][1] = "";

		allTextLines[21][0] = "Or you can just hang out around here if you'd like.";
		allTextLines[21][1] = "I won't judge.";

		allTextLines[22][0] = "Good luck, sir!";
		allTextLines[22][1] = "";

		allTextLines[23][0] = "Oh, and if you get some spare time, could you show me how to play the banjo?";
		allTextLines[23][1] = "";

		allTextLines[24][0] = "Thanks. I appreciate it.";
		allTextLines[24][1] = "";

		for (int i = 0; i < linesPerSingleDialogue; i++)
		{
			currentTextLines[i] = allTextLines[currentTextProgress][i];
		}


	}
	
	// Update is called once per frame
	void Update() 
	{

		for (int i = 0; i < linesPerSingleDialogue; i++)
		{
			currentTextLines[i] = allTextLines[currentTextProgress][i];
		}

		string createdText = "";
		for (int i = 0; i < currentTextLines.GetLength(0); i++)
		{
			createdText = createdText + currentTextLines[i] + "\n";
		}

		char[] theText = createdText.ToCharArray();
		char[] shownText = new char[theText.GetLength(0)];

		if (!atEndOfCurrentDialogue)
		{
			if (Input.GetMouseButtonDown(0))
			{
				currentCharacter = theText.GetLength(0);
				atEndOfCurrentDialogue = true;
			}

			for (int i = 0; i < theText.GetLength(0); i++)
			{
				if (i <= currentCharacter)
				{
					shownText[i] = theText[i];
				}
				else
				{
					shownText[i] = ' ';
				}
			}
			if (timer >= 0.025f)
			{
				currentCharacter++;
				timer = 0.0f;
			}
			if (currentCharacter == theText.GetLength(0))
			{
				atEndOfCurrentDialogue = true;
			}
		}
		else
		{
			shownText = theText;

			if (Input.GetMouseButtonDown(0) && currentTextProgress < dialogueLineSets - 1)
			{
				currentCharacter = 0;
				currentTextProgress++;
				atEndOfCurrentDialogue = false;
			}
		}

		myText.text = new string(shownText);

		timer += Time.deltaTime;
	}
}
