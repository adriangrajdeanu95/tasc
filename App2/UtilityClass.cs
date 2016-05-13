using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;

namespace App2
{
    public class UtilityClass
    {
        
        public static async Task<string> readStringFromLocalFile(string filename)
        {
            // reads the contents of file 'filename' in the app's local storage folder and returns it as a string

            // access the local folder
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
            // open the file 'filename' for reading
            Stream stream = await local.OpenStreamForReadAsync(filename);
            string text;

            // copy the file contents into the string 'text'
            using (StreamReader reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }

            return text;
        }

        public static async Task saveStringToLocalFile(string filename, string content)
        {
            // saves the string 'content' to a file 'filename' in the app's local storage folder
            byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes(content.ToCharArray());

            // create a file with the given filename in the local folder; replace any existing file with the same name
            StorageFile file = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

            // write the char array created from the content string into the file
            using (var stream = await file.OpenStreamForWriteAsync())
            {
                stream.Write(fileBytes, 0, fileBytes.Length);
            }
        }

        public void TextToData()
        {
            string TemporaryData = readStringFromLocalFile("data.txt").Result;
            string[] TemporaryDataSplit = TemporaryData.Split('\n');
            string[] TemporaryCloneIndexes;

            for (int i=0; i<TemporaryDataSplit.Length; i+=12)
            {
                Globals.TaskList[i / 12] = new TaskObject();

                Globals.TaskList[i / 12].TaskName = TemporaryDataSplit[i];
                Globals.TaskList[i / 12].Description = TemporaryDataSplit[i + 1];
                Globals.TaskList[i / 12].Deadline = Convert.ToDateTime(TemporaryDataSplit[i + 2]);
                Globals.TaskList[i / 12].AdditionDate = Convert.ToDateTime(TemporaryDataSplit[i + 3]);
                Globals.TaskList[i / 12].StartDate = Convert.ToDateTime(TemporaryDataSplit[i + 4]);
                Globals.TaskList[i / 12].EndDate = Convert.ToDateTime(TemporaryDataSplit[i + 5]);
                Globals.TaskList[i / 12].UserPriority = Convert.ToDouble(TemporaryDataSplit[i + 6]);
                Globals.TaskList[i / 12].EstimatedTime = Convert.ToDouble(TemporaryDataSplit[i + 7]);
                Globals.TaskList[i / 12].Sessions = Convert.ToDouble(TemporaryDataSplit[i + 8]);
                Globals.TaskList[i / 12].TruePriority = Convert.ToDouble(TemporaryDataSplit[i + 9]);

                TemporaryCloneIndexes = TemporaryDataSplit[i + 11].Split(' ');
                
                for (int j=0; j<TemporaryCloneIndexes.Length; j++)
                {
                    Globals.TaskList[i / 12].CloneIndexes[j] = Convert.ToInt32(TemporaryCloneIndexes[j]);
                }

            }
        }
        
     /*   public static async Task DataToText()
        {
            string ObjectString = "";
            for (int i=0; i<Globals.TaskList.Length; i++)
            {
                ObjectString += Globals.TaskList[i].TaskName + '\n';
                ObjectString += Globals.TaskList[i].Description + '\n';
                ObjectString += Convert.ToString(Globals.TaskList[i].Deadline) + '\n';
                ObjectString += Convert.ToString(Globals.TaskList[i].AdditionDate) + '\n';
                ObjectString += Convert.ToString(Globals.TaskList[i].StartDate) + '\n';
                ObjectString += Convert.ToString(Globals.TaskList[i].EndDate) + '\n';
                ObjectString += Convert.ToString(Globals.TaskList[i].UserPriority) + '\n';
                ObjectString += Convert.ToString(Globals.TaskList[i].EstimatedTime) + '\n';
                ObjectString += Convert.ToString(Globals.TaskList[i].Sessions) + '\n';
                ObjectString += Convert.ToString(Globals.TaskList[i].TruePriority) + '\n';
                ObjectString += string.Join(" ", Globals.TaskList[i].CloneIndexes) + '\n';              
            }

            await saveStringToLocalFile("data.txt", ObjectString);
        }
        */
    }
}