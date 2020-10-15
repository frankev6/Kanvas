var clockOpen = false;

function startTimer(duration, display) {
    var timer = duration, minutes, seconds;
    setInterval(function () {
        minutes = parseInt(timer / 60, 10)
        seconds = parseInt(timer % 60, 10);

        minutes = minutes < 10 ? "0" + minutes : minutes;
        seconds = seconds < 10 ? "0" + seconds : seconds;

        display.text(minutes + ":" + seconds);

        if (--timer < 0) {
            timer = duration;
        }
    }, 1000);
}

jQuery(function ($) {
    var fiveMinutes = 60 * 5,
        display = $('#time');
    startTimer(fiveMinutes, display);
});

$('.clock-toggle').on('click', function() {
    if(clockOpen) {
        $('.clock').addClass('clock-close');

        $('.clock-toggle').text('^');
    } else {
        $('.clock').removeClass('clock-close');
        $('.clock-toggle').text('x');
    }

    clockOpen = !clockOpen;
});