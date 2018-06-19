using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    public GameObject panel;
    public AudioManager audsrc;

    public void PickGanfaul()
    {
        panel.SetActive(true);

        PlayerSelect.Instance.playerName = "Ganfaul";

        audsrc.GanfaulPickPlay();
    }

    public void PickMaria()
    {
        panel.SetActive(true);

        PlayerSelect.Instance.playerName = "Maria";

        audsrc.MariaPickPlay();
    }
}
