using UnityEngine;
using System.Collections;

public class TestButton : MonoBehaviour 
{
	void OnMouseDown()
	{
		NUnitLiteUnityRunner.RunTests();
	}
}
