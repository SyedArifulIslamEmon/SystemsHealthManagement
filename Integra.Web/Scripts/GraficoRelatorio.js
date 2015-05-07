function GerarScriptGraficoPizza(obj, titulo, desc, valores) {
    var teste = null;
    //Chrome
    var retorno = '$("#' + obj + '").wijpiechart({ '
                        + ' radius: 140, '
                        + ' legend: { visible: true, compass: "east" }, '
                        + ' hint: {content: function () {return this.data.label + " - " + Globalize.format(this.value / this.total, "p2");}}, '
                        + ' header: {text: "' + titulo + '"}, '
                        + ' labels: { '
                            + ' style: {"font-size": 11}, '
                            + ' formatter: function () {return Globalize.format(this.value / this.total, "p2");}, '
                            + ' connectorStyle: {fill: "red","stroke-width": 2}, '
                            + ' position: "outside",offset: 15 '
                        + ' }, '
                        + ' seriesList: [ ' + GerarStringSeriesPizza(desc, valores) + ' ] '
                        + ' }); ';

    //IE
    //    var retorno = '$("#' + obj + '").wijcompositechart({ '
    //                        + ' axis: {y: {gridMajor: {visible: false},textVisible: false}, x: {visible: false,textVisible: false}}, '
    //                        + ' stacked: false, '
    //                        + ' hint: {content: function () {return this.label + " - " + this.y;}}, '
    //                        + ' header: {text: "' + titulo + '"}, '
    //                        + 'seriesList: [{'
    //                        + 'type: "pie",legendEntry: true, radius: 130, data: ['
    //                        + GerarStringSeriesPizza(desc, valores) + ']}]'
    //                        + '});';

    window.eval(retorno);
}

function GerarStringSeriesPizza(desc, valores) {
    var retorno = '';
    for (var contador = 0; contador < desc.length; contador++) {
        if (contador > 0) {
            retorno += ' ,{label: "' + desc[contador] + '",legendEntry: true,data: ' + valores[contador] + ',offset: 0} ';
        } else {
            retorno += ' {label: "' + desc[contador] + '",legendEntry: true,data: ' + valores[contador] + ',offset: 0} ';
        }
    }
    return retorno;
}

function GerarStringSeriesCompostas(tipo, label, desc, valores) {
    var retorno = '';
    for (var contador = 0; contador < tipo.length; contador++) {
        if (contador > 0) {
            retorno += ' ,{type: "' + tipo[contador] + '",label: "' + label[contador] + '",legendEntry: true, ';
        } else {
            retorno += ' {type: "' + tipo[contador] + '",label: "' + label[contador] + '",legendEntry: true, ';
        }
        retorno += 'data: { x: [' + desc[contador] + '], y: [' + valores[contador] + '] }';

        if (tipo[contador] == 'line') {
            retorno += ' , markers: {visible: true,type: "circle"} ';
        }
        retorno += ' } ';
    }
    return retorno;
}

function GerarScriptGrafico(obj, titulo, tipo, label, desc, valores) {
    var retorno = '$("#' + obj + '").wijcompositechart({ '
                        + ' axis: {y: {text: ""}, x: {text: ""}}, '
                        + ' stacked: false, '
                        + ' legend: { visible: true, compass: "south" }, '
                        + ' hint: {content: function () {return this.x + " - " + this.y;}}, '
                        + ' header: {text: "' + titulo + '"}, '
                        + 'seriesList: [' + GerarStringSeriesCompostas(tipo, label, desc, valores) + ']'
                        + '});';
    window.eval(retorno);

}


function GerarScriptGraficoStacked(obj, titulo, tipo, label, desc, valores) {
    var retorno = '$("#' + obj + '").wijcompositechart({ '
                        + ' axis: {y: {text: ""}, x: {text: ""}}, '
                        + ' stacked: true, '
                        + ' legend: { visible: true, compass: "south" }, '
                        + ' hint: {content: function () {return this.x + " - " + this.y;}}, '
                        + ' header: {text: "' + titulo + '"}, '
                        + 'seriesList: [' + GerarStringSeriesCompostas(tipo, label, desc, valores) + ']'
                        + '});';
    window.eval(retorno);
}

function GerarScriptGraficoStackedPerc(obj, titulo, tipo, label, desc, valores) {
    var retorno = '$("#' + obj + '").wijcompositechart({ '
                        + ' axis: {y: {text: ""}, x: {text: ""}}, '
                        + ' stacked: true, '
                        + ' is100Percent: true, '
                        + ' legend: { visible: true, compass: "south" }, '
                        + ' hint: {content: function () {return this.x + " - " + this.y + " - " + Globalize.format(this.y / RetornaTotalStackedPerc(this), "p2") ;}}, '
                        + ' header: {text: "' + titulo + '"}, '
                        + 'seriesList: [' + GerarStringSeriesCompostas(tipo, label, desc, valores) + ']'
                        + '});';
    window.eval(retorno);
}

