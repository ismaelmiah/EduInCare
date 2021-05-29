$(document).ready(function() {

    $("#adddesignation").on('click', function () {
        var modal = $("#modal-designation");
        modal.modal('show');
        $.ajax({
            method: "GET",
            url: "Designation/Upsert"
        }).done(function (response) {
            $("#contentArea").html(response);
            $("#modal-designation").modal('toggle');
            LoadFormData();
        }).fail(function (xhr, ajaxOptions, thrownError) {
            //console.log(xhr.status);
            //console.log(thrownError);
            alertify.set('notifier', 'position', 'top-right');
            alertify.error('Marks not entered! Please enter mark for this exam!');
        });
    });

    $('#designation').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": "/Employee/Designation/GetDesignations",
        "columnDefs": [
            {
                "orderable": false,
                "targets": 1,
                "render": function (data, type, row) {
                    return `
                            <button type="submit" class="btn btn-warning editdesignation btn-sm" data-id='${data}' value='${data}'>
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

    $('#designation_filter').addClass("text-right");

    $('#designation').on('click', '.show-bs-modal', function (event) {
        var id = $(this).data("id");
        var modal = $("#modal-default");
        modal.find('.modal-body p').text('Are you sure you want to delete this record?');
        $("#deleteId").val(id);
        $("#deleteForm").attr("action", "/Employee/Designation/delete");
        modal.modal('show');
    });

    $('#designation').on('click', '.editdesignation', function (event) {
        var id = $(this).data("id");
        var modal = $("#modal-designation");
        modal.modal('show');
        $.ajax({
            method: "GET",
            url: "Designation/upsert/" + id
        }).done(function (response) {
            $("#contentArea").html(response);
            $("#modal-designation").modal('toggle');
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


function LoadFormData() {
    $("#createDesignation").on('click',
        function() {
            $("#designationForm").submit();
        });
}
