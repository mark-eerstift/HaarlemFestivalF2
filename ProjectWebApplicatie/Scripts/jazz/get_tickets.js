$(document).ready(function () {
    $(".mynavbar").addClass("posfixed");
    $(".mynavbar-buttons").addClass("jazz");
    $(".image-logo").addClass("jazz");
    $(".footer").addClass("jazz-get_tickets");

    $("#ticket_type").change(function () {
        resetSelect("ticket_date");
        resetSelect("ticket_name");
        $(".jazz_artist").show();
        var selected = $(this).children("option:selected").val();
        setTicketDateSelect(selected);
    });
    $("#ticket_date").change(function (event) {
        resetSelect("ticket_name");
        var selected = $(this).children("option:selected").val();
        if (selected == "all_days") {
            $(".jazz_artist").hide();
        }
        else {
            $(".jazz_artist").show();
        }
        setTicketNameSelect(selected);
    });
});

function resetSelect(id) {
    $("#" + id).find("option:not(:first)").remove();
    $("#" + id + " option[value=0]").prop("selected", true);
}

function setTicketDateSelect(selected) {
    var ticket_date_select = $("#ticket_date"); // load the element only once

    if (selected == "all_access") {
        ticket_date_select.append($("<option>", { value: "all_days" }).text("ALL DAYS!"));
    }
    ticket_date_select.append($("<option>", { value: "26-7-2019" }).text("Thursday 26 July"));
    ticket_date_select.append($("<option>", { value: "27-7-2019" }).text("Friday 27 July"));
    ticket_date_select.append($("<option>", { value: "28-7-2019" }).text("Saturday 28 July"));
}

function setTicketNameSelect(selected) {
    
}
