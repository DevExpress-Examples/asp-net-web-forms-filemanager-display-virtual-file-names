using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        IEnumerable<FileSystemObjectInfo> foldersToShow = new FileSystemObjectInfo[] {
            new FileSystemObjectInfo(){ PrivateName = "Folder 1", PublicName = "First Folder" },
            new FileSystemObjectInfo(){ PrivateName =  "Folder 3", PublicName = "Third Folder"},
            new FileSystemObjectInfo(){ PrivateName = "Folder 1\\Subfolder 1-1", PublicName = "First Folder\\First Sub"},
        };
        IEnumerable<FileSystemObjectInfo> filesToShow = new FileSystemObjectInfo[] {
            new FileSystemObjectInfo(){ PrivateName = "Folder 1\\File 1.txt", PublicName = "First Folder\\First File.txt"},
            new FileSystemObjectInfo(){ PrivateName = "Folder 1\\File 2.txt", PublicName = "First Folder\\Second File.txt"},
            new FileSystemObjectInfo(){ PrivateName = "Folder 1\\File 3.txt", PublicName = "First Folder\\Third File.txt"},
            new FileSystemObjectInfo(){ PrivateName = "Folder 1\\Subfolder 1-1\\Doc 1.txt", PublicName = "First Folder\\First Sub\\First Doc.txt"},
            new FileSystemObjectInfo(){ PrivateName = "Folder 3\\Article 1.txt", PublicName = "Third Folder\\First Article.txt"},
            new FileSystemObjectInfo(){ PrivateName = "Folder 3\\Article 2.txt", PublicName = "Third Folder\\Second Article.txt"},
            new FileSystemObjectInfo(){ PrivateName = "Folder 3\\Article 3.txt", PublicName = "Third Folder\\Third Article.txt"},
        };
        FileManager.CustomFileSystemProvider = new CustomPhysicalFileSystemProvider("~/Files/Root", foldersToShow, filesToShow);
    }
}