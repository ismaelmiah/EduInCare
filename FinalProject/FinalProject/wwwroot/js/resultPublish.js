$(document).ready(function () {
    $('#results_wrapper').remove();
    $.ajax({
        method: "GET",
        url: "GetAcademicYears"
    }).done(function (data) {
        var s = "";
        for (var i = 0; i < data.length; i++) {
            s += '<option value="' + data[i].value + '">' + data[i].text + '</option>';
        }
        $("#AcademicYearId").html(s);
        populateCourse(data[0].value);
    }).fail(function (xhr, ajaxOptions, thrownError) {
        console.log(xhr.status);
        console.log(thrownError);
    });

    $("#deleteResult").on("click",
        function () {
            const examId = $('#ExamId').val();
            const sectionId = $('#SectionId').val();
            const academicYearId = $('#AcademicYearId').val();
            const courseId = $("#CourseId").val();

            const Url = "DeleteResult?academicYearId=" +
                academicYearId +
                "&courseId=" +
                courseId +
                "&sectionId=" +
                sectionId +
                "&examId=" +
                examId;
            $.ajax({
                method: "GET",
                url: Url
            }).done(function (data) {
                if (data) {
                    $('#results_wrapper').remove();
                    alertify.set('notifier', 'position', 'top-right');
                    alertify.success('Result Deleted Success');
                }
                else {
                    alertify.set('notifier', 'position', 'top-right');
                    alertify.error('Result Deleted Problem');
                }
            }).fail(function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status);
                console.log(thrownError);
            });
        });

    $('#getResult').on("click", function () {
        const examId = $('#ExamId').val();
        const sectionId = $('#SectionId').val();
        const academicYearId = $('#AcademicYearId').val();
        const courseId = $("#CourseId").val();

        const Url = "GetResults?academicYearId=" +
            academicYearId +
            "&courseId=" +
            courseId +
            "&sectionId=" +
            sectionId +
            "&examId=" +
            examId;


        $('#results').DataTable({
            "processing": true,
            "serverSide": true,
            "language": {
                "searchPlaceholder": "Student Name"
            },
            "ajax": Url,
            "initComplete": function (settings, json) {
                $('#results').show();
                $('[data-toggle="tooltip"]').tooltip();
            },
            "columnDefs": [
                {
                    "orderable": false,
                    "targets": 5,
                    "render": function (data, type, row) {
                        return `
                                    <button data-toggle="tooltip" data-placement="top" title="Marksheet" class="btn btn-info btn-sm" onclick="window.location.href='/admin/course/profile/${data}'" value='${data}'>
                                                                            <i class="fas fa-file-pdf"></i>
                                                                        </button>
                                    <button class="btn btn-info btn-sm" data-toggle="tooltip" data-placement="top" title="Public Marksheet" onclick="window.location.href='/admin/course/profile/${data}'" value='${data}'>
                                        <i class="far fa-file-alt"></i>
                                    </button>`;
                    }
                }
            ]
        });

        $('#results_filter').addClass("text-right");

        //$('#marks').on('click', '.show-bs-modal', function (event) {
        //    var id = $(this).data("id");
        //    var modal = $("#modal-default");
        //    modal.find('.modal-body p').text('Are you sure you want to delete this record?');
        //    $("#deleteId").val(id);
        //    $("#deleteForm").attr("action", "/admin/exam/delete");
        //    modal.modal('show');
        //});

        //$("#deleteButton").click(function () {
        //    $("#deleteForm").submit();
        //});
    });


    $("#AcademicYearId").change(function () {
        populateCourse(this.value);
        currentAmount = 0;
        $('#markentry').remove();
    });

    $("#CourseId").change(function () {
        populateSection(this.value);
        currentAmount = 0;
        $('#markentry').remove();
    });

    $("#SectionId").change(function () {
        currentAmount = 0;
        $('#markentry').remove();
    });

    $("#SubjectId").change(function () {
        currentAmount = 0;
        $('#markentry').remove();
    });

    $('#ExamId').on('change', function () {
        currentAmount = 0;
        $('#markentry').remove();
    });
});

function populateSection(courseId) {
    $.ajax({
        method: "GET",
        url: "GetSectionsByCourse?courseId=" + courseId
    }).done(function (data) {
        var s = "";
        for (var i = 0; i < data.length; i++) {
            s += '<option value="' + data[i].value + '">' + data[i].text + '</option>';
        }
        $("#SectionId").html(s);
        populateExams(courseId);
    }).fail(function (xhr, ajaxOptions, thrownError) {
        console.log(xhr.status);
        console.log(thrownError);
    });
}

function populateCourse(yearId) {
    $.ajax({
        method: "GET",
        url: "GetCoursesByYear?yearId=" + yearId
    }).done(function (data) {
        var s = "";
        for (var i = 0; i < data.length; i++) {
            s += '<option value="' + data[i].value + '">' + data[i].text + '</option>';
        }
        $("#CourseId").html(s);
        populateSection(data[0].value);
    }).fail(function (xhr, ajaxOptions, thrownError) {
        console.log(xhr.status);
        console.log(thrownError);
    });
}

function populateExams(courseId) {
    $.ajax({
        method: "GET",
        url: "GetExams?courseId=" + courseId,
        dataType: "json",
        success: function (data) {
            var s = "";
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].value + '">' + data[i].text + '</option>';
            }
            $("#ExamId").html(s);
        }
    }).done(function (data) {
        var s = "";
        for (var i = 0; i < data.length; i++) {
            s += '<option value="' + data[i].value + '">' + data[i].text + '</option>';
        }
        $("#ExamId").html(s);
    }).fail(function (xhr, ajaxOptions, thrownError) {
        console.log(xhr.status);
        console.log(thrownError);
    });
}