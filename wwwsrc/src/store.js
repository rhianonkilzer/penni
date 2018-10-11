import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "//localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "//localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    vaults: [],
    keeps: {},
    activeVault: {},
    vaultKeeps: []
  },

  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setVault(state, vault) {
      state.activeVault = vault
    },
    setKeep(state, keeps) {
      state.keeps = keeps
    },
    setVaultKeeps(state, vaultkeeps) {
      state.vaultKeeps = vaultkeeps
    }
  },


  actions: {

    // AUTH STUFF
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }) {
      auth.delete('logout')
        .then(res => {
          router.push({ name: 'login' })

        })
    },
    // END OF AUTH

    // VAULT STUFF
    getVaults({ commit, dispatch }) {
      api.get('vaults')
        .then(res => {
          commit('setVaults', res.data)
        })
    },
    getVault({ commit, dispatch }, vaultId) {
      api.get('vaults/' + vaultId)
        .then(res => {
          commit('setVault', res.data)
        })
    },
    addVault({ commit, dispatch }, vaultData) {
      api.post('vaults', vaultData)
        .then(serverVault => {
          dispatch('getVaults')
        })
    },
    deleteVault({ commit, dispatch }, vaultId) {
      api.delete('vaults/' + vaultId)
        .then(res => {
          dispatch('getVaults')
        })
    },
    goToVaults() {
      router.push({ name: 'vaults' })
    },

    //END OF VAULTS

    //Keeps
    getKeeps({ commit, dispatch }, vaultId) {
      api.get('vaults/' + vaultId + '/keeps')
        .then(res => {
          commit('setKeeps', res.data)
        })
    },

    addKeep({ commit, dispatch }, keepData) {

      api.post('/keeps', keepData)
        .then(res => {
          dispatch('getKeeps', keepData.vaultId)
        })
    },

    deleteKeep({ commit, dispatch }, keepData) {
      api.delete('keeps/' + keepData._id)
        .then(res => {
          dispatch('getkeeps', keepData.vaultId)
        })
    },
    updateKeep({ commit, dispatch }, keep) {
      api.put('keeps/' + keep._id, keep)
        .then(res => {
          dispatch('getKeeps', keep.VaultId)
          dispatch('getKeeps', keep.oldVaultId)
        })
    },

    // END OF KEEPS

  }
})