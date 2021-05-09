
const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      {
        path: '/home',
        name: 'home',
        component: () => import('pages/Index.vue'),
        meta: {
          public: false
        }
      },
      {
        path: '/citizens',
        name: 'citizens',
        component: () => import('pages/citizens/Index.vue'),
        meta: {
          public: false
        }
      },
      {
        path: '/tasks',
        name: 'tasks',
        component: () => import('pages/tasks/Index.vue'),
        meta: {
          public: false
        }
      },
      {
        path: '/miranda',
        name: 'miranda',
        component: () => import('pages/tasks/Miranda.vue'),
        meta: {
          public: false
        }
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
