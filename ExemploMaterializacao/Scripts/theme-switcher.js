$(document).ready(function () {
    var themeSwitch = $('#theme-switch-checkbox');
    var htmlElement = $('html');
    var currentTheme = localStorage.getItem('theme');

    function setTheme(theme) {
        if (theme === 'dark') {
            htmlElement.attr('data-theme', 'dark');
            themeSwitch.prop('checked', true);
        } else {
            htmlElement.removeAttr('data-theme');
            themeSwitch.prop('checked', false);
        }
    }

    if (currentTheme) {
        setTheme(currentTheme);
    }

    themeSwitch.on('change', function () {
        if ($(this).is(':checked')) {
            localStorage.setItem('theme', 'dark');
            setTheme('dark');
        } else {
            localStorage.setItem('theme', 'light');
            setTheme('light');
        }
    });
});