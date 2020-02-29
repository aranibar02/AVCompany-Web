$(document).ready(function () {
    $('.finish').click(function () {
        var files = $('#filesUpload').get(0).files
        console.log(files)
    })
})
