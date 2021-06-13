﻿$(function () {
    $('#checkall').change(function () {
        $('.cb-element').prop('checked', this.checked);
    });

    $('.cb-element').change(function () {
        if ($('.cb-element:checked').length == $('.cb-element').length) {
            $('#checkall').prop('checked', true);
        }
        else {
            $('#checkall').prop('checked', false);
        }
    });

    $("#delete").click(function () {
        var a = $('input:checked');
        var out = [];

        for (var x = 0; x < a.length; x++) {
            out.push(a[x].value);
        }

        if (out.length > 0) {
            $.ajax({
                url: "/users/delete",
                type: "POST",
                data: { selectedObjects: out },
                success: function (response) {
                    if (response == true) {
                        location.reload();
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.log(textStatus, errorThrown);
                }
            });
        }

    });

    $("#lock").click(function () {
        var a = $('input:checked');
        var out = [];

        for (var x = 0; x < a.length; x++) {
            out.push(a[x].value);
        }

        if (out.length > 0) {
            $.ajax({
                url: "/users/lock",
                type: "POST",
                data: { selectedObjects: out },
                success: function (response) {
                    if (response.isRedirectToLogin == true) {
                        window.location.href = "https://localhost:5001/account/login";
                    } else {
                        Location.reload();
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.log(textStatus, errorThrown);
                }
            });
        }

    });

    $("#unlock").click(function () {
        var a = $('input:checked');
        var out = [];

        for (var x = 0; x < a.length; x++) {
            out.push(a[x].value);
        }

        if (out.length > 0) {
            $.ajax({
                url: "/users/unlock",
                type: "POST",
                data: { selectedObjects: out },
                success: function (response) {
                    if (response == true) {
                        location.reload();
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.log(textStatus, errorThrown);
                }
            });
        }
    });
});