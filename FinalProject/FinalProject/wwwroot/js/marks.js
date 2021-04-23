$(document).ready(function () {

    function generateTable(url) {
        return $.ajax({
                method: "GET",
                url: url,
                dataType: "json"
            });
    };
    
    function getStudents(url) {
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
        let studentsUrl = "Marks/GetStudentsAndExamRules?academicYearId=" + $("#AcademicYearId").val()
            + "&courseId=" + $("#CourseId").val() + "&sectionId=" + $("#SectionId").val()
            + "&examId=" + $("#ExamId").val();

        var studentList;

        let myTable = document.querySelector('#markTable');

            getStudents(studentsUrl).done(function(response) {
                studentList = response;
                console.log(studentList);
                let markDistributionHeader = response.examRule.exam.marksDistributionTypes.split(',');
                let totalMark = response.examRule.totalExamMarks;
                let passMark = response.examRule.passMarks;

                let headers = ['#','Student Name', 'Role No'];
                headers = headers.concat(markDistributionHeader);
                headers = headers.concat(['Total Mark', 'Pass Mark', 'Absent', 'Action']);

                let table = document.createElement('table');
                table.setAttribute('class', 'table text-center table-hover table-bordered table-striped');
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
                    if (index == 0) {
                        head.setAttribute('style', 'width: 10px;');
                    }

                    head.appendChild(textNode);
                    headerRow.appendChild(head);
                });
                tableHeader.appendChild(headerRow);
                let noOfColumn = (7 + markDistributionHeader.length);
                let noOfRows = response.registeredStudents.length;
                console.log(noOfRows + " " + noOfColumn + ' ' + markDistributionHeader.length);
                for (var i = 0; i < noOfRows; i++) {
                    var studentName = response.registeredStudents[i].student.firstName
                        + " " + response.registeredStudents[i].student.middleName + " " + response.registeredStudents[i].student.lastName;
                    var studentRole = response.registeredStudents[i].rollNo;
                    let row = document.createElement('tr');

                    for (var j = 0; j < noOfColumn; j++) {
                        let tableData = document.createElement('td');
                        if (j === 0) {
                            let textNode = document.createTextNode(i + 1);
                            tableData.appendChild(textNode);
                        } else if(j === 1) {
                            let textNode = document.createTextNode(studentName);
                            tableData.setAttribute('style', 'width: 300px;');
                            tableData.appendChild(textNode);
                        } else if (j === 2) {
                            let textNode = document.createTextNode(studentRole);
                            tableData.setAttribute('style', 'width: 10px;');
                            tableData.appendChild(textNode);
                        } else if(j === noOfColumn - 1) {
                            let button = document.createElement('button');
                            button.setAttribute('class', 'btn btn-warning');
                            tableData.appendChild(button);
                        } else if (j === noOfColumn - 2) {
                            let input = document.createElement('input');
                            input.setAttribute('type', 'checkbox');
                            tableData.appendChild(input);
                        } else if (j === noOfColumn - 3) {
                            let input = document.createElement('input');
                            input.setAttribute('readonly', 'readonly');
                            input.setAttribute('type', 'text');
                            input.setAttribute('class', 'form-control');
                            tableData.appendChild(input);
                        }else if (j === noOfColumn - 4) {
                            let input = document.createElement('input');
                            input.setAttribute('readonly', 'readonly');
                            input.setAttribute('type', 'text');
                            input.setAttribute('class', 'form-control');
                            tableData.appendChild(input);
                        } else {
                            let input = document.createElement('input');
                            input.setAttribute('type', 'text');
                            input.setAttribute('class', 'form-control');
                            tableData.appendChild(input);
                        }
                        row.appendChild(tableData);
                        console.log(i + ' ' + j);
                    }
                    tableBody.appendChild(row);
                }
                table.appendChild(tableHeader);
                table.appendChild(tableBody);
                myTable.appendChild(table);
            });
        //generateTable("Marks/GenerateTableByExamId?examId=" + $('#ExamId').val()).done(function(response) {
            
        //});
       

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