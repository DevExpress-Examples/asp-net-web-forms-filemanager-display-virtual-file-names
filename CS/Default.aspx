<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.17.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DxSample</title>
</head>
<body>
    <form id="form1" runat="server"> 
        <dx:ASPxFileManager runat="server" ID="FileManager" ClientInstanceName="fileManger" Height="340">
            <ClientSideEvents SelectedFileOpened="function(s, e) {
	             e.file.Download();
	             e.processOnServer = false;
             }" />
            <SettingsEditing AllowCopy="false" AllowMove="false" AllowRename="false" AllowCreate="false" 
                AllowDelete="true" AllowDownload="true" />
            <SettingsUpload Enabled="false" />
        </dx:ASPxFileManager>
    </form>
</body>
</html>
