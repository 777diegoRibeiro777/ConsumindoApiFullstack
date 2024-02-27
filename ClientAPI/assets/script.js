//FETCH Tabela Clientes
document.addEventListener('DOMContentLoaded', () => {
    const apiUrl = 'https://localhost:7164/api/Clientes';

    const tableBody = document.querySelector('#Data-Clientes tbody');
    
    fetch(apiUrl)
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro ao consumir a API: ' + response.status);
            }
            return response.json();
        })
        .then(data => {

            tableBody.innerHTML = '';

            data.forEach(user => {
                const row = document.createElement('tr');
                row.innerHTML = `
                    <td>${user.idcliente}</td>
                    <td>${user.nome}</td>
                    <td>${user.endereco}</td>
                    <td>${user.numeroTelefone}</td>
                    <td>${user.email}</td>
                    <td>${user.prescricaoMedicas}</td>
                    <td>${user.vendaProdutos}</td>
                `;
                tableBody.appendChild(row);
            });
        })
        .catch(error => {
            console.error('Ocorreu um erro:', error);
        });
});

//FETCH Tabela Entrega Produtos
document.addEventListener('DOMContentLoaded', () => {
    const apiUrl = 'https://localhost:7164/api/EntregaProdutos';

    const tableBody = document.querySelector('#Data-EntregaProdutos tbody');
    
    fetch(apiUrl)
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro ao consumir a API: ' + response.status);
            }
            return response.json();
        })
        .then(data => {

            tableBody.innerHTML = '';

            data.forEach(user => {
                const row = document.createElement('tr');
                row.innerHTML = `
                    <td>${user.identrega}</td>
                    <td>${user.fornecedorId}</td>
                    <td>${user.produtosEntregues}</td>
                    <td>${user.quantidadeEntregue}</td>
                    <td>${user.dataEntrega}</td>
                    <td>${user.fornecedor}</td>
                `;
                tableBody.appendChild(row);
            });
        })
        .catch(error => {
            console.error('Ocorreu um erro:', error);
        });
});

//FETCH Tabela Farmacêuticos
document.addEventListener('DOMContentLoaded', () => {
    const apiUrl = 'https://localhost:7164/api/Farmaceuticos';

    const tableBody = document.querySelector('#Data-Farmaceuticos tbody');
    
    fetch(apiUrl)
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro ao consumir a API: ' + response.status);
            }
            return response.json();
        })
        .then(data => {

            tableBody.innerHTML = '';

            data.forEach(user => {
                const row = document.createElement('tr');
                row.innerHTML = `
                    <td>${user.idfarmacutico}</td>
                    <td>${user.nome}</td>
                    <td>${user.numeroRegistroProfissional}</td>
                    <td>${user.numeroTelefone}</td>
                    <td>${user.email}</td>
                    <td>${user.prescricaoMedicas}</td>
                    <td>${user.vendaProdutos}</td>
                `;
                tableBody.appendChild(row);
            });
        })
        .catch(error => {
            console.error('Ocorreu um erro:', error);
        });
});

//FETCH Tabela Fornecedores
document.addEventListener('DOMContentLoaded', () => {
    const apiUrl = 'https://localhost:7164/api/Fornecedores';

    const tableBody = document.querySelector('#Data-Fornecedores tbody');
    
    fetch(apiUrl)
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro ao consumir a API: ' + response.status);
            }
            return response.json();
        })
        .then(data => {

            tableBody.innerHTML = '';

            data.forEach(user => {
                const row = document.createElement('tr');
                row.innerHTML = `
                    <td>${user.idfornecedor}</td>
                    <td>${user.nomeFornecedor}</td>
                    <td>${user.endereco}</td>
                    <td>${user.numeroTelefone}</td>
                    <td>${user.email}</td>
                    <td>${user.entregaProdutos}</td>
                `;
                tableBody.appendChild(row);
            });
        })
        .catch(error => {
            console.error('Ocorreu um erro:', error);
        });
});

//FETCH Tabela Prescrições Médicas
document.addEventListener('DOMContentLoaded', () => {
    const apiUrl = 'https://localhost:7164/api/PrescricoesMedicas';

    const tableBody = document.querySelector('#Data-PrescricoesMedicas tbody');
    
    fetch(apiUrl)
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro ao consumir a API: ' + response.status);
            }
            return response.json();
        })
        .then(data => {

            tableBody.innerHTML = '';

            data.forEach(user => {
                const row = document.createElement('tr');
                row.innerHTML = `
                    <td>${user.idprescricao}</td>
                    <td>${user.pacienteId}</td>
                    <td>${user.farmaceuticoId}</td>
                    <td>${user.dataPrescricao}</td>
                    <td>${user.medicamentosPrescritos}</td>
                    <td>${user.farmaceutico}</td>
                    <td>${user.paciente}</td>
                `;
                tableBody.appendChild(row);
            });
        })
        .catch(error => {
            console.error('Ocorreu um erro:', error);
        });
});

//FETCH Tabela Produtos Farmacêuticos
document.addEventListener('DOMContentLoaded', () => {
    const apiUrl = 'https://localhost:7164/api/ProdutosFarmaceuticos';

    const tableBody = document.querySelector('#Data-ProdutosFarmaceuticos tbody');
    
    fetch(apiUrl)
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro ao consumir a API: ' + response.status);
            }
            return response.json();
        })
        .then(data => {

            tableBody.innerHTML = '';

            data.forEach(user => {
                const row = document.createElement('tr');
                row.innerHTML = `
                    <td>${user.idproduto}</td>
                    <td>${user.nomeProduto}</td>
                    <td>${user.descricao}</td>
                    <td>${user.fabricante}</td>
                    <td>${user.preco}</td>
                    <td>${user.quantidadeEstoque}</td>
                    <td>${user.dataValidade}</td>
                `;
                tableBody.appendChild(row);
            });
        })
        .catch(error => {
            console.error('Ocorreu um erro:', error);
        });
});

//FETCH Tabela Vendas Produtos
document.addEventListener('DOMContentLoaded', () => {
    const apiUrl = 'https://localhost:7164/api/VendasProdutos';

    const tableBody = document.querySelector('#Data-VendasProdutos tbody');
    
    fetch(apiUrl)
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro ao consumir a API: ' + response.status);
            }
            return response.json();
        })
        .then(data => {

            tableBody.innerHTML = '';

            data.forEach(user => {
                const row = document.createElement('tr');
                row.innerHTML = `
                    <td>${user.idvenda}</td>
                    <td>${user.dataVenda}</td>
                    <td>${user.clienteId}</td>
                    <td>${user.farmaceuticoId}</td>
                    <td>${user.valorTotal}</td>
                    <td>${user.cliente}</td>
                    <td>${user.farmaceutico}</td>
                `;
                tableBody.appendChild(row);
            });
        })
        .catch(error => {
            console.error('Ocorreu um erro:', error);
        });
});


function showContent(id) {
    var contents = document.querySelectorAll('.content');
    contents.forEach(function(content) {
      content.style.display = 'none';
    });

    var selectedContent = document.getElementById(id);
    if (selectedContent) {
      selectedContent.style.display = 'block';
    }
  }

  function showAllContent() {
    var contents = document.querySelectorAll('.content');
    contents.forEach(function(content) {
      content.style.display = 'block';
    });
}

document.addEventListener('DOMContentLoaded', function() {
    const navItems = document.querySelectorAll('.nav-item');
  
    navItems.forEach(item => {
      item.addEventListener('click', function() {
        navItems.forEach(navItem => {
          navItem.classList.remove('active');
        });
  
        this.classList.add('active');
      });
    });
  });