$(document).ready(function () {
    function Contrain(tex_one, text_two) {
        if (tex_one.indexOf(text_two) != -1)
            return true;
    }
    $("#Search").keyup(function () {
        var searchText = $("#Search").val().toLowerCase();
        $(".Search").each(function () {
            if (!Contrain($(this).text().toLowerCase(), searchText)) {
                $(this).hide();
            } else {
                $(this).show();
            }
        });
    });
});