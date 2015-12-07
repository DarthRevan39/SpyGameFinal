using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ZipSave : MonoBehaviour {

    [HideInInspector]
    public string zipCode = "ZIP";

	// Use this for initialization
	void Start () {
        zipCode = "ZIP";    
        DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update ()
    {
      //  if (zipCode.Equals("ZIP"))
          //  zipCode = "31207";
        //if(zipCode != null)
        //Debug.Log(zipCode);
    }
}
