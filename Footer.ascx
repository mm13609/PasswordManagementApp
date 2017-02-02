<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="PasswordWebApp.Footer" %>
<html>
    <head>
         <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <title>
            e
        </title>
    </head>
    <body onload="AddYear()">
       <section class="footer">
           
               <div class="col-md-12">
                    <div class="panel-footer">
                        <p class="h6" id="year1"></p>
               </div>   
           </div>
           
       </section>
          
        <script type="text/javascript">
            function AddYear()
            {
                var date = new Date();
               document.getElementById('year1').innerHTML = "&#169;" + date.getFullYear();
            }
</script>
    </body>
</html>