function showerror(title, message) {
    toastr.error(message, title, {
        tapToDismiss: true,
        toastClass: 'toast',
        containerId: 'toast-container',
        debug: false,
        showMethod: 'fadeIn',
        showDuration: 100,
        showEasing: 'swing',
        hideMethod: 'fadeOut',
        hideDuration: 300,
        hideEasing: 'swing',
        closeMethod: false,
        closeDuration: false,
        closeEasing: false,
        extendedTimeOut: 300,
        iconClasses: {
            error: 'toast-error',
            info: 'toast-info',
            success: 'toast-success',
            warning: 'toast-warning',
            iconClass: 'toast-info',
            positionClass: 'toast-top-right',
            timeOut: 5000,
            titleClass: 'toast-title',
            messageClass: 'toast-message',
            escapeHtml: false,
            target: 'body',
            closeHtml: '<button type="button">&times;</button>',
            newestOnTop: true,
            preventDuplicates: true,
            progressBar: true
        }
    });
}
function showsuccess(title, message) {
    toastr.success(message, title, {
        tapToDismiss: true,
        toastClass: 'toast',
        containerId: 'toast-container',
        debug: false,
        showMethod: 'fadeIn',
        showDuration: 100,
        showEasing: 'swing',
        hideMethod: 'fadeOut',
        hideDuration: 300,
        hideEasing: 'swing',
        closeMethod: false,
        closeDuration: false,
        closeEasing: false,
        extendedTimeOut: 300,
        iconClasses: {
            error: 'toast-error',
            info: 'toast-info',
            success: 'toast-success',
            warning: 'toast-warning',
            iconClass: 'toast-info',
            positionClass: 'toast-top-right',
            timeOut: 5000,
            titleClass: 'toast-title',
            messageClass: 'toast-message',
            escapeHtml: false,
            target: 'body',
            closeHtml: '<button type="button">&times;</button>',
            newestOnTop: true,
            preventDuplicates: true,
            progressBar: true
        }
    });
}