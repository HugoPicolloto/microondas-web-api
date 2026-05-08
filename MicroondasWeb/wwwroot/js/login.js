async function autenticarApi() {
    if (!tokenExpirado()) {

        modalAviso("API já autenticada");

        return;
    }

    const usuario = document.getElementById("loginUsuario").value.trim();
    const senha = document.getElementById("loginSenha").value.trim();

    if (!usuario || !senha) {

        atualizarStatusApi(false);

        modalAviso("Informe usuário e senha");

        return;
    }

    try {

        const response = await fetch('/api/auth/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                usuario,
                senha
            })
        });

        const data = await response.json();

        if (!response.ok || !data.sucesso) {

            atualizarStatusApi(false);

            modalErro(data.mensagem || "Usuário ou senha inválidos");

            return;
        }

        salvarToken(data.dados.token);

        limparLogin();

        atualizarStatusApi(true);

        modalSucesso("API autenticada com sucesso");
    }
    catch (err) {

        atualizarStatusApi(false);

        modalErro(err.mensagem);
    }
}

function salvarToken(token) {

    localStorage.setItem("token", token);

    const payload = parseJwt(token);

    localStorage.setItem("token_exp", payload.exp);
}

function validarTokenInicial() {

    const token = localStorage.getItem("token");

    if (!token) {

        atualizarStatusApi(false);
        return;
    }

    if (tokenExpirado()) {

        logoutApi("Token expirado. Faça login novamente.");

        return;
    }

    atualizarStatusApi(true);
}

function parseJwt(token) {

    const base64 = token.split('.')[1];

    const json = atob(base64);

    return JSON.parse(json);
}

function tokenExpirado() {

    const exp = localStorage.getItem("token_exp");

    if (!exp)
        return true;

    const agora = Math.floor(Date.now() / 1000);

    return agora >= exp;
}

function atualizarStatusApi(auth) {

    const dot = document.getElementById("statusDot");
    const text = document.getElementById("statusText");

    if (auth) {

        dot.classList.remove("offline");
        dot.classList.add("online");

        text.innerText = "API Autenticada";
    }
    else {

        dot.classList.remove("online");
        dot.classList.add("offline");

        text.innerText = "API Não autenticada";
    }
}

document.addEventListener("DOMContentLoaded", () => {

    validarTokenInicial();

    carregarProgramas();
});


function authHeaders() {

    return {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + localStorage.getItem("token")
    };
}

function limparLogin() {
    document.getElementById("loginSenha").value = "";
    document.getElementById("loginUsuario").value = "";

}

async function apiFetch(url, options = {}) {

    if (tokenExpirado()) {

        logoutApi(
            "Token expirado. Faça login novamente."
        );

    }

    options.headers = {
        ...authHeaders(),
        ...(options.headers || {})
    };

    const response = await fetch(url, options);

    const data = await response.json();

    if (!response.ok || !data.sucesso) {

        if (response.status === 401) {

            logoutApi(
                "Sessão inválida. Faça login novamente."
            );
        }

        throw new Error(data.mensagem || "Erro na requisição");
    }

    return data.dados;
}

function logoutApi(msg = null) {

    localStorage.removeItem("token");
    localStorage.removeItem("token_exp");

    atualizarStatusApi(false);

    if (msg)
        modalAviso(msg);
}