function RetornaTotalStackedPerc(barra) {
    var total = 0;
    if (barra.data.lineSeries != undefined) {
        barra = barra.data.lineSeries;
    }
    for (var i = 0; i < barra.data.y.length; i++) {
        total += barra.data.y[i];
    }
    if (total == 0) {
        total = 1;
    }
    return total.toString();
}

function GerarScriptGraficoDoubleAxes(obj, titulo, tipo, label, desc, valores, axis) {
    var retorno = '$("#' + obj + '").wijcompositechart({ '
                        + ' axis: {y: [{text: "" ,gridMajor:{visible:false}} ,{text: "",  compass: "east"}], x: {text: ""}}, '
                        + ' stacked: false, '
                        + ' legend: { visible: true, compass: "south" }, '
                        + ' hint: {content: function () {return this.x + " - " + this.y;}}, '
                        + ' header: {text: "' + titulo + '"}, '
                        + 'seriesList: [' + GerarStringSeriesCompostasDoubleAxe(tipo, label, desc, valores, axis) + ']'
                        + '});';
    window.eval(retorno);
}

function GerarScriptGraficoDoubleAxesPercHint(obj, titulo, tipo, label, desc, valores, axis) {
    var retorno = '$("#' + obj + '").wijcompositechart({ '
                        + ' axis: {y: [{text: "" ,gridMajor:{visible:false}} ,{text: "",  compass: "east"}], x: {text: ""}}, '
                        + ' stacked: false, '
                        + ' legend: { visible: true, compass: "south" }, '
                        + ' hint: {content: function () {return this.x + " - " + this.y + " - " + Globalize.format(this.y / RetornaTotalStackedPerc(this), "p2");}}, '
                        + ' header: {text: "' + titulo + '"}, '
                        + 'seriesList: [' + GerarStringSeriesCompostasDoubleAxe(tipo, label, desc, valores, axis) + ']'
                        + '});';
    window.eval(retorno);
}

function GerarStringSeriesCompostasDoubleAxe(tipo, label, desc, valores, axis) {
    var retorno = '';
    for (var contador = 0; contador < tipo.length; contador++) {
        if (contador > 0) {
            retorno += ' ,{type: "' + tipo[contador] + '",label: "' + label[contador] + '",legendEntry: true, ';
        } else {
            retorno += ' {type: "' + tipo[contador] + '",label: "' + label[contador] + '",legendEntry: true, ';
        }
        retorno += 'data: { x: [' + desc[contador] + '], y: [' + valores[contador] + '] }';

        if (axis != '0') {
            retorno += ', yAxis: ' + axis[contador];
        }

        if (tipo[contador] == 'line') {
            retorno += ' , markers: {visible: true,type: "circle"} ';
        }
        retorno += ' } ';
    }
    return retorno;
}

function GerarScriptGraficoStackedCustom(obj, titulo, tipo, label, desc, valores) {
    var retorno = '$("#' + obj + '").wijcompositechart({ '
                        + ' axis: {y: {text: ""}, x: {text: ""}}, '
                        + ' stacked: true, '
                        + ' legend: { visible: true, compass: "east" }, '
                        + ' showChartLabels: false, '
                        + ' hint: {content: function () {return this.label + " - " + this.y;}}, '
                        + ' header: {text: "' + titulo + '"}, '
                        + 'seriesList: [' + GerarStringSeriesCompostas(tipo, label, desc, valores) + ']'
                        + '});';
    window.eval(retorno);
}

function GerarScriptGraficoPizzaCustom(obj, titulo, desc, valores) {

    //Chrome
    var retorno = '$("#' + obj + '").wijpiechart({ '
                        + ' radius: 140, '
                        + ' legend: { visible: true, compass: "east" }, '
                        + ' hint: {content: function () {return this.data.label + " - " + this.value;}}, '
                        + ' header: {text: "' + titulo + '"}, '
                        + ' labels: { '
                            + ' style: {"font-size": 11}, '
                            + ' formatter: function () {return this.value;}, '
                            + ' connectorStyle: {fill: "red","stroke-width": 2}, '
                            + ' position: "outside",offset: 15 '
                        + ' }, '
                        + ' seriesList: [ ' + GerarStringSeriesPizza(desc, valores) + ' ] '
                        + ' }); ';

    //IE
    //    var retorno = '$("#' + obj + '").wijcompositechart({ '
    //                        + ' axis: {y: {gridMajor: {visible: false},textVisible: false}, x: {visible: false,textVisible: false}}, '
    //                        + ' stacked: false, '
    //                        + ' hint: {content: function () {return this.label + " - " + this.y;}}, '
    //                        + ' header: {text: "' + titulo + '"}, '
    //                        + 'seriesList: [{'
    //                        + 'type: "pie",legendEntry: true, radius: 130, data: ['
    //                        + GerarStringSeriesPizza(desc, valores) + ']}]'
    //                        + '});';

    window.eval(retorno);
}



