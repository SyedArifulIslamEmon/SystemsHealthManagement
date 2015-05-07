if (!Array.prototype.indexOf) {
    Array.prototype.indexOf = function (searchElement /*, fromIndex */) {
        "use strict";
        if (this == null) {
            throw new TypeError();
        }
        var t = Object(this);
        var len = t.length >>> 0;
        if (len === 0) {
            return -1;
        }
        var n = 0;
        if (arguments.length > 1) {
            n = Number(arguments[1]);
            if (n != n) { // shortcut for verifying if it's NaN
                n = 0;
            } else if (n != 0 && n != Infinity && n != -Infinity) {
                n = (n > 0 || -1) * Math.floor(Math.abs(n));
            }
        }
        if (n >= len) {
            return -1;
        }
        var k = n >= 0 ? n : Math.max(len - Math.abs(n), 0);
        for (; k < len; k++) {
            if (k in t && t[k] === searchElement) {
                return k;
            }
        }
        return -1;
    };
}
ko.bindingHandlers.money = {
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        $(element).text(accounting.formatMoney(value, "R$ ", 2, ".", ","));
    }
};

ko.bindingHandlers.number = {
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        $(element).text(accounting.formatNumber(value, 0, ""));
    }
};

ko.bindingHandlers.file = {
    init: function (element, valueAccessor) {
        $(element).attr('type', 'file');
        if (ko.isObservable(valueAccessor())) {
            var observable = valueAccessor();
            $(element).change(function () {
                if (this.files.length > 0)
                    observable(this.files[0]);
            });
            observable.subscribe(function (i, a) {
                if (!(i instanceof File)) {
                    $(element).val('');
                }
            });
        }
    }
};

ko.utils.ToDate = function (stringData) {
    var re = /-?\d+/;
    var m = re.exec(stringData);
    return new Date(parseInt(m[0]));
};

ko.bindingHandlers.dateExtension = {
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        var re = /-?\d+/;
        var m = re.exec(value);
        if (m) {
            var d = new Date(parseInt(m[0]));
            $(element).text($.datepicker.formatDate('dd/mm/yy', d));
        }
    }
};

ko.bindingHandlers.date = {
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        var re = /-?\d+/;
        var m = re.exec(value);
        if (m) {
            var d = new Date(parseInt(m[0]));
            $(element).text($.datepicker.formatDate('dd/MM/yy', d));
        }
    }
};

ko.bindingHandlers.maskMoney = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var currentValue = ko.utils.unwrapObservable(valueAccessor());
        var settings = $.extend({ prefixo: "R$ ", precisao: 2, decimal: ",", milhar: '.' }, allBindingsAccessor().maskOptions ? allBindingsAccessor().maskOptions : {});
        var valorASerEscrito = "";
        if (currentValue > 0)
            valorASerEscrito = settings.prefixo + " " + currentValue;
        ko.selectExtensions.writeValue(element, valorASerEscrito);

        ko.utils.registerEventHandler(element, "keyup", function () {
            var observable = valueAccessor();
            var valorStr = element.value;
            var centavos = "";
            var reais;
            var virgula = false;
            valorStr = valorStr.replace(settings.prefixo, '');

            reais = valorStr;
            if (valorStr.indexOf(settings.decimal) >= 0) {
                virgula = true;
                centavos = valorStr.substring(valorStr.indexOf(settings.decimal) + 1, valorStr.length);
                reais = valorStr.substring(0, valorStr.indexOf(settings.decimal));
                if (centavos.length > settings.precisao)
                    centavos = centavos.substr(0, settings.precisao);
            }
            var valor = 0;
            if (reais.length || centavos.length)
                valor = Number(reais + "." + centavos);
            observable(valor);
            valorASerEscrito = "";
            if (reais.length)
                valorASerEscrito = settings.prefixo + reais + (centavos.length ? settings.decimal + centavos : virgula ? settings.decimal : "");
            ko.selectExtensions.writeValue(element, valorASerEscrito);
        });

        ko.utils.registerEventHandler(element, "keydown", function (event) {
            var newValue = element.value.replace(/ /g, '');
            if (newValue.indexOf(settings.decimal) >= 0) {
                if (event.which === settings.decimal.charCodeAt(0))
                    return false;
            }

            if (settings.precisao > 0 && event.keyCode === 188) {
                return true;
            }

            if (event.keyCode === 46 || event.keyCode === 8 || event.keyCode === 9 || event.keyCode === 27 || event.keyCode === 13 ||
                (event.keyCode == 65 && event.ctrlKey === true) ||
                    (event.keyCode >= 35 && event.keyCode <= 39)) {
                return true;
            } else {
                if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                    return false;
                }
            }
            return true;
        });

        ko.utils.registerEventHandler(element, "blur", function () {
            var text = ko.utils.unwrapObservable(valueAccessor()) || 0;
            var valor = text.toFixed(settings.precisao);
            valorASerEscrito = "";
            if (valor > 0) {
                var valorStr = valor.toString();
                var centavos = "";
                var reais = valorStr;
                if (settings.precisao > 0) {
                    centavos = valorStr.substring(valorStr.indexOf('.') + 1, valorStr.length);
                    reais = valorStr.substring(0, valorStr.indexOf('.'));
                }
                valorASerEscrito = settings.prefixo + reais + (centavos.length ? settings.decimal + centavos : "");
                ko.selectExtensions.writeValue(element, valorASerEscrito);
            }
        });
    },
    update: function (element, valueAccessor, allBindingsAccessor) {
        var settings = $.extend({ prefixo: "R$ ", precisao: 2, decimal: ",", milhar: '.' }, allBindingsAccessor().maskOptions ? allBindingsAccessor().maskOptions : {});
        var valor = ko.utils.unwrapObservable(valueAccessor());
        var valorASerEscrito = "";
        if (valor > 0) {
            var valorStr = valor.toString();
            var centavos = "";
            var reais = valorStr;
            if (settings.precisao > 0 && (valor - parseInt(valor)) > 0) {
                centavos = valorStr.substring(valorStr.indexOf('.') + 1, valorStr.length);
                reais = valorStr.substring(0, valorStr.indexOf('.'));
            }
            valorASerEscrito = settings.prefixo + reais + (centavos.length ? settings.decimal + centavos : "");
        }
        ko.selectExtensions.writeValue(element, valorASerEscrito);
    }
};

