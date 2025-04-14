using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;
using TMPro;

public class FileManager : MonoBehaviour
{
    public TMP_Text filePathText; // UI Text to display the file path
    public RawImage imageDisplay; // UI RawImage to display the image
    private string savedFilePath;

    // Call this function when a button is clicked to choose the file
    public void ChooseFile()
    {
        string filePath = UnityEditor.EditorUtility.OpenFilePanel("Select a file", "", "jpg,png,pdf");
        if (filePath.Length != 0)
        {
            savedFilePath = Path.Combine(Application.persistentDataPath, Path.GetFileName(filePath));
            File.Copy(filePath, savedFilePath, true); // Copy the file to persistent data path
            filePathText.text = "File Saved: " + savedFilePath;
            DisplayFile(savedFilePath);
        }
    }

    // Function to display the file (image or PDF)
    private void DisplayFile(string filePath)
    {
        string extension = Path.GetExtension(filePath).ToLower();
        if (extension == ".jpg" || extension == ".png")
        {
            DisplayImage(filePath);
        }
        else if (extension == ".pdf")
        {
            // Handle PDF viewing (using a plugin or external tool)
            // Placeholder for handling PDF (For example, external PDF viewer launch)
            filePathText.text = "PDF file saved. Use external viewer to open.";
        }
        else
        {
            filePathText.text = "Unsupported file type!";
        }
    }

    // Function to display an image in RawImage UI element
    private void DisplayImage(string filePath)
    {
        byte[] fileData = File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(fileData); // Load image into Texture2D

        imageDisplay.texture = texture; // Display the texture in the RawImage component
    }
}
