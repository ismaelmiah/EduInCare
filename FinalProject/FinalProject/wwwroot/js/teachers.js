$(function () {
    $('#teachers').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": "/Admin/Employee/GetTeachers",
        "columnDefs": [
            {
                "orderable": false,
                "targets": 2,
                "render": function (data, type, row) {
                    return `<img src=${data} width='50px' />`;
                }
            },
        ]
    });

    $('#teachers_filter').addClass("text-right");
});