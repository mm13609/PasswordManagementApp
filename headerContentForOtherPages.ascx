<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="headerContentForOtherPages.ascx.cs" Inherits="PasswordWebApp.headerContentForOtherPages" %>
<html>
    <head>
        <title></title>
            <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
         
      <style type="text/css">
          #header
          {
              background-color:white;
          }
             img
          { 
             animation-duration: 4s;
             animation-direction:alternate;
             animation-name: slidein;
          }
          @keyframes slidein
          {
              from
              {
                  margin-left:100%;
                  width: auto;
              }
              to 
              {
                  margin-left:0%;
                  width: 100%;
              }
          }
      </style>
    </head>
    <body>
                <div class="container">
                <div class="row">
                    <div class ="col-md-4 col-md-offset-0"><img class="img-responsive" alt="tiger"src="images/images.png" /></div>
                    <div class="col-md-6 col-lg-offset-0"><asp:Label CssClass="h1" runat="server" ID="lblName" /></div>
                    <div class="col-md-2"><asp:Button runat="server" Text="Sign Out" ID="btnSignOff" CssClass="btn-default btn-success" OnClick="btn_Click" /></div>
                </div>
                </div>             
    </body>
</html>