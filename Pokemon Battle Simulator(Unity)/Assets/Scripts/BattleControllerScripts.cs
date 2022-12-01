using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Networking;
using System.Linq;

public class BattleControllerScripts : MonoBehaviour
{
    private System.Random Rand = new System.Random();
    private Functions fn = new Functions();
    private List<ActivePokemon> Team1 = new List<ActivePokemon>();
    private List<ActivePokemon> Team2 = new List<ActivePokemon>();
    private Team T1;
    private Team T2;
    private ActivePokemon T1Fighter;
    private ActivePokemon T2Fighter;
    private Move T1Move;
    private Move T2Move;
    private List<int> T1BattleStats;
    private List<int> T2BattleStats;
    private AI Ai;
    [SerializeField] private Texture2D[] Team1Textures = new Texture2D[6];
    [SerializeField] private Texture2D[] Team2Textures = new Texture2D[6];
    [SerializeField] private List<string> PlayerFaintedMembers = new List<string>();
    [SerializeField] private List<string> AiFaintedMembers = new List<string>();

    [Header("Battle Elements")]
    [SerializeField] private GameObject Content;
    [SerializeField] private TextMeshProUGUI T1Health;
    [SerializeField] private TextMeshProUGUI T2Health;
    [Header("Prefabs")]
    [SerializeField] private GameObject MoveBox;
    [SerializeField] private GameObject SwitchBox;
    [Header("On-Screen Images")]
    [SerializeField] private RawImage P1Image;
    [SerializeField] private RawImage P2Image;
    [SerializeField] private RawImage P1Pokeball;
    [SerializeField] private RawImage P2Pokeball;
    [SerializeField] private Image P1Healthbar;
    [SerializeField] private Image P2Healthbar;
    [SerializeField] private Image P1Deathbar;
    [SerializeField] private Image P2Deathbar;
    [Header("Music")]
    [SerializeField] private AudioClip BattleTheme;
    [SerializeField] private AudioClip VictoryTheme;
    [SerializeField] private AudioClip LossSound;
    [Header("Misc")]
    [SerializeField] private Texture2D Pokeball;

