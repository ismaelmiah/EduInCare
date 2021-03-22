$(function () {
    $('#teachers').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": "/Admin/Employee/GetTeachers",
        "columnDefs": [
            {
                "orderable": false,
                "targets": 3,
                "render": function (data, type, row) {
                    return `<img src=${data} width='50px' />`;
                }
            },
            {
                "orderable": false,
                "targets": 7,
                "render": function (data, type, row) {
                    return `<a class="btn btn-info btn-sm" href='/Employee/Home/Profile/${data}'">
                                <i class="fas fa-info-circle"></i>
                                Details
                            </a>
                            <button type="submit" class="btn btn-warning btn-sm" onclick="window.location.href='/Employee/Home/Upsert/${data}?isAdmin=true'" value='${data}'>
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

    $('#teachers_filter').addClass("text-right");

    $('#teachers').on('click', '.show-bs-modal', function (event) {
        var id = $(this).data("id");
        var modal = $("#modal-default");
        modal.find('.modal-body p').text('Are you sure you want to delete this record?');
        $("#deleteId").val(id);
        $("#deleteForm").attr("action", "/Employee/home/delete");
        modal.modal('show');
    });

    $("#deleteButton").click(function () {
        $("#deleteForm").submit();
    });
});