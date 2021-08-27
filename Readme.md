<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/141351899/17.2.8%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830558)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# ASPxFileManager - How to show custom folder and file names instead of real ones by implementing a custom PhysicalFileSystemProvider
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/141351899/)**
<!-- run online end -->


<p>This example describes how to show custom folder and file names and access real folders/files by these names in the file system. The main idea is to create a <a href="https://documentation.devexpress.com/AspNet/9907/ASP-NET-WebForms-Controls/File-Management/File-Manager/Concepts/File-System-Providers/Custom-File-System-Provider">custom file system provider</a> that will transform real names to "virtual" names (and vice versa) and build corresponding paths to access folders and files. 
<br/>Refer to <b>App_Code\CustomPhysicalFileSystemProvider.cs</b> for more information.

The "virtual" names are defined in a separate custom store along with real names. In this example, the store is represented by a list of hard-coded names, whereas in a real app, the store may be organized differently (e.g., as a database).
<br/>Take a look at <b>Default.aspx.cs</b> to see the names used to represent the <b>Files</b> directory contents.

See also:<br><a href="https://www.devexpress.com/Support/Center/p/E5024">ASPxFileManager - How to implement a List data bound custom file system provider</a><br><a href="https://www.devexpress.com/Support/Center/p/E2900">ASPxFileManager - How to implement a LINQ to SQL based file system provider</a></p>
