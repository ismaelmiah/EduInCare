$(function () {

    $("#addGrade").on('click', function () {
        var modal = $("#modal-grade");
        modal.modal('show');
        $.ajax({
            method: "GET",
            url: "Grade/Upsert"
        }).done(function (response) {
            $("#contentArea").html(response);
            $("#modal-grade").modal('toggle');
            LoadFormData();
        }).fail(function (xhr, ajaxOptions, thrownError) {
            //console.log(xhr.status);
            //console.log(thrownError);
            alertify.set('notifier', 'position', 'top-right');
            alertify.error('Marks not entered! Please enter mark for this exam!');
        });
    });


    $('#grades').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": "/Admin/grade/GetGrades",
        "columnDefs": [
            {
                "orderable": false,
                "targets": 1,
                "render": function (data, type, row) {
                   var table ='<div class="text-center">' +
                       '<table class="table text-center table-hover table-bordered table-striped" id="rulesTable">' +
                           '<thead class="thead-dark">' +
                               '<tr>' +
                                   '<th>Name</th>' +
                                   '<th>Point</th>' +
                                   '<th>From</th>' +
                                   '<th>UpTo</th>' +
                               '</tr>' +
                           '</thead>' +
                        '<tbody>';
                    var serializedData = JSON.parse(data);
                    serializedData.forEach((item) => {
                        var rows =
                            `<tr> <td>${item.Name}</td><td>${item.Point}</td><td>${item.Minimum}</td><td>${
                                item.Maximum}</td></tr>`;
                        table += rows;
                    });
                    table += '</tbody></table>';
                    return table;
                }
            },
            {
                "orderable": false,
                "targets": 2,
                "render": function (data, type, row) {
                    return `
                                    <button type="submit" class="btn btn-warning btn-sm" onclick="window.location.href='/admin/grade/upsert/${data}'" value='${data}'>
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

    $('#grades_filter').addClass("text-right");

    $('#grades').on('click', '.show-bs-modal', function (event) {
        var id = $(this).data("id");
        var modal = $("#modal-default");
        modal.find('.modal-body p').text('Are you sure you want to delete this record?');
        $("#deleteId").val(id);
        $("#deleteForm").attr("action", "/admin/grade/delete");
        modal.modal('show');
    });

    $("#deleteButton").click(function () {
        $("#deleteForm").submit();
    });

});

var LoadFormData = function() {
    $("#gradeSubmit").click(function () {
        $("#gradeFrom").submit();
    });
}