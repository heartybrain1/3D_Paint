using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEditor.Rendering.Universal;

namespace CR
{
	[VolumeComponentEditor(typeof(CleanOutline))]
	public class CleanOutlineEditor : VolumeComponentEditor
	{
		private SerializedDataParameter standaloneActive;
		private SerializedDataParameter debugMode;
		private SerializedDataParameter outlineColor;
		private SerializedDataParameter outlineThickness;
		private SerializedDataParameter enableClosenessBoost;
		private SerializedDataParameter closenessBoostThickness;
		private SerializedDataParameter closenessBoostNear;
		private SerializedDataParameter closenessBoostFar;
		private SerializedDataParameter enableDistanceFade;
		private SerializedDataParameter distanceFadeNear;
		private SerializedDataParameter distanceFadeFar;
		private SerializedDataParameter depthSampleType;
		private SerializedDataParameter depthThickness;
		private SerializedDataParameter depthMultiplier;
		private SerializedDataParameter depthBias;
		private SerializedDataParameter depthThreshold;
		private SerializedDataParameter depth9TilesThreshold;
		private SerializedDataParameter depth9TilesBottomFix;
		private SerializedDataParameter normalThickness;
		private SerializedDataParameter normalCheckDirection;
		private SerializedDataParameter normalMultiplier;
		private SerializedDataParameter normalBias;
		private SerializedDataParameter normalThreshold;
		private SerializedDataParameter enableNormalOutline;
		
		public override void OnEnable()
		{
			var o = new PropertyFetcher<CleanOutline>(serializedObject);

			standaloneActive = Unpack(o.Find(x => x.standaloneActive));
			debugMode = Unpack(o.Find(x => x.debugMode));
			outlineColor = Unpack(o.Find(x => x.outlineColor));
			outlineThickness = Unpack(o.Find(x => x.outlineThickness));
			enableClosenessBoost = Unpack(o.Find(x => x.enableClosenessBoost));
			closenessBoostThickness = Unpack(o.Find(x => x.closenessBoostThickness));
			closenessBoostNear = Unpack(o.Find(x => x.closenessBoostNear));
			closenessBoostFar = Unpack(o.Find(x => x.closenessBoostFar));
			enableDistanceFade = Unpack(o.Find(x => x.enableDistanceFade));
			distanceFadeNear = Unpack(o.Find(x => x.distanceFadeNear));
			distanceFadeFar = Unpack(o.Find(x => x.distanceFadeFar));
			depthSampleType = Unpack(o.Find(x => x.depthSampleType));
			depthThickness = Unpack(o.Find(x => x.depthThickness));
			depthMultiplier = Unpack(o.Find(x => x.depthMultiplier));
			depthBias = Unpack(o.Find(x => x.depthBias));
			depthThreshold = Unpack(o.Find(x => x.depthThreshold));
			depth9TilesThreshold = Unpack(o.Find(x => x.depth9TilesThreshold));
			depth9TilesBottomFix = Unpack(o.Find(x => x.depth9TilesBottomFix));
			normalThickness = Unpack(o.Find(x => x.normalThickness));
			normalCheckDirection = Unpack(o.Find(x => x.normalCheckDirection));
			normalMultiplier = Unpack(o.Find(x => x.normalMultiplier));
			normalBias = Unpack(o.Find(x => x.normalBias));
			normalThreshold = Unpack(o.Find(x => x.normalThreshold));
			enableNormalOutline = Unpack(o.Find(x => x.enableNormalOutline));
		}

		public override void OnInspectorGUI()
		{  
			PropertyField(standaloneActive);
			EditorGUILayout.LabelField("General", EditorStyles.miniLabel);
			PropertyField(outlineColor);
			PropertyField(outlineThickness);

			EditorGUILayout.BeginVertical("box");
			PropertyField(enableClosenessBoost);
			if (enableClosenessBoost.value.boolValue)
			{
				PropertyField(closenessBoostThickness);
				PropertyField(closenessBoostNear);
				PropertyField(closenessBoostFar);
			}
			EditorGUILayout.EndVertical();

			EditorGUILayout.BeginVertical("box");
			PropertyField(enableDistanceFade);
			if (enableDistanceFade.value.boolValue)
			{
				PropertyField(distanceFadeNear);
				PropertyField(distanceFadeFar);
			}
			EditorGUILayout.EndVertical();

			EditorGUILayout.BeginVertical("box");
			EditorGUILayout.LabelField("Depth", EditorStyles.miniLabel);
			PropertyField(depthThickness);
			PropertyField(depthMultiplier);
			PropertyField(depthBias);
			PropertyField(depthThreshold);
			PropertyField(depthSampleType);
			if (depthSampleType.value.enumValueIndex == 0)
			{

			}
			else if (depthSampleType.value.enumValueIndex == 1)
			{
				PropertyField(depth9TilesThreshold);
				PropertyField(depth9TilesBottomFix);
			}
			EditorGUILayout.EndVertical();

			EditorGUILayout.BeginVertical("box");
			EditorGUILayout.LabelField("Normal", EditorStyles.miniLabel);
			PropertyField(enableNormalOutline);
			PropertyField(normalThickness);
			PropertyField(normalCheckDirection);
			PropertyField(normalMultiplier);
			PropertyField(normalBias);
			PropertyField(normalThreshold);
			EditorGUILayout.EndVertical();

			EditorGUILayout.LabelField("Debug", EditorStyles.miniLabel);
			PropertyField(debugMode);
		}
	}
}
