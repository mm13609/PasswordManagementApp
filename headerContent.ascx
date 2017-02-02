<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="headerContent.ascx.cs" Inherits="PasswordWebApp.header1" %>
<html>
    <head>
        <title></title>
            <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
             <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>

        <script src="js/angular.min.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                $(div).animate({ heigth: "toggle", width: "toggle" }, 3000, function () { });
                //$("div").click(function () {
                //    $("img").animate({height: "toggle", width: "toggle"}, 3000).fadeIn({height:"", width:""}, 5000)
                //});
            });
        </script>


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
                <div class ="col-md-4 col-md-offset-0"><img class="img-responsive" alt="tiger"src="images/images.png" />
                </div>
                <div class="col-md-8 col-lg-offset-0">
                    <p class="h1">Password Management Application</p>
                    <br />                 
                </div>
                </div>
            </body>
</html>