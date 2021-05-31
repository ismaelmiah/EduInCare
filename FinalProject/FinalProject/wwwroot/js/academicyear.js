$(function () {
    $("#addAcademicYear").on('click', function() {
        var modal = $("#modal-academicYear");
        modal.modal('show');
        $.ajax({
            method: "GET",
            url: "AcademicYear/Upsert"
        }).done(function (response) {
            $("#contentArea").html(response);
            $("#modal-academicYear").modal('toggle');
            LoadFormData();
        }).fail(function (xhr, ajaxOptions, thrownError) {
            //console.log(xhr.status);
            //console.log(thrownError);
            alertify.set('notifier', 'position', 'top-right');
            alertify.error('Marks not entered! Please enter mark for this exam!');
        });
    });

    $('#academicyear').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": "/Admin/AcademicYear/GetAcademicYears",
        "columnDefs": [
            {
                "orderable": false,
                "targets": 6,
                "render": function (data, type, row) {
                    return `
                                    <button type="submit" class="btn btn-warning academicEdit btn-sm" data-id='${data}' value='${data}'>
                                        <i class="fas fa-pencil-alt">
                                        </i>
                                        Edit
                                    </button>
                                    <button type="submit" class="btn btn-danger btn-sm show-bs-modal" href="#" data-id='${data}' value='${data}'>
                                        <i class="fas fa-trash">
                                        </i>
                                        Delete
                                    </button>`;
                }
            }
        ]
    });

    $('#academicyear_filter').addClass("text-right");

    $('#academicyear').on('click', '.show-bs-modal', function (event) {
        var id = $(this).data("id");
        var modal = $("#modal-default");
        modal.find('.modal-body p').text('Are you sure you want to delete this record?');
        $("#deleteId").val(id);
        $("#deleteForm").attr("action", "/admin/AcademicYear/delete");
        modal.modal('show');
    });
    
    $('#academicyear').on('click', '.academicEdit', function (event) {
        var id = $(this).data("id");
        var modal = $("#modal-academicYear");
        modal.modal('show');
        $.ajax({
            method: "GET",
            url: "AcademicYear/Upsert?id="+id
        }).done(function (response) {
            $("#contentArea").html(response);
            $("#modal-academicYear").modal('toggle');
            LoadFormData();
        }).fail(function (xhr, ajaxOptions, thrownError) {
            //console.log(xhr.status);
            //console.log(thrownError);
            alertify.set('notifier', 'position', 'top-right');
            alertify.error('Marks not entered! Please enter mark for this exam!');
        });
    });

    $("#deleteButton").click(function () {
        $("#deleteForm").submit();
    });
});

var LoadFormData = function () {

    var date = new Date();

    var day = date.getDate();
    var month = date.getMonth() + 1;
    var year = date.getFullYear();

    if (month < 10) month = "0" + month;
    if (day < 10) day = "0" + day;

    var today = year + "-" + month + "-" + day;


    document.getElementById('StartDate').value = today;
    document.getElementById('EndDate').value = today;

    $("#academicYearSubmit").click(function () {
        $("#academicYearForm").submit();
    });
}