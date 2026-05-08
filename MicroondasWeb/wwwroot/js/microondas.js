let timer = null;
let inputAtivo = "tempo";

function selecionarInput(tipo, el) {

    inputAtivo = tipo;

    document.querySelectorAll(".selector")
        .forEach(btn => btn.classList.remove("ativo"));

    el.classList.add("ativo");
}

function addNumero(n) {

    const input = document.getElementById(inputAtivo);
    if (!input) return;

    input.value += n;
}


function iniciar() {
    const tempoVal = document.getElementById("tempo").value;
    const potenciaVal = document.getElementById("potencia").value;


    apiFetch('/api/microondas/iniciar', {
        method: 'POST',
        body: JSON.stringify({
            tempo: tempoVal ? parseInt(tempoVal) : null,
            potencia: potenciaVal ? parseInt(potenciaVal) : null
        })
    })
        .then(data => {
            if (data) atualizarTela(data);

            if (timer) {
                clearInterval(timer);
                timer = null;
            }
            iniciarTimer();
        })
        .catch(err => modalErro(err.message));
}

function iniciarTimer() {
    timer = setInterval(() => {
        apiFetch('/api/microondas/tick', {
            method: 'POST'
        })
            .then(data => {
                if (!data) return;

                atualizarTela(data);

                if (data.status !== 'EmExecucao') {
                    clearInterval(timer);
                    timer = null;
                }
            });
    }, 1000);
}

function pauseOuCancelar() {
    apiFetch('/api/microondas/status')
        .then(data => {
            if (!data) return;

            const isExecutando = data.status == 'EmExecucao';

            const url = isExecutando
                ? '/api/microondas/pause'
                : '/api/microondas/cancel';

            apiFetch(url, {
                method: 'POST'
            })
                .then(data => {

                    if (!isExecutando) {
                        limparTela();

                        if (timer) {
                            clearInterval(timer);
                            timer = null;
                        }

                        return;
                    }

                    if (data) atualizarTela(data);
                });
        });
}

function atualizarTela(data) {
    const stringDisplay = document.getElementById("stringDisplay");
    const tempo = document.getElementById("tempo");
    const potencia = document.getElementById("potencia");

    if (!stringDisplay || !tempo || !potencia) return;

    stringDisplay.innerText = data.stringAquecimento;
    tempo.value = formatarTempo(data.tempoRestante);
    potencia.value = data.potencia;

    aplicarBloqueio(data);
}

function limparTela() {
    document.getElementById("stringDisplay").innerText = "";
    document.getElementById("tempo").value = "";
    document.getElementById("potencia").value = "";

    desbloquearControles();

}

function formatarTempo(segundos) {
    let m = Math.floor(segundos / 60);
    let s = segundos % 60;
    return `${m}:${s.toString().padStart(2, '0')}`;
}

function aplicarBloqueio(data) {

    const bloquear = data.programaAtivo;

    document.getElementById("tempo").disabled = bloquear;
    document.getElementById("potencia").disabled = bloquear;

    const programas = document.getElementById("programasFixos");

    if (bloquear) {
        programas.classList.add("bloqueado");
    } else {
        programas.classList.remove("bloqueado");
    }

    document.querySelectorAll(".keypad button").forEach(b => {
        b.disabled = bloquear;
    });
}

function desbloquearControles() {

    document.getElementById("tempo").disabled = false;
    document.getElementById("potencia").disabled = false;

    document
        .getElementById("programasFixos")
        .classList.remove("bloqueado");

    document.querySelectorAll(".keypad button").forEach(b => {
        b.disabled = false;
    });
}