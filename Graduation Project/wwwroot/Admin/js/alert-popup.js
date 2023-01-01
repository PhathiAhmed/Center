!function ($) {
    "use strict";
    document.querySelector('.showcase.sweet button').onclick = function () {
        swal("Oops...", "Something went wrong!", "error");
    };

    document.querySelector('button.message').onclick = function () {
        swal("Here's a message!");
    };

    document.querySelector('button.timer').onclick = function () {
        swal({
            title: "Auto close alert!",
            text: "I will close in 2 seconds.",
            timer: 2000,
            showConfirmButton: false
        });
    };
    document.querySelector('button.title-text ').onclick = function () {
        swal("Here's a message!", "It's pretty, isn't it?");
    };

    document.querySelector('button.success ').onclick = function () {
        swal("Good job!", "You clicked the button!", "success");
    };

    document.querySelector('button.warning.confirm').onclick = function () {
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

    document.querySelector('button.warning.cancel').onclick = function () {
        swal({
            title: "Are you sure?",
            text: "You will not be able to recover this imaginary file!",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: '#DD6B55',
            confirmButtonText: 'Yes, delete it!',
            cancelButtonText: "No, cancel plx!",
            closeOnConfirm: false,
            closeOnCancel: false
        },
                function (isConfirm) {
                    if (isConfirm) {
                        swal("Deleted!", "Your imaginary file has been deleted!", "success");
                    } else {
                        swal("Cancelled", "Your imaginary file is safe :)", "error");
                    }
                });
    };

    document.querySelector('button.custom-icon ').onclick = function () {
        swal({
            title: "Sweet!",
            text: "Here's a custom image.",
            imageUrl: 'images/thumbs-up.jpg'
        });
    };

    document.querySelector('button.message-html ').onclick = function () {
        swal({
            title: "HTML <small>Title</small>!",
            text: 'A custom <span style="color:#F8BB86">html<span> message.',
            html: true
        });
    };

    document.querySelector('button.input').onclick = function () {
        swal({
            title: "An input!",
            text: 'Write something interesting:',
            type: 'input',
            showCancelButton: true,
            closeOnConfirm: false,
            animation: "slide-from-top",
            inputPlaceholder: "Write something",
        },
                function (inputValue) {
                    if (inputValue === false)
                        return false;

                    if (inputValue === "") {
                        swal.showInputError("You need to write something!");
                        return false;
                    }

                    swal("Nice!", 'You wrote: ' + inputValue, "success");

                });
    };

    document.querySelector('button.theme').onclick = function () {
        swal({
            title: "Themes!",
            text: "Here's the Twitter theme for SweetAlert!",
            confirmButtonText: "Cool!",
            customClass: 'twitter'
        });
    };

    document.querySelector('button.ajax ').onclick = function () {
        swal({
            title: 'Ajax request example',
            text: 'Submit to run ajax request',
            type: 'info',
            showCancelButton: true,
            closeOnConfirm: false,
            showLoaderOnConfirm: true,
        }, function () {
            setTimeout(function () {
                swal('Ajax request finished!');
            }, 2000);
        });
    };


}(window.jQuery);
