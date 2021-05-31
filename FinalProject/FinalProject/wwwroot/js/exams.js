$(function () {

    $("#addExam").on('click', function () {
        var modal = $("#modal-exam");
        modal.modal('show');
        $.ajax({
            method: "GET",
            url: "Exam/Upsert"
        }).done(function (response) {
            $("#contentArea").html(response);
            $("#modal-exam").modal('toggle');
            LoadFormData();
        }).fail(function (xhr, ajaxOptions, thrownError) {
            //console.log(xhr.status);
            //console.log(thrownError);
            alertify.set('notifier', 'position', 'top-right');
            alertify.error('Marks not entered! Please enter mark for this exam!');
        });
    });


    $('#exams').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": "/Admin/exam/GetExams",
        "columnDefs": [
            {
                "orderable": false,
                "targets": 2,
                "render": function (data, type, row) {
                    return `${data.split(',').map(w => '<span class="lead"><span class="badge badge-pill badge-info">' + w.charAt(0).toUpperCase() + w.slice(1) + '</span></span>').join(' ')}`;
                }
            },
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
                                    <button type="button" class="btn btn-warning examedit btn-sm" data-id='${data}' value='${data}'>
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

    $('#exams_filter').addClass("text-right");

    $('#exams').on('click', '.examedit', function (event) {
        var id = $(this).data("id");
        var modal = $("#modal-exam");
        modal.modal('show');
        $.ajax({
            method: "GET",
            url: "Exam/Upsert?id="+id
        }).done(function (response) {
            $("#contentArea").html(response);
            $("#modal-exam").modal('toggle');
            LoadFormData();
        }).fail(function (xhr, ajaxOptions, thrownError) {
            //console.log(xhr.status);
            //console.log(thrownError);
            alertify.set('notifier', 'position', 'top-right');
            alertify.error('Marks not entered! Please enter mark for this exam!');
        });
    });

    $('#exams').on('click', '.show-bs-modal', function (event) {
        var id = $(this).data("id");
        var modal = $("#modal-default");
        modal.find('.modal-body p').text('Are you sure you want to delete this record?');
        $("#deleteId").val(id);
        $("#deleteForm").attr("action", "/admin/exam/delete");
        modal.modal('show');
    });

    $("#deleteButton").click(function () {
        $("#deleteForm").submit();
    });
});

var LoadFormData = function() {

    $("#examSubmit").click(function () {
        $("#examForm").submit();
    });


    $("#MarksDistributionTypes").select2({
        width: 'resolve'
    })
}