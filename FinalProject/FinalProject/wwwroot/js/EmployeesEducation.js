$(function () {
    $('#employeeseducation').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": "/Employee/EmployeeEducation/GetEmployeeEducations",
        "columnDefs": [
            {
                "orderable": false,
                "targets": 8,
                "render": function (data, type, row) {
                    return `<a class="btn btn-info btn-sm" href='/student/Home/Profile/${data}'">
                                <i class="fas fa-info-circle"></i>
                                Details
                            </a>
                            <button type="submit" class="btn btn-warning btn-sm" onclick="window.location.href='/student/Home/Upsert/${data}'" value='${data}'>
                                <i class="fas fa-edit"></i>
                                Edit
                            </button>
                            <button type="submit" class="btn btn-danger btn-sm show-bs-modal" href="#" data-id='${data}' value='${data}'>
                                <i class="fas fa-trash"></i>
                                Delete
                            </button>`;
                }
            }
        ]
    });

    $('#employeeseducation_filter').addClass("text-right");

    $('#employeeseducation').on('click', '.show-bs-modal', function (event) {
        var id = $(this).data("id");
        var modal = $("#modal-default");
        modal.find('.modal-body p').text('Are you sure you want to delete this record?');
        $("#deleteId").val(id);
        $("#deleteForm").attr("action", "/student/home/delete");
        modal.modal('show');
    });

    $("#deleteButton").click(function () {
        $("#deleteForm").submit();
    });
});