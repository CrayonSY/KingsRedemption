using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    /*
    [SerializeField] private LogCollector _logCollector;
    [SerializeField] private ScoreManager _scoreManager;
    

    // write the notes on a text file
    public void OnClick()
    {
        Note[] notes = _logCollector.GetNotes();

        // Erase all texts in the text file
        using (var fileStream = new FileStream(@".\note" + _scoreManager.difficulty + ".txt", FileMode.Open))
        {
            fileStream.SetLength(0);
        }

        foreach (Note note in notes)
        {
            string log = note.perfectTime + "\n" + note.x + "\n" + note.y + "\n";
            string file_path = //@"https://shinnosukeyasuda.com/king/note" + _scoreManager.difficulty + ".txt";
            Path.Combine(@".\note" + _scoreManager.difficulty + ".txt");
            if (!File.Exists(file_path)) return;
            // �t�@�C������f�[�^��ǂݎ��
            string file_data = string.Empty;    // �t�@�C���̃f�[�^
            using (StreamReader sr = new StreamReader(file_path))   // UTF-8�̃e�L�X�g�p
            {
                file_data = sr.ReadToEnd(); // �t�@�C���̃f�[�^���u���ׂāv�擾����
            }
            log = file_data + log;
            // �t�@�C���փe�L�X�g�f�[�^����������
            using (StreamWriter sw = new StreamWriter(file_path))   // UTF-8�̃e�L�X�g�p
            {
                sw.Write(log); // �t�@�C���փe�L�X�g�f�[�^���o�͂���
            }
        }
    }
    */
}
