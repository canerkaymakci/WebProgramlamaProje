function showNotification(type, message) {
    debugger;
    toastr.options = {
        closeButton: true,
        progressBar: true,
        positionClass: 'toastr-top-right',
    };
    toastr[type](message)
    
}