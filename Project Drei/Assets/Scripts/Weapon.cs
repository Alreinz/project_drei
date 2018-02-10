using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public string weaponName;
    public Sprite sprite;
    public GameObject bullet;
    public float spread;
    public float reloadTime;

    public bool loaded = true;
    
    public bool Fire ( Vector2 direction ) {
        if ( loaded ) {
            GameObject bulletObject = GameObject.Instantiate(bullet);
            bulletObject.transform.position = this.transform.position;

            float actualSpread = Random.Range(-spread, spread);
            //Debug.Log(direction);
            Projectile bulletScript = bulletObject.GetComponent<Projectile>();
            bulletScript.Initialize(direction);
            loaded = false;
            Invoke("Reload", reloadTime);
            return true;
        } else {
            return false;
        }
    }

    public void Reload () {
        loaded = true;
    }
}
