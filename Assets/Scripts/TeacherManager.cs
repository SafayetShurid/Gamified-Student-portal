using UnityEngine;
using TMPro;
using SFB; // StandaloneFileBrowser namespace
using System.IO;
using EasyUI.Toast;

public class TeacherManager : MonoBehaviour
{

    public TMP_Text teacherNameText;
    Teacher currentTeacher;
    public TMP_InputField teacherAssignmentText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTeacher = DatabaseManager.instance.GetCurrentTeacher();
        //teacherNameText.text = currentTeacher.TeacherName;
        teacherNameText.text = PlayerPrefs.GetString(PlayerPrefData.TEACHER_NAME);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private string savedFilePath;
    public void OpenFilePicker()
    {
        // Open the file browser dialog for picking a file (single file selection)
        string[] paths = StandaloneFileBrowser.OpenFilePanel("Select PDF File", "", "pdf", false);

        if (paths.Length > 0)
        {
            // Display the selected file path
            Debug.Log("File selected: " + paths[0]);
            savedFilePath = Path.Combine(Application.persistentDataPath, Path.GetFileName(paths[0]));
            File.Copy(paths[0], savedFilePath, true); // Copy the file to persistent data path
            //filePathText.text = "File Saved: " + savedFilePath;
            
            DatabaseManager.instance.UpdateCourseAssignmentPathByTeacherName(currentTeacher.TeacherName, savedFilePath);
            Toast.Show("File uploaded succesfully");
            //DisplayFile(savedFilePath);

            // Here, you can implement the file upload logic (e.g., sending the file to a server, reading its contents, etc.)
        }
        else
        {
            Debug.Log("No file selected.");
        }
    }

    public void UploadAssignmentText()
    {
        DatabaseManager.instance.UpdateCourseAssignmentTextByTeacherName(PlayerPrefs.GetString(PlayerPrefData.TEACHER_NAME),teacherAssignmentText.text);
    }



}
