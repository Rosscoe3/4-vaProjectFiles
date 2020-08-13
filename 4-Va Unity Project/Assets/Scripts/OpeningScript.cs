using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class OpeningScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sendObject, pg1, pg2, pg3, pg4;
    public Button myButton;
    public TMP_InputField inputText;
    public TMP_Text welcomeText;

    static readonly string PasswordHash = "P@@Sw0rd";
    static readonly string SaltKey = "S@LT&KEY";
    static readonly string VIKey = "@1B2c3D4e5F6g7H8";

    bool firstPage = false;
    bool secondPage = false;
    bool thirdPage = false;

    void Start()
    {
        myButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputText.text == "" && !firstPage)
        {
            myButton.interactable = false;
        }
        else
        {
            myButton.interactable = true;
        }
    }

    public void Continue()
    {

        if (!firstPage)
        {
            // Debug.Log("The Encrypted hash: " + Encrypt(inputText.text));
            //Debug.Log("The Decrypted hash: " + Decrypt(Encrypt(inputText.text)));

            sendObject.GetComponent<SendToGoogle>().saveName(inputText.text, Encrypt(inputText.text));
            //SendToGoogle.send.saveName(inputText.text);
            welcomeText.text = "Welcome " + inputText.text + "!";
            pg1.SetActive(false);
            firstPage = true;
            secondPage = true;
        }
        else if (secondPage)
        {
            pg2.SetActive(false);
            pg3.SetActive(true);
            thirdPage = true;
            secondPage = false;
        }
        else if (thirdPage)
        {
            pg3.SetActive(false);
            pg4.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    //public string Md5Sum(string strToEncrypt)
    //{
    //    System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
    //    byte[] bytes = ue.GetBytes(strToEncrypt);

    //    // encrypt bytes
    //    System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
    //    byte[] hashBytes = md5.ComputeHash(bytes);

    //    // Convert the encrypted bytes back to a string (base 16)
    //    string hashString = "";

    //    for (int i = 0; i < hashBytes.Length; i++)
    //    {
    //        hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
    //    }

    //    return hashString.PadLeft(32, '0');
    //}

    public void LoadApplication(String sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public static string Encrypt(string plainText)
    {
        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

        byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
        var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
        var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

        byte[] cipherTextBytes;

        using (var memoryStream = new MemoryStream())
        {
            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            {
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                cipherTextBytes = memoryStream.ToArray();
                cryptoStream.Close();
            }
            memoryStream.Close();
        }
        return Convert.ToBase64String(cipherTextBytes);
    }

    public static string Decrypt(string encryptedText)
    {
        byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
        byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
        var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

        var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
        var memoryStream = new MemoryStream(cipherTextBytes);
        var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        byte[] plainTextBytes = new byte[cipherTextBytes.Length];

        int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
        memoryStream.Close();
        cryptoStream.Close();
        return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
    }
}
