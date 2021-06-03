using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Active : MonoBehaviour
{
    public Animator anim;
    public GameObject border;

    public Material[] materials;
    public bool played;

    private void Start()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].SetFloat("_VertBeweging", 0);
        }

    }
    public void play()
    {
        anim.Play("CloseDoor");
        border.SetActive(true);
        StartCoroutine(enableShader());
        
        //material1.shader = Shader.Find("Specular");
    }

    public IEnumerator enableShader()
    {
        foreach(Material m in materials)
        {
            m.SetFloat("_VertBeweging", m.GetFloat("_VertBeweging") + 0.01f * Time.deltaTime);
        }
        yield return new WaitForSeconds(0.01f);
        if(materials[1].GetFloat("_VertBeweging") < 0.6f)
        {
            StartCoroutine(enableShader());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!played)
        {
            play();
            played = true;
        }
    }
}