    private int AiTier = 1;
    private int TurnCounter = 1;
    private int BoxYpos = -275;
    private int BoxXpos = -780;
    private bool Waiting = true;
    private bool T1Moved = false;
    private bool T2Moved = false;
    private bool SetFieldGifs = false;
    private bool GennedSwitches = false;
    private bool T1Fainted = false;
    private bool T2Fainted = false;
    private bool T1WaitingforSwitch = false;
    private bool T2WaitingforSwitch = false;
    private bool PlayerWins = false;
    private bool AiWins = false;
    private bool GameOver = false;
    private GameObject[] MoveBoxes = new GameObject[4];
    private GameObject[] SwitchBoxes = new GameObject[6];
    private bool Raises;
    private bool AttackChange = false;
    private bool DefenseChange = false;
    private bool SpecialAttackChange = false;
    private bool SpecialDefenseChange = false;
    private bool User;
    private bool SpeedChange = false;
    private int Stages;
    private bool Ready = false;
    // Start is called before the first frame update
    void Start()
    {
        fn.GenTypes();
        fn.GenNatures();
        fn.SetInflictors();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameOver == false)
        {
            if(Ready == true)
            {
                if (PlayerWins == false && AiWins == false)
                {
                    #region Texture
                    if (P1Image.GetComponent<UniGifImage>().nowState != UniGifImage.State.Loading && P2Image.GetComponent<UniGifImage>().nowState != UniGifImage.State.Loading && SetFieldGifs == false)
                    {
                        P1Image.rectTransform.sizeDelta = new Vector2(P1Image.GetComponent<UniGifImageAspectController>().m_originalWidth * 2.5f, P1Image.GetComponent<UniGifImageAspectController>().m_originalHeight * 2.5f);
                        P1Pokeball.enabled = false;
                        P1Image.enabled = true;
                        P2Image.rectTransform.sizeDelta = new Vector2(P2Image.GetComponent<UniGifImageAspectController>().m_originalWidth * 2.5f, P2Image.GetComponent<UniGifImageAspectController>().m_originalHeight * 2.5f);
                        P2Pokeball.enabled = false;
                        P2Image.enabled = true;
                        if (MoveBoxes[0] != null)
                        {
                            MoveBoxes[0].GetComponent<Button>().interactable = true;
                        }
                        if (MoveBoxes[1] != null)
                        {
                            MoveBoxes[1].GetComponent<Button>().interactable = true;
                        }
                        if (MoveBoxes[2] != null)
                        {
                            MoveBoxes[2].GetComponent<Button>().interactable = true;
                        }
                        if (MoveBoxes[3] != null)
                        {
                            MoveBoxes[3].GetComponent<Button>().interactable = true;
                        }
                        SetFieldGifs = true;
                    }
                    if (CheckTextures() == true && GennedSwitches == false)
                    {
                        GenSwitchBoxes();
                        GennedSwitches = true;
                    }
                    #endregion
                    #region Checks
                    P1Healthbar.fillAmount = (float)T1BattleStats[0] / (float)T1Fighter.HP;
                    P2Healthbar.fillAmount = (float)T2BattleStats[0] / (float)T2Fighter.HP;
                    if (T1BattleStats[0] > 0)
                    {
                        T1Health.text = $"{T1BattleStats[0]}/{T1Fighter.ReturnStat(0)}";
                    }
                    else
                    {
                        T1Health.text = $"0/{T1Fighter.ReturnStat(0)}";
                    }
                    if (T2BattleStats[0] > 0)
                    {
                        T2Health.text = $"{T2BattleStats[0]}/{T2Fighter.ReturnStat(0)}";
                    }
                    else
                    {
                        T2Health.text = $"0/{T2Fighter.ReturnStat(0)}";
                    }

                    if (T1BattleStats[0] <= 0 && T1WaitingforSwitch == false)
                    {
                        FaintPokemon(1);
                        T1Fainted = true;
                    }
                    else
                    {
                        T1Fainted = false;
                    }
                    if (T2BattleStats[0] <= 0 && T2WaitingforSwitch == false)
                    {
                        FaintPokemon(2);
                        T2Fainted = true;
                    }
                    else
                    {
                        T2Fainted = false;
                    }
                    if (T1Moved == true && T2Moved == true)
                    {
                        if (T1WaitingforSwitch == false && T2WaitingforSwitch == false)
                        {
                            T1Moved = false;
                            T2Moved = false;
                            CompleteTurn();
                        }
                    }
                    #endregion
                }
                else
                {
                    if (PlayerWins == true)
                    {
                        GameObject.Find("MusicController").SendMessage("PlayMusic", VictoryTheme);
                        Content.GetComponent<ContentUpdate>().AddText("Turn", "You Win!");
                        GameOver = true;
                    }

                    if (AiWins == true)
                    {
                        GameObject.Find("MusicController").SendMessage("PlayMusic", LossSound);
                        Content.GetComponent<ContentUpdate>().AddText("Turn", "You Lost...");
                        GameOver = true;
                    }
                }
            }
        }
    }

    public void SetBattleSetup(Team ChosenTeam, int ChosenAi)
    {
        T1 = ChosenTeam;
        AiTier = ChosenAi;
        if (T1 != null)
        {
            foreach (Pokemon p in T1.ReturnList())
            {
                Team1.Add(fn.ConvertToActive(p));
            }
        }
        Ai = new AI(AiTier - 1);
        Team2 = Ai.ReturnTeam();
        T1Fighter = Team1[0];
        T2Fighter = Team2[0];
        for (int i = 0; i < Team1.Count; i++)
        {
            StartCoroutine(GetTexture(WebScraper.GetPokemonImageRef(Team1[i].ReturnName()), 1, i));
        }
        for (int i = 0; i < Team2.Count; i++)
        {
            StartCoroutine(GetTexture(WebScraper.GetPokemonImageRef(Team2[i].ReturnName()), 2, i));
        }
        P1Image.enabled = false;
        P1Image.GetComponent<UniGifImage>().SetGifFromUrl(WebScraper.GetPokemonShowdownGifRef(T1Fighter.ReturnName(), T1Fighter.Shiny, true));
        P1Image.transform.rotation = Quaternion.identity;
        P2Image.enabled = false;
        P2Image.GetComponent<UniGifImage>().SetGifFromUrl(WebScraper.GetPokemonShowdownGifRef(T2Fighter.ReturnName(), T2Fighter.Shiny, false));
        for (int i = 0; i < T1Fighter.Moveset.Count; i++)
        {
            Instantiate(MoveBox, new Vector3(BoxXpos, BoxYpos, 0), Quaternion.identity, transform.parent.gameObject.transform);
            MoveBoxes[i] = GameObject.Find("MoveButton(Clone)");
            GameObject.Find("MoveButton(Clone)").GetComponent<MoveBoxScript>().SetMove(T1Fighter.Moveset[i]);
            BoxXpos += 350;
        }
        BoxXpos = -770;
        BoxYpos = -350;
        T1BattleStats = T1Fighter.stats.ToList();
        T2BattleStats = T2Fighter.stats.ToList();
        P1Pokeball.texture = Pokeball;
        P2Pokeball.texture = Pokeball;
        if (MoveBoxes[0] != null)
        {
            MoveBoxes[0].GetComponent<Button>().interactable = false;
        }
        if (MoveBoxes[1] != null)
        {
            MoveBoxes[1].GetComponent<Button>().interactable = false;
        }
        if (MoveBoxes[2] != null)
        {
            MoveBoxes[2].GetComponent<Button>().interactable = false;
        }
        if (MoveBoxes[3] != null)
        {
            MoveBoxes[3].GetComponent<Button>().interactable = false;
        }
        GameObject.Find("MusicController").SendMessage("PlayMusic", BattleTheme);
        Ready = true;
    }

    public void SwitchPokemon(string PokemonName)
    {
        int TeamIndex = 0;
        for(int i = 0; i < Team1.Count; i++)
        {
            if(Team1[i].ReturnName() == PokemonName)
            {
                TeamIndex = i;
                break;
            }
        }
        P1Pokeball.enabled = true;
        P1Image.enabled = false;
        StartCoroutine(P1Image.GetComponent<UniGifImage>().SetGifFromUrlCoroutine(WebScraper.GetPokemonShowdownGifRef(Team1[TeamIndex].ReturnName(), Team1[TeamIndex].Shiny, true)));
        if (MoveBoxes[0] != null)
        {
            MoveBoxes[0].GetComponent<Button>().interactable = false;
        }
        if (MoveBoxes[1] != null)
        {
            MoveBoxes[1].GetComponent<Button>().interactable = false;
        }
        if (MoveBoxes[2] != null)
        {
            MoveBoxes[2].GetComponent<Button>().interactable = false;
        }
        if (MoveBoxes[3] != null)
        {
            MoveBoxes[3].GetComponent<Button>().interactable = false;
        }
        SetFieldGifs = false;
        for(int i = 0; i < MoveBoxes.Length; i++)
        {
            if (MoveBoxes[i] != null)
            {
                if(i < Team1[TeamIndex].Moveset.Count)
                {
                    MoveBoxes[i].gameObject.SetActive(true);
                    MoveBoxes[i].GetComponent<MoveBoxScript>().SetMove(Team1[TeamIndex].Moveset[i]);
                }
                else
                {
                    MoveBoxes[i].gameObject.SetActive(false);
                }
            }
            else
            {
                Instantiate(MoveBox, new Vector3(-780 + (350 * (i + 1)), -275, 0), Quaternion.identity, transform.parent.gameObject.transform);
                MoveBoxes[i] = GameObject.Find("MoveButton(Clone)");
                GameObject.Find("MoveButton(Clone)").GetComponent<MoveBoxScript>().SetMove(Team1[TeamIndex].Moveset[i]);
            }
        }
        Content.GetComponent<ContentUpdate>().AddText("Default", $"{T1Fighter.ReturnName()} come back!");
        T1Fighter = Team1[TeamIndex];
        T1BattleStats = T1Fighter.stats.ToList();
        Content.GetComponent<ContentUpdate>().AddText("Default", $"Go {T1Fighter.ReturnName()}!");
        P1Image.rectTransform.sizeDelta = new Vector2(200, 200);
        T1WaitingforSwitch = false;
    }

    public void CheckStatusUse(string MoveEffect)
    {
        string[] Words = MoveEffect.Split(' ');
        string prev;
        foreach (string w in Words)
        {
            prev = w;
            switch (w)
            {
                case "raises":
                    Raises = true;
                    break;

                case "lowers":
                    Raises = false;
                    break;

                case "user's":
                    User = true;
                    break;

                case "target's":
                    User = false;
                    break;

                case "Attack":
                    if (prev == "Special")
                    {
                        SpecialAttackChange = true;
                    }
                    else
                    {
                        AttackChange = true;
                    }
                    break;

                case "Defense":
                    if (prev == "Special")
                    {
                        SpecialDefenseChange = true;
                    }
                    else
                    {
                        DefenseChange = true;
                    }
                    break;

                case "Speed":
                    SpeedChange = true;
                    break;

                case "one":
                    Stages = 1;
                    break;

                case "two":
                    Stages = 2;
                    break;

                case "three":
                    Stages = 3;
                    break;

                case "four":
                    Stages = 4;
                    break;

                case "five":
                    Stages = 5;
                    break;
            }
        }
    }

    public void FaintPokemon(int Team)
    {
        switch (Team)
        {
            case 1:
                T1WaitingforSwitch = true;
                Content.GetComponent<ContentUpdate>().AddText("Default", $"{T1Fighter.ReturnName()} Fainted");
                P1Image.rectTransform.sizeDelta = new Vector2(90, 90);
                P1Image.enabled = false;
                P1Pokeball.enabled = true;
                PlayerFaintedMembers.Add(T1Fighter.ReturnName());
                int PlayerCheck = 0;
                foreach(ActivePokemon p in Team1)
                {
                    if (PlayerFaintedMembers.Contains(p.ReturnName()))
                    {
                        PlayerCheck++;
                    }
                }
                if(PlayerCheck >= Team1.Count)
                {
                    AiWins = true;
                }
                if (MoveBoxes[0] != null)
                {
                    MoveBoxes[0].GetComponent<Button>().interactable = false;
                }
                if (MoveBoxes[1] != null)
                {
                    MoveBoxes[1].GetComponent<Button>().interactable = false;
                }
                if (MoveBoxes[2] != null)
                {
                    MoveBoxes[2].GetComponent<Button>().interactable = false;
                }
                if (MoveBoxes[3] != null)
                {
                    MoveBoxes[3].GetComponent<Button>().interactable = false;
                }
                for(int i = 0; i < SwitchBoxes.Length; i++)
                {
                    if(SwitchBoxes[i] != null)
                    {
                        if(SwitchBoxes[i].GetComponent<SwitchBoxScript>().ReturnPokemonName() == T1Fighter.ReturnName())
                        {
                            SwitchBoxes[i].GetComponent<Button>().interactable = false;
                            break;
                        }
                    }
                }
                break;

            case 2:
                T2WaitingforSwitch = true;
                Content.GetComponent<ContentUpdate>().AddText("Default", $"{T2Fighter.ReturnName()} Fainted");
                P2Image.rectTransform.sizeDelta = new Vector2(90, 90);
                P2Image.enabled = false;
                P2Pokeball.enabled = true;
                AiFaintedMembers.Add(T2Fighter.ReturnName().ToLower());
                int TeamIndex = Ai.SwitchPokemon(T1Fighter, AiFaintedMembers);
                if(TeamIndex == 10)
                {
                    PlayerWins = true;
                    return;
                }
                Content.GetComponent<ContentUpdate>().AddText("Change", $"The enemy retrieved {T2Fighter.ReturnName()}");
                T2Fighter = Team2[TeamIndex];
                for (int i = 0; i < T1BattleStats.Count; i++)
                {
                    T2BattleStats[i] = T2Fighter.ReturnStat(i);
                }
                Content.GetComponent<ContentUpdate>().AddText("Change", $"The enemy sent out {T2Fighter.ReturnName()}");
                StartCoroutine(P2Image.GetComponent<UniGifImage>().SetGifFromUrlCoroutine(WebScraper.GetPokemonShowdownGifRef(Team2[TeamIndex].ReturnName(), Team2[TeamIndex].Shiny, false)));
                SetFieldGifs = false;
                T2WaitingforSwitch = false;
                break;
        }
    }
    public void CompleteTurn()
    {
        if (T1BattleStats[5] > T2BattleStats[5])
        {
            Content.GetComponent<ContentUpdate>().AddText("Turn", $"Turn: {TurnCounter}");
            TurnCounter++;
            UseMove(T1Fighter, T2Fighter, T1Move, 1, 1);
            if (T2BattleStats[0] > 0)
            {
                UseMove(T2Fighter, T1Fighter, T2Move, 1, 2);
            }
            foreach (GameObject MoveBox in MoveBoxes)
            {
                if (MoveBox != null)
                {
                    MoveBox.GetComponent<MoveBoxScript>().SetAvailable();
                }
            }
            return;
        }

        if (T1BattleStats[5] < T2BattleStats[5])
        {
            Content.GetComponent<ContentUpdate>().AddText("Turn", $"Turn: {TurnCounter}");
            TurnCounter++;
            UseMove(T2Fighter, T1Fighter, T2Move, 1, 2);
            if (T1BattleStats[0] > 0)
            {
                UseMove(T1Fighter, T2Fighter, T1Move, 1, 1);
            }
            foreach (GameObject MoveBox in MoveBoxes)
            {
                if (MoveBox != null)
                {
                    MoveBox.GetComponent<MoveBoxScript>().SetAvailable();
                }
            }
            return;
        }

        if (T1BattleStats[5] == T2BattleStats[5])
        {
            int ran = Rand.Next(0, 1);
            switch (ran)
            {
                case 0:
                    UseMove(T1Fighter, T2Fighter, T1Move, 1, 1);
                    T1Moved = false;
                    if (T2BattleStats[0] > 0)
                    {
                        UseMove(T2Fighter, T1Fighter, T2Move, 1, 2);
                    }
                    T2Moved = false;
                    break;

                case 1:
                    UseMove(T2Fighter, T1Fighter, T2Move, 1, 2);
                    T2Moved = false;
                    if (T1BattleStats[0] > 0)
                    {
                        UseMove(T1Fighter, T2Fighter, T1Move, 1, 1);
                    }
                    T1Moved = false;
                    break;
            }
        }
        foreach (GameObject MoveBox in MoveBoxes)
        {
            if (MoveBox != null)
            {
                MoveBox.GetComponent<MoveBoxScript>().SetAvailable();
            }
        }
    }

    IEnumerator GetTexture(string refurl, int P, int p)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(refurl);
        yield return www.SendWebRequest();
        Texture2D PokemonTexture;
        switch (P)
        {
            case 1:
                PokemonTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                Team1Textures[p] = PokemonTexture;
                break;

            case 2:
                PokemonTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                Team2Textures[p] = PokemonTexture;
                break;
        }
    }
    public void RecieveMove(Move M)
    {
        if(Waiting == true && T1WaitingforSwitch == false)
        {
            T1Move = M;
            T1Moved = true;
            T2Move = Ai.PickMove(T2Fighter, T1Fighter);
            T2Moved = true;
        }
    }



    public void RecieveTeam(Team T)
    {
        T1 = T;
    }
    public void RecieveAiTeam(Team T)
    {
        T2 = T;
    }
    bool CheckTextures()
    {
        int counter = 0;
        foreach(Texture2D T in Team1Textures)
        {
            if(T != null)
            {
                counter++;
            }
        }
        if(counter == Team1.Count)
        {
            return true;
        }
        return false;
    }
    void GenSwitchBoxes()
    {
        for (int i = 0; i < Team1.Count; i++)
        {
            if(Team1Textures[i] != null)
            {
                Instantiate(SwitchBox, new Vector3(BoxXpos, BoxYpos - 100, 0), Quaternion.identity, transform.parent.gameObject.transform);
                GameObject.Find("SwitchPokemon(Clone)").GetComponent<SwitchBoxScript>().SetPokemon(Team1[i], Sprite.Create(Team1Textures[i], new Rect(0, 0, Team1Textures[i].width, Team1Textures[i].height), new Vector2(0.5f, 0.5f)));
                SwitchBoxes[i] = GameObject.Find("SwitchPokemon(Clone)");
                GameObject.Find("SwitchPokemon(Clone)").name = $"{Team1[i].ReturnName()}SwitchBox";
                BoxXpos += 250;
            }
        }
    }
    public void UseMove(ActivePokemon P, ActivePokemon P2, Move M, float Weather, int Team)
    {
        if(T1Fainted == true || T2Fainted == true)
        {
            return;
        }
        int hitchance = UnityEngine.Random.Range(0, 100);
        string identity = P.ReturnName();
        if (P.Nickname != null)
        {
            identity = P.Nickname;
        }
        if (M.ReturnAccuracy() != 100)
        {
            if (hitchance >= M.ReturnAccuracy())
            {
                Content.GetComponent<ContentUpdate>().AddText("Default", $"{identity} used {M.ReturnName()}");
                Content.GetComponent<ContentUpdate>().AddText("Default", "It missed!");
                return;
            }
        }
        int Attack = 0;
        int Defense = 0;

        switch (M.ReturnAttackType())
        {
            case "Physical":
                if(Team == 1)
                {
                    Attack = T1BattleStats[1];
                    Defense = T2BattleStats[2];
                }
                else
                {
                    Attack = T2BattleStats[1];
                    Defense = T1BattleStats[2];
                }
                
                break;

            case "Special":
                if (Team == 1)
                {
                    Attack = T1BattleStats[3];
                    Defense = T2BattleStats[4];
                }
                else
                {
                    Attack = T2BattleStats[3];
                    Defense = T1BattleStats[4];
                }
                break;

            case "Status":
                CheckStatusUse(M.ReturnInfo());
                float Multiplier = 1;
                string change = " ";
                if(Raises != true)
                {
                    Stages = -Stages;
                }
                switch (Stages)
                {
                    case -6:
                        Multiplier = 0.25f;
                        change = "severly fell!";
                        break;

                    case -5:
                        Multiplier = 0.28571428571f;
                        change = "severly fell!";
                        break;

                    case -4:
                        Multiplier = 0.33333333333f;
                        change = "severly fell!";
                        break;

                    case -3:
                        Multiplier = 0.4f;
                        change = "severly fell!";
                        break;

                    case -2:
                        Multiplier = 0.5f;
                        change = "harshly fell!";
                        break;

                    case -1:
                        Multiplier = 0.66666666666f;
                        change = "fell!";
                        break;

                    case 0:
                        Multiplier = 1;
                        break;

                    case 1:
                        Multiplier = 1.5f;
                        change = "rose!";
                        break;

                    case 2:
                        Multiplier = 2;
                        change = "rose sharply!";
                        break;

                    case 3:
                        Multiplier = 2.5f;
                        change = "rose drastically!";
                        break;

                    case 4:
                        Multiplier = 3;
                        change = "rose drastically!";
                        break;

                    case 5:
                        Multiplier = 3.5f;
                        change = "rose drastically!";
                        break;

                    case 6:
                        Multiplier = 4;
                        change = "rose drastically!";
                        break;
                }
                if(User == true)
                {
                    if(AttackChange == true)
                    {
                        T1BattleStats[1] = (int)Math.Round(T1BattleStats[1] * Multiplier);
                        Content.GetComponent<ContentUpdate>().AddText("Change", $"{T1Fighter.ReturnName()}'s attack {change}");
                    }
                    if(DefenseChange == true)
                    {
                        T1BattleStats[2] = (int)Math.Round(T1BattleStats[2] * Multiplier);
                        Content.GetComponent<ContentUpdate>().AddText("Change", $"{T1Fighter.ReturnName()}'s defense {change}");
                    }
                    if(SpecialAttackChange == true)
                    {
                        T1BattleStats[3] = (int)Math.Round(T1BattleStats[3] * Multiplier);
                        Content.GetComponent<ContentUpdate>().AddText("Change", $"{T1Fighter.ReturnName()}'s special attack {change}");
                    }
                    if(SpecialDefenseChange == true)
                    {
                        T1BattleStats[4] = (int)Math.Round(T1BattleStats[4] * Multiplier);
                        Content.GetComponent<ContentUpdate>().AddText("Change", $"{T1Fighter.ReturnName()}'s special defense {change}");
                    }
                    if(SpeedChange == true)
                    {
                        T1BattleStats[5] = (int)Math.Round(T1BattleStats[5] * Multiplier);
                        Content.GetComponent<ContentUpdate>().AddText("Change", $"{T1Fighter.ReturnName()}'s speed {change}");
                    }
                }
                else
                {
                    if (AttackChange == true)
                    {
                        T2BattleStats[1] = (int)Math.Round(T2BattleStats[1] * Multiplier);
                        Content.GetComponent<ContentUpdate>().AddText("Change", $"The opposing {T2Fighter.ReturnName()}'s attack {change}");
                    }
                    if (DefenseChange == true)
                    {
                        T2BattleStats[2] = (int)Math.Round(T2BattleStats[2] * Multiplier);
                        Content.GetComponent<ContentUpdate>().AddText("Change", $"The opposing {T2Fighter.ReturnName()}'s defense {change}");
                    }
                    if (SpecialAttackChange == true)
                    {
                        T2BattleStats[3] = (int)Math.Round(T2BattleStats[3] * Multiplier);
                        Content.GetComponent<ContentUpdate>().AddText("Change", $"The opposing {T2Fighter.ReturnName()}'s special attack {change}");
                    }
                    if (SpecialDefenseChange == true)
                    {
                        T2BattleStats[4] = (int)Math.Round(T2BattleStats[4] * Multiplier);
                        Content.GetComponent<ContentUpdate>().AddText("Change", $"The opposing {T2Fighter.ReturnName()}'s special defense {change}");
                    }
                    if (SpeedChange == true)
                    {
                        T2BattleStats[5] = (int)Math.Round(T2BattleStats[5] * Multiplier);
                        Content.GetComponent<ContentUpdate>().AddText("Change", $"The opposing {T2Fighter.ReturnName()}'s speed {change}");
                    }
                }
                Raises = false;
                AttackChange = false;
                DefenseChange = false;
                SpecialAttackChange = false;
                SpecialDefenseChange = false;
                User = false;
                SpeedChange = false;
                Stages = 0;
                M.DecreasePP();
                return;
        }

        float CriticalMultiplier = 1;
        if (UnityEngine.Random.Range(0, 100) < 5)
        {
            CriticalMultiplier = 1.5f;
        }
        float RandomRange = (float)(Math.Round((Rand.NextDouble() * (15) + 85)) / 100);
        float STAB = 1;
        if (P.ReturnType1() == M.ReturnType() || P.ReturnType2() == M.ReturnType())
        {
            STAB = 1.5f;
        }
        float typeeffectiveness = fn.TypeEffectiveness(M.ReturnType(), P2.ReturnType1(), P2.ReturnType2());
        float burn = 1;
        if (P.OnFire == true)
        {
            burn = 0.5f;
        }
        int damage = fn.DamageCalc(P.Level, M.ReturnBaseDamage(), Attack, Defense, Weather, CriticalMultiplier, STAB, RandomRange, typeeffectiveness, burn, 1);
        string effectiveness = "";
        switch (typeeffectiveness)
        {
            case 2:
                effectiveness = "was Super Effective!";
                break;
            case 4:
                effectiveness = "was Super Effective!";
                break;
            case 0.5f:
                effectiveness = "was Not very Effective";
                break;
            case 0:
                effectiveness = "had No Effect";
                break;
        }
        fn.SetStatus(P2, M);
        M.DecreasePP();
        Content.GetComponent<ContentUpdate>().AddText("Default", $"{identity} used {M.ReturnName()}");
        if (effectiveness != "")
        {
            Content.GetComponent<ContentUpdate>().AddText("Default", $"It {effectiveness}");
        }
        if(effectiveness != "had No Effect")
        {
            Content.GetComponent<ContentUpdate>().AddText("Default", $"Hit for {damage} damage!");
        }
        if(Team == 2)
        {
            T1BattleStats[0] = T1BattleStats[0] - damage;
        }
        else
        {
            T2BattleStats[0] = T2BattleStats[0] - damage;
        }
    }


}
