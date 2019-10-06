$(document).ready(function () {
    // Initialize Editor
    //$('.textarea-editor').wysihtml5();
    $('.textarea-editor').summernote(
        {
            height: 600,                 // set editor height
            minHeight: null,             // set minimum height of editor
            maxHeight: null,             // set maximum height of editor
            focus: true                  // set focus to editable area after initializing summernote
        });

    $('.submit').click(function () {
        var markupStr = $('.textarea-editor').summernote('code');
        var webPageTypeIdLabel = $('#WebPageTypeIdLabel');
        var webPageTypeId = webPageTypeIdLabel.text();

        var newContent = {
            web_page_type_id: parseInt(webPageTypeId),
            html_content: markupStr
        };

        var dataType = 'application/json; charset=utf-8';
        var jsonData = JSON.stringify(newContent);
        $.ajax({
            type: "POST",
            url: "/api/ContentApi/PostWebPageContent",
            contentType: dataType,
            dataType: "json",
            data: jsonData,
            success: function (result) {

                if (result.success) {
                    alert('Update success. ');
                }
                else {
                    alert('Update failed. ');
                }

            }, //End of AJAX Success function  

            failure: function (data) {
                alert(data.responseText);
            }, //End of AJAX failure function  
            error: function (data) {
                alert(data.responseText);
            } //End of AJAX error function  

        });
    });
});
