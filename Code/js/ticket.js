// tickets-agente.js - DASHBOARD COMPLETO DO AGENTE

// ==================== VERIFICAÇÃO DE LOGIN ====================
const idAgente = localStorage.getItem("IdAgente");
const nomeAgente = localStorage.getItem("NomeAgente");

if (!idAgente) {
    alert("Acesso negado! Faça login como agente.");
    window.location.href = "login-agente.html";
} else {
    // Atualiza o nome do agente no header (com verificação de segurança)
    const elementoNome = document.getElementById("nomeAgente");
    if (elementoNome) {
        elementoNome.textContent = nomeAgente || "Agente";
    }
}

function sair() {
    localStorage.removeItem("IdAgente");
    localStorage.removeItem("NomeAgente");
    localStorage.removeItem("FuncaoAgente");
    window.location.href = "login-agente.html";
}

// ==================== SISTEMA DE TICKETS ====================
const baseURL = 'https://localhost:7269';
const API_TICKETS = `${baseURL}/api/Tickets`;

// Função auxiliar pra pegar iniciais do nome
const getInitials = nome => {
    if (!nome) return '??';
    const partes = nome.split(' ');
    return (partes[0][0] + (partes[1]?.[0] || '')).toUpperCase();
};

// Função pra formatar horário
const formatTime = data => {
    const d = new Date(data);
    return `${String(d.getHours()).padStart(2, '0')}:${String(d.getMinutes()).padStart(2, '0')}`;
};

// Cria uma linha completa de ticket
const gerarLinha = (ticket) => {
    const cliente = ticket.cliente || {};
    const clienteNome = cliente.nome || "Desconhecido";
    const clienteEmail = cliente.email || "-";
    const iniciais = getInitials(clienteNome);
    const hora = formatTime(ticket.dataCriacao || ticket.DataCriacao);
    const status = ticket.status || ticket.Status || 'Aberto';
    const ativo = status.toLowerCase() === 'resolvido' ? 'inativo' : 'ativo';

    return `
    <div class="row" role="row" onclick="abrirTicket(${ticket.idTicket || ticket.IdTicket})" style="cursor: pointer;">
        <div class="cell">
            <div class="user">
                <div class="avatar">${iniciais}</div>
                <div>
                    <div class="name">${clienteNome}</div>
                    <div class="sub">Cliente</div>
                </div>
            </div>
        </div>
        <div class="cell">${ticket.idTicket || ticket.IdTicket}</div>
        <div class="cell">RH</div>
        <div class="cell email">${clienteEmail}</div>
        <div class="cell">${hora}</div>
        <div class="cell"><span class="status ${ativo}">${status.toUpperCase()}</span></div>
    </div>
    `;
};

// ==================== PAGINAÇÃO ====================
let ticketsAtuais = [];
let paginaAtual = 1;
const ticketsPorPagina = 5;

function atualizarPaginacao() {
    const totalPaginas = Math.ceil(ticketsAtuais.length / ticketsPorPagina);
    const footer = document.querySelector('.footer');
    
    if (!footer) return;

    // Atualiza texto da página
    const paginaTexto = footer.querySelector('.page-text') || document.createElement('div');
    paginaTexto.className = 'page-text';
    paginaTexto.textContent = `Página ${paginaAtual} de ${totalPaginas}`;
    
    // Atualiza botões de paginação
    const paginacao = footer.querySelector('.pagination') || document.createElement('div');
    paginacao.className = 'pagination';
    
    let botoesHTML = `
        <div class="page-btn ${paginaAtual === 1 ? 'disabled' : ''}" onclick="mudarPagina(${paginaAtual - 1})">❮</div>
    `;
    
    // Botões de páginas
    for (let i = 1; i <= totalPaginas; i++) {
        botoesHTML += `<div class="page-btn ${i === paginaAtual ? 'active' : ''}" onclick="mudarPagina(${i})">${i}</div>`;
    }
    
    botoesHTML += `<div class="page-btn ${paginaAtual === totalPaginas ? 'disabled' : ''}" onclick="mudarPagina(${paginaAtual + 1})">❯</div>`;
    
    paginacao.innerHTML = botoesHTML;
    footer.innerHTML = '';
    footer.appendChild(paginaTexto);
    footer.appendChild(paginacao);
}

function mudarPagina(novaPagina) {
    const totalPaginas = Math.ceil(ticketsAtuais.length / ticketsPorPagina);
    if (novaPagina < 1 || novaPagina > totalPaginas) return;
    
    paginaAtual = novaPagina;
    renderizarTickets();
}

function renderizarTickets() {
    const tabela = document.querySelector('.table');
    const footer = tabela.querySelector('.footer');
    const linhasAntigas = tabela.querySelectorAll('.row:not(.header)');
    linhasAntigas.forEach(l => l.remove());

    const inicio = (paginaAtual - 1) * ticketsPorPagina;
    const fim = inicio + ticketsPorPagina;
    const ticketsPagina = ticketsAtuais.slice(inicio, fim);

    let html = '';
    ticketsPagina.forEach(ticket => {
        html += gerarLinha(ticket);
    });

    footer.insertAdjacentHTML('beforebegin', html);
    atualizarPaginacao();
}

// ==================== CARREGAR TICKETS ====================
async function carregarTickets() {
    try {
        console.log("🔄 Carregando tickets para o agente:", nomeAgente);
        
        const resp = await fetch(API_TICKETS);
        if (!resp.ok) throw new Error('Erro ao buscar tickets');
        const tickets = await resp.json();

        ticketsAtuais = tickets;
        paginaAtual = 1;
        renderizarTickets();
        
        console.log(`✅ ${tickets.length} tickets carregados`);
    } catch (err) {
        console.error("❌ Erro:", err);
        const tabela = document.querySelector('.table');
        const footer = tabela.querySelector('.footer');
        footer.insertAdjacentHTML('beforebegin', `<div class="row"><div class="cell">Erro: ${err.message}</div></div>`);
    }
}

// ==================== FUNÇÕES EXTRAS ====================
function abrirTicket(idTicket) {
    // Quando clicar em um ticket, abre a tela de detalhes
    const idAgente = localStorage.getItem("IdAgente");
    window.location.href = `pages/ticket.html?id=${idTicket}&agente=${idAgente}`;
}

// ==================== INICIALIZAÇÃO ====================
document.addEventListener('DOMContentLoaded', function() {
    console.log("🚀 Dashboard do agente iniciado");
    console.log("Agente logado:", { id: idAgente, nome: nomeAgente });
    carregarTickets();
});

// Exportar funções para o escopo global
window.mudarPagina = mudarPagina;
window.carregarTickets = carregarTickets;
window.sair = sair;
window.abrirTicket = abrirTicket;