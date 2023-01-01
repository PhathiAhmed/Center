!function ($) {
    "use strict";

    document.querySelector('.timer-alert').onclick = function () {
        swal({
            title: "Auto close alert!",
            text: "I will close in 3 seconds.",
            timer: 3000,
            showConfirmButton: false
        });
    };
    document.querySelector('.success-alert').onclick = function () {
        swal("Good job!", "You clicked the button!", "success");
    };
    document.querySelector('.simple-alert').onclick = function () {
        swal({
            title: "Welcome in Alerts",
            text: "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
        });
    };
    document.querySelector('.warning-alert').onclick = function () {
        swal({
            title: "Are you sure?",
            text: "You will not be able to recover this imaginary file!",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: '#DD6B55',
            confirmButtonText: 'Yes, delete it!',
            closeOnConfirm: false
        },
                function () {
                    swal("Deleted!", "Your imaginary file has been deleted!", "success");
                });
    };
}(window.jQuery);