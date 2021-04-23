$(document).ready(function () {

    function generateTable(url) {
        return $.ajax({
                method: "GET",
                url: url,
                dataType: "json"
            });
    };

    $('#getMarks').on("click", function () {
        
    });

    $('#updateMarks').on("click", function () {
        
    });

    $('#btnAdd').on("click", function () {
        let url = "GetStudentsAndExamRules?academicyearId=" + $("#AcademicYearId").val()
            + "&courseId=" + $("#CourseId").val() + "&sectionId=" + $("#SectionId").val()
            + "&examId=" + $("#ExamId").val();

        let myTable = document.querySelector('#markTable');
        generateTable("Marks/GenerateTableByExamId?examId=" + $('#ExamId').val()).done(function(response) {
            let headers = response.marksDistributionTypes.split(',');

            let table = document.createElement('table');
            let headerRow = document.createElement('tr');

            headers.forEach(header => {
                let head = document.createElement('th');
                let textNode = document.createTextNode(header);

                head.appendChild(textNode);
                headerRow.appendChild(head);
            });

            table.appendChild(headerRow);
            myTable.appendChild(table);
        });
       

        //loadDataTable(url);
    });

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

function loadDataTable(url) {
    dataTable = $('#exams').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": url,
        "columnDefs": [
        ]
    });
}