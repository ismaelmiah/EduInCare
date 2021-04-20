$(function() {
    loadDataTable($("#CourseId").val());

    $("#CourseId").change(function () {
        loadDataTable(this.value);
        console.log(this.value);
    });

    function loadDataTable(courseId) {
        $('#examrules').DataTable({
            "processing": true,
            "serverSide": true,
            "destroy": true,
            "searching": false,
            "autoWidth": true,
            "ajax": "/Admin/examrules/GetExamRules?courseId=" + courseId,
            "columnDefs": [
                {
                    "orderable": false,
                    "targets": 2,
                    "width": '30%',
                    "render": function(data, type, row) {
                        var table = '<div class="text-center">' +
                            '<table class="table text-center table-hover table-bordered table-striped" id="rulesTable">' +
                            '<thead class="thead-dark">' +
                            '<tr>' +
                            '<th>Type</th>' +
                            '<th>Total Marks</th>' +
                            '<th>Passing Marks</th>' +
                            '</tr>' +
                            '</thead>' +
                            '<tbody>';
                        var serializedData = JSON.parse(data);
                        serializedData.forEach((item) => {
                            var rows =
                                `<tr> <td>${item.DistributionType}</td><td>${item.TotalMarks}</td><td>${item.PassMarks
                                    }</td></tr>`;
                            table += rows;
                        });
                        table += '</tbody></table>';
                        return table;
                    }
                },
                {
                    "orderable": false,
                    "targets": 5,
                    "width": '15%',
                    "render": function(data, type, row) {
                        return `
                                    <button type="submit" class="btn btn-warning btn-sm" onclick="window.location.href='/admin/examrules/upsert/${
                            data}'" value='${data}'>
                                        <i class="fas fa-pencil-alt">
                                        </i>
                                        Edit
                                    </button>
                                    <button type="submit" class="btn btn-danger btn-sm show-bs-modal" href="#" data-id='${
                            data}' value='${data}'>
                                        <i class="fas fa-trash">
                                        </i>
                                        Delete
                                    </button>`;
                    }
                }
            ]
        });
    }

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