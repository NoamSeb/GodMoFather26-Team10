using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class InputEffectManager : MonoBehaviour
{
    #region Solid Snail
    [BoxGroup("Solid Snail")] public bool ssHasRain = false;
    [BoxGroup("Solid Snail")] public Image ssRainImage;
    [BoxGroup("Solid Snail")] public bool ssHasSun = false;
    [BoxGroup("Solid Snail")] public Image ssSunImage;
    [BoxGroup("Solid Snail")] public bool ssHasSnow = false;
    [BoxGroup("Solid Snail")] public Image ssSnowImage;
    [BoxGroup("Solid Snail")] public bool ssHasWind = false;
    [BoxGroup("Solid Snail")] public Image ssWindImage;
    [BoxGroup("Solid Snail")] public bool ssHasSalt = false;
    [BoxGroup("Solid Snail")] public Image ssSaltImage;
    [BoxGroup("Solid Snail")] public bool ssHasMutagene = false;
    [BoxGroup("Solid Snail")] public Image ssMutageneImage;
    #endregion Solid Snail

    #region Snailson Mandela
    [BoxGroup("Snailson Mandela")] public bool smHasRain = false;
    [BoxGroup("Snailson Mandela")] public Image smRainImage;
    [BoxGroup("Snailson Mandela")] public bool smHasSun = false;
    [BoxGroup("Snailson Mandela")] public Image smSunImage;
    [BoxGroup("Snailson Mandela")] public bool smHasSnow = false;
    [BoxGroup("Snailson Mandela")] public Image smSnowImage;
    [BoxGroup("Snailson Mandela")] public bool smHasWind = false;
    [BoxGroup("Snailson Mandela")] public Image smWindImage;
    [BoxGroup("Snailson Mandela")] public bool smHasSalt = false;
    [BoxGroup("Snailson Mandela")] public Image smSaltImage;
    [BoxGroup("Snailson Mandela")] public bool smHasMutagene = false;
    [BoxGroup("Snailson Mandela")] public Image smMutageneImage;
    #endregion Snailson Mandela

    #region Snaildenring
    [BoxGroup("Snaildenring")] public bool srHasRain = false;
    [BoxGroup("Snaildenring")] public Image srRainImage;
    [BoxGroup("Snaildenring")] public bool srHasSun = false;
    [BoxGroup("Snaildenring")] public Image srSunImage;
    [BoxGroup("Snaildenring")] public bool srHasSnow = false;
    [BoxGroup("Snaildenring")] public Image srSnowImage;
    [BoxGroup("Snaildenring")] public bool srHasWind = false;
    [BoxGroup("Snaildenring")] public Image srWindImage;
    [BoxGroup("Snaildenring")] public bool srHasSalt = false;
    [BoxGroup("Snaildenring")] public Image srSaltImage;
    [BoxGroup("Snaildenring")] public bool srHasMutagene = false;
    [BoxGroup("Snaildenring")] public Image srMutageneImage;
    #endregion Snaildenring

    #region Escar Crow
    [BoxGroup("Escar Crow")] public bool ecHasRain = false;
    [BoxGroup("Escar Crow")] public Image ecRainImage;
    [BoxGroup("Escar Crow")] public bool ecHasSun = false;
    [BoxGroup("Escar Crow")] public Image ecSunImage;
    [BoxGroup("Escar Crow")] public bool ecHasSnow = false;
    [BoxGroup("Escar Crow")] public Image ecSnowImage;
    [BoxGroup("Escar Crow")] public bool ecHasWind = false;
    [BoxGroup("Escar Crow")] public Image ecWindImage;
    [BoxGroup("Escar Crow")] public bool ecHasSalt = false;
    [BoxGroup("Escar Crow")] public Image ecSaltImage;
    [BoxGroup("Escar Crow")] public bool ecHasMutagene = false;
    [BoxGroup("Escar Crow")] public Image ecMutageneImage;
    #endregion Escar Crow

    // Update is called once per frame
    void Update()
    {
        #region Solid Snail
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ssHasRain = !ssHasRain;
            ssRainImage.gameObject.SetActive(ssHasRain);
            GameManager.Instance.Snails[0].hasRain = ssHasRain;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ssHasSun = !ssHasSun;
            ssSunImage.gameObject.SetActive(ssHasSun);
            GameManager.Instance.Snails[0].hasSun = ssHasSun;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ssHasSnow = !ssHasSnow;
            ssSnowImage.gameObject.SetActive(ssHasSnow);
            GameManager.Instance.Snails[0].hasSnow = ssHasSnow;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ssHasWind = !ssHasWind;
            ssWindImage.gameObject.SetActive(ssHasWind);
            GameManager.Instance.Snails[0].hasWind = ssHasWind;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ssHasSalt = !ssHasSalt;
            ssSaltImage.gameObject.SetActive(ssHasSalt);
            GameManager.Instance.Snails[0].hasSalt = ssHasSalt;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ssHasMutagene = !ssHasMutagene;
            ssMutageneImage.gameObject.SetActive(ssHasMutagene);
            GameManager.Instance.Snails[0].hasMutagene = ssHasMutagene;
        }
        #endregion Solid Snail

        #region Snailson Mandela
        if (Input.GetKeyDown(KeyCode.Q))
        {
            smHasRain = !smHasRain;
            smRainImage.gameObject.SetActive(smHasRain);
            GameManager.Instance.Snails[1].hasRain = smHasRain;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            smHasSun = !smHasSun;
            smSunImage.gameObject.SetActive(smHasSun);
            GameManager.Instance.Snails[1].hasSun = smHasSun;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            smHasSnow = !smHasSnow;
            smSnowImage.gameObject.SetActive(smHasSnow);
            GameManager.Instance.Snails[1].hasSnow = smHasSnow;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            smHasWind = !smHasWind;
            smWindImage.gameObject.SetActive(smHasWind);
            GameManager.Instance.Snails[1].hasWind = smHasWind;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            smHasSalt = !smHasSalt;
            smSaltImage.gameObject.SetActive(smHasSalt);
            GameManager.Instance.Snails[1].hasSalt = smHasSalt;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            smHasMutagene = !smHasMutagene;
            smMutageneImage.gameObject.SetActive(smHasMutagene);
            GameManager.Instance.Snails[1].hasMutagene = smHasMutagene;
        }
        #endregion Snailson Mandela

        #region Snaildenring
        if (Input.GetKeyDown(KeyCode.A))
        {
            srHasRain = !srHasRain;
            srRainImage.gameObject.SetActive(srHasRain);
            GameManager.Instance.Snails[2].hasRain = srHasRain;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            srHasSun = !srHasSun;
            srSunImage.gameObject.SetActive(srHasSun);
            GameManager.Instance.Snails[2].hasSun = srHasSun;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            srHasSnow = !srHasSnow;
            srSnowImage.gameObject.SetActive(srHasSnow);
            GameManager.Instance.Snails[2].hasSnow = srHasSnow;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            srHasWind = !srHasWind;
            srWindImage.gameObject.SetActive(srHasWind);
            GameManager.Instance.Snails[2].hasWind = srHasWind;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            srHasSalt = !srHasSalt;
            srSaltImage.gameObject.SetActive(srHasSalt);
            GameManager.Instance.Snails[2].hasSalt = srHasSalt;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            srHasMutagene = !srHasMutagene;
            srMutageneImage.gameObject.SetActive(srHasMutagene);
            GameManager.Instance.Snails[2].hasMutagene = srHasMutagene;
        }
        #endregion Snaildenring

        #region Escar Crow
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ecHasRain = !ecHasRain;
            ecRainImage.gameObject.SetActive(ecHasRain);
            GameManager.Instance.Snails[3].hasRain = ecHasRain;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            ecHasSun = !ecHasSun;
            ecSunImage.gameObject.SetActive(ecHasSun);
            GameManager.Instance.Snails[3].hasSun = ecHasSun;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ecHasSnow = !ecHasSnow;
            ecSnowImage.gameObject.SetActive(ecHasSnow);
            GameManager.Instance.Snails[3].hasSnow = ecHasSnow;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            ecHasWind = !ecHasWind;
            ecWindImage.gameObject.SetActive(ecHasWind);
            GameManager.Instance.Snails[3].hasWind = ecHasWind;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            ecHasSalt = !ecHasSalt;
            ecSaltImage.gameObject.SetActive(ecHasSalt);
            GameManager.Instance.Snails[3].hasSalt = ecHasSalt;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            ecHasMutagene = !ecHasMutagene;
            ecMutageneImage.gameObject.SetActive(ecHasMutagene);
            GameManager.Instance.Snails[3].hasMutagene = ecHasMutagene;
        }
        #endregion Escar Crow
    }
}