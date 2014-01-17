<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="PhotoWebPro" %>
<%@ Import Namespace="System.IO" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>PhotoShare</title>
    
    <%--<link href="../../Content/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />--%>
    <link href="../../Content/themes/base/svwp_style.css" rel="stylesheet" type="text/css" />
    <link href="<%= Url.Content("~/Content/galleria.classic.css")%>" rel="stylesheet" type="text/css" />

      <style media="screen" type="text/css">
             #galleria{height:320px; width:100%}
    </style>
    
    <script src="<%= Url.Content("~/Scripts/jquery/jquery-1.6.4.min.js")%>" type="text/javascript"></script>
    <script src="<%= Url.Content("~/Scripts/jquery/jquery-ui-1.8.18.min.js")%>" type="text/javascript"></script>

    <script src="<%= Url.Content("~/Scripts/jquery/plugins/jquery.timers.js")%>" type="text/javascript"></script>
   <%-- <script src="<%= Url.Content("~/Scripts/jquery/plugins/jquery.slideViewerPro.1.5.js")%>" type="text/javascript"></script>    --%>
   <%-- <script src="<%= Url.Content("~/Scripts/jquery/plugins/json2.js")%>" type="text/javascript"></script>--%>

    <script src="<%= Url.Content("~/Scripts/jquery/jquery.form.js")%>" type="text/javascript"></script>
    <script src="<%= Url.Content("~/Scripts/jquery/jquery.signalR.js")%>" type="text/javascript"></script>
    <script src="/signalr/hubs" type="text/javascript"></script>    
    <script src="<%= Url.Content("~/Scripts/PhotoSharing.js")%>" type="text/javascript"></script>

    <script src="<%= Url.Content("~/Scripts/jquery/plugins/galleria-1.2.6.js")%>" type="text/javascript"></script>
    <script src="<%= Url.Content("~/Scripts/jquery/plugins/galleria.classic.js")%>" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {

            //jQuery("div.svwp").prepend("<img src='<%= Url.Content("~/Content/images/svwloader.gif")%>' class='ldrgif' alt='loading...'/ >"); //change with YOUR loader image path   

            // Load the classic theme
            //Galleria.loadTheme('<%= Url.Content("~/Scripts/jquery/plugins/galleria.classic.js")%>');

            // Initialize Galleria
            //$('#galleria').galleria();
            $('#galleria').galleria();
            

        });
    </script>

  

</head>
<body>
    <center><h1>Sharing Photos</h1></center>
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <center>                    
                       <%-- <%=Html.PopulatePhotos("sharePhotos")%>--%>
                        <%=Html.PopulateGallery("galleria")%>
                    </center>
                </td>
            </tr>
            <tr>
                <td>
                    <center>
                    <div id="UpdatePhotoDiv">
                         <% using (Html.BeginForm("Upload", "PhotoShare", FormMethod.Post, new { id = "frmUploadPhoto", enctype = "multipart/form-data"}))
                            {%>
                                    <input name="uploadFile" type="file" accept="image/jpeg" />
                                    <input type="submit" value="Upload Photo" />
                            <%} %>
                    </div>
                    </center>
                    <%--<img src='<%=Url.Action("DisplayPhoto", new { Filename = "129763331036451267.upload" }) %>' id="test" alt="Error" />--%>
                </td>
            </tr>
        </table>        
    </div>  
</body>
</html>
