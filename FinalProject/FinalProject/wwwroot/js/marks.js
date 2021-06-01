$(document).ready(function () {

    $('#publish').on("click", function () {
        const examId = $('#ExamId').val();
        const sectionId = $('#SectionId').val();
        const academicYearId = $('#AcademicYearId').val();
        const subjectId = $('#SubjectId').val();
        const courseId = $("#CourseId").val();


        const studentsUrl = "Marks/PublishResult?academicYearId=" +
            academicYearId +
            "&courseId=" +
            courseId +
            "&subjectId=" +
            subjectId +
            "&sectionId=" +
            sectionId +
            "&examId=" +
            examId;

        $.ajax({
            method: "GET",
            url: studentsUrl
        }).done(function (response) {
            alertify.set('notifier', 'position', 'top-right');
            if (response) {
                alertify.success('Result Published');
            } else {
                alertify.success('Result Published, Please Entered Mark for All Students');
            }
        }).fail(function (xhr, ajaxOptions, thrownError) {
            //console.log(xhr.status);
            //console.log(thrownError);
            alertify.error('Result Published, Please Entered Mark for All Students');
        });
    });

    $('#getMarks').on("click", function () {
        const examId = $('#ExamId').val();
        const sectionId = $('#SectionId').val();
        const academicYearId = $('#AcademicYearId').val();
        const subjectId = $('#SubjectId').val();
        const courseId = $("#CourseId").val();


        const studentsUrl = "Marks/GetStudentsMarks?academicYearId=" +
            academicYearId +
            "&courseId=" +
            courseId +
            "&subjectId=" +
            subjectId +
            "&sectionId=" +
            sectionId +
            "&examId=" +
            examId;

        $.ajax({
            method: "GET",
            url: studentsUrl
        }).done(function (response) {
            if (response.length > 1) {
                $("#markTable").html(response);
                $('#marks').DataTable({
                    "lengthChange": false,
                    "searching": false
                });
                $('#marks_filter').addClass("text-right");
            }
            else if (response.length === 0) {
                alertify.set('notifier', 'position', 'top-right');
                alertify.error('Marks not entered! Please enter mark for this exam!');
            } else {
                alertify.set('notifier', 'position', 'top-right');
                alertify.error('Result Already Published!');
            }
        }).fail(function (xhr, ajaxOptions, thrownError) {
            //console.log(xhr.status);
            //console.log(thrownError);
            alertify.set('notifier', 'position', 'top-right');
            alertify.error('Marks not entered! Please enter mark for this exam!');
        });;
    });

    $('#updateMarks').on("click", function () {

        const examId = $('#ExamId').val();
        const sectionId = $('#SectionId').val();
        const academicYearId = $('#AcademicYearId').val();
        const subjectId = $('#SubjectId').val();
        const courseId = $("#CourseId").val();


        let studentsUrl = "Marks/MarksEntry?academicYearId=" +
            academicYearId +
            "&courseId=" +
            courseId +
            "&subjectId=" +
            subjectId +
            "&sectionId=" +
            sectionId +
            "&examId=" +
            examId +
            "&isMarkSet=" +
            true;

        $.ajax({
            method: "GET",
            url: studentsUrl
        }).done(function (response) {
            if (response.length > 1) {
                $("#markTable").html(response);
                $('#marks').DataTable({
                    "lengthChange": false,
                    "searching": false
                });
                $('#marks_filter').addClass("text-right");
            }
            else if (response.length === 0) {
                alertify.set('notifier', 'position', 'top-right');
                alertify.error('Marks not entered! Please enter mark for this exam!');
            }else {
                alertify.set('notifier', 'position', 'top-right');
                alertify.error('Result Already Published!');
            }
        }).fail(function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status);
            console.log(thrownError);
        });
    });

    $(document).on("click", '#update', function () {

        const examId = $('#ExamId').val();
        const sectionId = $('#SectionId').val();
        const academicYearId = $('#AcademicYearId').val();
        const subjectId = $('#SubjectId').val();

        const studentId = $(this).data("studentid");
        const record = $(this).data("row");
        const markArray = Array.from(document.getElementsByClassName(`Marks[${record}]`));
        var totalMarksArray = Array.from(document.getElementsByClassName(`TotalMarks[${record}]`));
        var passMarkArray = Array.from(document.getElementsByClassName(`PassMarks[${record}]`));

        let studentMarks = [];
        markArray.forEach((item, index) => {
            var num = parseInt(item.value) || 0;
            var type = $(item).data('name');
            var total = totalMarksArray[index].value;
            var pass = passMarkArray[index].value;
            studentMarks.push({
                Mark: num,
                Type: type.toString(),
                TotalMark: total,
                PassMark: pass
            });
        });
        const present = $(`#z${record}__Present:checked`).val();

        studentResultUpdate(
            {
                Present: present,
                StudentId: studentId,
                ExamId: examId,
                StudentMark: studentMarks
            }
        );
    });

    $(document).on("click", '#result', function () {

        const examId = $('#ExamId').val();
        const sectionId = $('#SectionId').val();
        const academicYearId = $('#AcademicYearId').val();
        const subjectId = $('#SubjectId').val();

        const studentId = $(this).data("studentid");
        const record = $(this).data("row");
        const markArray = Array.from(document.getElementsByClassName(`Marks[${record}]`));
        var totalMarksArray = Array.from(document.getElementsByClassName(`TotalMarks[${record}]`));
        var passMarkArray = Array.from(document.getElementsByClassName(`PassMarks[${record}]`));

        let studentMarks = [];
        markArray.forEach((item, index) => {
            var num = parseInt(item.value) || 0;
            var type = $(item).data('name');
            var total = totalMarksArray[index].value;
            var pass = passMarkArray[index].value;
            studentMarks.push({
                Mark: num,
                Type: type.toString(),
                TotalMark: total,
                PassMark: pass
            });
        });
        const present = $(`#z${record}__Present:checked`).val();

        studentResultSave(
            {
                Present: present,
                StudentId: studentId,
                ExamId: examId,
                StudentMark: studentMarks
            }
        );
    });

    $(document).on('change', "input[type='number']", function () {
        var marks = Array.from(document.getElementsByClassName(`Marks[${$(this).data('id')}]`));
        let totalMark = 0;
        marks.forEach((item, idx) => {
            totalMark += parseInt(item.value) || 0;;
        });
        var totalMarkField = document.getElementById(`TotalMarks[${$(this).data('id')}]`);
        totalMarkField.value = totalMark;
    });


    $('#entryMarks').on("click", function () {
        const examId = $('#ExamId').val();
        const sectionId = $('#SectionId').val();
        const academicYearId = $('#AcademicYearId').val();
        const subjectId = $('#SubjectId').val();
        const courseId = $("#CourseId").val();


        let studentsUrl = "Marks/MarksEntry?academicYearId=" +
            academicYearId +
            "&courseId=" +
            courseId +
            "&subjectId=" +
            subjectId +
            "&sectionId=" +
            sectionId +
            "&examId=" +
            examId;

        $.ajax({
            method: "GET",
            url: studentsUrl
        }).done(function (response) {
            if (response.length > 1) {
                $("#markTable").html(response);
                $('#marks').DataTable({
                    "lengthChange": false,
                    "searching": false
                });
                $('#marks_filter').addClass("text-right");
            }
            else if (response.length === 0) {
                alertify.set('notifier', 'position', 'top-right');
                alertify.error('Marks not entered! Please enter mark for this exam!');
            } else {
                alertify.set('notifier', 'position', 'top-right');
                alertify.error('Result Already Published or No Student Left of Marks Enter!');
            }
        }).fail(function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status);
            console.log(thrownError);
        });
    });


    function studentResultSave(data) {
        $.ajax({
            method: "POST",
            url: "Marks/AjaxMarkSave",
            data: data,
            success: function (response) {
                alertify.set('notifier', 'position', 'top-right');
                console.log(this);
                if (response.success) {
                    alertify.success('Mark Saved');
                } else {
                    alertify.error('Mark Not Saved');
                }
            }
        });
    }

    function studentResultUpdate(data) {
        $.ajax({
            method: "POST",
            url: "Marks/AjaxMarkSave",
            data: data,
            success: function (response) {
                alertify.set('notifier', 'position', 'top-right');
                console.log(this);
                if (response.success) {
                    alertify.warning('Mark Updated');
                } else {
                    alertify.error('Mark Not Update');
                }
            }
        });
    }

    populateCourse($("#AcademicYearId").val());

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