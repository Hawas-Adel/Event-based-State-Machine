using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDemo : MonoBehaviour
{
	public bool ButtonDown(string keyCode) => Input.GetKey(keyCode);
}
