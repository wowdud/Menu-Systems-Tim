using System.Collections.Generic;//Allows Dictionary
using UnityEngine;//Connects to Unity and Unity elements
using UnityEngine.UI;//Allows UI Elements
using System;//Allows Serialization 

namespace CanvasUI
{
    public class KeyBindManager : MonoBehaviour
    {
        public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
        [Serializable] // Allows us to see our struct when we use it in an array
        public struct KeyUISetup
        {
            public string keyName;
            public Text keyDisplayText;
            public string defaultKey;
            //Temp key if you want to make sure you cant double bound
        }
        //Array of our Key Names, UI Text for the Key and Default Key  
        public KeyUISetup[] keySetup;
        public GameObject currentKey;
        public Color32 changedKey = new Color32(39, 171, 249, 255);
        public Color32 selectedKey = new Color32(239, 116, 36, 255);
        private void Start()
        {
            Debug.Log("How many");

            //For loop to add the keys to the Dictionary with Save or Default depending on load for all the keys in base set up array
            for (int i = 0; i < keySetup.Length; i++)
            {
                if (!keys.ContainsKey(keySetup[i].keyName))
                {
                    //add key according to the saved string or default
                    keys.Add(keySetup[i].keyName, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(keySetup[i].keyName, keySetup[i].defaultKey)));
                }

                //for all the UI Text Change the Display to what the Bind is
                keySetup[i].keyDisplayText.text = keys[keySetup[i].keyName].ToString();
            }
        }
        public void SaveKeys()
        {
            //for each key
            foreach (var key in keys)
            {
                //save key to player prefs
                PlayerPrefs.SetString(key.Key,key.Value.ToString());
            }
            PlayerPrefs.Save();
        }
        public void ChangeKey(GameObject clickedKey)
        {
            //current key is the clicked key
            currentKey = clickedKey;
            //if we have clicked a key and its selected
            if (clickedKey != null)
            {
                //this is just visual to know its clicked...like a debug
                currentKey.GetComponent<Image>().color = selectedKey;
            }
        }
        private void OnGUI()//will allow us to run Events
        {
            string newKey = "";//temp key code name
            Event e = Event.current;//temp current event
            if(currentKey != null)//if we have a key selected to change
            {
                if(e.isKey)//and the event that happens is a key press
                {
                    newKey = e.keyCode.ToString();//hold onto the name of that key
                }
                //There is an issue Getting the Shift Keys the Following will Fix That
                if (Input.GetKey(KeyCode.LeftShift))//if we press left shift
                {
                    newKey = "LeftShift";//set the name of the key to left shift
                }
                if (Input.GetKey(KeyCode.RightShift))//if we press Right shift
                {
                    newKey = "RightShift";//set the name of the key to Right shift
                }
                if (newKey != "")//if we have recorded a key
                {
                    keys[currentKey.name] = (KeyCode)System.Enum.Parse(typeof(KeyCode), newKey);
                    //the Above changes out Key in the Dictionary to the Key we Just Pressed
                    currentKey.GetComponentInChildren<Text>().text = newKey;
                    //That changes the Display Text to Match the new Key
                    currentKey.GetComponent<Image>().color = changedKey;//To show we changed it...debug
                    currentKey = null; //Reset and wait
                }
            }
        }
    }
}
