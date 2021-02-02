
const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { name: 'home', path: '', component: () => import('pages/home.vue') },
      {
        name: 'produto',
        path: 'produto',
        component: () => import('pages/produto.vue')
      },
      {
        name: 'produtoForm',
        path: 'produto/:id',
        component: () => import('pages/produtoForm.vue')
      },
      { name: 'categoria', path: 'categoria', component: () => import('pages/categoria.vue') }
    ]
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: '*',
    component: () => import('pages/Error404.vue')
  }
]

export default routes
