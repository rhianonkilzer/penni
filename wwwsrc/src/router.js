import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import MyVaults from './views/MyVaults.vue'
// @ts-ignore
import Keeps from './views/Keeps.vue'
// @ts-ignore
import Vault from './views/Vault.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/vaults/:vaultId',
      name: 'vault',
      component: Vault
    },
    {
      path: '/myvaults',
      name: 'myvaults',
      component: MyVaults
    },
    {
      path: '/keeps',
      name: 'keeps',
      component: Keeps
    },
    {
      path: "*",
      redirect: '/'
    }
  ]
})
