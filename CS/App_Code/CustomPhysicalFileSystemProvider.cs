using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

public class CustomPhysicalFileSystemProvider : PhysicalFileSystemProvider {

    IEnumerable<FileSystemObjectInfo> foldersToShow;
    IEnumerable<FileSystemObjectInfo> filesToShow;
    public CustomPhysicalFileSystemProvider(string rootFolder, IEnumerable<FileSystemObjectInfo> foldersToShow, IEnumerable<FileSystemObjectInfo> filesToShow)
        : base(rootFolder)
    {
        this.foldersToShow = foldersToShow;
        this.filesToShow = filesToShow;
    }
    public override IEnumerable<FileManagerFolder> GetFolders(FileManagerFolder parentFolder) {
        if(IsRootFolder(parentFolder)) {
            var res = GetPublicFolderList(parentFolder);
            return res;
        }
        else {
            FileManagerFolder privateFolder = ConvertToPrivateName(parentFolder);
            var res = GetPublicFolderList(privateFolder);
            return res;
        }
    }
    public override IEnumerable<FileManagerFile> GetFiles(FileManagerFolder parentFolder) {
        var privateFolder = ConvertToPrivateName(parentFolder);
        return GetPublicFileList(privateFolder);
    }
    public override bool Exists(FileManagerFile file) {
        return base.Exists(ConvertToPrivateName(file));
    }
    public override bool Exists(FileManagerFolder folder) {
        return base.Exists(ConvertToPrivateName(folder));
    }
    public override DateTime GetLastWriteTime(FileManagerFile file) {
        return base.GetLastWriteTime(ConvertToPrivateName(file));
    }
    public override DateTime GetLastWriteTime(FileManagerFolder folder) {
        return base.GetLastWriteTime(ConvertToPrivateName(folder));
    }
    public override long GetLength(FileManagerFile file) {
        return base.GetLength(ConvertToPrivateName(file));
    }
    public override Stream ReadFile(FileManagerFile file) {
        return base.ReadFile(ConvertToPrivateName(file));
    }
    public override void DeleteFolder(FileManagerFolder folder)
    {
        var privateFolder = ConvertToPrivateName(folder);
        base.DeleteFolder(privateFolder);
    }
    public override void DeleteFile(FileManagerFile file)
    {
        var privateFile = ConvertToPrivateName(file);
        base.DeleteFile(privateFile);
    }
    bool IsRootFolder(FileManagerFolder folder)
    {
        return folder.RelativeName == String.Empty;
    }
    IEnumerable<FileManagerFolder> GetPublicFolderList(FileManagerFolder privateParentFolder)
    {
        return base.GetFolders(privateParentFolder)
            .Where(folder => foldersToShow.Select(f => f.PrivateName).Contains(folder.RelativeName))
            .Select(ConvertToPublicName)
            .ToList();
    }
    IEnumerable<FileManagerFile> GetPublicFileList(FileManagerFolder privateParentFolder)
    {
        return base.GetFiles(privateParentFolder)
            .Where(file => filesToShow.Select(f => f.PrivateName).Contains(file.RelativeName))
            .Select(ConvertToPublicName)
            .ToList();
    }
    FileManagerFile ConvertToPublicName(FileManagerFile file) {
        var fileInfo = filesToShow.SingleOrDefault(f => f.PrivateName == file.RelativeName);
        return new FileManagerFile(this, fileInfo.PublicName);
    }
    FileManagerFile ConvertToPrivateName(FileManagerFile file) {
        var fileInfo = filesToShow.SingleOrDefault(f => f.PublicName == file.RelativeName);
        return new FileManagerFile(this, fileInfo.PrivateName);
    }
    FileManagerFolder ConvertToPublicName(FileManagerFolder folder) {
        var folderInfo = foldersToShow.SingleOrDefault(f => f.PrivateName == folder.RelativeName);
        return new FileManagerFolder(this, folderInfo.PublicName);
    }
    FileManagerFolder ConvertToPrivateName(FileManagerFolder folder) {
        var folderInfo = foldersToShow.SingleOrDefault(f => f.PublicName == folder.RelativeName);
        if (folderInfo == null)
        {
            return folder;
        }
        return new FileManagerFolder(this, folderInfo.PrivateName);
    }
}

public class FileSystemObjectInfo
{
    public string PublicName { get; set; }
    public string PrivateName { get; set; }
}