using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum AchievementCondition {
	EQUALS, GREATER_THAN, LESS_THAN, GREATER_THAN_OR_EQUALS, LESS_THAN_OR_EQUALS, NOT
}

public enum DataType {
	BOOL, INT, FLOAT, DOUBLE
}

[System.Serializable]
public class AchievementValue {
	public DataType targetValueType;
	private string propertyName;
	private object observableObject;
	
	public object val {
		get {
			return observableObject.GetType().GetProperty(propertyName).GetValue(observableObject, null);
		}
	}

	public AchievementValue ( object observableObject, string propertyName ) {
		this.observableObject = observableObject;
		this.propertyName = propertyName;
		
		Debug.Log(observableObject);
		Debug.Log(propertyName);
		if (val is bool ) {
			targetValueType = DataType.BOOL;
		} else if ( val is int) {
			targetValueType = DataType.INT;
		} else if ( val is float ) {
			targetValueType = DataType.FLOAT;
		}
	}
}

[System.Serializable]
public class Achievement:MonoBehaviour {
	
	public string title;
	public string description;
	public GameObject observableObject;
	protected AchievementValue observableValue;
	
	private DataType targetValueType;
	public string variableName;
	public AchievementCondition condition;
	public int intValue;
	public float floatValue;
	public bool boolValue;
	
	public bool isComplete;
	public bool isProcessed;

	//public void Start () {
		//SetObservable(observableObject, variableName);
	//} /

	protected void SetObservable ( object obj, string propertyName ) {
		observableValue = new AchievementValue(obj, propertyName);
		targetValueType = observableValue.targetValueType;
	}
	
	public void Update () {
		if ( !isComplete && observableObject) {
			switch ( targetValueType ) {
				case DataType.BOOL:
					CheckBoolCondition( (bool) observableValue.val, boolValue, condition);
					break;
				case DataType.INT:
					CheckIntegerCondition( (int)observableValue.val, intValue, condition);
					break;
				case DataType.FLOAT:
					CheckFloatCondition( (float)observableValue.val, floatValue, condition);
					break;
			}
		}
	}
	
	void CheckBoolCondition ( bool value, bool targetValue, AchievementCondition condition ) {
		switch ( condition ) {
			case AchievementCondition.EQUALS:
				if ( value == targetValue ) {
					isComplete = true;
				}
				break;
			case AchievementCondition.NOT:
				if ( value != targetValue ) {
					isComplete = true;
				}
				break;
		}
	}
	
	void CheckIntegerCondition ( int value, int targetValue, AchievementCondition condition ) {
		switch ( condition ) {
			case AchievementCondition.EQUALS:
				if ( value == targetValue ) {
					isComplete = true;
				}
				break;
			case AchievementCondition.NOT:
				if ( value != targetValue ) {
					isComplete = true;
				}
				break;
			case AchievementCondition.GREATER_THAN_OR_EQUALS:
				if ( value >= targetValue ) {
					isComplete = true;
				}
				break;
			case AchievementCondition.GREATER_THAN:
				if ( value > targetValue ) {
					isComplete = true;
				}
				break;
			case AchievementCondition.LESS_THAN_OR_EQUALS:
				if ( value <= targetValue ) {
					isComplete = true;
				}
				break;
			case AchievementCondition.LESS_THAN:
				if ( value < targetValue ) {
					isComplete = true;
				}
				break;
		}
	}
	
	void CheckFloatCondition ( float value, float targetValue, AchievementCondition condition ) {
		switch ( condition ) {
			case AchievementCondition.EQUALS:
				if ( value == targetValue ) {
					isComplete = true;
				}
				break;
			case AchievementCondition.NOT:
				if ( value != targetValue ) {
					isComplete = true;
				}
				break;
			case AchievementCondition.GREATER_THAN_OR_EQUALS:
				if ( value >= targetValue ) {
					isComplete = true;
				}
				break;
			case AchievementCondition.GREATER_THAN:
				if ( value > targetValue ) {
					isComplete = true;
				}
				break;
			case AchievementCondition.LESS_THAN_OR_EQUALS:
				if ( value <= targetValue ) {
					isComplete = true;
				}
				break;
			case AchievementCondition.LESS_THAN:
				if ( value < targetValue ) {
					isComplete = true;
				}
				break;
		}
	}
}


/*
[CustomEditor(typeof(Achievement))]
public class AchievementEditor:Editor {
	
	private Achievement achievement;
	public SerializedProperty targetValueType;
	SerializedProperty intValue;
	SerializedProperty floatValue;
	SerializedProperty boolValue;

	private void OnEnable () {
		targetValueType = serializedObject.FindProperty("targetValueType");
		intValue = serializedObject.FindProperty("intValue");
		floatValue = serializedObject.FindProperty("floatValue");
		boolValue = serializedObject.FindProperty("boolValue");
	}

	public override void OnInspectorGUI () {
		serializedObject.Update();
		achievement = (Achievement) target;
		
		System.Reflection.MemberInfo[] members = achievement.observableObject.GetType().GetMembers();
		string [] memberInfo = new string[members.Length];
		for ( int i = 0; i  < memberInfo.Length; i++ ) {
			memberInfo[i] = members[i].Name;
		}
		int selected = 0;
		selected = EditorGUILayout.Popup("Label", selected, memberInfo); 

        serializedObject.ApplyModifiedProperties ();
	}
}*/