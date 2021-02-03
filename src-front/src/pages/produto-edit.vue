<template>
  <q-page padding>
    <div class="q-pa-md" style="max-width: 1200px">
      <div class="row q-mb-md">
        <div class="col text-h5">produto</div>
        <div class="col-auto"># {{ campos.id }}</div>
      </div>
      <q-form @submit="tryLoading(salvar)" class="q-gutter-sm">
        <div class="row items-baseline">
          <q-input v-model="campos.descricao" label="descrição" class="col-12" filled lazy-rules
            :rules="[ val => val && val.length > 0 || 'obrigatório']" />
        </div>
        <div class="row items-baseline">
          <q-input v-model="campos.unidade" label="unidade" class="col-6 col-md-3" filled />
          <q-input filled v-model="campos.valor" label="valor" mask="#.##" fill-mask="0" reverse-fill-mask
            class="col-6 col-md-3 q-pl-md" input-class="text-right" lazy-rules
            :rules="[ val => !!val || 'obrigatório' ]" />
        </div>
        <div class="row items-baseline">
          cadastro: <strong class="q-ml-md">{{ $format.datetime(campos.datahora_cadastro) }}</strong>
        </div>
        <div>
          <q-btn label="salvar" type="submit" color="primary" />
          <q-btn v-if="campos.id" label="remover" color="negative" class="q-ml-sm" @click="tryLoading(remover)" />
          <q-btn label="voltar" color="primary" flat class="q-ml-sm" :to="{ name: 'produto-list' }" />
        </div>
      </q-form>
    </div>
  </q-page>
</template>

<script>
  export default {
    name: 'produto-edit',

    data() {
      return {
        campos: {}
      }
    },

    methods: {
      async atualizar() {
        if ((this.$route.params.id || '0') === '0') {
          this.$set(this.campos, 'datahora_cadastro', new Date())
          this.$set(this.campos, 'unidade', 'UN')
          return
        }

        try {
          loading.show()
          const resposta = await backend('get', 'produto/' + this.$route.params.id)
          this.campos = resposta.data
        } catch (erro) {
          notifyError('Erro na consulta do produto', erro)
        } finally {
          loading.hide()
        }
      },

      async salvar() {
        if (this.campos.id) {
          await backend('put', 'produto/' + this.campos.id, this.campos)
        } else {
          await backend('post', 'produto', this.campos)
        }
        notifyPositive('Produto salvo com sucesso')
        this.$router.push({ name: 'produto-list' })
      },

      async remover() {
        await backend('delete', 'produto/' + this.campos.id)
        notifyPositive('Produto removido com sucesso')
        this.$router.push({ name: 'produto-list' })
      }
    },

    mounted() {
      this.atualizar()
    }
  }
</script>