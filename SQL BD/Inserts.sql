INSERT INTO Funcao ( NomeFuncao) VALUES
('Admnistrador'),
('Agente');


INSERT INTO Problema (Titulo, Descricao, Solucao) VALUES
('Peça Não Chegou no Prazo', 
 'Faz 10 dias que comprei e ainda não recebi minha bateria',
 'Vou verificar o rastreamento agora e te passar a localização. Se não chegar até amanhã, enviamos uma nova sem custo!'),

('Produto Veio Errado', 
 'Comprei roda prata e chegou preta, diferente da foto',
 'Lamento pelo erro! Vamos enviar um motorista na sua casa amanhã para buscar a errada e trazer a cor certa, tudo por nossa conta!'),

('Não Sei Se a Peça Serve no Meu Carro', 
 'Tenho um Civic 2018 e não sei se este filtro de ar é compatível',
 'Me passa o chassi ou placa do seu carro que confirmo na hora! Se não servir, a troca é gratuita!'),

('Problema na Instalação', 
 'Comprei um alarme mas não consigo instalar sozinho',
 'Temos parceria com oficinas na sua região! Agendo uma instalação para você com 30% de desconto!'),

('Arrependeu da Compra', 
 'Comprei um aerofólio mas mudei de ideia',
 'Sem problemas! Enviamos um motoboy para buscar na sua casa e o reembolso vai direto no seu PIX em até 2 horas!'),

('Dúvida Sobre Garantia', 
 'Comprei uma central multimídia há 3 meses e parou de funcionar',
 'Sua garantia é de 1 ano! Vamos enviar uma nova hoje mesmo e um técnico para instalar gratuitamente!');













SELECT NomeProduto, DescricaoProduto FROM PRODUTO;

SELECT Titulo, Descricao, Solucao FROM Problema;