<template>
    <div class="row">

        <div class="keeps col-12">
            <form @submit.prevent="addBoard">
                <input type="text" placeholder="Name of Keep" v-model="newKeep.name" required>
                <input type="text" placeholder="Description" v-model="newKeep.description">
            </form>
            <button type="submit">Create Keep</button>

            <div class="keep" v-for="keep in keeps" :key="board._id">

            </div>
        </div>
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
        }
    }
</script>

<style scoped>

</style>