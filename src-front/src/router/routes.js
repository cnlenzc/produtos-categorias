
const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      {
        name: 'home',
        path: '',
        component: () => import('pages/home.vue')
      },
      {
        name: 'produto-list',
        path: 'produto',
        component: () => import('pages/produto-list.vue')
      },
      {
        name: 'produto-edit',
        path: 'produto/:id',
        component: () => import('pages/produto-edit.vue')
      },
      {
        name: 'categoria-list',
        path: 'categoria',
        component: () => import('pages/categoria-list.vue')
      },
      {
        name: 'categoria-edit',
        path: 'categoria/:id',
        component: () => import('pages/categoria-edit.vue')
      }
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
