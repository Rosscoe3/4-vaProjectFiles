using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Decryption : MonoBehaviour
{
    public TMP_InputField inputText;
    public TMP_Text decryptedText;
    public Button myButton;

    static readonly string PasswordHash = "P@@Sw0rd";
    static readonly string SaltKey = "S@LT&KEY";
    static readonly string VIKey = "@1B2c3D4e5F6g7H8";

    void Start()
    {
        myButton.interactable = false; 
    }

    void Update()
    {
        if (inputText.text == "")
        {
            myButton.interactable = false;
        }
        else
        {
            myButton.interactable = true;
        }
    }

    // Start is called before the first frame update
    public void OnPress()
    {
        string decryption = Decrypt(inputText.text);
        decryptedText.text = "Your ID is: " + decryption;

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
