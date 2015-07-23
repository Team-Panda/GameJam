using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameRules : MonoBehaviour {

	// number of availables player "size-levels"
	private static int maxLevel = 10;
	public static int maxSpirit;

	// required collections points for level transitions
	private static int[] levelConditions = new int[] {1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233};

	// color codes according to level
	private static Color[] levelColors = new Color[] {
		new Color(9/255f,117/255f,130/255f,1),
		new Color(226/255f, 134/255f, 119/255f,1),
		new Color(86/255f, 212/255f, 191/255f,1),
		new Color(255/255f, 168/255f, 9/255f,1),
		new Color(190/255f, 126/255f, 227/255f,1),
		new Color(139/255f, 241/255f, 245/255f,1),
		new Color(255/255f, 237/255f, 101/255f,1),
		new Color(255/255f, 107/255f, 95/255f,1),
		new Color(174/255f, 63/255f, 141/255f,1),
		new Color(208/255f, 188/255f, 155/255f,1)
	};


	// public getters
	public static int MaxLevel { get{ return maxLevel; } }
	public static int[] LevelConditions { get{ return levelConditions; } }
	public static Color[] LevelColors { get{ return levelColors; } }
}
