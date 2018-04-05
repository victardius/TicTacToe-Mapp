using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreenOrientation : MonoBehaviour {

    private void Start()
    {
        Screen.autorotateToLandscapeLeft = true;

        Screen.autorotateToLandscapeRight = true;

        Screen.autorotateToPortrait = true;

        Screen.autorotateToPortraitUpsideDown = true;

        Screen.orientation = ScreenOrientation.AutoRotation;
    }
}
