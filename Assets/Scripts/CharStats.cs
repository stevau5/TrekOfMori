﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{

    public string charName;
    public int playerLevel = 1;
    public int currentEXP;
    public int[] expToNextLevel;
    public int maxLevel = 100;
    public int baseEXP = 1000; 


    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 100;
    public int[] mpLvlBonus; 
    public int strength;
    public int defence;
    public int weaponPower;
    public int armorPower;
    public string equippedWeapon;
    public string equippedArmor;
    public Sprite charImage; 

    // Start is called before the first frame update
    void Start()
    {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP; 

        for(int i = 2; i < expToNextLevel.Length; i++) {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i-1] * 1.05f);
        }


        mpLvlBonus = new int[maxLevel];
        mpLvlBonus[1] = 5;
        for(int i = 2; i < mpLvlBonus.Length; i++) {
            mpLvlBonus[i] = mpLvlBonus[i - 1] + 2; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K)) {
            addExp(250);
        }
    }

    public void addExp(int expToAdd) {
        currentEXP += expToAdd;

        if (playerLevel < maxLevel) {
            if (currentEXP >= expToNextLevel[playerLevel]) {
                currentEXP -= expToNextLevel[playerLevel];
                playerLevel++;
                Debug.Log("Congrats, you are now level: " + playerLevel);

                //determine whether to add str or def .. based on odd or even.

                if (playerLevel % 2 == 0) {
                    strength++;
                    Debug.Log("Congrats, your strength level is now: " + strength);

                }
                else {
                    defence++;
                    Debug.Log("Congrats, your defence level is now: " + defence);

                }

                maxHP = Mathf.FloorToInt(maxHP * 1.05f);
                currentHP = maxHP;

                maxMP += mpLvlBonus[playerLevel-1];
                currentMP = maxMP;

            }
        }

        if(playerLevel >= maxLevel) {
            currentEXP = 0;
        }

    }


}
