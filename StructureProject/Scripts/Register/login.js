$(document).ready(function () {
    $('.login-info-box').fadeOut();
    $('.login-show').addClass('show-log-panel');



    $('#BirthDate').datetimepicker({
        useCurrent: false,
        format: 'D/M/YYYY',
        maxDate: moment().subtract(18, 'years').format('l')
    })
});


$('.login-reg-panel input[type="radio"]').on('change', function () {
    if ($('#log-login-show').is(':checked')) {
        $('.register-info-box').fadeOut();
        $('.login-info-box').fadeIn();

        $('.white-panel').addClass('right-log');
        $('.register-show').addClass('show-log-panel');
        $('.login-show').removeClass('show-log-panel');

    }
    else if ($('#log-reg-show').is(':checked')) {
        $('.register-info-box').fadeIn();
        $('.login-info-box').fadeOut();

        $('.white-panel').removeClass('right-log');

        $('.login-show').addClass('show-log-panel');
        $('.register-show').removeClass('show-log-panel');
    }
});
$('#myCheck').click(function () {
    if ($(this).is(':checked')) {
        $('#submit').removeAttr('disabled');
    } else {
        $('#submit').attr('disabled', 'disabled');
    }
});




$.validator.addMethod('date', function (value, element) {
    if (this.optional(element)) {
        return true;
    }
    var valid = true;
    return valid;
});
