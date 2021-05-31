$(document).ready(function () {
    $("#CourseId").select2();

    $("#addExamRule").on('click', function () {
        var modal = $("#modal-examrules");
        modal.modal('show');
        $.ajax({
            method: "GET",
            url: "ExamRules/Upsert"
        }).done(function (response) {
            $("#contentArea").html(response);
            $("#modal-examrules").modal('toggle');
            LoadFormData();
        }).fail(function (xhr, ajaxOptions, thrownError) {
            //console.log(xhr.status);
            //console.log(thrownError);
            alertify.set('notifier', 'position', 'top-right');
            alertify.error('Marks not entered! Please enter mark for this exam!');
        });
    });

    loadDataTable($("#CourseId").val());

    $("#CourseId").change(function () {
        loadDataTable(this.value);
        console.log(this.value);
    });

    $('#examrules_filter').addClass("text-right");

    $('#examrules').on('click', '.examruleedit', function (event) {
        var id = $(this).data("id");
        var modal = $("#modal-examrules");
        modal.modal('show');
        $.ajax({
            method: "GET",
            url: "ExamRules/Upsert?id=" + id
        }).done(function (response) {
            $("#contentArea").html(response);
            $("#modal-examrules").modal('toggle');
            LoadFormData();
        }).fail(function (xhr, ajaxOptions, thrownError) {
            //console.log(xhr.status);
            //console.log(thrownError);
            alertify.set('notifier', 'position', 'top-right');
            alertify.error('Marks not entered! Please enter mark for this exam!');
        });
    });

    $("#deleteButton").click(function () {
        $("#deleteForm").submit();
    });

});
function loadDataTable(courseId) {
    $('#examrules').DataTable({
        "processing": true,
        "serverSide": true,
        "destroy": true,
        "searching": false,
        "autoWidth": true,
        "ajax": "/Admin/examrules/GetExamRules?courseId=" + courseId,
        "columnDefs": [
            {
                "orderable": false,
                "targets": 2,
                "width": '30%',
                "render": function (data, type, row) {
                    var table = '<div class="text-center">' +
                        '<table class="table text-center table-hover table-bordered table-striped" id="rulesTable">' +
                        '<thead class="thead-dark">' +
                        '<tr>' +
                        '<th>Type</th>' +
                        '<th>Total Marks</th>' +
                        '<th>Passing Marks</th>' +
                        '</tr>' +
                        '</thead>' +
                        '<tbody>';
                    var serializedData = JSON.parse(data);
                    serializedData.forEach((item) => {
                        var rows =
                            `<tr> <td>${item.DistributionType}</td><td>${item.TotalMarks}</td><td>${item.PassMarks
                            }</td></tr>`;
                        table += rows;
                    });
                    table += '</tbody></table>';
                    return table;
                }
            },
            {
                "orderable": false,
                "targets": 5,
                "width": '15%',
                "render": function (data, type, row) {
                    return `
                                    <button type="button" class="btn btn-warning examruleedit btn-sm" data-id='${data}' value='${data}'>
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

var LoadFormData = function () {

    $.ajax({
        method: "GET",
        url: "ExamRules/GetSubjects?courseId=" + $("#CourseId").val(),
        dataType: "json",
        success: function (data) {
            var s = "";
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].value + '">' + data[i].text + '</option>';
            }
            $("#SubjectId").html(s);
            populateExams($("#CourseId").val());
        }
    });

    $("#CourseId").select2();
    $("#SubjectId").select2();
    $("#ExamId").select2();
    $("#GradeId").select2();


    $("#CourseId").change(function () {
        populateSubjects(this.value);
    });

    $("#examRuleSubmit").click(function () {
        $("#examRuleForm").submit();
    });
    

    $("#ExamId").change(function () {
        populateTable(this.value);
    });

    $("#GradeId").change(function () {
        var mark = this.options[this.selectedIndex].text.split(' ')[0];
        populateMarks(mark);
    });

    function populateMarks(mark) {
        if (mark > 50) {
            $('#TotalExamMarks').val(mark);
            $('#PassMarks').val(parseInt(mark / 3));
        } else {
            $('#TotalExamMarks').val(mark);
            $('#PassMarks').val(parseInt(mark / 3) + 1);
        }
    }

    function populateExams(courseId) {
        $.ajax({
            method: "GET",
            url: "ExamRules/GetExams?courseId=" + courseId,
            dataType: "json",
            success: function (data) {
                var s = "";
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].value + '">' + data[i].text + '</option>';
                }
                $("#ExamId").html(s);
                populateMarks($("#GradeId option:selected").text().split(' ')[0]);
                populateTable(data[0].value);
            }
        });
    }

    function populateSubjects(courseId) {
        $.ajax({
            method: "GET",
            url: "ExamRules/GetSubjects?courseId=" + courseId,
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

    function populateTable(examId) {
        $.ajax({
            method: "GET",
            url: "ExamRules/GetMarkDistributions?examId=" + examId,
            dataType: "json",
            success: function (data) {
                const marksDistribution = data.marksDistributionTypes.split(',');
                var s = "";
                marksDistribution.forEach((item, index) => {
                    var row = `<tr>
                                                            <td class="w-25">
                                                                <input type="hidden" id="DistributionModels_${index}__DistributionType" name="DistributionModels[${index}].DistributionType" value="${item}" />
                                                                <label>${item}</label>
                                                            </td>
                                                            <td class="w-25">
                                                                <input class="form-control" id="DistributionModels_[${index}]_TotalMarks" type="number" name="DistributionModels[${index}].TotalMarks" />
                                                            </td>
                                                            <td class="w-25">
                                                                <input class="form-control" id="DistributionModels_${index}__PassMarks" type="number" name="DistributionModels[${index}].PassMarks" />
                                                            </td>
                                                        </tr>`;
                    s += row;
                });
                $("#marksdistributionbody").html(s);
            }
        });
    };
}