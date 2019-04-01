var selectOptions = null;
var totalPrice = 0;
var ticketPrice = 0;
var quantity = 0;

$(document).ready(function () {
    getSelectOptions();

    $(".mynavbar").addClass("posfixed");
    $(".mynavbar-buttons").addClass("jazz");
    $(".image-logo").addClass("jazz");
    $(".footer").addClass("jazz-get_tickets");

    $("#ticket_type").change(function () {
        resetSelect("ticket_date");
        resetSelect("ticket_name");
        resetTicketPrice();
        var selected = $(this).children("option:selected").val();
        if (selected == "all_access") {
            $(".jazz_artist").hide();
        }
        else {
            $(".jazz_artist").show();
        }
        setTicketDateSelect(selected);
        updatePrice();
    });
    $("#ticket_date").change(function () {
        resetSelect("ticket_name");
        var selected = $(this).children("option:selected").val();
        switch (selected) {
            case "all_days":
                ticketPrice = 85;
                break;

        }
        updatePrice();
        setTicketNameSelect(selected);
    });

    $("#quantity").change(function () {
        quantity = this.val();
        updatePrice();
    });
});

function getSelectOptions() {
    var url = '/Jazzs/GetJsonSelectorData';
    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: url,
        success: function (data) {
            selectOptions = data;
        },
        failure: function () {
            alert("Oops, could not get ticket data.");
        }
    });
}

function resetTicketPrice() {
    ticketPrice = 0;
}

function updatePrice() {
    totalPrice = ticketPrice * quantity;
    $("#jazz-lbl-total_price").val("Total price: €" + totalPrice.toFixed(2));
}

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
    console.log(selectOptions);
    var ticket_name_select = $("#ticket_name"); // load the element only once
    //ticket_name_select.append($("<option>", { value: data[0].Artiest.Naam }).text(data[0].Artiest.Naam));
    for (var i = 0; i < selectOptions.lenght; i++) {
        ticket_name_select.append($("<option>", { value: selectOptions[i].Artiest.Naam }).text(selectOptions[i].Artiest.Naam));
    }
}
