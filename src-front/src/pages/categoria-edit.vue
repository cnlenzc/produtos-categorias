<template>
  <q-page padding>
    <div class="q-pa-md" style="max-width: 1200px">
      <div class="row q-mb-md">
        <div class="col text-h5">categoria</div>
        <div class="col-auto"># {{ campos.id }}</div>
      </div>
      <q-form @submit="tryLoading(salvar)" class="q-gutter-sm">
        <div class="row items-baseline">
          <q-input v-model="campos.nome" label="nome" class="col-12" filled lazy-rules
            :rules="[ val => val && val.length > 0 || 'preenchimento obrigatório']" />
        </div>
        <div>
          <q-btn label="salvar" type="submit" color="primary" />
          <q-btn v-if="campos.id" label="remover" color="negative" class="q-ml-sm" @click="tryLoading(remover)" />
          <q-btn label="voltar" color="primary" flat class="q-ml-sm" :to="{ name: 'categoria-list' }" />
        </div>
      </q-form>
    </div>
  </q-page>
</template>

<script>
  export default {
    name: 'categoria-edit',

    data() {
      return {
        campos: {}
      }
    },

    methods: {
      async atualizar() {
        if ((this.$route.params.id || '0') === '0') {
          return
        }

        try {
          loading.show()
          const resposta = await backend('get', 'categoria/' + this.$route.params.id)
          this.campos = resposta.data
        } catch (erro) {
          notifyError('erro na consulta da categoria', erro)
        } finally {
          loading.hide()
        }
      },

      async salvar() {
        if (this.campos.id) {
          await backend('put', 'categoria/' + this.campos.id, this.campos)
        } else {
          await backend('post', 'categoria', this.campos)
        }
        notifyPositive('categoria salva com sucesso')
        this.$router.push({ name: 'categoria-list' })
      },

      async remover() {
        await backend('delete', 'categoria/' + this.campos.id)
        notifyPositive('categoria removida com sucesso')
        this.$router.push({ name: 'categoria-list' })
      }
    },

    mounted() {
      this.atualizar()
    }
  }
</script>