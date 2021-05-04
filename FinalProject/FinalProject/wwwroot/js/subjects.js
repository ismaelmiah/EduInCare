$(function () {
    $("#addSubject").on('click', function () {
        var modal = $("#modal-subject");
        modal.modal('show');
        $.ajax({
            method: "GET",
            url: "Subject/Upsert"
        }).done(function (response) {
            $("#contentArea").html(response);
            $("#modal-subject").modal('toggle');
        }).fail(function (xhr, ajaxOptions, thrownError) {
            //console.log(xhr.status);
            //console.log(thrownError);
            alertify.set('notifier', 'position', 'top-right');
            alertify.error('Marks not entered! Please enter mark for this exam!');
        });
    });

    $('#subjects').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": "/course/subject/GetSubjects",
        "columnDefs": [
            {
                "orderable": false,
                "targets": 5,
                "render": function (data, type, row) {
                    return `
                                    <button class="btn btn-info btn-sm" onclick="window.location.href='/course/subject/profile/${data}'" value='${data}'>
                                                                            <i class="fas fa-info">
                                                                            </i>
                                                                            Details
                                                                        </button>
                                    <button type="submit" class="btn btn-warning btn-sm" onclick="window.location.href='/course/subject/upsert/${data}'" value='${data}'>
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

    $('#subjects_filter').addClass("text-right");

    $('#subjects').on('click', '.show-bs-modal', function (event) {
        var id = $(this).data("id");
        var modal = $("#modal-default");
        modal.find('.modal-body p').text('Are you sure you want to delete this record?');
        $("#deleteId").val(id);
        $("#deleteForm").attr("action", "/course/subject/delete");
        modal.modal('show');
    });

    $("#deleteButton").click(function () {
        $("#deleteForm").submit();
    });
});