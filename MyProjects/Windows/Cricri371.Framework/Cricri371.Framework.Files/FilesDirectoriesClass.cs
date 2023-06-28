using System;
using System.Collections.Generic;
using System.IO;

namespace Cricri371.Framework.Files
{
    /// <summary>
    /// Class FilesDirectoriesClass. This class cannot be inherited. 
    /// </summary>
    public sealed class FilesDirectoriesClass
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="FilesDirectoriesClass" /> class from being created.
        /// </summary>
        private FilesDirectoriesClass()
        {
        }

        #region Copy

        /// <summary>
        /// Copies the specified path source. 
        /// </summary>
        /// <param name="pathSource">      The path source. </param>
        /// <param name="pathDestination"> The path destination. </param>
        /// <param name="copyDirectory">   if set to <c> true </c> [copy directory]. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static void Copy(string pathSource, string pathDestination, bool copyDirectory)
        {
            try
            {
                if (!string.IsNullOrEmpty(pathSource) && !string.IsNullOrEmpty(pathDestination))
                {
                    if (Directory.Exists(pathSource) && Directory.Exists(pathDestination))
                    {
                        pathDestination += pathSource.Substring(pathSource.LastIndexOf(@"\", StringComparison.CurrentCulture));

                        CopyDirectory(pathSource, pathDestination);
                    }
                    else
                    {
                        if (!copyDirectory)
                            pathDestination += pathSource.Substring(pathSource.LastIndexOf(@"\", StringComparison.CurrentCulture));

                        File.Copy(pathSource, pathDestination, true);
                    }
                }
            }
            catch (NotSupportedException nSE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(nSE, true));
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOORE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (UnauthorizedAccessException uAE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(uAE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (PathTooLongException pTLE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(pTLE, true));
            }
            catch (FileNotFoundException fNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(fNFE, true));
            }
            catch (DirectoryNotFoundException dNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(dNFE, true));
            }
            catch (IOException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        #endregion Copy

        #region CopyDirectory

        /// <summary>
        /// Copies the directory. 
        /// </summary>
        /// <param name="sourceDirectory">      The source directory. </param>
        /// <param name="destinationDirectory"> The destination directory. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static void CopyDirectory(string sourceDirectory, string destinationDirectory)
        {
            try
            {
                if (!string.IsNullOrEmpty(sourceDirectory) && !string.IsNullOrEmpty(destinationDirectory))
                {
                    string[] fileNames = Directory.GetFiles(sourceDirectory);

                    foreach (string fileName in fileNames)
                    {
                        string source = sourceDirectory + fileName.Substring(fileName.LastIndexOf(@"\", StringComparison.CurrentCulture));
                        string destination = destinationDirectory + fileName.Substring(fileName.LastIndexOf(@"\", StringComparison.CurrentCulture));

                        Copy(source, destination, true);
                    }

                    string[] directoryList = Directory.GetDirectories(sourceDirectory);

                    foreach (string directoryName in directoryList)
                    {
                        string source = sourceDirectory + directoryName.Substring(directoryName.LastIndexOf(@"\", StringComparison.CurrentCulture));
                        string destination = destinationDirectory + directoryName.Substring(directoryName.LastIndexOf(@"\", StringComparison.CurrentCulture));

                        CopyDirectory(source, destination);
                    }
                }
            }
            catch (NotSupportedException nSE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(nSE, true));
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aOORE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (UnauthorizedAccessException uAE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(uAE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (PathTooLongException pTLE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(pTLE, true));
            }
            catch (FileNotFoundException fNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(fNFE, true));
            }
            catch (DirectoryNotFoundException dNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(dNFE, true));
            }
            catch (IOException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        #endregion CopyDirectory

        #region CreateDirectory

        /// <summary>
        /// Creates the directory. 
        /// </summary>
        /// <param name="path">          The path. </param>
        /// <param name="directoryName"> Name of the directory. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static void CreateDirectory(string path, string directoryName)
        {
            try
            {
                if (!string.IsNullOrEmpty(path) && !string.IsNullOrEmpty(directoryName))
                    Directory.CreateDirectory(path + directoryName);
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (UnauthorizedAccessException uAE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(uAE, true));
            }
            catch (PathTooLongException pTLE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(pTLE, true));
            }
            catch (DirectoryNotFoundException dNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(dNFE, true));
            }
            catch (IOException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (NotSupportedException nSE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(nSE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
        }

        #endregion CreateDirectory

        #region ExistsDirectory

        /// <summary>
        /// Existses the directory. 
        /// </summary>
        /// <param name="directoryName"> Name of the directory. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public static bool ExistsDirectory(string directoryName)
        {
            if (!string.IsNullOrEmpty(directoryName))
                return Directory.Exists(directoryName);
            else
                return false;
        }

        #endregion ExistsDirectory

        #region ExistsFile

        /// <summary>
        /// Existses the file. 
        /// </summary>
        /// <param name="fileName"> Name of the file. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public static bool ExistsFile(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
                return File.Exists(fileName);
            else
                return false;
        }

        #endregion ExistsFile

        #region Delete

        /// <summary>
        /// Deletes the specified path. 
        /// </summary>
        /// <param name="path"> The path. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static void Delete(string path)
        {
            try
            {
                if (!string.IsNullOrEmpty(path))
                {
                    if (Directory.Exists(path))
                        Directory.Delete(path, true);
                    else
                    {
                        if (File.Exists(path))
                            File.Delete(path);
                    }
                }
            }
            catch (NotSupportedException nSE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(nSE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (UnauthorizedAccessException uAE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(uAE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (PathTooLongException pTLE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(pTLE, true));
            }
            catch (DirectoryNotFoundException dNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(dNFE, true));
            }
            catch (IOException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
        }

        #endregion Delete

        #region Rename

        /// <summary>
        /// Renames the specified source. 
        /// </summary>
        /// <param name="source">  The source. </param>
        /// <param name="newName"> The new name. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static void Rename(string source, string newName)
        {
            try
            {
                if (!string.IsNullOrEmpty(source) && !string.IsNullOrEmpty(newName))
                {
                    if (Directory.Exists(source))
                        Directory.Move(source, GetPathDirectory(source) + newName);
                    else
                    {
                        if (File.Exists(source))
                            File.Move(source, GetPathDirectory(source) + newName);
                    }
                }
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (FileNotFoundException fNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(fNFE, true));
            }
            catch (DirectoryNotFoundException dNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(dNFE, true));
            }
            catch (PathTooLongException pTLE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(pTLE, true));
            }
            catch (NotSupportedException nSE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(nSE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (IOException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (UnauthorizedAccessException uAE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(uAE, true));
            }
        }

        #endregion Rename

        #region GetPathDirectory

        /// <summary>
        /// Gets the path directory. 
        /// </summary>
        /// <param name="directoryPath"> The directory path. </param>
        /// <returns> The path of the directory. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static string GetPathDirectory(string directoryPath)
        {
            try
            {
                if (!string.IsNullOrEmpty(directoryPath))
                    return Path.GetDirectoryName(directoryPath) + Path.DirectorySeparatorChar;
                else
                    throw new ExceptionClass("(FileClass(GetPathDirectory)) The path doesn't exist");
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (PathTooLongException pTLE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(pTLE, true));
            }
        }

        #endregion GetPathDirectory

        #region GetFileName

        /// <summary>
        /// Gets the name of the file. 
        /// </summary>
        /// <param name="filePath"> The file path. </param>
        /// <returns> The file name. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static string GetFileName(string filePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(filePath))
                {
                    if (!Directory.Exists(filePath) && File.Exists(filePath))
                        return Path.GetFileName(filePath);
                    else
                        return string.Empty;
                }
                else
                    throw new ExceptionClass("(FileClass(GetFileName)) The filepath doesn't exist");
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
        }

        #endregion GetFileName

        #region GetFileExtension

        /// <summary>
        /// Gets the file extension. 
        /// </summary>
        /// <param name="filePath"> The file path. </param>
        /// <returns> The file extension. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static string GetFileExtension(string filePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(filePath))
                {
                    if (!Directory.Exists(filePath) && File.Exists(filePath))
                        return Path.GetExtension(filePath);
                    else
                        return string.Empty;
                }
                else
                    throw new ExceptionClass("(FileClass(GetFileExtension)) The filepath doesn't exist");
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
        }

        #endregion GetFileExtension

        #region GetDirectories

        /// <summary>
        /// Gets the directories. 
        /// </summary>
        /// <param name="path"> The path. </param>
        /// <returns> The list of directory information. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static IList<DirectoryInfo> GetDirectories(string path)
        {
            try
            {
                var listOfDirectories = new List<DirectoryInfo>();

                if (Directory.Exists(path) && !string.IsNullOrEmpty(path))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);

                    foreach (DirectoryInfo dInfo in directoryInfo.GetDirectories())
                    {
                        listOfDirectories.Add(dInfo);
                    }
                }

                return listOfDirectories;
            }
            catch (PathTooLongException pTLE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(pTLE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (System.Security.SecurityException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
        }

        #endregion GetDirectories

        #region GetFilesRecursive

        /// <summary>
        /// Gets the files recursive. 
        /// </summary>
        /// <param name="path"> The path. </param>
        /// <returns> The list of file information. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static IList<FileInfo> GetFilesRecursive(string path)
        {
            try
            {
                var listOfFiles = new List<FileInfo>();

                if (Directory.Exists(path) && !string.IsNullOrEmpty(path))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);

                    foreach (DirectoryInfo dInfo in directoryInfo.GetDirectories())
                    {
                        foreach (FileInfo fInfo in GetFiles(dInfo.FullName))
                            listOfFiles.Add(fInfo);
                    }

                    foreach (FileInfo fInfo in directoryInfo.GetFiles())
                    {
                        listOfFiles.Add(fInfo);
                    }
                }

                return listOfFiles;
            }
            catch (DirectoryNotFoundException dNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(dNFE, true));
            }
            catch (PathTooLongException pTLE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(pTLE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (System.Security.SecurityException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            catch (NotSupportedException nSE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(nSE, true));
            }
        }

        #endregion GetFilesRecursive

        #region GetFiles

        /// <summary>
        /// Gets the files. 
        /// </summary>
        /// <param name="path"> The path. </param>
        /// <returns> The list of files. </returns>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static IList<FileInfo> GetFiles(string path)
        {
            try
            {
                var listOfFiles = new List<FileInfo>();

                if (Directory.Exists(path) && path.Length != 0)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    FileInfo[] filesInfo = directoryInfo.GetFiles();

                    foreach (FileInfo fInfo in filesInfo)
                    {
                        listOfFiles.Add(fInfo);
                    }
                }

                return listOfFiles;
            }
            catch (DirectoryNotFoundException dNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(dNFE, true));
            }
            catch (PathTooLongException pTLE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(pTLE, true));
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (System.Security.SecurityException sE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(sE, true));
            }
            catch (NotSupportedException nSE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(nSE, true));
            }
        }

        #endregion GetFiles

        #region CompareFiles

        /// <summary>
        /// Compares the files. 
        /// </summary>
        /// <param name="fInfoSource">      The f information source. </param>
        /// <param name="fInfoDestination"> The f information destination. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public static bool CompareFiles(FileInfo fInfoSource, FileInfo fInfoDestination)
        {
            if (fInfoSource.LastWriteTime == fInfoDestination.LastWriteTime && fInfoSource.Length == fInfoDestination.Length)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Compares the files last write time. 
        /// </summary>
        /// <param name="fInfoSource">      The f information source. </param>
        /// <param name="fInfoDestination"> The f information destination. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public static bool CompareFilesLastWriteTime(FileSystemInfo fInfoSource, FileSystemInfo fInfoDestination)
        {
            if (fInfoSource.LastWriteTime == fInfoDestination.LastWriteTime)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Compares the size of the file. 
        /// </summary>
        /// <param name="fInfoSource">      The f information source. </param>
        /// <param name="fInfoDestination"> The f information destination. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public static bool CompareFileSize(FileInfo fInfoSource, FileInfo fInfoDestination)
        {
            if (fInfoSource.Length == fInfoDestination.Length)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Compares the file creation time. 
        /// </summary>
        /// <param name="fInfoSource">      The f information source. </param>
        /// <param name="fInfoDestination"> The f information destination. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public static bool CompareFileCreationTime(FileSystemInfo fInfoSource, FileSystemInfo fInfoDestination)
        {
            if (fInfoSource.CreationTime == fInfoDestination.CreationTime)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Compares the file path. 
        /// </summary>
        /// <param name="fInfoSource">      The f information source. </param>
        /// <param name="fInfoDestination"> The f information destination. </param>
        /// <returns> <c> true </c> if XXXX, <c> false </c> otherwise. </returns>
        public static bool CompareFilePath(FileSystemInfo fInfoSource, FileSystemInfo fInfoDestination)
        {
            if (fInfoSource.FullName == fInfoDestination.FullName)
                return true;
            else
                return false;
        }

        #endregion CompareFiles

        #region MoveFile

        /// <summary>
        /// Moves the file. 
        /// </summary>
        /// <param name="sourceFile">      The source file. </param>
        /// <param name="destinationFile"> The destination file. </param>
        /// <exception cref="ExceptionClass"> Thrown custom exception class. </exception>
        public static void MoveFile(string sourceFile, string destinationFile)
        {
            try
            {
                if (sourceFile.Length != 0 && destinationFile.Length != 0)
                    File.Move(sourceFile, destinationFile);
            }
            catch (ArgumentNullException aNE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aNE, true));
            }
            catch (FileNotFoundException fNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(fNFE, true));
            }
            catch (DirectoryNotFoundException dNFE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(dNFE, true));
            }
            catch (PathTooLongException pTLE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(pTLE, true));
            }
            catch (NotSupportedException nSE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(nSE, true));
            }
            catch (ArgumentException aE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(aE, true));
            }
            catch (IOException iOE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(iOE, true));
            }
            catch (UnauthorizedAccessException uAE)
            {
                throw new ExceptionClass(ExceptionClass.ManageExceptionMessage(uAE, true));
            }
        }

        #endregion MoveFile

        #region IsPictureFile

        /// <summary>
        /// Determines whether [is picture file] [the specified file name]. 
        /// </summary>
        /// <param name="fileName"> Name of the file. </param>
        /// <returns>
        /// <c> true </c> if [is picture file] [the specified file name]; otherwise, <c> false </c>.
        /// </returns>
        public static bool IsPictureFile(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToUpperInvariant();
            switch (extension)
            {
                case ".JPG":
                case ".JPEG":
                case ".BMP":
                case ".GIF":
                case ".TIF":
                case ".TIFF":
                case ".PNG":
                    return true;

                default:
                    return false;
            }
        }

        #endregion IsPictureFile
    }
}