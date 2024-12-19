using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Alchemy.Inspector;
using System.Text;

public class EnumBuild : MonoBehaviour
{
    [SerializeField]
    Object fileObject;
    [SerializeField]
    string enumName = null;
    [SerializeField]
    string ScriptName = null;
    [LabelText("Assets/")]
    [SerializeField]
    string folderLocation = null;

    [Button]
    public void BuildEnum()
    {
        if (fileObject == null)
        {
            Debug.LogError("fileObject is null");
            return;
        }
        if (System.String.IsNullOrEmpty(enumName))
        {
            Debug.LogError("EnumName isNull");
            return;
        }
        if (System.String.IsNullOrEmpty(ScriptName))
        {
            Debug.LogError("ScriptName isNull");
            return;
        }
        if (System.String.IsNullOrEmpty(folderLocation))
        {
            Debug.LogError("folderlocation isNull");
            return;
        }
        // コード生成
        List<string> writeCodes = new List<string>();
        writeCodes.Add("// EnumBuild.csで生成\n");
        writeCodes.Add("namespace AutoEnum");
        writeCodes.Add("{");
        writeCodes.Add("\t[System.Serializable]");
        writeCodes.Add($"\tpublic enum {enumName}");
        writeCodes.Add("\t{");
        writeCodes.Add("\t\tInvalid = -1,");
        var path = AssetDatabase.GetAssetPath(fileObject);
        var fileList = System.IO.Directory.GetFiles(System.IO.Path.GetDirectoryName(path), "*"); ;

        //Debug.Log("Path:" + System.IO.Path.GetDirectoryName(filePath));

        foreach (var filePath in fileList)
        {
            if (filePath.Contains(".meta"))
            {
                continue;
            }
            Debug.Log(filePath);
            string filename = System.IO.Path.GetFileNameWithoutExtension(filePath);
            writeCodes.Add($"\t\t{filename.Replace(" ", "")},");
        }
        writeCodes.Add("\t\tMax,");
        writeCodes.Add("\t};");
        writeCodes.Add("}");
        // 生成
        string codePath = Application.dataPath + $"/{folderLocation}/{ScriptName}.cs";
        File.Delete(codePath);
        FileStream stream = new FileStream(codePath, FileMode.OpenOrCreate);
        StreamWriter sw = new StreamWriter(stream, Encoding.UTF8);
        sw.Write("");
        foreach (var code in writeCodes)
        {
            sw.WriteLine(code);
        }
        sw.Close();
        AssetDatabase.Refresh();
        Debug.Log("更新終了");
    }

}

