Option Infer On

Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Web

Public Class CustomPhysicalFileSystemProvider
    Inherits PhysicalFileSystemProvider

    Private foldersToShow As IEnumerable(Of FileSystemObjectInfo)
    Private filesToShow As IEnumerable(Of FileSystemObjectInfo)
    Public Sub New(ByVal rootFolder As String, ByVal foldersToShow As IEnumerable(Of FileSystemObjectInfo), ByVal filesToShow As IEnumerable(Of FileSystemObjectInfo))
        MyBase.New(rootFolder)
        Me.foldersToShow = foldersToShow
        Me.filesToShow = filesToShow
    End Sub
    Public Overrides Function GetFolders(ByVal parentFolder As FileManagerFolder) As IEnumerable(Of FileManagerFolder)
        If IsRootFolder(parentFolder) Then
            Dim res = GetPublicFolderList(parentFolder)
            Return res
        Else
            Dim privateFolder As FileManagerFolder = ConvertToPrivateName(parentFolder)
            Dim res = GetPublicFolderList(privateFolder)
            Return res
        End If
    End Function
    Public Overrides Function GetFiles(ByVal parentFolder As FileManagerFolder) As IEnumerable(Of FileManagerFile)
        Dim privateFolder = ConvertToPrivateName(parentFolder)
        Return GetPublicFileList(privateFolder)
    End Function
    Public Overrides Function Exists(ByVal file As FileManagerFile) As Boolean
        Return MyBase.Exists(ConvertToPrivateName(file))
    End Function
    Public Overrides Function Exists(ByVal folder As FileManagerFolder) As Boolean
        Return MyBase.Exists(ConvertToPrivateName(folder))
    End Function
    Public Overrides Function GetLastWriteTime(ByVal file As FileManagerFile) As Date
        Return MyBase.GetLastWriteTime(ConvertToPrivateName(file))
    End Function
    Public Overrides Function GetLastWriteTime(ByVal folder As FileManagerFolder) As Date
        Return MyBase.GetLastWriteTime(ConvertToPrivateName(folder))
    End Function
    Public Overrides Function GetLength(ByVal file As FileManagerFile) As Long
        Return MyBase.GetLength(ConvertToPrivateName(file))
    End Function
    Public Overrides Function ReadFile(ByVal file As FileManagerFile) As Stream
        Return MyBase.ReadFile(ConvertToPrivateName(file))
    End Function
    Public Overrides Sub DeleteFolder(ByVal folder As FileManagerFolder)
        Dim privateFolder = ConvertToPrivateName(folder)
        MyBase.DeleteFolder(privateFolder)
    End Sub
    Public Overrides Sub DeleteFile(ByVal file As FileManagerFile)
        Dim privateFile = ConvertToPrivateName(file)
        MyBase.DeleteFile(privateFile)
    End Sub
    Private Function IsRootFolder(ByVal folder As FileManagerFolder) As Boolean
        Return folder.RelativeName = String.Empty
    End Function
    Private Function GetPublicFolderList(ByVal privateParentFolder As FileManagerFolder) As IEnumerable(Of FileManagerFolder)
        Return MyBase.GetFolders(privateParentFolder).Where(Function(folder) foldersToShow.Select(Function(f) f.PrivateName).Contains(folder.RelativeName)).Select(AddressOf ConvertToPublicName).ToList()
    End Function
    Private Function GetPublicFileList(ByVal privateParentFolder As FileManagerFolder) As IEnumerable(Of FileManagerFile)
        Return MyBase.GetFiles(privateParentFolder).Where(Function(file) filesToShow.Select(Function(f) f.PrivateName).Contains(file.RelativeName)).Select(AddressOf ConvertToPublicName).ToList()
    End Function
    Private Function ConvertToPublicName(ByVal file As FileManagerFile) As FileManagerFile
        Dim fileInfo = filesToShow.SingleOrDefault(Function(f) f.PrivateName = file.RelativeName)
        Return New FileManagerFile(Me, fileInfo.PublicName)
    End Function
    Private Function ConvertToPrivateName(ByVal file As FileManagerFile) As FileManagerFile
        Dim fileInfo = filesToShow.SingleOrDefault(Function(f) f.PublicName = file.RelativeName)
        Return New FileManagerFile(Me, fileInfo.PrivateName)
    End Function
    Private Function ConvertToPublicName(ByVal folder As FileManagerFolder) As FileManagerFolder
        Dim folderInfo = foldersToShow.SingleOrDefault(Function(f) f.PrivateName = folder.RelativeName)
        Return New FileManagerFolder(Me, folderInfo.PublicName)
    End Function
    Private Function ConvertToPrivateName(ByVal folder As FileManagerFolder) As FileManagerFolder
        Dim folderInfo = foldersToShow.SingleOrDefault(Function(f) f.PublicName = folder.RelativeName)
        If folderInfo Is Nothing Then
            Return folder
        End If
        Return New FileManagerFolder(Me, folderInfo.PrivateName)
    End Function
End Class

Public Class FileSystemObjectInfo
    Public Property PublicName() As String
    Public Property PrivateName() As String
End Class