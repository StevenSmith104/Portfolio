using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class MinorDialogData : MonoBehaviour {
	private List<MinorDialog> database = new List<MinorDialog>();
	private JsonData dialogData;

	// Use this for initialization
	void Start () 
	{
		dialogData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Scripts/StreamingAssets/MinorDialog.json"));
		ConstructItemDatabase();
	}

	public MinorDialog FetchDialogByID(int id)
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
			database.Add(new MinorDialog((int)dialogData[i]["id"], 
				dialogData[i]["speech"].ToString()));
		}
	}
}

public class MinorDialog
{
	public int ID{ get; set; }
	public string Speech { get; set; }

	public MinorDialog(int id, string speech)
	{
		this.ID = id;
		this.Speech = speech;
	}
}
