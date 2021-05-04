$(function () {

    $("#addCourse").on('click', function () {
        var modal = $("#modal-course");
        modal.modal('show');
        $.ajax({
            method: "GET",
            url: "Course/Upsert"
        }).done(function (response) {
            $("#contentArea").html(response);
            $("#modal-course").modal('toggle');
            LoadFormData();
        }).fail(function (xhr, ajaxOptions, thrownError) {
            //console.log(xhr.status);
            //console.log(thrownError);
            alertify.set('notifier', 'position', 'top-right');
            alertify.error('Marks not entered! Please enter mark for this exam!');
        });
    });

    $('#courses').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": "/Admin/course/GetClasses",
        "columnDefs": [
            {
                "orderable": false,
                "targets": 7,
                "render": function (data, type, row) {
                    return `
                                    <button class="btn btn-info btn-sm" onclick="window.location.href='/admin/course/profile/${data}'" value='${data}'>
                                                                            <i class="fas fa-info">
                                                                            </i>
                                                                            Details
                                                                        </button>
                                    <button type="submit" class="btn btn-warning btn-sm" onclick="window.location.href='/admin/course/upsert/${data}'" value='${data}'>
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

var LoadFormData = function() {
    $('#HaveCompulsorySubject').change(function () {
        if ($(this).is(":checked")) {
            $("#MaxCompulsorySubjectDiv").css("visibility", "visible");
        }
        else {
            $("#MaxCompulsorySubjectDiv").css("visibility", "hidden");
        }
    });

    $("#courseSubmit").click(function () {
        $("#courseForm").submit();
    });
}