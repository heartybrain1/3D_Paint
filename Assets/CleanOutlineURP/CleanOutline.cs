using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace CR
{
	public enum CleanOutlineDebugMode
	{
		Off,
		Depth,
		Normal,
		DepthAndNormal
	}

	public enum CleanOutlineDepthSample
	{
		FiveTiles,
		NineTiles
	}

	[Serializable]
	public sealed class CleanOutlineDebugModeParameter : VolumeParameter<CleanOutlineDebugMode> { }

	[Serializable]
	public sealed class CleanOutlineDepthSampleParameter : VolumeParameter<CleanOutlineDepthSample> { }
	
	[Serializable, VolumeComponentMenu("CR/CleanOutline")]
	public class CleanOutline : VolumeComponent, IPostProcessComponent
	{
		public BoolParameter standaloneActive = new BoolParameter(true, false);

		[Tooltip("Use debug mode to see outlines only")]
        public CleanOutlineDebugModeParameter debugMode = new CleanOutlineDebugModeParameter { value = CleanOutlineDebugMode.Off };

        [Tooltip("Color of outline")]
        public ColorParameter outlineColor = new ColorParameter(Color.black, true);

        [Tooltip("Thickness to both Depth and Normal outlines")]
        public FloatParameter outlineThickness = new FloatParameter(1.0f, true);

        [Tooltip("At closer distance, the outline thickness will be boosted a little")]
        public BoolParameter enableClosenessBoost = new BoolParameter(false);
        
        [Tooltip("Extra boosted thickness at close range")]
        public ClampedFloatParameter closenessBoostThickness = new ClampedFloatParameter(1, 0.01f, 5f);
        
        [Tooltip("The near depth where boost will be 1")]
        public ClampedFloatParameter closenessBoostNear = new ClampedFloatParameter(0.3f, 0.00f, 1f);
       
        [Tooltip("The far depth where boost will be 0")]
        public ClampedFloatParameter closenessBoostFar = new ClampedFloatParameter(0.7f, 0.01f, 1f);

        [Tooltip("At further distance, the outline strength will be reduced, 0 at the farthest")]
        public BoolParameter enableDistanceFade = new BoolParameter(true, true);
        
        [Tooltip("The near depth where fade started as 1")]
        public ClampedFloatParameter distanceFadeNear = new ClampedFloatParameter(0.15f, 0.00f, 1f, true);
        
        [Tooltip("The near depth where fade will reach 0 to give no outline")]
        public ClampedFloatParameter distanceFadeFar = new ClampedFloatParameter(0.6f, 0.01f, 1f, true);
                
        ///depth
        [Tooltip("Depth Sample Type")]
        public CleanOutlineDepthSampleParameter depthSampleType = new CleanOutlineDepthSampleParameter { value = CleanOutlineDepthSample.FiveTiles };
        [Tooltip("Thickness of depth outline")]
        public FloatParameter depthThickness = new FloatParameter(1.0f, true);

        [Tooltip("Multiplier of the depth outline strength")]
        public FloatParameter depthMultiplier = new FloatParameter(1.0f, true);

        [Tooltip("Bias of the depth outline strength")]
        public FloatParameter depthBias = new FloatParameter(1.0f, true);

        [Tooltip("Threshold of the depth outline, sample result lower than threshold will be ignored")]
        public ClampedFloatParameter depthThreshold = new ClampedFloatParameter(0.1f, 0f, 1f, true);

        [Tooltip("Threshold to remap the NineTiles depth result")]
        
        public ClampedFloatParameter depth9TilesThreshold = new ClampedFloatParameter(0.5f, 0f, 1f, true);
        
        [Tooltip("A bottom height to fix a weird effect in NineTiles sample")]
        public ClampedFloatParameter depth9TilesBottomFix = new ClampedFloatParameter(0.005f, 0.0f, 0.1f, true);
     
        [Tooltip("Thickness of Normal")]
        public FloatParameter normalThickness = new FloatParameter(1.0f, true);

        [Tooltip("Noraml check direction instead raw values, directions will be calculated into angles to check the difference")]
        public BoolParameter normalCheckDirection = new BoolParameter(true, true);

        [Tooltip("Multiplier of the normal outline strength")]
        public FloatParameter normalMultiplier = new FloatParameter(5.0f, true);

        [Tooltip("Bias of the normal outline strength")]
        public FloatParameter normalBias = new FloatParameter(10.0f, true);

        [Tooltip("Threshold of the normal outline, sample result lower than threshold will be ignored")]
        public ClampedFloatParameter normalThreshold = new ClampedFloatParameter(0.3f, 0f, 1f, true);

        [Tooltip("Best practice is to normal outline only for lowploy scense, if for high poly and normal texture object it will appear weirdly")]
        public BoolParameter enableNormalOutline = new BoolParameter( true, true);

        public bool IsActive()
        {
	        return standaloneActive.value;
        }
   
		public bool IsTileCompatible() => true;
		
	}
}
