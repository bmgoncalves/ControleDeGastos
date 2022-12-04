
$(".btn-remove").click(function () {
    var url = $(this).data("url");

    $.confirm({
        title: 'Confirm?',
        content: 'Confirm delete?',
        type: 'red',
        theme: 'bootstrap',
        typeAnimated: true,
        buttons: {
            Delete: {
                text: 'Delete',
                btnClass: 'btn-red',
                action: function () {
                    $.ajax({
                        url: url,
                        type: "GET",
                        dataType: 'html',
                        success: function () {  
                            $(".div-alert-success").prop("hidden", false);
                            setTimeout(function () {
                                $(".div-alert-success").fadeOut("slow", function () {
                                    $(this).prop("hidden", true);
                                });
                                location.reload();
                            }, 1500);
                        },
                        error: function (data) {
                            $(".spanErro").html("");
                            $(".spanErro").html(data.responseText);
                            $(".div-alert").prop("hidden", false);
                            setTimeout(function () {
                                $(".div-alert").fadeout("slow", function () {
                                    $(this).prop("hidden", true);
                                });
                                location.reload();
                            }, 2500);
                        }
                    });
                }
            },
            cancel: function () {
            }
        }
    });

});

