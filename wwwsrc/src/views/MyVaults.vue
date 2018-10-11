<template>
    <div class="myvaults">


    </div>
</template>


<script>
    export default {
        name: 'myvaults',
        data() {
            return {}
        },
        created() {
            //blocks users not logged in
            if (!this.$store.state.user.id) {
                this.$router.push({ name: "login" });
            }
        },
        computed: {},
        methods: {},
        components: {}
    }
</script>


<style scoped>

</style>