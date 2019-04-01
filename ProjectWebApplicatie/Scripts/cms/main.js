$(document).ready(function () {
    var baseUrl = window.location.origin;
    var targetPath = "/Jazzs/Index";
    
    $.get(baseUrl + targetPath, function (result) {
        if ($(result).find("#jazz_subpage_title_1").length) {
            $("#title1").val($(result).find("#jazz_subpage_title_1").text());
        }
        if ($(result).find("#jazz_subpage_title_2").length) {
            $("#title2").val($(result).find("#jazz_subpage_title_2").text());
        }
        if ($(result).find("#jazz_subpage_title_3").length) {
            $("#title3").val($(result).find("#jazz_subpage_title_3").text());
        }
        if ($(result).find("#jazz_subpage_title_4").length) {
            $("#title4").val($(result).find("#jazz_subpage_title_4").text());
        }

        if ($(result).find("#jazz_subpage_text_1").length) {
            $("#text1").val($(result).find("#jazz_subpage_text_1").text());
        }
        if ($(result).find("#jazz_subpage_text_2").length) {
            $("#text2").val($(result).find("#jazz_subpage_text_2").text());
        }
        if ($(result).find("#jazz_subpage_text_3").length) {
            $("#text3").val($(result).find("#jazz_subpage_text_3").text());
        }
        if ($(result).find("#jazz_subpage_text_4").length) {
            $("#text4").val($(result).find("#jazz_subpage_text_4").text());
        }
    });
});