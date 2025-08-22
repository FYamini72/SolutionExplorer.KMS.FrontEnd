document.addEventListener('keydown', function (e) {
    if (e.key === 'F12' || (e.ctrlKey && e.shiftKey && (e.key === 'I' || e.key === 'J'))) {
        e.preventDefault();
    }
});

document.addEventListener('contextmenu', function (e) {
    e.preventDefault();
});

function confirmDelete(message) {
    return Swal.fire({
        title: message,
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'بله',
        cancelButtonText: 'خیر'
    }).then((result) => {
        return result.isConfirmed; // برگرداندن نتیجه تأیید  
    });
}

function showToast(icon, title) {
    const Toast = Swal.mixin({
        toast: true,
        position: "top-start",
        showConfirmButton: false,
        timer: 4000,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.onmouseenter = Swal.stopTimer;
            toast.onmouseleave = Swal.resumeTimer;
        }
    });
    Toast.fire({
        icon: icon,
        title: title
    });
}

function showSpinner() {
    debugger;
    if ($('#defaultSpinner').hasClass('hide')) {
        $('#defaultSpinner').removeClass('hide');
    }
}

function showSpinner(id) {
    if ($('#' + id).hasClass('hide')) {
        $('#' + id).removeClass('hide');
    }
}

function hideSpinner() {
    debugger;
    if (!$('#defaultSpinner').hasClass('hide')) {
        $('#defaultSpinner').addClass('hide');
    }
}

function hideSpinner(id) {
    if (!$('#' + id).hasClass('hide')) {
        $('#' + id).addClass('hide');
    }
}