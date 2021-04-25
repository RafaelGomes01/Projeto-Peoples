USE M_Peoples;

SELECT idFuncionario as 'Id', nome as 'Nome', sobrenome as 'Sobrenome' FROM Funcionarios;

-- Buscar os funcionarios pelo nome
SELECT * FROM Funcionarios
WHERE nome = 'Catarina';

-- Buscar funcionario trazendo o nome e sobrenome
SELECT CONCAT(nome, ' ', sobrenome ) AS 'Nome Completo' 
FROM Funcionarios;

-- Ordernar os Nomes de forma crescente ou descrescente
SELECT nome, sobrenome FROM Funcionarios
ORDER BY nome DESC;
-- ORDER BY nome ASC;


