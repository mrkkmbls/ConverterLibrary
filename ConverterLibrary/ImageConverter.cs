using System;
using System.Diagnostics;
using System.IO;

public class ImageConverter
{
    public void ConvertToWebP(string jpegFilePath, string webpFilePath)
    {
        try
        {
            string cwebpPath = "D:Projects/Byte Converter/ByteConverter/Reference/cwebp.exe"; // Replace with the actual path to the cwebp executable
            string arguments = $"\"{jpegFilePath}\" -o \"{webpFilePath}\"";

            Process process = new Process();
            process.StartInfo.FileName = cwebpPath;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                string errorMessage = process.StandardError.ReadToEnd();
                throw new Exception($"Error converting image to WebP format: {errorMessage}");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error converting image to WebP format", ex);
        }
    }
}
