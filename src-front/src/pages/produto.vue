<template>
  <q-page padding>
    <div class="q-pa-md">
      <q-table title="produtos" :data="lista" :columns="columns" row-key="id">
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
              {{ props.cols[0].value }} xx
              <q-btn size="sm" color="primary" round dense :to="{ name: 'produtoForm', params: { id: props.cols[0].value } }"
                icon="edit" />
            </q-td>
            <q-td v-for="col in props.cols" :key="col.name" :props="props">
              {{ col.value }}
            </q-td>
          </q-tr>
        </template>
      </q-table>
    </div>
    <q-btn color="primary" label="adicionar" :to="{ name: 'produtoForm', params: { id: 0 } }" />
  </q-page>
</template>

<script>
  export default {
    name: 'produto',

    computed: {
      columns() {
        return [
          // {
          //   name: 'name',
          //   required: true,
          //   label: 'Dessert (100g serving)',
          //   align: 'left',
          //   field: row => row.name,
          //   format: val => `${val}`,
          //   sortable: true
          // },
          { name: 'id', align: 'right', label: 'id', field: 'id', sortable: true },
          { name: 'descricao', label: 'descricao', field: 'descricao', sortable: true },
          { name: 'unidade', label: 'UN', field: 'unidade', sortable: true },
          { name: 'valor', label: 'valor', field: 'valor', sortable: true },
          { name: 'data_criacao', label: 'criação', field: 'data_criacao', sortable: true }
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
          const resposta = await backend('get', 'produto')
          this.lista = resposta.data
        } catch (erro) {
          notifyError('Erro na consulta de produtos', erro)
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