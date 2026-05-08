function abrirModal(tipo, mensagem, onConfirm = null) {

    const modal = document.getElementById("messageModal");

    const titulo = document.getElementById("modalTitulo");
    const texto = document.getElementById("modalMensagem");

    const btnOk = document.getElementById("btnModalOk");
    const btnCancel = document.getElementById("btnModalCancel");

    titulo.innerText = tipo;
    texto.innerText = mensagem;

    modal.classList.remove("hidden");

    btnOk.onclick = () => {

        fecharModalMensagem();

        if (onConfirm)
            onConfirm();
    };

    if (tipo === "Confirmação") {

        btnCancel.classList.remove("hidden");

        btnCancel.onclick = () => {
            fecharModalMensagem();
        };
    }
    else {

        btnCancel.classList.add("hidden");
    }
}

function fecharModalMensagem() {

    document
        .getElementById("messageModal")
        .classList.add("hidden");
}

function modalSucesso(msg) {
    abrirModal("Sucesso", msg);
}

function modalErro(msg) {
    abrirModal("Erro", msg);
}

function modalAviso(msg) {
    abrirModal("Aviso", msg);
}

function modalConfirmacao(msg, callback) {
    abrirModal("Confirmação", msg, callback);
}