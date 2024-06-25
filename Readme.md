<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/141351899/17.2.8%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830558)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# File Manager for ASP.NET Web Forms - How to display virtual names of folders and files 
This example demonstrates how to display virtual names for folders and files in the [File Manager](https://docs.devexpress.com/AspNet/9032/components/file-management/file-manager) control. Users can access and manage folders and files by these virtual names.

![Display Virtual File Names](result.png)

This example implements a custom file system provider that transforms actual names of files and folders to virtual names and vice versa. The `foldersToShow` variable stores actual and virtual folder names. The `filesToShow` variable stores actual and virtual file names. Instead of variables, you can use another custom storage (for instance, a database).

## Files to Review

- [CustomPhysicalFileSystemProvider.cs](./CS/App_Code/CustomPhysicalFileSystemProvider.cs) (VB: [CustomPhysicalFileSystemProvider.vb](./VB/App_Code/CustomPhysicalFileSystemProvider.vb))
- [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
- [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))

## Documentation

- [Custom File System Provider](https://docs.devexpress.com/AspNet/9907/components/file-management/file-manager/concepts/file-system-providers/custom-file-system-provider)

## More Examples

- [How to implement a custom file system provider for a List data source](https://github.com/DevExpress-Examples/asp-net-web-forms-file-manager-list-custom-file-system-provider)
- [How to implement a custom file system provider for LINQ to SQL data source](https://github.com/DevExpress-Examples/asp-net-web-forms-file-manager-linq-to-sql-custom-file-system-provider)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-filemanager-display-virtual-file-names&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-filemanager-display-virtual-file-names&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
