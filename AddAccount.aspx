<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAccount.aspx.cs" Inherits="PasswordWebApp.AddAccount" %>
<%@ Register src="Footer.ascx" tagname="Footer" tagprefix="uc2" %>
<%@ Register src="headerContentForOtherPages.ascx" tagname="headerContentForOtherPages" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Account</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />   
     <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
     <link rel="stylesheet" href="http://cdn.datatables.net/1.10.2/css/jquery.dataTables.min.css" />
      <script type="text/javascript" src="http://cdn.datatables.net/1.10.2/js/jquery.dataTables.min.js"></script>
       <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
     <script>
         $(document).ready(function () {
             $('#PasswordDataGrid').dataTable();
         });
    </script>
    <style type="text/css">
        .entry:not(:first-of-type)
        {
            margin-top: 10px;
        }

        .glyphicon
        {
            font-size: 12px;
        }
    </style>             
</head>
<body class="body">
        <form id="form1" runat="server">
    <div class="container">
        <section class="header">
            <div class="page-header">
                <uc1:headerContentForOtherPages ID="headerContentForOtherPages1" runat="server" />
            </div>
        </section>
        <br />
        <div class="row">
            <div class="col-md-12">
              <a href="Home.aspx">Home</a>
          </div>
        </div>
        <br />
      <div class="row">
          <div class="form-group row">
            <label for="example-text-input" class="col-xs-2 col-form-label">Account Name</label>
             <div class="col-xs-10">
                 <asp:TextBox CssClass="form-control" runat="server" ID="txtAccountName" />
            </div>
            </div>
          <div class="form-group row">
            <label for="example-text-input" class="col-xs-2 col-form-label">User Name</label>
             <div class="col-xs-10"> 
                 <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" />
            </div>
            </div>
   <div class="form-group row">
            <label for="example-text-input" class="col-xs-2 col-form-label">Password</label>
             <div class="col-xs-10">
                 <asp:TextBox ID="txtPassword" type="password" CssClass="form-control" runat="server" />
            </div>
        </div>
         </div>
         <section id="submit">
        <div class ="row">
          <div class="col-lg-12">
              <asp:Button CssClass="btn-success" ID="btnSubmit" runat="server" Text="Add" OnClick="btnSubmit_Click"/>
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
