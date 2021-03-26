$(function () {
    $('#courses').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": "/Admin/course/GetClasses",
        "columnDefs": [
            {
                "orderable": false,
                "targets": 3,
                "render": function (data, type, row) {
                    return `<button type="submit" class="btn btn-info btn-sm" onclick="window.location.href='/admin/course/edit/${data}'" value='${data}'>
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

    $('#courses_filter').addClass("text-right");

    $('#courses').on('click', '.show-bs-modal', function (event) {
        var id = $(this).data("id");
        var modal = $("#modal-default");
        modal.find('.modal-body p').text('Are you sure you want to delete this record?');
        $("#deleteId").val(id);
        $("#deleteForm").attr("action", "/admin/course/delete");
        modal.modal('show');
    });

    $("#deleteButton").click(function () {
        $("#deleteForm").submit();
    });
});