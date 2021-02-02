import axios from 'axios'

const baseURL = 'https://localhost:41623/api'

const statusHttp = {
  400: 'Dados inválidos',
  404: 'Informação não encontrada no servidor'
}

export default async function (method, url, data) {
  try {
    const resposta = await axios({
      method,
      baseURL,
      url,
      // valores do response.status que não devem gerar exception
      validateStatus: status => status >= 200 && status <= 500,
      // timeout de 30 seg
      timeout: 30000,
      data
    })

    const sucesso = [200, 201, 204].includes(resposta.status)

    // trata-se aqui todos os erros com http status diferente de sucesso
    if (!sucesso) {
      const mensagem = statusHttp[resposta.status] || 'Ops! Ocorreu um erro no servidor'
      console.error('Erro retornado pelo backend\n', JSON.stringify(resposta.data, 0, 2))
      verificarErro(true, mensagem)
    }

    return resposta
  } catch (erro) {
    // aqui, erros ja tradados e com mensagem que devem ser mostradas ao usuário
    if (erro.name === 'ErroValidacao') {
      throw erro
    }

    if (erro.name === 'Error') {
      // erro quando o usuário esta sem internet
      verificarErro(erro.message === 'Network Error',
        'Sem internet ou erro de comunicação!')

      // aqui aparece erros de timeout quando servidor nao responde
      verificarErro(erro.message.startsWith('timeout of '),
        'Tempo limite esgotado ao aguardar a conexão!')
    }

    // aqui aparece outros erros quando servidor nao responde
    verificarErro(true, 'Falha no acesso ao servidor! ' + erro.toString())
  }
}