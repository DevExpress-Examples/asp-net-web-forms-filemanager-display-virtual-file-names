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
		Dim foldersToShow As IEnumerable(Of FileSystemObjectInfo) = New FileSystemObjectInfo() {
			New FileSystemObjectInfo() With {
				.PrivateName = "Folder 1",
				.PublicName = "First Folder"
			},
			New FileSystemObjectInfo() With {
				.PrivateName = "Folder 3",
				.PublicName = "Third Folder"
			},
			New FileSystemObjectInfo() With {
				.PrivateName = "Folder 1\Subfolder 1-1",
				.PublicName = "First Folder\First Sub"
			}
		}
		Dim filesToShow As IEnumerable(Of FileSystemObjectInfo) = New FileSystemObjectInfo() {
			New FileSystemObjectInfo() With {
				.PrivateName = "Folder 1\File 1.txt",
				.PublicName = "First Folder\First File.txt"
			},
			New FileSystemObjectInfo() With {
				.PrivateName = "Folder 1\File 2.txt",
				.PublicName = "First Folder\Second File.txt"
			},
			New FileSystemObjectInfo() With {
				.PrivateName = "Folder 1\File 3.txt",
				.PublicName = "First Folder\Third File.txt"
			},
			New FileSystemObjectInfo() With {
				.PrivateName = "Folder 1\Subfolder 1-1\Doc 1.txt",
				.PublicName = "First Folder\First Sub\First Doc.txt"
			},
			New FileSystemObjectInfo() With {
				.PrivateName = "Folder 3\Article 1.txt",
				.PublicName = "Third Folder\First Article.txt"
			},
			New FileSystemObjectInfo() With {
				.PrivateName = "Folder 3\Article 2.txt",
				.PublicName = "Third Folder\Second Article.txt"
			},
			New FileSystemObjectInfo() With {
				.PrivateName = "Folder 3\Article 3.txt",
				.PublicName = "Third Folder\Third Article.txt"
			}
		}
		FileManager.CustomFileSystemProvider = New CustomPhysicalFileSystemProvider("~/Files/Root", foldersToShow, filesToShow)
	End Sub
End Class