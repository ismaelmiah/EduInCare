$(function () {
    $('#academicyear').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": "/Admin/AcademicYear/GetAcademicYears",
        "columnDefs": [
            {
                "orderable": false,
                "targets": 5,
                "render": function (data, type, row) {
                    return `
                                    <button class="btn btn-info btn-sm" onclick="window.location.href='/admin/AcademicYear/profile/${data}'" value='${data}'>
                                                                            <i class="fas fa-info">
                                                                            </i>
                                                                            Details
                                                                        </button>
                                    <button type="submit" class="btn btn-warning btn-sm" onclick="window.location.href='/admin/AcademicYear/upsert/${data}'" value='${data}'>
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

    $("#deleteButton").click(function () {
        $("#deleteForm").submit();
    });
});