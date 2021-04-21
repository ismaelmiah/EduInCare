$(document).ready(function () {

    //loadDataTable();
    populateCourse($("#AcademicYearId").val());
    //populateSection($("#CourseId").val());
    //loadDataTable($("#CourseId").val());

    $("#AcademicYearId").change(function () {
        populateCourse(this.value);
    });

    $("#CourseId").change(function () {
        populateSection(this.value);
    });

    $('#exams_filter').addClass("text-right");

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

function populateSection(courseId) {
    $.ajax({
        method: "GET",
        url: "Marks/GetSectionsByCourse?courseId=" + courseId,
        dataType: "json",
        success: function (data) {
            var s = "";
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].value + '">' + data[i].text + '</option>';
            }
            $("#SectionId").html(s);
            populateSubjects(courseId);
        }
    });
}

function populateCourse(yearId) {
    $.ajax({
        method: "GET",
        url: "Marks/GetCoursesByYear?yearId=" + yearId,
        dataType: "json",
        success: function (data) {
            var s = "";
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].value + '">' + data[i].text + '</option>';
            }
            $("#CourseId").html(s);
            populateSection(data[0].value);
        }
    });
}

function populateSubjects(courseId) {
    $.ajax({
        method: "GET",
        url: "Marks/GetSubjects?courseId=" + courseId,
        dataType: "json",
        success: function (data) {
            var s = "";
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].value + '">' + data[i].text + '</option>';
            }
            $("#SubjectId").html(s);
            populateExams(courseId);
        }
    });
}

function populateExams(courseId) {
    $.ajax({
        method: "GET",
        url: "Marks/GetExams?courseId=" + courseId,
        dataType: "json",
        success: function (data) {
            var s = "";
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].value + '">' + data[i].text + '</option>';
            }
            $("#ExamId").html(s);
        }
    });
}
var dataTable;

function loadDataTable() {
    dataTable = $('#exams').DataTable({
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
                                    <button type="submit" class="btn btn-warning btn-sm" onclick="window.location.href='/admin/exam/upsert/${data}'" value='${data}'>
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
}