﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float intensity;
    private Material material;
    public Shader shader;

    // Creates a private material used to the effect
    void Awake()
    {
        material = new Material(shader);
    }

    // Postprocess the image
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (intensity == 0)
        {
            Graphics.Blit(source, destination);
            return;
        }

        material.SetFloat("_intensity", intensity);
        Graphics.Blit(source, destination, material);

    }
}
