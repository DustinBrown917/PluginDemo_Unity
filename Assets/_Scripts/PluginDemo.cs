using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class PluginDemo : MonoBehaviour
{
    const string dllFile = "WeightedRand";

    [DllImport(dllFile)]
    private static extern int GetVal(int[] vals, float[] weights, int count);

    public WeightedPair[] weightedList = new WeightedPair[0];

    public bool test = false;


    private void OnValidate()
    {
        if (test) {
            Debug.Log(GetValue());
            test = false;
        }
    }

    public int GetValue()
    {
        if(weightedList.Length == 0) { return 0; }

        int[] vals = new int[weightedList.Length];
        float[] weights = new float[weightedList.Length];

        for(int i = 0; i < weightedList.Length; i++) {
            vals[i] = weightedList[i].value;
            weights[i] = weightedList[i].weight;
        }

        return GetVal(vals, weights, weightedList.Length);
    }

    [Serializable]
    public class WeightedPair
    {
        public int value = 0;
        public float weight = 0.0f;
    }
}
