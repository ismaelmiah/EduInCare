$(function () {

    $("#addDepartment").on('click', function () {
        var modal = $("#modal-department");
        modal.modal('show');
        $.ajax({
            method: "GET",
            url: "Department/Upsert"
        }).done(function (response) {
            $("#contentArea").html(response);
            $("#modal-department").modal('toggle');
            LoadFormData();
        }).fail(function (xhr, ajaxOptions, thrownError) {
            //console.log(xhr.status);
            //console.log(thrownError);
            alertify.set('notifier', 'position', 'top-right');
            alertify.error('Marks not entered! Please enter mark for this exam!');
        });
    });

    $('#departments').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": "/Admin/Department/GetDepartments",
        "columnDefs": [
            {
                "orderable": false,
                "targets": 2,
                "render": function (data, type, row) {
                    return `
                            <button type="submit" class="btn departmentEdit btn-warning btn-sm" data-id='${data}' value='${data}'>
                                <i class="fas fa-edit"></i>
                                Edit
                            </button>
                            <button type="submit" class="btn btn-danger btn-sm show-bs-modal" href="#" data-id='${data}' value='${data}'>
                                <i class="fas fa-trash"></i>
                                Delete
                            </button>`;
                }
            }
        ]
    });

    $('#departments_filter').addClass("text-right");

    $('#departments').on('click', '.show-bs-modal', function (event) {
        var id = $(this).data("id");
        var modal = $("#modal-default");
        modal.find('.modal-body p').text('Are you sure you want to delete this record?');
        $("#deleteId").val(id);
        $("#deleteForm").attr("action", "/Admin/Department/delete");
        modal.modal('show');
    });
    
    $('#departments').on('click', '.departmentEdit', function (event) {
        var id = $(this).data("id");
        var modal = $("#modal-department");
        modal.modal('show');
        $.ajax({
            method: "GET",
            url: "Department/Upsert?id="+id
        }).done(function (response) {
            $("#contentArea").html(response);
            $("#modal-department").modal('toggle');
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
    $("#departmentSubmit").click(function () {
        $("#departmentForm").submit();
    });
}