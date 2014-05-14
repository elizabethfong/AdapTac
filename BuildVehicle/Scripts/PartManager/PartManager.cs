using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.IO;

public class PartManager : MonoBehaviour 
{
	public bool makePersistent = true;
	public static PartManager inst;
	//public TextAsset xmlDataFile;

	private string mDataFilename = "Assets/XML/data.xml";
	private XmlReader mXmlReader;
	private XmlDocument mDataXml;

	private Dictionary<string, Dictionary<string, Part>> parts;

	// Use this for initialization
	void Start () 
	{
		parts = new Dictionary<string, Dictionary<string, Part>>();

		inst = this;

		//Initialize our table of part categories
		parts[Part.PartCategory.CATEGORY_COCKPIT.ToString()] 	= new Dictionary<string, Part>();
		parts[Part.PartCategory.CATEGORY_ENGINE.ToString()] 	= new Dictionary<string, Part>();
		parts[Part.PartCategory.CATEGORY_FRAME.ToString()] 		= new Dictionary<string, Part>();
		parts[Part.PartCategory.CATEGORY_TIRE.ToString()] 		= new Dictionary<string, Part>();
		parts[Part.PartCategory.CATEGORY_WEAPON.ToString()] 	= new Dictionary<string, Part>();

		if(makePersistent)
		{
			DontDestroyOnLoad(this.gameObject);
		}

		Debug.Log("[PartManager::PartManager()] - Initialized.");

		Model.partManager = this;

		LoadParts();
	}
	
	public Dictionary<string, Part> GetPartCategoryTable(Part.PartCategory pCategory)
	{
		if(parts[pCategory.ToString()] == null) return null;

		return parts[pCategory.ToString()];
	}

	public Part GetPart(Part.PartCategory pCategory, Part.PartID pID)
	{
		Dictionary<string, Part> parts = GetPartCategoryTable(pCategory);

		Part tempPart = parts[pID.ToString()];

		return tempPart;
	}

	private void LoadParts()
	{
		//NOTE: Apparently, the commented out code did not work properly on the mobile device.
		/*XmlReaderSettings readerSettings = new XmlReaderSettings();
		readerSettings.ValidationType = ValidationType.None;
		
		mXmlReader = XmlReader.Create(mDataFilename, readerSettings);
		mDataXml = new XmlDocument();
		mDataXml.Load(mXmlReader);

		XmlNodeList partsList = mDataXml.GetElementsByTagName("part");*/

		TextAsset testXml = (TextAsset) Resources.Load("data", typeof(TextAsset));

		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml(testXml.text);

		XmlNodeList partsList = xmlDoc.GetElementsByTagName("part");

		Part tempPart;

		foreach(XmlNode node in partsList)
		{
			tempPart = new Part();
			tempPart.partCategory = ParseCategoryEnum(node.Attributes["category"].Value);
			tempPart.partId = ParseIDEnum(node.Attributes["id"].Value);
			tempPart.partIconFrameID = ParseFrameEnum(node.Attributes["frameId"].Value);
			tempPart.partName = node.Attributes["name"].Value;

			if(node.Attributes["ranking"].Value != "")
			{
				tempPart.partRanking = int.Parse(node.Attributes["ranking"].Value);
			}
			else
			{
				tempPart.partRanking = 0;
			}

			if(node.Attributes["acceleration"].Value != "")
			{
				tempPart.partAcceleration = float.Parse(node.Attributes["acceleration"].Value);
			}
			else
			{
				tempPart.partAcceleration = 0.0f;
			}

			if(node.Attributes["braking"].Value != "")
			{
				tempPart.partBraking = float.Parse(node.Attributes["braking"].Value);
			}
			else
			{
				tempPart.partBraking = 0.0f;
			}

			if(node.Attributes["armor"].Value != "")
			{
				tempPart.partArmor = float.Parse(node.Attributes["armor"].Value);
			}
			else
			{
				tempPart.partArmor = 0.0f;
			}

			if(node.Attributes["speed"].Value != "")
			{
				tempPart.partSpeed = float.Parse(node.Attributes["speed"].Value);
			}
			else
			{
				tempPart.partSpeed = 0.0f;
			}

			if(node.Attributes["drag"].Value != "")
			{
				tempPart.partDrag = float.Parse(node.Attributes["drag"].Value);
			}
			else
			{
				tempPart.partDrag = 0.0f;
			}

			if(node.Attributes["accuracy"].Value != "")
			{
				tempPart.partAccuracy = float.Parse(node.Attributes["accuracy"].Value);
			}
			else
			{
				tempPart.partAccuracy = 0.0f;
			}

			tempPart.partRange = ParseRangeEnum(node.Attributes["range"].Value);

			if(node.Attributes["damage"].Value != "")
			{
				tempPart.partDamage = float.Parse(node.Attributes["damage"].Value);
			}
			else
			{
				tempPart.partDamage = 0.0f;
			}

			if(node.Attributes["ranking"].Value != "")
			{
				tempPart.partRanking = int.Parse(node.Attributes["ranking"].Value);
			}
			else
			{
				tempPart.partRanking = 0;
			}

			tempPart.partSpecial = node.Attributes["special"].Value;
			tempPart.partTagLine = node.Attributes["tagline"].Value;

			switch(tempPart.partCategory)
			{
				case Part.PartCategory.CATEGORY_COCKPIT:
					parts[Part.PartCategory.CATEGORY_COCKPIT.ToString()][node.Attributes["id"].Value] = tempPart;
					break;
				case Part.PartCategory.CATEGORY_ENGINE:
					parts[Part.PartCategory.CATEGORY_ENGINE.ToString()][node.Attributes["id"].Value] = tempPart;
					break;
				case Part.PartCategory.CATEGORY_FRAME:
					parts[Part.PartCategory.CATEGORY_FRAME.ToString()][node.Attributes["id"].Value] = tempPart;
					break;
				case Part.PartCategory.CATEGORY_TIRE:
					parts[Part.PartCategory.CATEGORY_TIRE.ToString()][node.Attributes["id"].Value] = tempPart;
					break;
				case Part.PartCategory.CATEGORY_WEAPON:
					parts[Part.PartCategory.CATEGORY_WEAPON.ToString()][node.Attributes["id"].Value] = tempPart;
					break;
				case Part.PartCategory.CATEGORY_NONE:
					break;
				default:
					break;
			}
		}
	}

