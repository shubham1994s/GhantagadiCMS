$(document).ready(function () {
    debugger;

    $("#demoGridnew").DataTable({

        "sDom": "ltipr",
        //"order": [[10, "desc"]],
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        // "pageLength": 1,
        //  "bPaginate": false,
        width: 670,
        "ajax": {
            "url": "/Datable/GetJqGridJson?rn=EmployeeSummarynew",
            "type": "POST",
            "datatype": "json"

        },

        "columnDefs":
            [{
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            ],
        "columns": [
            { "data": "daID", "name": "daID", "id": "daID", "autoWidth": true },
            { "data": "UserName", "name": "userName", "autoWidth": true },
            { "data": "daDate", "name": "daDate", "autoWidth": true },
            { "data": "StartTime", "name": "startTime", "autoWidth": true },
            { "data": "DaEndDate", "name": "daEndDate", "autoWidth": true },
            { "data": "EndTime", "name": "endTime", "autoWidth": true },
            { "data": "VehicleNumber", "name": "VehicleNumber", "autoWidth": true },
            /*   { "render": function (data, type, full, meta) { return '<a   data-toggle="modal" class="tooltip1" style="cursor:pointer" onclick="work_route(' + full["daID"] + ')" ><i id="viewPlaceHolder" class="material-icons location-icon">location_on</i><span class="tooltiptext1">Work Map Route</span> </a>'; }, "width": "10px" },*/
            { "data": "InBatteryStatus", "name": "InBatteryStatus", "autoWidth": true },
            { "data": "OutBatteryStatus", "name": "OutBatteryStatus", "autoWidth": true },


        ],
        //Sort: "locId DESC"
    });
    var UserId = $('#selectnumber').val();
    $.ajax({
        type: "post",
        url: "/Location/UserList",
        data: { userId: UserId },
        datatype: "json",
        traditional: true,
        success: function (data) {
            district = '<option value="-1">Select Employee</option>';
            for (var i = 0; i < data.length; i++) {
                district = district + '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';
            }
            //district = district + '</select>';
            $('#selectnumber').html(district);
        }
    });
    BindVehicalnumber(0);
   

    $('#selectnumber').change(function () {
        debugger;
        var selectednumber = $('#selectnumber option:selected').val();
        BindVehicalnumber(selectednumber);
    });
    $('#showmap').click(function () {
        debugger;
        var partialViewToInsert = oTable.data()[0].daID;
        replaceContentsOfDiv(partialViewToInsert);
       
    });
    function replaceContentsOfDiv(partialViewToInsert) {
        debugger;
        $.ajax({
            url: '/Employee/partial_work_route?daId=' + partialViewToInsert,
            data: {  daId: partialViewToInsert },
            type: "POST",
            success: function (data) {
                $('#map').html(data);
                $('#map').show();
            }
        });
    }
  
    
   
});
function BindVehicalnumber(selectednumber) {
    var vehiclenumber = selectednumber;
    debugger;
    $.ajax({
        type: "post",
        url: "/Location/VehicalList?userId=" + selectednumber,
        data: { vehcileNumber: vehiclenumber },
        datatype: "json",
        traditional: true,
        success: function (data) {
            district = '<option value="-1">Select Vehical Number</option>';
            for (var i = 0; i < data.length; i++) {
                district = district + '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';
            }
            //district = district + '</select>';
            $('#selectVehicalnumber').html(district);
        }
    });
}
function test(id) {
    window.location.href = "/Attendence/Location?daId=" + id;
};


//function work_route(id) {
//    debugger;
//    window.location.href = "/Employee/WorkMapRoute?daId=" + id;
//};


function map(a) {
    window.location.href = "/Location/viewLocation?teamId=" + a;

};
//////////////////////////////////////////////////////////////////////////////

function Filter1() {

    Search();
    $('#map').hide();
  
}

function Search() {
    debugger;

    var txt_fdate, txt_tdate, Client, UserId;
    var name = [];
    var arr = [$('#txt_fdate').val(), $('#txt_tdate').val()];

    for (var i = 0; i <= arr.length - 1; i++) {
        name = arr[i].split("/");
        arr[i] = name[1] + "/" + name[0] + "/" + name[2];
    }

    txt_fdate = arr[0];
    txt_tdate = arr[1];
    UserId = $('#selectnumber').val();
    Vehicalnumber = $('#selectVehicalnumber').val();
    Client = " ";
    NesEvent = " ";
    var Product = "";
    var catProduct = "";
    var value = txt_fdate + "," + txt_tdate + "," + UserId + "," + Vehicalnumber + "," + $("#s").val();//txt_fdate + "," + txt_tdate + "," + UserId + "," + Client + "," + NesEvent + "," + Product + "," + catProduct + "," + 1;
    if (UserId != -1)
    {

    oTable = $('#demoGridnew').DataTable();
    oTable.search(value).draw();
    oTable.search("");
        $('#map').show();
        $('#showmap').show();
    }
    if (UserId == -1) {
        $("#demoGridnew tbody").empty();  
      
        $('#map').hide();
        $('#showmap').hide();
       // oTable = $('#demoGridnew').DataTable();
        

        
    }
 
}
