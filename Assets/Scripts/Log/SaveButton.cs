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
            // ファイルからデータを読み取る
            string file_data = string.Empty;    // ファイルのデータ
            using (StreamReader sr = new StreamReader(file_path))   // UTF-8のテキスト用
            {
                file_data = sr.ReadToEnd(); // ファイルのデータを「すべて」取得する
            }
            log = file_data + log;
            // ファイルへテキストデータを書き込む
            using (StreamWriter sw = new StreamWriter(file_path))   // UTF-8のテキスト用
            {
                sw.Write(log); // ファイルへテキストデータを出力する
            }
        }
    }
    */
}
