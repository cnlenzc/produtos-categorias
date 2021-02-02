import * as excecao from 'utils/excecao'
import backend from 'utils/backend'

export default ({ Vue }) => {
  Vue.prototype.$utils = {
    ...excecao,
    backend
  }
  global.verificarErro = excecao.verificarErro
  global.backend = backend
}
