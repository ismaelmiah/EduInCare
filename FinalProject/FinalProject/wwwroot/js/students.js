$(function () {
    $('#students').DataTable({
        "processing": true,
        "serverSide": true,
        "searching": true,       
        "ajax": "/Admin/Student/GetStudents",
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
                "targets": 8,
                "render": function (data, type, row) {
                    return `<button type="submit" class="btn btn-info btn-sm" onclick="window.location.href='/admin/products/edit/${data}'" value='${data}'>
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

    $('#students').on('click', '.show-bs-modal', function (event) {
        var id = $(this).data("id");
        var modal = $("#modal-default");
        modal.find('.modal-body p').text('Are you sure you want to delete this record?');
        $("#deleteId").val(id);
        $("#deleteForm").attr("action", "/student/home/delete");
        modal.modal('show');
    });

    $("#deleteButton").click(function () {
        $("#deleteForm").submit();
    });
});
