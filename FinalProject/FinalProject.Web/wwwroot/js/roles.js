$(function () {
    $('#roles').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": "/Administrative/Administrative/GetRoles",
        "columnDefs": [
            {
                "orderable": false,
                "targets": 1,
                "render": function (data, type, row) {
                    return `
                                    <button type="submit" class="btn btn-warning btn-sm" onclick="window.location.href='/Administrative/Administrative/upsertrole/${data}'" value='${data}'>
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

    $('#roles_filter').addClass("text-right");

    $('#roles').on('click', '.show-bs-modal', function (event) {
        var id = $(this).data("id");
        var modal = $("#modal-default");
        modal.find('.modal-body p').text('Are you sure you want to delete this record?');
        $("#deleteId").val(id);
        $("#deleteForm").attr("action", "/Administrative/Administrative/DeleteRole");
        modal.modal('show');
    });

    $("#deleteButton").click(function () {
        $("#deleteForm").submit();
    });
});