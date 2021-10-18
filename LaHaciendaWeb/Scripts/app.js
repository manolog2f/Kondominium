
function loading() {
    $("#loading").css({
        'display': 'block'
    });
    return false;
}

function hide_loading() {
    $("#loading").css({
        'display': 'none'
    });
    return false;
}

function setDropdown() {
    //Para implementar los dropdown multiselect
    $('select[multiple]').multiselect({
        columns: 1,
        placeholder: 'Seleccione',
        search: true,
        searchOptions: {
            'default': 'Buscar'
        },
        selectAll: true,
        texts: {
            selectAll: 'Seleccionar todos'
        }
    });
}

function collapseMenu() {
    $('.admin-app').addClass('collapse-menu');
    $('.btn-collapse-menu').css('display', 'none');
    $('.btn-extend-menu').css('display', 'block');
}
function extendMenu() {
    $('.admin-app').removeClass('collapse-menu');
    $('.btn-collapse-menu').css('display', 'block');
    $('.btn-extend-menu').css('display', 'none');
}

$("document").ready(function () {
    $('[data-toggle="popover"]').popover();

    //Para implementar los dropdown multiselect
    setDropdown();

    //Para cambiar el icono que muestra el menu izquierdo
    if (window.innerWidth > 767) {
    } else {
    }

    $('#toogleMenu').click(function () {
        $('.admin-app').toggleClass('open');
    });
});