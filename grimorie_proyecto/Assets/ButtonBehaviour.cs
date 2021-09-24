using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    Button FireBallSpell;
    
    public bool is_active = false;
    public bool is_unlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        Button btn =  FireBallSpell.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick(){
		Debug.Log ("You have clicked the button!");
	}
}
