$(document).ready(function () {

    var limit = 1;
    var currentAmount = 0;
    var numberOfRows;


    function getStudents(url) {
        $.ajax({
            method: "GET",
            url: url,
            dataType: "json",
            cache: true,
            success: function (data) {
                generateTable(data);
            }
        });
    };

    function markDistributions(data) {
        var list = [];
        var maxValue = [];
        data.forEach((item, idx) => {
            let cnt = 0;
            for (var key in item) {
                if (item.hasOwnProperty(key) && 0 === cnt) list.push(item[key]);
                if (item.hasOwnProperty(key) && cnt === 1) maxValue.push(item[key]);
                cnt++;
                if (cnt > 1) break;
            }
        });
        return { list, maxValue };
    }

    function generateTable(response) {
        console.log(response);
        let parseJsonData = JSON.parse(response.examRule.marksDistribution);
        var distributionsData = markDistributions(parseJsonData);
        let markDistributionHeader = distributionsData.list;
        console.log(markDistributionHeader);
        let totalMark = response.examRule.totalExamMarks;
        let passMark = response.examRule.passMarks;

        let headers = ['#', 'Student Name', 'Role No'];
        headers = headers.concat(markDistributionHeader);
        headers = headers.concat(['Total Mark', 'Pass Mark', 'Absent', 'Action']);

        let myTable = document.querySelector('#markTable');
        let table = document.createElement('table');
        table.setAttribute('class', 'table text-center table-hover table-bordered table-striped');
        table.setAttribute('id', 'generatedTable');

        let tableHeader = document.createElement('thead');
        tableHeader.setAttribute('class', 'thead-dark');

        let tableBody = document.createElement('tbody');

        let headerRow = document.createElement('tr');

        headers.forEach((header, index) => {
            let head = document.createElement('th');

            let textNode = document.createTextNode(header);

            if (index > 1) {
                head.setAttribute('style', 'width: 100px;');
            }
            if (index === 0) {
                head.setAttribute('style', 'width: 10px;');
            }

            head.appendChild(textNode);
            headerRow.appendChild(head);
        });
        tableHeader.appendChild(headerRow);

        let noOfColumn = (7 + markDistributionHeader.length);
        numberOfRows = response.registeredStudents.length;


        let countDistributionType = 0;

        for (var i = 0; i < numberOfRows; i++) {
            var studentName = response.registeredStudents[i].student.firstName
                + " " + response.registeredStudents[i].student.middleName + " " + response.registeredStudents[i].student.lastName;
            var studentRole = response.registeredStudents[i].student.rollNo;
            var studentId = response.registeredStudents[i].studentId;
            var zero = 0;

            let row = document.createElement('tr');
            row.setAttribute('class', `row_no`);
            for (var j = 0; j < noOfColumn; j++) {
                let tableData = document.createElement('td');
                if (j === 0) {
                    let textNode = document.createTextNode(i + 1);
                    tableData.appendChild(textNode);
                } else if (j === 1) {
                    let textNode = document.createTextNode(studentName);
                    tableData.setAttribute('style', 'width: 300px;');
                    let input = document.createElement('INPUT');
                    input.setAttribute('type', 'hidden');
                    input.setAttribute('class', 'form-control');
                    input.setAttribute('value', `${studentId}`);

                    tableData.appendChild(textNode);
                } else if (j === 2) {
                    let textNode = document.createTextNode(studentRole);
                    tableData.setAttribute('style', 'width: 10px;');
                    tableData.appendChild(textNode);
                } else if (j === noOfColumn - 1) {
                    let button = document.createElement('button');
                    button.setAttribute('class', 'btn btn-outline-success');
                    button.setAttribute('type', 'button');
                    button.setAttribute('id', 'resultSave');
                    button.setAttribute('data-id', i);
                    button.setAttribute('data-studentid', studentId);
                    button.innerHTML = 'Save';
                    tableData.appendChild(button);
                } else if (j === noOfColumn - 2) {
                    let input = document.createElement('INPUT');
                    input.setAttribute('type', 'checkbox');
                    input.setAttribute('class', `form-control`);
                    input.setAttribute('id', `present[${i}]`);
                    tableData.appendChild(input);
                } else if (j === noOfColumn - 3) {
                    let input = document.createElement('INPUT');
                    input.setAttribute('readonly', 'readonly');
                    input.setAttribute('type', 'text');
                    input.setAttribute('value', passMark);
                    input.setAttribute('class', 'form-control');
                    tableData.appendChild(input);
                } else if (j === noOfColumn - 4) {
                    let input = document.createElement('INPUT');
                    input.setAttribute('readonly', 'readonly');
                    input.setAttribute('value', `${zero}`);
                    input.setAttribute('type', 'text');
                    input.setAttribute('id', `TotalMarks[${i}]`);
                    input.setAttribute('class', `form-control`);
                    tableData.appendChild(input);
                } else {
                    let input = document.createElement('INPUT');
                    input.setAttribute('type', 'number');
                    input.setAttribute('data-id', `${i}`);
                    input.setAttribute('data-input', `${j}`);
                    input.setAttribute('value', `${zero}`);
                    input.setAttribute('data-name', `${distributionsData.list[countDistributionType]}`);
                    input.setAttribute('max', `${distributionsData.maxValue[i]}`);
                    input.setAttribute('min', `${zero}`);
                    input.setAttribute('class', `form-control StudentMarks[${i}]`);
                    tableData.appendChild(input);
                    countDistributionType++;
                }
                row.appendChild(tableData);
            }
            tableBody.appendChild(row);
        }
        table.appendChild(tableHeader);
        table.appendChild(tableBody);
        myTable.appendChild(table);
    }

    $('#getMarks').on("click",
        function () {

        });

    $('#updateMarks').on("click",
        function () {

        });

    $(document).on('click', '#resultSave', function () {

        //console.log($(this).data("id") + ' ' + $(this).data("studentid"));
        var studentId = $(this).data("studentid");
        var record = $(this).data("id");
        var markArray = Array.from(document.getElementsByClassName(`StudentMarks[${record}]`));

        let studentMarks = [];
        markArray.forEach(item => {
            var num = parseInt(item.value) || 0;
            var name = $(item).data('name');
            studentMarks.push({
                Mark: num,
                Name: name.toString()
            });
        });
        console.log(studentMarks);
        let present = document.getElementById(`present[${record}]`).checked;
        let examId = $('#ExamId').val();
        let sectionId = $('#SectionId').val();
        let academicYearId = $('#AcademicYearId').val();
        let subjectId = $('#SubjectId').val();

        studentResultSave(
            {
                Present: present,
                StudentId: studentId,
                ExamId: examId,
                SectionId: sectionId,
                AcademicYearId: academicYearId,
                SubjectId: subjectId,
                StudentMark: studentMarks
            }
        );
    });

    $(document).on('change', "input[type='number']", function () {
        var marks = Array.from(document.getElementsByClassName(`StudentMarks[${$(this).data('id')}]`));
        let totalMark = 0;
        marks.forEach((item, idx) => {
            totalMark += parseInt(item.value) || 0;;
        });
        var totalMarkField = document.getElementById(`TotalMarks[${$(this).data('id')}]`);
        totalMarkField.value = totalMark;
    });

    $('#ExamId').on('change', function () {
        currentAmount = 0;
        let generatedTable = $('#generatedTable');
        generatedTable.remove();
    });
    $('#btnAdd').on("click", function () {
        let studentsUrl = "Marks/GetStudentsAndExamRules?academicYearId=" + $("#AcademicYearId").val()
            + "&courseId=" + $("#CourseId").val() + "&sectionId=" + $("#SectionId").val()
            + "&examId=" + $("#ExamId").val();

        if (currentAmount < limit) {
            getStudents(studentsUrl);
            currentAmount++;
        }
    });


    function studentResultSave(data) {
        $.ajax({
            method: "POST",
            url: "Marks/AjaxMarkSave",
            data: data,
            success: function (response) {
                console.log(response);
            }
        });
    }

    //loadDataTable();
    populateCourse($("#AcademicYearId").val());
    //populateSection($("#CourseId").val());
    //loadDataTable($("#CourseId").val());

    $("#AcademicYearId").change(function () {
        populateCourse(this.value);
        currentAmount = 0;
        let generatedTable = $('#generatedTable');
        generatedTable.remove();
    });

    $("#CourseId").change(function () {
        populateSection(this.value);
        currentAmount = 0;
        let generatedTable = $('#generatedTable');
        generatedTable.remove();
    });

    $("#SectionId").change(function () {
        currentAmount = 0;
        let generatedTable = $('#generatedTable');
        generatedTable.remove();
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