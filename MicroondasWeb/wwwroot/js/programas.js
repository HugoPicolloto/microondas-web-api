function carregarProgramas() {

    apiFetch('/api/programas/listarTodos')
        .then(data => {

            const container = document.getElementById("programasFixos");

            container.innerHTML = "";

            data.forEach(p => {

                const card = document.createElement("div");

                card.className = p.fixo
                    ? "programa-card"
                    : "programa-card custom";

                card.innerHTML = `
                    <div class="card-top">

                        <h4>${p.nome} ${p.simbolo}</h4>

                        ${!p.fixo
                        ? `
                                <button class="btn-delete"
                                    onclick="event.stopPropagation(); excluirPrograma('${p.id}')">
                                    ✕
                                </button>
                              `
                        : ''}

                    </div>

                    <div class="alimento">
                        ${p.alimento}
                    </div>

                    <div class="info">
                        <span>⏱ ${p.tempo}s</span>
                        <span>⚡ ${p.potencia}</span>
                    </div>

                    <div class="instrucao">
                        ${p.instrucao ?? ''}
                    </div>
                `;

                card.onclick = () => executarPrograma(p.nome);

                container.appendChild(card);
            });
        })
        .catch(err => alert(err.message));
}

function executarPrograma(id) {

    apiFetch(`/api/programas/${id}`, {
        method: 'POST'
    })
        .then(data => {

            atualizarTela(data);

            if (timer) {
                clearInterval(timer);
                timer = null;
            }

            iniciarTimer();
        })
        .catch(err => modalErro(err.message));
}

function salvarPrograma() {

    const nome = document.getElementById("novoNome").value.trim();
    const alimento = document.getElementById("novoAlimento").value.trim();
    const tempo = document.getElementById("novoTempo").value.trim();
    const potencia = document.getElementById("novoPotencia").value.trim();
    const simbolo = document.getElementById("novoSimbolo").value.trim();
    const instrucao = document.getElementById("novaInstrucao").value.trim();

    if (!nome || !alimento || !tempo || !potencia || !simbolo) {

        modalAviso("Preencha os campos obrigatórios");

        return;
    }

    apiFetch('/api/programas/criar', {
        method: 'POST',
        body: JSON.stringify({
            nome,
            alimento,
            tempo: parseInt(tempo),
            potencia: parseInt(potencia),
            stringAquecimento: '',
            instrucao,
            simbolo
        })
    })
        .then(() => {

            fecharModal();

            limparFormularioPrograma();

            carregarProgramas();

            modalSucesso("Programa criado com sucesso");
        })
        .catch(err => modalErro(err.message));
}

function limparFormularioPrograma() {

    document.getElementById("novoNome").value = "";
    document.getElementById("novoAlimento").value = "";
    document.getElementById("novoTempo").value = "";
    document.getElementById("novoPotencia").value = "";
    document.getElementById("novoSimbolo").value = "";
    document.getElementById("novaInstrucao").value = "";
}


function excluirPrograma(id) {

    modalConfirmacao(
        "Deseja realmente excluir este programa?",
        () => {

            apiFetch(`/api/programas/${id}`, {
                method: 'DELETE'
            })
                .then(() => {

                    carregarProgramas();

                    modalSucesso(
                        "Programa removido com sucesso"
                    );
                })
                .catch(err => {

                    modalErro(err.message);
                });
        });
}