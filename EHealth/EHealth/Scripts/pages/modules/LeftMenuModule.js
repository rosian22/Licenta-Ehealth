var leftMenuModule = function () {

    function changeLeftMenu(e, VM) {
        var classTextForCurrentTab = "";

        for (var a = 0; a < $('.muscle-groups').children().length; a++) {
            if ($($('.muscle-groups').children()[a]).hasClass('active') === true) {
                classTextForCurrentTab = $($('.muscle-groups').children()[a]).text();
            }
        }

        if (typeof (VM) === 'object') {
            VM.ActiveSectionGroupPaire[classTextForCurrentTab] = $(e.target).text().toLocaleLowerCase();
            VM.Init();
        }

        classTextForCurrentTab = classTextForCurrentTab.toLocaleLowerCase();
        classTextForCurrentTab = `.${classTextForCurrentTab.replace(' ', '-')} .left-side-menu`;
        var items = $(classTextForCurrentTab).children();
        for (var a = 0; a < items.length; a++) {
            $(items[a]).removeClass('active');
        }

        $(e.target).addClass('active');
    }


    return {
        changeLeftMenu: changeLeftMenu
    }
}();