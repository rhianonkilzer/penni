<template>
  <div class="home">
    <h1>Welcome, {{$store.state.user.username}}!</h1>
    <button @click="logout">LOGOUT</button>

  </div>
</template>

<script>
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
      goToVaults() {
        this.$store.dispatch("goToVaults")
      },

    },
    mounted() {
      this.$store.dispatch("getKeeps", this.vaultId)
    },
  };
</script>
<style scoped>

</style>