function GerarScriptGraficoBar(obj, titulo, desc, valores) {
    var retorno = '$("#' + obj + '").wijbarchart({ '
            + ' header: { '
            + ' text: "' + titulo + '"'
            + ' }, '
            + ' clusterWidth: 60, ' //size of each bar (or group of bars if multiple series are used) 
            + ' marginTop: 70, ' //Lessen the top markgin 
            + ' marginRight: 60, ' //Add more right margin to make sure header text aligns with axis text 
            + ' axis: { '
            + ' y: {'
                    //text: "USD (thousands)",
            + '      textStyle: { '
            + '      "font-weight": "normal",'
            + '      "margin-bottom": 5, '//space the axis text away from the axis line
            + '    },'
            //+ '        min: 0, '//Minimum value for axis 
            //+ '        max: ' + maior + ', '//Maximum value for axis 
            + '        autoMin: true, '//Tell the chart not to automatically generate minimum value for axis 
            + '        autoMax: true, '//Tell the chart not to automatically generate maximum value for axis 
            + '        gridMajor: { visible: false }, '//hide gridMajor lines 
            + '        visible: true, '//show line along axis 
            + '        tickMajor: {'
            + '            position: "outside", '//position tick marks outside of axis line 
            + '            style: {'
            + '                stroke: "#999999" '//Make the tick marks match axis line color 
            + '            }'
            + '    },'
            + '    },'
            + '    x: {'
            + '       visible: false,'
            + '        compass: "north", '//Position the x axis labels on top of the chart 
            + '        textStyle: {'
            + '            "font-weight": "normal"'
            + '        }'
            + '    }'
            + '},'
            + 'showChartLabels: true, '//Hide labels on each bar 
            + 'hint: {'
            + '    content: function () {'
            + '        return this.x + ":" + Globalize.format(this.y); '//Display x value and format y value as currency after multiplying by 1000 
            + '    },'
            + '    contentStyle: {'
            + '        "font-size": "14px",'
            + '    },'
            + '    style: {'
            + '        fill: "#444444"'
            + '    }'
            + '},'
            + 'shadow: false,'
            + 'seriesList: [{'
            + '    label:"Atual",'
            + '    legendEntry: true, '//Prevent series from being added to legend 
            + '    data: {'
            + '        x: ['
            + GerarStringSeriesBarsDesc(desc, valores) + '],'
            + '        y: ['
            + GerarStringSeriesBarsValores(desc, valores) + ']'
            + '   }'
            + '}],'
            + 'seriesStyles: ['
            + '    {'
            + '        fill: "rgb(136,189,230)", '//fill color of bar 
            + '        stroke: "none" '//border color of bar 
            + '    }'
            + ']'
    + '});';
    window.eval(retorno);
    //$('#' + obj).html(retorno);
}




function GerarStringSeriesBarsDesc(desc, valores) {
    var retorno = '';
    for (var contador = 0; contador < desc.length; contador++) {
        if (contador > 0) {
            retorno += ',"' + desc[contador] + '"';
        } else {
            retorno += '"' + desc[contador] + '"';
        }
    }
    return retorno;
}

function GerarStringSeriesBarsValores(desc, valores) {
    var retorno = '';
    for (var contador = 0; contador < valores.length; contador++) {
        if (contador > 0) {
            retorno += ',' + valores[contador];
        } else {
            retorno += valores[contador];
        }
    }
    return retorno;
}

function GerarScriptGraficoStackedCustomPercent(obj, titulo, tipo, label, desc, valores) {
    var retorno = '$("#' + obj + '").wijbarchart({ '
                        + ' indicator: { '
                        + '  visible: true '
                        + ' }, '
                        + ' axis: {y: {text: ""}, x: {text: ""}}, '
                        + ' horizontal: false,  '
                        + ' stacked: true, '
                        + ' legend: { visible: true, compass: "east" }, '
                        + ' showChartLabels: false, '
                        + ' hint: {content: function () {return this.label + " - " + this.y;}}, '
                        + ' header: {text: "' + titulo + '"}, '
                        + 'seriesList: [' + GerarStringSeriesCompostas(tipo, label, desc, valores) + ']'
                        + '});';
    window.eval(retorno);
}

function GerarScriptGraficoPizzaCustomHint(obj, titulo, desc, valores) {
    //Chrome
    var retorno = '$("#' + obj + '").wijpiechart({ '
                        + ' radius: 140, '
                        + ' legend: { visible: true, compass: "east" }, '
                        + ' hint: {content: function () {return this.data.label + " - " + this.value + " - " + Globalize.format(this.value / this.total, "p2");}}, '
                        + ' header: {text: "' + titulo + '"}, '
                        + ' labels: { '
                            + ' style: {"font-size": 11}, '
                            + ' formatter: function () {return this.value + " - " + Globalize.format(this.value / this.total, "p2");}, '
                            + ' connectorStyle: {fill: "red","stroke-width": 2}, '
                            + ' position: "outside",offset: 15 '
                        + ' }, '
                        + ' seriesList: [ ' + GerarStringSeriesPizza(desc, valores) + ' ] '
                        + ' }); ';
    window.eval(retorno);
}