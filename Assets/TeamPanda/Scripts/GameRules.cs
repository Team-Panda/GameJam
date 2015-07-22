using UnityEngine;
using System.Collections;

public class GameRules : MonoBehaviour {

	// number of availables player "size-levels"
	private static int maxLevel = 10;

	// required collections points for level transitions
	private static int[] levelConditions = new int[] {1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233};

	// public getters
	public static int MaxLevel { get{ return maxLevel; } }
	public static int[] LevelConditions { get{ return levelConditions; } }
}
