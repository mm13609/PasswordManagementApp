<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PasswordWebApp.Login"%>

<%@ Register src="headerContent.ascx" tagname="headerContent" tagprefix="uc1" %>

<%@ Register src="Footer.ascx" tagname="Footer" tagprefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .body
        {

        }
    </style>
    
</head>
<body class="body">
    <form id="form1" runat="server">
     
        <div class="container-fluid">
        <section id="header">
            <div class="page-header">
                <uc1:headerContent ID="headerContent1" runat="server" />
            </div>

        </section>
        <br />
    
     <section id="username">
          <div class="row">
          <div class="col-lg-12">
      User name: &nbsp <asp:TextBox CssClass="input-sm" runat="server" ID="txtUsername"/> 
    </div>
     </div>
     </section>
            <br />
<section id="password">
    <div class="row">
              <div class="col-lg-12">
         Password: &nbsp <asp:TextBox type="password" CssClass="input-sm" runat="server" ID="txtPassword" />
     </div>
         </div>
</section>
            <br />
    <section id="submit">
    
        <div class ="row">
          <div class="col-lg-12">
              <asp:Button CssClass="btn-success" ID="btnSubmit" runat="server" Text="Submit" OnClick="Submit_Click"/>
          </div>
        </div>
       </section>
            <br />
    <section id="footer">
        <uc2:Footer ID="Footer1" runat="server" />
    </section>
    </div>

    </form>
        
</body>
</html>
