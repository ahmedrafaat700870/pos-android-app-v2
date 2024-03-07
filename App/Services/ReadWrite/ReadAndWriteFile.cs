namespace App.Services.ReadWrite
{
    public class ReadAndWriteFile
    {
        public async void WirteTextToFile(string text, string targetFileName)
        {
            // Write the file content to the app data directory  
            string targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, targetFileName);
            using FileStream outputStream = System.IO.File.OpenWrite(targetFile);
            outputStream.SetLength(0);
            using StreamWriter streamWriter = new StreamWriter(outputStream );
            await streamWriter.WriteAsync(text);
        }
        public async Task WirteTextToFileAsync(string text, string targetFileName)
        {
            // Write the file content to the app data directory  
            string targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, targetFileName);
            using FileStream outputStream = System.IO.File.OpenWrite(targetFile);
            using StreamWriter streamWriter = new StreamWriter(outputStream);
            await streamWriter.WriteAsync(text);
        }

        public  void WriteTextToFileBeFile(string targetFileName , string content)
        {
            // Write the file content to the app data directory  
            string targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, targetFileName);
            //File.WriteAllText(targetFile , content);

            string filePath = targetFile;

            // Clear the file content by setting its length to zero
            using (FileStream fileStream = File.Open(filePath, FileMode.Open))
            {
                fileStream.SetLength(0);
            }
        }

        public string ReadTextFile(string targetFileName)
        {
            
            string targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, targetFileName);
            if (!File.Exists(targetFile))
                return string.Empty;
            using FileStream InputStream = System.IO.File.OpenRead(targetFile);
            using StreamReader reader = new StreamReader(InputStream);
            return reader.ReadToEndAsync().Result;
        }

        public async Task<string> ReadTextFileAsync(string targetFileName)
        {
            string targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, targetFileName);
            if (!File.Exists(targetFile))
                return string.Empty;
            using FileStream InputStream = System.IO.File.OpenRead(targetFile);
            using StreamReader reader = new StreamReader(InputStream);
            return await reader.ReadToEndAsync();
        }
    }
}
