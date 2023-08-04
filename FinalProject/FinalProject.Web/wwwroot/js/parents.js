$(function () {
    $('#parents').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": "/Admin/Parents/GetParents",
    });

    $('#parents_filter').addClass("text-right");
});