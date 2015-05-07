$(document).ready(function () {
    $(document).ajaxStart(function () {
        AbrirMensagemCarregandoPagina();
    });

    $(document).ajaxStop(function () {
        FecharMensagemCarregandoPagina();
    });
});

function AbrirMensagemCarregandoPagina() {
    try {
        var objetoHtml;

        objetoHtml = GerarDivCarregando();

        $(objetoHtml).css("visibility", "visible");
        $.blockUI(
            {
                message: $(objetoHtml)
                , css: {
                    border: 'none',
                    backgroundColor: '#459AD6',
                    width: $(window).width(),
                    left: 0,
                }
            }
        );
    }
    catch (e) {
        alert(e);
    }
}

function FecharMensagemCarregandoPagina() {
    $.unblockUI();
}

function GerarDivCarregando() {
    var strHTMLOutros = "";
    var strHTML_IE = "";
    var Mensagem = "";

    strHTMLOutros = "<div id='divCarregandoPagina' class='carregandoPagina'>";
    strHTMLOutros += "  <div class='windows8'>";
    strHTMLOutros += "      <div class='wBall' id='wBall_1'>";
    strHTMLOutros += "          <div class='wInnerBall'></div>";
    strHTMLOutros += "      </div>";
    strHTMLOutros += "      <div class='wBall' id='wBall_2'>";
    strHTMLOutros += "          <div class='wInnerBall'></div>";
    strHTMLOutros += "      </div>";
    strHTMLOutros += "      <div class='wBall' id='wBall_3'>";
    strHTMLOutros += "          <div class='wInnerBall'></div>";
    strHTMLOutros += "      </div>";
    strHTMLOutros += "      <div class='wBall' id='wBall_4'>";
    strHTMLOutros += "          <div class='wInnerBall'></div>";
    strHTMLOutros += "      </div>";
    strHTMLOutros += "      <div class='wBall' id='wBall_5'>";
    strHTMLOutros += "          <div class='wInnerBall'></div>";
    strHTMLOutros += "      </div>";
    strHTMLOutros += "      <div class='textoDeslisandoEsquerda'>Processo em Andamento...</div>";
    strHTMLOutros += "  </div>";
    strHTMLOutros += "</div>";

    if (navigator.userAgent.toLowerCase().match("msie")) {
        if (!navigator.userAgent.toLowerCase().match("trident/6") || !navigator.userAgent.toLowerCase().match("msie 10")) {

            strHTMLOutros = "";

            strHTML_IE = "<div id='divImagemCarregandoPagina' class='carregandoPaginaIE'>";
            strHTML_IE += " <div class='imagemCarregando'>";
            strHTML_IE += "     <img id='imgCarregandoWindows' src='/Content/Images/loadWindows8.gif' />";
            strHTML_IE += " </div>";
            strHTML_IE += " <div class='textoCarregandoIE'>Processo em Andamento...</div>";
            strHTML_IE += "</div>";

            Mensagem = strHTML_IE;
        }
        else {
            Mensagem = strHTMLOutros;
        }
    }
    else {
        Mensagem = strHTMLOutros;
    }

    return Mensagem;
}