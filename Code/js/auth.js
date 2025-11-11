const API_URL = "https://localhost:7269/api/clientes";

async function cadastrarCliente() {
  const nome = document.querySelector("#nome").value;
  const email = document.querySelector("#emailCadastro").value;
  const senha = document.querySelector("#senhaCadastro").value;

  const payload = { nome, email, senha };

  const resp = await fetch(`${API_URL}/register`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(payload)
  });

  if (resp.ok) {
    alert("✅ Cadastro realizado com sucesso!");
    // ... troca de formulário
  } else {
    const text = await resp.text();
    alert("❌ Erro: " + text);
  }
}

async function loginCliente() {
  const email = document.querySelector("#email").value;
  const senha = document.querySelector("#senha").value;

  const payload = { email, senha };

  const resp = await fetch(`${API_URL}/login`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(payload)
  });

  if (resp.ok) {
    const data = await resp.json();
    localStorage.setItem("clienteId", data.IdCliente || data.idCliente);
    window.location.href = "index.html"; // seu redirecionamento
  } else {
    const text = await resp.text();
    alert("❌ " + (text || "E-mail ou senha incorretos."));
  }
}
