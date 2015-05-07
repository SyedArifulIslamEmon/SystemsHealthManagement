/*
obj = {
    titulo: 'titulo da mensagem', //obrigatório
    mensagem: 'texto da mensagem', //obrigatório
    tipo: 'tipo da mensagem (aviso, erro, sucesso)', 
    botao: 'texto do botão (quando for um único botao)', 
    callback: function executada ao clicar no botão, quando não definida, executa-se $.un
();
    botoes: [ // só exibe caso [botao] esteja nulo (ou não seja passado nada)
       {botao: 'nome', callback: function}
       {botao: 'nome', callback: function}
       {botao: 'nome', callback: function}
       {botao: 'nome', callback: function}
       {botao: 'nome', callback: function}
    ]
    duracao: milisgundos para mostrar a imagem
}
Exemplo de Chamada:
    Mensagem.Alert({
        titulo: "Ola", 
        mensagem: "Mundo",
        tipo: "aviso",
        //botao: "Fechar",
        //callback: function(){
        //    alert('ola mundo');
        //    $.unblockUI();
        //}
        botoes: [
            {
                botao: "Sim", 
                callback: function(){
                    alert('ola mundo bonito');
                }
            },
            {
                botao: "Não", 
                callback: function(){
                    $.unblockUI();
                }
            }
        ]
    });
*/
function Mensagem() {
    this.InserirHtml = function (id, obj) {
        var html = "";
        if (obj.tipo == null)
            obj.tipo = "aviso";
        if (obj.botao == null && obj.duracao == null && obj.botoes == null)
            obj.duracao = 5000;
        if (obj.duracao == null)
            obj.duracao = 0;
        html += "<section id=\"" + id + "\" class=\"central_mensagem\" > ";
        html += "   <div class=\"mensagem " + obj.tipo.toLowerCase() + "\" posicao=\"0\" > ";
        html += "       <div class=\"corpo\"> ";
        html += "           <div class=\"titulo\"> ";
        html += obj.titulo;
        html += "           </div> ";
        html += "           <div class=\"texto textoDeslisandoEsquerda\"> ";
        html += obj.mensagem;
        html += "           </div> ";
        html += "       </div> ";
        html += "   </div> ";
        html += "   <div class=\"mensagem_botao\"> ";
        if (obj.botao != null) {
            html += "  <div class=\"direita\">";
            html += "      <button id=\"" + id + "_botao\">" + obj.botao + "</button>";
            html += "  </div>";
        }
        else if (obj.botoes != null) {
            html += "  <div class=\"direita\">";
            for (var i = 0; i < obj.botoes.length; i++)
                html += "      <button id=\"" + id + "_botao_" + i + "\">" + obj.botoes[i].botao + "</button>";
            html += "  </div>";

        }
        html += "  </div>";
        html += "</section>";
        if ($('body').children().length > 0)
            $('body').append(html);
        else
            $('body').children(':first').before(html);
    }
    this.Alert = function (obj) {
        var id = Math.uuid();
        this.InserirHtml(id, obj);

        //Eventos para a mensagem
        if (obj.botao != null) {
            if (obj.callback == null) {
                $("#" + id + "_botao").click(function () {
                    $.unblockUI();
                });
            }
            else {
                $("#" + id + "_botao").click(obj.callback);
            }
        }
        else if (obj.botao == null && obj.botoes != null) {
            for (var i = 0; i < obj.botoes.length; i++) {
                $("#" + id + "_botao_" + i).click(obj.botoes[i].callback)
            }
        }
        $.blockUI({
            message: $('#' + id + ''),
            css: {
                border: 'none',
                width: $(window).width(),
                margin: 0,
                left: 0,
            }
        });
        if (obj.duracao > 0)
            setTimeout("$.unblockUI()", obj.duracao);
    };
    this.CarregarMensagens = function (botao, duracao) {
        if (botao == null && duracao == null)
            obj.duracao = 4000;
        jQuery.ajax({
            url: '/Mensagem/Exibir',
            type: 'GET',
            dataType: 'html',
            data: { botao: botao, duracao: duracao },
            success: function (data) {
                $('body').children(':first').before(data);
            }
        });
    };
}
var Mensagem = new Mensagem();
//TODO:    criar MensagemConfirm que le o click do elemento, e para o envio do post e trata o botao escolhido e decide se continua o post ou não
//$('#botao').Mensagem({
//    botoes: {
//        0: {texto: "Sim", callback: funcaoSim},
//        1: {texto: "Não", callback: funcaoNao},
//        2: {texto: "Cancelar", callback: funcaoCancelar}
//    },
//    duracao: -1,
//    texto: "",
//    titulo: ""
//});