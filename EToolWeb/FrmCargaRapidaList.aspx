<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmCargaRapidaList.aspx.cs" Inherits="EToolWeb.FrmCargaRapidaList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Carga Rapida</title>
    <link href="css/Style.css" rel="stylesheet" />
    <link href="bootstrap/css/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen" />
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" media="screen" />
    <script>
        var popUpWin = 0;
        function PopUp(URLStr, left, top, width, height) {
            if (popUpWin) {
                if (!popUpWin.closed) popUpWin.close();
            }
            popUpWin = open(URLStr, 'popUpWindows', 'toolbar=no,scrollbars=yes,location=no,directories=no,status=no,menubar=no,resizable=no,copyhistory=yes,width=' + width + ',height=' + height + ',left=' + left + ', top=' + top + ',screenX=' + left + ',screenY=' + top + '');
        }
        function OpenPopup() {
            window.open("actualizarpop.aspx" + URLStr, "Custom", "scrollbars=yes,resizable=no,menubar=no,status=no,toolbar=no,width=600,height=400");
            return false;
        }
        function Mensaje() {
            window.alert('El registro se actualizó con exito');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" class="form-inline" role="form">
        <div class="container">
            <div class="form-group col-md-5" >
                <label class="sr-only" for="txtEmpleado">Empledo</label>
                <asp:TextBox ID="txtEmpleado" runat="server" class="form-control" placeholder="Nombre de empleado"></asp:TextBox>
            </div>
            <div class="form-group col-md-5">
                <label class="sr-only" for="ejemplo_password_2">Contraseña</label>
                <asp:DropDownList ID="ddlEntrenamiento" runat="server" class="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="container">
            <div class='col-md-5'>
                <div class="form-group">
                    <div class='input-group date' id='datetimepicker6'>
                        <asp:TextBox ID="txtFechaIni" runat="server" class="form-control"></asp:TextBox>                 
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </div>
            </div>
            <div class='col-md-5'>
                <div class="form-group">
                    <div class='input-group date' id='datetimepicker7'>
                        <asp:TextBox ID="txtFechaFin" runat="server" class="form-control"></asp:TextBox>
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </div>
            </div>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-default" OnClick="btnBuscar_Click"/>
          
        </div>
       <div>
           <br>
               <asp:Literal ID="ltlCapacitaciones" runat="server"></asp:Literal>
           <asp:GridView ID="gvCapacitaciones" runat="server" class="table table-hover"></asp:GridView>
        </br>
    </form>
    <script type="text/javascript" src="jquery/jquery-1.8.3.min.js" charset="UTF-8"></script>
    <script type="text/javascript" src="bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/bootstrap-datetimepicker.js" charset="UTF-8"></script>
    <script type="text/javascript" src="js/locales/bootstrap-datetimepicker.es.js" charset="UTF-8"></script>
<script type="text/javascript">
    $(function () {
        $('#datetimepicker6').datetimepicker({
            language: 'es',
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 2,
            minView: 2,
            forceParse: 0,
            format: 'dd/mm/yyyy'
        });
        $('#datetimepicker7').datetimepicker({
            language: 'es',
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 2,
            minView: 2,
            forceParse: 0,
            format: 'dd/mm/yyyy'
        });
        $("#datetimepicker6").on("dp.change", function (e) {
            $('#datetimepicker7').data("DateTimePicker").minDate(e.date);
        });
        $("#datetimepicker7").on("dp.change", function (e) {
            $('#datetimepicker6').data("DateTimePicker").maxDate(e.date);
        });
    });
</script>
</body>
</html>