ko.bindingHandlers.maskInput = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var maskConfig = allBindingsAccessor().maskConfig ? allBindingsAccessor().maskConfig : {};
        $(element).mask(maskConfig);

        ko.utils.registerEventHandler(element, 'blur', function () {
            var observable = valueAccessor();

            observable($(element).mask());
            var last = $(element).val().substr($(element).val().indexOf("-") + 1);

            if (last.length == 3) {
                var move = $(element).val().substr($(element).val().indexOf("-") - 1, 1);
                var lastfour = move + last;
                var first = $(element).val().substr(0, 9);

                $(element).val(first + '-' + lastfour);
            }

        });

        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            if ($(element).unMask != undefined)
                $(element).unMask();
        });
    },
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        $(element).val(value);
    }
};

jQuery(function ($) {
    $.datepicker.regional['pt-BR'] = {
        closeText: 'Fechar',
        prevText: '&#x3c;Anterior',
        nextText: 'Pr&oacute;ximo&#x3e;',
        currentText: 'Hoje',
        monthNames: ['Janeiro', 'Fevereiro', 'Mar&ccedil;o', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
        dayNames: ['Domingo', 'Segunda-feira', 'Ter&ccedil;a-feira', 'Quarta-feira', 'Quinta-feira', 'Sexta-feira', 'Sabado'],
        dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
        dayNamesMin: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
        weekHeader: 'Sm',
        dateFormat: 'dd/mm/yy',
        firstDay: 0,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };
    $.datepicker.setDefaults($.datepicker.regional['pt-BR']);
});

ko.bindingHandlers.datepicker1 = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        //initialize datepicker with some optional options
        var options = allBindingsAccessor().datepickerOptions || {};
        $(element).datepicker(options);

        //handle the field changing
        ko.utils.registerEventHandler(element, "change", function () {
            var observable = valueAccessor();
            observable($(element).datepicker("getDate"));
        });

        //handle disposal (if KO removes by the template binding)
        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $(element).datepicker("destroy");
        });
        $(element).mask("99/99/9999");
    },
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor()),
            current = $(element).datepicker("getDate");

        if (value - current !== 0) {
            $(element).datepicker("setDate", value);
        }
    }
};

ko.extenders.numeric = function (target, precision) {
    //create a writeable computed observable to intercept writes to our observable
    var result = ko.computed({
        read: target,  //always return the original observables value
        write: function (newValue) {
            var current = target(),
                roundingMultiplier = Math.pow(10, precision),
                newValueAsNum = isNaN(newValue) ? 0 : parseFloat(+newValue),
                valueToWrite = Math.round(newValueAsNum * roundingMultiplier) / roundingMultiplier;

            //only write if it changed
            if (valueToWrite !== current) {
                target(valueToWrite);
            } else {
                //if the rounded value is the same, but a different value was written, force a notification for the current field
                if (newValue !== current) {
                    target.notifySubscribers(valueToWrite);
                }
            }
        }
    });

    //initialize with current value to make sure it is rounded appropriately
    result(target());

    //return the new computed observable
    return result;
};