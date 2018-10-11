<template>
    <div class="keeps">


    </div>
</template>

<script>
    export default {
        name: 'keeps',
        data() {
            return {}
        },
        computed: {
            keeps() {
                return this.$store.state.keeps[this.keepData._id]
            }
        },
        methods: {
            deleteKeep(keepData) {
                this.$store.dispatch("deleteKeep", keepData);
            },
        },
        components: {
            Keep
        },
        props: ["keepData"]
    }
</script>

<style scoped>

</style>