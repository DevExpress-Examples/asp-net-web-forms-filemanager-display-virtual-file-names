Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        Dim foldersToShow As IEnumerable(Of FileSystemObjectInfo) = New FileSystemObjectInfo() { _
            New FileSystemObjectInfo() With { _
                .PrivateName = "Folder 1", _
                .PublicName = "First Folder" _
            }, _
            New FileSystemObjectInfo() With { _
                .PrivateName = "Folder 3", _
                .PublicName = "Third Folder" _
            }, _
            New FileSystemObjectInfo() With { _
                .PrivateName = "Folder 1\Subfolder 1-1", _
                .PublicName = "First Folder\First Sub" _
            } _
        }
        Dim filesToShow As IEnumerable(Of FileSystemObjectInfo) = New FileSystemObjectInfo() { _
            New FileSystemObjectInfo() With { _
                .PrivateName = "Folder 1\File 1.txt", _
                .PublicName = "First Folder\First File.txt" _
            }, _
            New FileSystemObjectInfo() With { _
                .PrivateName = "Folder 1\File 2.txt", _
                .PublicName = "First Folder\Second File.txt" _
            }, _
            New FileSystemObjectInfo() With { _
                .PrivateName = "Folder 1\File 3.txt", _
                .PublicName = "First Folder\Third File.txt" _
            }, _
            New FileSystemObjectInfo() With { _
                .PrivateName = "Folder 1\Subfolder 1-1\Doc 1.txt", _
                .PublicName = "First Folder\First Sub\First Doc.txt" _
            }, _
            New FileSystemObjectInfo() With { _
                .PrivateName = "Folder 3\Article 1.txt", _
                .PublicName = "Third Folder\First Article.txt" _
            }, _
            New FileSystemObjectInfo() With { _
                .PrivateName = "Folder 3\Article 2.txt", _
                .PublicName = "Third Folder\Second Article.txt" _
            }, _
            New FileSystemObjectInfo() With { _
                .PrivateName = "Folder 3\Article 3.txt", _
                .PublicName = "Third Folder\Third Article.txt" _
            } _
        }
        FileManager.CustomFileSystemProvider = New CustomPhysicalFileSystemProvider("~/Files/Root", foldersToShow, filesToShow)
    End Sub
End Class