using System.Collections;
using UnityEngine;

public class AIBossManager : AICharacterManager
{
    public int bossID = 0;
    [SerializeField] bool hasBeenDefeated = false;

    [Header("TEST")]
    [SerializeField] bool defeatBossDebug = false;

    protected override void Awake()
    {
        if (!WorldSaveGameManager.instance.currentPlayerData.bossesAwake.ContainsKey(bossID))
        {
            WorldSaveGameManager.instance.currentPlayerData.bossesAwake.Add(bossID, false);
            WorldSaveGameManager.instance.currentPlayerData.bossesDefeat.Add(bossID, false);
        }
        else
        {
            hasBeenDefeated = WorldSaveGameManager.instance.currentPlayerData.bossesDefeat[bossID];

            if (hasBeenDefeated)
            {
                gameObject.SetActive(false);
            }
        }
    }

    protected override void Update()
    {
        base.Update();

        if (defeatBossDebug)
        {
            defeatBossDebug = false;
            hasBeenDefeated = true;

            if (!WorldSaveGameManager.instance.currentPlayerData.bossesAwake.ContainsKey(bossID))
            {
                WorldSaveGameManager.instance.currentPlayerData.bossesAwake.Add(bossID, true);
                WorldSaveGameManager.instance.currentPlayerData.bossesDefeat.Add(bossID, true);
            }
            else
            {
                WorldSaveGameManager.instance.currentPlayerData.bossesAwake.Remove(bossID);
                WorldSaveGameManager.instance.currentPlayerData.bossesDefeat.Remove(bossID);
                WorldSaveGameManager.instance.currentPlayerData.bossesAwake.Add(bossID, true);
                WorldSaveGameManager.instance.currentPlayerData.bossesDefeat.Add(bossID, true);
            }

            WorldSaveGameManager.instance.SaveGame();
        }
    }

    public IEnumerator ProcessDeathEvent()
    {
        characterStatManager.CurrentHealth = 0;
        characterCurrentState.isDead = true;

        hasBeenDefeated = true;

        if (!WorldSaveGameManager.instance.currentPlayerData.bossesAwake.ContainsKey(bossID))
        {
            WorldSaveGameManager.instance.currentPlayerData.bossesAwake.Add(bossID, true);
            WorldSaveGameManager.instance.currentPlayerData.bossesDefeat.Add(bossID, true);
        }
        else
        {
            WorldSaveGameManager.instance.currentPlayerData.bossesAwake.Remove(bossID);
            WorldSaveGameManager.instance.currentPlayerData.bossesDefeat.Remove(bossID);
            WorldSaveGameManager.instance.currentPlayerData.bossesAwake.Add(bossID, true);
            WorldSaveGameManager.instance.currentPlayerData.bossesDefeat.Add(bossID, true);
        }

        WorldSaveGameManager.instance.SaveGame();

        yield return new WaitForSeconds(5);


    }
}
