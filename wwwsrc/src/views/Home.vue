<template>
  <div class="home">
    <div class="if-loggin" v-if="user.id">
      <h1>Welcome, {{$store.state.user.username}}!</h1>
      <button @click="logout">LOGOUT</button>
    </div>
    <router-link to="/login">Login</router-link>
    <MyVaults />

    <Keeps />
  </div>
</template>

<script>
  import Keeps from '@/views/Keeps';
  import MyVaults from '@/views/MyVaults';

  export default {
    name: "home",
    mounted() {

    },
    computed: {
      user() {
        return this.$store.state.user
      }
    },
    methods: {
      addKeep() {
        this.$store.dispatch("addKeep", this.keep);
        this.Keep = { name: "", description: "", img: img, isPrivate: isPrivate }
      },
      logout() {
        this.$store.dispatch("logout")
      },
      // goToVaults() {
      //   this.$store.dispatch("goToVaults")
      // }

    },
    mounted() {
      this.$store.dispatch("getAllKeeps", this.vaultId)
    },
    components: {
      Keeps,
      MyVaults
    }
  };
</script>
<style scoped>

</style>