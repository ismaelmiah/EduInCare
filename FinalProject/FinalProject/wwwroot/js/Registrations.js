$(document).ready(function () {
    $("#registerStudent").on('click', function () {
        var modal = $("#modal-registration");
        modal.modal('show');
        $.ajax({
            method: "GET",
            url: "Registration/Upsert"
        }).done(function (response) {
            $("#contentArea").html(response);
            $("#modal-registration").modal('toggle');
            LoadFormData();
        }).fail(function (xhr, ajaxOptions, thrownError) {
            //console.log(xhr.status);
            //console.log(thrownError);
            alertify.set('notifier', 'position', 'top-right');
            alertify.error('Marks not entered! Please enter mark for this exam!');
        });
    });


    $('#Registrations').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": "/course/Registration/GetRegisteredData",
        "columnDefs": [
            {
                "orderable": false,
                "targets": 7,
                "render": function (data, type, row) {
                    return `
                                    <button class="btn btn-info btn-sm" onclick="window.location.href='/course/Registration/profile/${data}'" value='${data}'>
                                                                            <i class="fas fa-info">
                                                                            </i>
                                                                            Details
                                                                        </button>
                                    <button type="submit" class="btn btn-warning btn-sm" onclick="window.location.href='/course/Registration/upsert/${data}'" value='${data}'>
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

    $('#Registrations_filter').addClass("text-right");

    $('#Registrations').on('click', '.show-bs-modal', function (event) {
        var id = $(this).data("id");
        var modal = $("#modal-default");
        modal.find('.modal-body p').text('Are you sure you want to delete this record?');
        $("#deleteId").val(id);
        $("#deleteForm").attr("action", "/course/Registration/delete");
        modal.modal('show');
    });

    $("#deleteButton").click(function () {
        $("#deleteForm").submit();
    });
});


var LoadFormData = function () {

    $.ajax({
        method: "GET",
        url: "Registration/GetAcademicYears",
        dataType: "json",
        success: function (data) {
            var s = "";
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].value + '">' + data[i].text + '</option>';
            }
            $("#AcademicYearId").html(s);
            populateCourse(data[0].value);
        }
    });

    $("#AcademicYearId").select2({
        width: 'resolve'
    });
    $("#CourseId").select2({
        width: 'resolve'
    });
    $("#SectionId").select2({
        width: 'resolve'
    });
    $("#StudentId").select2({
        width: 'resolve'
    });

    $("#AcademicYearId").change(function () {
        populateCourse(this.value);
    });

    $("#CourseId").change(function () {
        populateSection(this.value);
    });

    function populateCourse(yearId) {
        $.ajax({
            method: "GET",
            url: "Registration/GetCoursesByYear?yearId=" + yearId,
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

    function populateSection(courseId) {
        $.ajax({
            method: "GET",
            url: "Registration/GetSectionsByCourse?courseId=" + courseId
        }).done(function (data) {
            var s = "";
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].value + '">' + data[i].text + '</option>';
            }
            $("#SectionId").html(s);
            populateStudent(courseId);
        }).fail(function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status);
            console.log(thrownError);
        });
    }
    function populateStudent(courseId) {
        $.ajax({
            method: "GET",
            url: "Registration/GetStudents?courseId=" + courseId,
            dataType: "json",
            success: function (data) {
                var s = "";
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].value + '">' + data[i].text + '</option>';
                }
                $("#StudentId").html(s);
            }
        });
    };
};