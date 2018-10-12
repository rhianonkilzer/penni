<template>
  <div class="home">
    <h1>Welcome, {{$store.state.user.username}}!</h1>
    <!-- IF LOGGED IN DRAW NAVBAR -->
    <button @click="logout">LOGOUT</button>
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
      // blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
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