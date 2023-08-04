$(function () {
    $('#applicants').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": "/Student/Home/GetApplicants",
        "columnDefs": [
            {
                "orderable": false,
                "targets": 1,
                "render": function (data) {
                    return `<img src=${data} width='50px' />`;
                }
            },
            {
                "orderable": false,
                "targets": 5,
                "render": function (data, type, row) {
                    var approved = `<a class="dropdown-item show-bs-modal-student ml-1" href="#" data-id='${data}' value='${data}'><i class="fa fa-check mr-1"></i>Approve</a>`;
                    var rejected = `<a class="dropdown-item show-bs-modal ml-1" href="#" data-id='${data}' value='${data}'><i class="fa fa-ban mr-1"></i>Reject</a>`;
                    var detailed = `<a class="btn btn-default btn-sm show-bs-modal-student_detials ml-1" href="#" data-id='${data}' value='${data}'><i class="fa fa-info mr-1"></i>Details</a>`;
                    var returnData = `<div class="btn-group" role="group"><button id="btnGroupDrop1" type="button" class="btn btn- ${row[6] === "Approved"
                        ? "btn-outline-success"
                        : "" || row[6] === "Pending"
                            ? "btn-outline-warning"
                            : "" || row[6] === "Rejected"
                                ? "btn-outline-danger"
                                : ""
                        } dropdown-toggle btn-sm mr-2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                              ${row[6]}
                            </button>
                 <div class="dropdown-menu" aria-labelledby="btnGroupDrop1">`;
                    if (row[6] === 'Approved') {
                        returnData += rejected + `</div></div>`;
                    } else if (row[6] === 'Rejected') {
                        returnData += approved + `</div></div>`;
                    } else {
                        returnData += approved + rejected + `</div></div>`;
                    }
                    return returnData + detailed;
                }
            }
        ]
    });

    $('#applicants_filter').addClass("text-right");

    $('#applicants').on('click', '.show-bs-modal', function () {
        var id = $(this).data("id");
        var modal = $("#modal-default");
        modal.find('.modal-body p').text('Are you sure you want to reject this Student?');
        $("#rejectId").val(id);
        modal.modal('show');
    });

    $('#applicants').on('click', '.show-bs-modal-student', function () {
        var id = $(this).data("id");
        var modal = $("#modal-student");
        modal.find('.modal-body p').text('Are you sure you want to approve this Student?');
        $("#approveId").val(id);
        modal.modal('show');
    });

    $('#applicants').on('click', '.show-bs-modal-student_detials', function () {
        var modal = $("#modal-student-details");
        modal.modal('show');
    });

    $('#applicants').on('click', '.show-bs-modal-student_detials', function () {
        var id = $(this).data("id");
        console.log(id);
        $.ajax({
            method: 'Get',
            url: "/Student/Home/_ApplicationDetails",
            data: { id: id }
        }).done(function (response) {
            $("#contentArea").html(response);
            $("#modal-student-details").modal('toggle');
        }).fail(function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status);
            console.log(thrownError);
        });
    });

    $("#rejectButton").click(function () {
        $("#rejectForm").submit();
    });

    $("#approveButton").click(function () {
        $("#approveForm").submit();
    });
});
