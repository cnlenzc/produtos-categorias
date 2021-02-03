<template>
  <q-page padding>
    <div class="q-pa-md" style="max-width: 600px">
      <q-table title="categorias" :data="lista" :columns="columns" row-key="id">
        <template v-slot:header="props">
          <q-tr :props="props">
            <q-th auto-width />
            <q-th v-for="col in props.cols" :key="col.name" :props="props">
              {{ col.label }}
            </q-th>
          </q-tr>
        </template>
        <template v-slot:body="props">
          <q-tr :props="props">
            <q-td auto-width>
              <q-btn size="sm" color="primary" round dense
                :to="{ name: 'categoria-edit', params: { id: props.cols[0].value } }" icon="edit" />
            </q-td>
            <q-td v-for="col in props.cols" :key="col.name" :props="props">
              {{ col.value }}
            </q-td>
          </q-tr>
        </template>
      </q-table>
    </div>
    <q-btn color="primary" label="adicionar" :to="{ name: 'categoria-edit', params: { id: 0 } }" />
  </q-page>
</template>

<script>
  export default {
    name: 'categoria-list',

    computed: {
      columns() {
        return [
          { name: 'id', align: 'right', label: 'id', field: 'id', sortable: true },
          { name: 'nome', align: 'left', label: 'nome', field: 'nome', sortable: true }
        ]
      }
    },

    data() {
      return {
        lista: []
      }
    },

    methods: {
      async atualizar() {
        try {
          loading.show()
          const resposta = await backend('get', 'categoria')
          this.lista = resposta.data
        } catch (erro) {
          notifyError('Erro na consulta de categorias', erro)
        } finally {
          loading.hide()
        }
      }
    },

    mounted() {
      this.atualizar()
    }
  }
</script>