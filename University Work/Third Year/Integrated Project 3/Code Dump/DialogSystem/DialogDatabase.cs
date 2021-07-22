using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class DialogDatabase : MonoBehaviour {
	private List<Dialog> database = new List<Dialog>();
	private JsonData dialogData;

	// Use this for initialization
	void Start () 
	{
		dialogData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Scripts/StreamingAssets/Dialog.json"));
		ConstructItemDatabase();
	}
	
	public Dialog FetchDialogByID(int id)
	{
		for(int i = 0; i < database.Count; i++)
		{
			if(database[i].ID == id)
			{
				return database[i];
			}
		}
		return null;
	}

	void ConstructItemDatabase()
	{
		for(int i = 0; i < dialogData.Count; i++)
		{
			database.Add(new Dialog((int)dialogData[i]["id"], 
				dialogData[i]["inactiveSpeech"].ToString(), 
				dialogData[i]["activeSpeech"].ToString(), 
				dialogData[i]["activeSpeech2"].ToString()));
		}
	}



}

public class Dialog
{
	public int ID{ get; set; }
	public string InactiveSpeech{ get; set; }
	public string ActiveSpeech{ get; set; }
	public string ActiveSpeech2{ get; set; }

	public Dialog(int id, string inactiveSpeech, string activeSpeech, string activeSpeech2)
	{
		this.ID = id;
		this.InactiveSpeech = inactiveSpeech;
		this.ActiveSpeech = activeSpeech;
		this.ActiveSpeech2 = activeSpeech2;
	}
}
