ko.bindingHandlers.semanticDropdown = {
    init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var data = valueAccessor();
        if (!data) {
            data = {};
        }
        data['clearble'] = true;
        data['placeholder'] = 'Choose...';

        $(element).dropdown(data);

    },
    update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {

    }
};