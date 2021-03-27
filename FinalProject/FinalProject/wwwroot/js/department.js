$(function () {
    $('#departments').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": "/Admin/Department/GetDepartments",
        "columnDefs": [
            {
                "orderable": false,
                "targets": 2,
                "render": function (data, type, row) {
                    return `<a class="btn btn-info btn-sm" href='/Admin/Department/Profile/${data}'">
                                <i class="fas fa-info-circle"></i>
                                Details
                            </a>
                            <button type="submit" class="btn btn-warning btn-sm" onclick="window.location.href='/Admin/Department/Upsert/${data}'" value='${data}'>
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

    $("#deleteButton").click(function () {
        $("#deleteForm").submit();
    });
});
