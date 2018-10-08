<template>
  <div class="home">
    <h1>Penni</h1>
    <h1>Welcome, {{$store.state.user.username}}!</h1>
  </div>
</template>

<script>
  export default {
    name: "home",
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    }
  };
</script>
<style scoped>
  h1 {
    color: rgb(255, 255, 255);
    background-color: rgba(0, 0, 0, 0.678);
  }
</style>