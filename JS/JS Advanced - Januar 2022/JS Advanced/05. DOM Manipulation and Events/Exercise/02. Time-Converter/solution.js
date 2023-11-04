function attachEventsListeners() {
    let convertInputElements = document.querySelectorAll('input[value="Convert"]');

    Array.from(convertInputElements).forEach((input) => {
        input.addEventListener('click', convert);
    });

    function convert(e) {
        let daysInputElement = document.getElementById('days');
        let hoursInputElement = document.getElementById('hours');
        let minutesInputElement = document.getElementById('minutes');
        let secondsInputElement = document.getElementById('seconds');

        let targetElement = e.target.parentElement;
        let id = targetElement.children[1].id;
        let value = targetElement.children[1].value;

        const hoursPerDay = 24;
        const minutesPerHour = 60;
        const secondsPerMinute = 60;

        switch (id) {
            case 'days':
                daysInputElement.value = value;
                hoursInputElement.value = value * hoursPerDay;
                minutesInputElement.value = value * hoursPerDay * minutesPerHour;
                secondsInputElement.value = value * hoursPerDay * minutesPerHour * secondsPerMinute;
                break;
            case 'hours':
                daysInputElement.value = value / hoursPerDay;
                hoursInputElement.value = value;
                minutesInputElement.value = value * minutesPerHour;
                secondsInputElement.value = value * minutesPerHour * secondsPerMinute;
                break;
            case 'minutes':
                daysInputElement.value = value / minutesPerHour / hoursPerDay;
                hoursInputElement.value = value / minutesPerHour
                minutesInputElement.value = value;
                secondsInputElement.value = value * secondsPerMinute;
                break;
            case 'seconds':
                daysInputElement.value = value / secondsPerMinute / minutesPerHour / hoursPerDay;
                hoursInputElement.value = value / secondsPerMinute / minutesPerHour
                minutesInputElement.value = value / secondsPerMinute;
                secondsInputElement.value = value;
                break;
        }
    }
}