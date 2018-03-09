document.onkeydown = handle;

function handle(e) {
    switch (e.keyCode) {
    case 38:
        location.href = location.href.substr(0, 27) + '/Move?direction=3';
        break;
    case 40:
        location.href = location.href.substr(0, 27) + '/Move?direction=0';
        break;
    case 37:
        location.href = location.href.substr(0, 27) + '/Move?direction=2';
        break;
    case 39:
        location.href = location.href.substr(0, 27) + '/Move?direction=1';
        break;
    case 32:
        location.href = location.href.substr(0, 27) + '/Move?direction=-1';
        break;
    case 107:
        location.href = location.href.substr(0, 27) + '/Move?direction=4';
        break;
    case 109:
        location.href = location.href.substr(0, 27) + '/Move?direction=5';
        break;
    default: break;

    }
}