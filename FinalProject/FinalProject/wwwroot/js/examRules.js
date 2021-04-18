$(function () {
    $('#examrules').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": "/Admin/examrules/GetExamRules",
        "columnDefs": [
            {
                "orderable": false,
                "targets": 3,
                "render": function (data, type, row) {
                    return `<label class="btn ${data === true ? 'btn-success' : 'btn-danger'} active">${data === true ? 'YES' : 'NO'}</label>`;
                }
            },
            {
                "orderable": false,
                "targets": 4,
                "render": function (data, type, row) {
                    return `
                                    <button type="submit" class="btn btn-warning btn-sm" onclick="window.location.href='/admin/examrules/upsert/${data}'" value='${data}'>
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

    $('#examrules_filter').addClass("text-right");

    $('#examrules').on('click', '.show-bs-modal', function (event) {
        var id = $(this).data("id");
        var modal = $("#modal-default");
        modal.find('.modal-body p').text('Are you sure you want to delete this record?');
        $("#deleteId").val(id);
        $("#deleteForm").attr("action", "/admin/examrules/delete");
        modal.modal('show');
    });

    $("#deleteButton").click(function () {
        $("#deleteForm").submit();
    });
});