	//Shuffle Parts Icons
	public Part[] ShufflePartIcons(Part.PartCategory pCategory)
	{
		Debug.Log("ShufflePartIcons");
		Dictionary<string, Part> partTable = GetPartCategoryTable(pCategory);

		int i = 0;
		Part.FrameID[] frameIds = new Part.FrameID[partTable.Count];

		foreach(Part part in partTable.Values)
		{
			frameIds[i] = part.partIconFrameID;
			i++;
		}

		Shuffle(frameIds);
		Shuffle(frameIds);
		Shuffle(frameIds);

		//Randomize part frame icons
		i = 0;
		Part[] parts = new Part[partTable.Count];

		foreach(Part part in partTable.Values)
		{
			//partTable[part.partId.ToString()].partIconFrameID = frameIds[i];
			part.partIconFrameID = frameIds[i];
			parts[i] = part;
			i++;
		}

		return parts;
	}

	private void Shuffle(Part.FrameID[] pArray)
	{
		for (int t = 0; t < pArray.Length; t++ )			
		{			
			Part.FrameID tmp = pArray[t];			
			int r = Random.Range(t, pArray.Length);			
			pArray[t] = pArray[r];			
			pArray[r] = tmp;			
		}
	}
	
	//The following static functions are used to convert from string to enum values.

	public static Part.FrameID ParseFrameEnum(string value)
	{
		Part.FrameID frameEnum = (Part.FrameID)System.Enum.Parse(typeof(Part.FrameID), value);
		
		return frameEnum;
	}

	public static Part.PartCategory ParseCategoryEnum(string value)
	{
		Part.PartCategory categoryEnum = (Part.PartCategory)System.Enum.Parse(typeof(Part.PartCategory), value);
		
		return categoryEnum;
	}

	public static Part.PartID ParseIDEnum(string value)
	{
		Part.PartID idEnum = (Part.PartID)System.Enum.Parse(typeof(Part.PartID), value);
		
		return idEnum;
	}

	public static Part.WeaponRange ParseRangeEnum(string value)
	{
		Part.WeaponRange rangeEnum = (Part.WeaponRange)System.Enum.Parse(typeof(Part.WeaponRange), value);
		
		return rangeEnum;
	}
}
