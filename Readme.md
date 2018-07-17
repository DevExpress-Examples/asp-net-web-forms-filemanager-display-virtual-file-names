
# ASPxFileManager - How to show custom folder and file names instead of real ones by implementing a custom PhysicalFileSystemProvider


<p>This example describes how to show custom folder and file names and access real folders/files by these names in the file system. The main idea is to create a <a href="https://documentation.devexpress.com/AspNet/9907/ASP-NET-WebForms-Controls/File-Management/File-Manager/Concepts/File-System-Providers/Custom-File-System-Provider">custom file system provider</a> that will transform real names to "virtual" names (and vice versa) and build corresponding paths to access folders and files. 
<br/>Refer to <b>App_Code\CustomPhysicalFileSystemProvider.cs</b> for more information.

The "virtual" names are defined in a separate custom store along with real names. In this example, the store is represented by a list of hard-coded names, whereas in a real app, the store may be organized differently (e.g., as a database).
<br/>Take a look at <b>Default.aspx.cs</b> to see the names used to represent the <b>Files</b> directory contents.

See also:<br><a href="https://www.devexpress.com/Support/Center/p/E5024">ASPxFileManager - How to implement a List data bound custom file system provider</a><br><a href="https://www.devexpress.com/Support/Center/p/E2900">ASPxFileManager - How to implement a LINQ to SQL based file system provider</a></p>
